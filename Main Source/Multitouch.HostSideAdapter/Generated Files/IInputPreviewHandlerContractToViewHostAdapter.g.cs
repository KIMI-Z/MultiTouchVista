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
    
    [System.AddIn.Pipeline.HostAdapterAttribute()]
    public class IInputPreviewHandlerContractToViewHostAdapter : Multitouch.Contracts.IInputPreviewHandler
    {
        private Multitouch.Contracts.Contracts.IInputPreviewHandlerContract _contract;
        private System.AddIn.Pipeline.ContractHandle _handle;
        static IInputPreviewHandlerContractToViewHostAdapter()
        {
        }
        public IInputPreviewHandlerContractToViewHostAdapter(Multitouch.Contracts.Contracts.IInputPreviewHandlerContract contract)
        {
            _contract = contract;
            _handle = new System.AddIn.Pipeline.ContractHandle(contract);
        }
        public Multitouch.IPreviewResult Handle(IContact contact)
        {
            return Multitouch.HostSideAdapters.IPreviewResultHostAdapter.ContractToViewAdapter(_contract.Handle(Multitouch.Contracts.HostSideAdapters.IContactHostAdapter.ViewToContractAdapter(contact)));
        }
        internal Multitouch.Contracts.Contracts.IInputPreviewHandlerContract GetSourceContract()
        {
            return _contract;
        }
    }
}

