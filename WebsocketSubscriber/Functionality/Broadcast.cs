using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebsocketSubscriber.Functionality
{
    public static class Broadcast
    {
        public static void UpdateSubscribers(IHubContext context)
        {
            while(true)
            {
                EventQueueProcessor.Process(context);
                Thread.Sleep(3000);
            }
        }
    }
}