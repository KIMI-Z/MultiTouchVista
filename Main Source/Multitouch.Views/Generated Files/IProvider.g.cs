//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3031
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Multitouch.Contracts
{
    
    [System.AddIn.Pipeline.AddInBaseAttribute()]
    public interface IProvider
    {
        bool IsRunning
        {
            get;
        }
        // /// <summary>/// Raised when contact changes./// </summary>
        event System.EventHandler<ContactChangedEventArgs> ContactChanged;
        // /// <summary>/// Starts provider and sending events./// </summary>
        void Start();
        // /// <summary>/// Stops provider and sending events./// </summary>
        void Stop();
    }
}

