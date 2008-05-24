using System;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;
using Multitouch.Contracts;
using Multitouch.Service.Logic;
using Multitouch.Service.Logic.ExternalInterfaces;

namespace Multitouch.Service.Logic
{
	class InputProviderManager : IDisposable
	{
		IProvider inputProvider;
		ServiceHost serviceHost;
		List<IInputPreviewHandler> inputPreviewHandlers;
		List<IInputPostHandler> inputPostHandlers;

		public InputProviderManager(IProvider inputProvider)
		{
			inputPreviewHandlers = new List<IInputPreviewHandler>();
			inputPostHandlers = new List<IInputPostHandler>();
			StartService();

			LoadInputHandlers();

			this.inputProvider = inputProvider;
			this.inputProvider.ContactChanged += inputProvider_ContactChanged;
			this.inputProvider.Start();
		}

		public void Dispose()
		{
			inputProvider.Stop();
			inputProvider.ContactChanged -= inputProvider_ContactChanged;
			inputProvider = null;

			serviceHost.Close();
		}

		void LoadInputHandlers()
		{
			AddInToken.EnableDirectConnect = true;
			string[] warnings = AddInStore.Update(PipelineStoreLocation.ApplicationBase);
			Array.ForEach(warnings, message => Trace.TraceWarning(message));

			Collection<AddInToken> previewTokens = AddInStore.FindAddIns(typeof(IInputPreviewHandler), PipelineStoreLocation.ApplicationBase);
			foreach (AddInToken token in previewTokens)
				inputPreviewHandlers.Add(token.Activate<IInputPreviewHandler>(AppDomain.CurrentDomain));

			Collection<AddInToken> postTokens = AddInStore.FindAddIns(typeof(IInputPostHandler), PipelineStoreLocation.ApplicationBase);
			foreach (var token in postTokens)
				inputPostHandlers.Add(token.Activate<IInputPostHandler>(AppDomain.CurrentDomain));
		}

		void inputProvider_ContactChanged(object sender, ContactChangedEventArgs e)
		{
			IPreviewResult result = null;
			foreach (IInputPreviewHandler handler in inputPreviewHandlers)
			{
				result = handler.Handle(e.Contact);
				if(result.Handled)
					break;
			}
			if (result != null)
				ApplicationInterfaceService.ContactChanged(result.HWnd, new HandledContactChangedEventArgs(result.Contact));
			else
				ApplicationInterfaceService.ContactChanged(e);

			foreach (IInputPostHandler handler in inputPostHandlers)
				handler.Handle(e.Contact);
		}

		void StartService()
		{
			Uri baseAddress = new Uri("net.pipe://localhost/Multitouch.Service/ApplicationInterface");
			serviceHost = new ServiceHost(typeof(ApplicationInterfaceService), baseAddress);
			NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			serviceHost.AddServiceEndpoint(typeof(IApplicationInterface), binding, string.Empty);

			ServiceMetadataBehavior serviceMetadataBehavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if (serviceMetadataBehavior == null)
				serviceMetadataBehavior = new ServiceMetadataBehavior();
			serviceMetadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
			serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

			serviceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");
			serviceHost.Open();
		}
	}
}