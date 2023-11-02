﻿using Microsoft.AspNetCore.SignalR;

namespace SignalR101_.Hubs
{
    public class MessageHub: Hub
    {
        /*To observe 3 Clients type
         * 1. All
         * 2. Caller
         * 3. Others
         */
       
        public async Task SendMessageAsync(string message,IEnumerable<string> connectionIds)
        {
            #region Caller
            //The type that communicates with the client only sending information to the server
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //The type that communicates with all clients connected to the server.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Others
            //That type that sends messages to all clients except the client that only sends notifications to the server.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Methods
            //Hub Clients Methods allow displaying customized behaviors. It's like filtering, grouping

            #region AllExcept
            //Notifies all clients connected to the server except the specified clients
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            //It notifies only a specified client among the clients connected to the server.
            //Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage",message);
            #endregion

            #region Clients
            //It notifies only the specified clients among the clients connected to the server.
            Clients.Clients(connectionIds).SendAsync("receiveMessage",message);
            #endregion

            #region Group
            //It is a function that notifies all clients specified in the group.
            //It has a few steps.
            /*
             * 1. Create a group
             * 2. Subscribe Clients to the Group
             */
            #endregion

            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("showConnectionId", Context.ConnectionId);
        }
    }
}
