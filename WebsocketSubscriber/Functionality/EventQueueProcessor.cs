using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsocketSubscriber.Functionality
{
    public static class EventQueueProcessor
    {
        public static void Process(IHubContext context)
        {
            var Events = new EventQueue().GetEvents();
            if (Events.Count > 0)
            {
                foreach (var Event in Events)
                {
                    context.Clients.All.broadcastMessage($"Event Id:{Event.Id} , and Message: {Event.Message}");
                }
                RetirePublishedEvent.RetireEvents(Events);
            }
            else
                context.Clients.All.broadcastMessage("No events to report as of now.");
            
        }
    }
}