using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebsocketSubscriber.Functionality;

namespace WebsocketSubscriber
{
    public class PublisherHub : Hub
    {
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        public void StartUpdates()
        {
            Broadcast.UpdateSubscribers(GlobalHost.ConnectionManager.GetHubContext<PublisherHub>());
        }
        
        public override Task OnConnected()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool T)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(T);
        }
    }
}