//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3031
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Multitouch.Contracts.HostSideAdapters
{
    
    public class IInputPostHandlerHostAdapter
    {
        internal static Multitouch.Contracts.IInputPostHandler ContractToViewAdapter(Multitouch.Contracts.Contracts.IInputPostHandlerContract contract)
        {
            if (((System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(contract) != true) 
                        && contract.GetType().Equals(typeof(IInputPostHandlerViewToContractHostAdapter))))
            {
                return ((IInputPostHandlerViewToContractHostAdapter)(contract)).GetSourceView();
            }
            else
            {
                return new IInputPostHandlerContractToViewHostAdapter(contract);
            }
        }
        internal static Multitouch.Contracts.Contracts.IInputPostHandlerContract ViewToContractAdapter(Multitouch.Contracts.IInputPostHandler view)
        {
            if (view.GetType().Equals(typeof(IInputPostHandlerContractToViewHostAdapter)))
            {
                return ((IInputPostHandlerContractToViewHostAdapter)(view)).GetSourceContract();
            }
            else
            {
                return new IInputPostHandlerViewToContractHostAdapter(view);
            }
        }
    }
}

