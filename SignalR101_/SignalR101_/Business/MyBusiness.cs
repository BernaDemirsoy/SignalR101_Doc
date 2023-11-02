using Microsoft.AspNetCore.SignalR;
using SignalR101_.Hubs;

namespace SignalR101_.Bussiness
{
    public class MyBusiness
    {
        private readonly IHubContext<Myhub> _hobcontext;

        public MyBusiness(IHubContext<Myhub> hobcontext)
        {
            _hobcontext = hobcontext;
        }

        /// <summary>
        /// This method will send a message (parameter) to all subscribers or in other words clients in the system.
        /// It is a async method.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Task</returns>
        public async Task SendMessageAsync(string message)
        {
            // SendAsync method will trigger the receiveMessage method on the client side with the message parameters.
            await _hobcontext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
