//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3031
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Multitouch.Contracts.AddInSideAdapters
{
    
    public class IContactChangedEventHandlerContractToViewAddInAdapter
    {
        private Multitouch.Contracts.Contracts.IContactChangedEventHandlerContract _contract;
        private System.AddIn.Pipeline.ContractHandle _handle;
        public IContactChangedEventHandlerContractToViewAddInAdapter(Multitouch.Contracts.Contracts.IContactChangedEventHandlerContract contract)
        {
            _contract = contract;
            _handle = new System.AddIn.Pipeline.ContractHandle(contract);
        }
        public void Handler(object sender, Multitouch.Contracts.ContactChangedEventArgs args)
        {
            _contract.Handler(Multitouch.Contracts.AddInSideAdapters.ContactChangedEventArgsAddInAdapter.ViewToContractAdapter(args));
        }
        internal Multitouch.Contracts.Contracts.IContactChangedEventHandlerContract GetSourceContract()
        {
            return _contract;
        }
    }
}

