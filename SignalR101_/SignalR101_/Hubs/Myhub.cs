using Microsoft.AspNetCore.SignalR;

namespace SignalR101_.Hubs
{
    //If the Class is a hub class, it must be inherited from the Hub class which comes from the AspNetCore SignalR library
    public class Myhub : Hub
    {
        //This class includes sorts of operations which can ensure communications from TSP protocols.

        /// <summary>
        /// This method will send a message (parameter) to all subscribers or in other words clients in the system.
        /// It is a async method.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Task</returns>
        public async Task SendMessageAsync(string message)
        {
            // SendAsync method will trigger the receiveMessage method on the client side with the message parameters.
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
