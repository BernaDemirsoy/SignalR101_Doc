using Microsoft.AspNetCore.SignalR;
using SignalR101_.Interfaces;

namespace SignalR101_.Hubs
{
    //If the Class is a hub class, it must be inherited from the Hub class which comes from the AspNetCore SignalR library
    public class Myhub : Hub<IMessageClient>
    {
        //This list is a static list that hosts our clients are have been already connected.
        //We are going to use it for connection events methods that we will override from the hub class.
        static List<string> clients=new List<string>();

        //This class includes sorts of operations which can ensure communications from TSP protocols.

        /// <summary>
        /// This method will send a message (parameter) to all subscribers or in other words clients in the system.
        /// It is a async method.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Task</returns>

        //public async Task SendMessageAsync(string message)
        //{
        //    // SendAsync method will trigger the receiveMessage method on the client side with the message parameters.
        //    await Clients.All.SendAsync("receiveMessage", message);
        //}

        //Hub classes has plenty of functions that we can override in our myhub class.

        //Connection Events
        //Notes: Connection events are useful functions for logging operations on the SignalR app.

        /*What is connectionId?
        It is a unique value given by the system to clients connecting to the hub. Its purpose is to identify clients from each other.
        */

        /* First:
         * OnConnectedAsync  Method is a connection state events. If any new client is connected to the system, this method is triggered.
        */
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            // await Clients.All.SendAsync("clientsList", clients);
            //await Clients.All.SendAsync("userJoined",Context.ConnectionId);

            //When IMessageClient added
            await Clients.All.ClientsList(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
            
        }

        /*Second:
         *  OnDisconnectedAsync Method is a connection state events. If any client has lost their connection to the system when they have already had a connection, this method is triggered.
         */
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clientsList", clients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);

            //When IMessageClient added
            await Clients.All.ClientsList(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }


    }
}
