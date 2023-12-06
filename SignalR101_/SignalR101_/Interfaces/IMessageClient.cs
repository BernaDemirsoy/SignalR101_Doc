namespace SignalR101_.Interfaces
{
    public interface IMessageClient
    {
        //This interface IMessageClient helps out no typing faults from occurring.
        // For exp: on My hub class

        /*There are connection events methods. One of them is OnConnectedAsyn()
         * That includes
         *await Clients.All.SendAsync("userJoined",Context.ConnectionId);
         * 
         * If not using strongly typed hubs as it Hub<IMessageClient>, this row is open to typing errors 
         * 
        */ 

        Task ClientsList(List<string> clients);

        Task UserJoined(string connectionId);

        Task UserLeaved(string connectionId);
    }
}
