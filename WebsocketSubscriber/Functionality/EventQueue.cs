using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using WebsocketSubscriber.Data;
using WebsocketSubscriber.Models;
using Dapper;

namespace WebsocketSubscriber.Functionality
{
    public class EventQueue
    {
        public List<Events> GetEvents()
        {
            using (var Connection = new DatabaseHelper().ConnectionProvider())
            {
                var EventList = Connection.Query<Events>("[Events].[RetrieveEvents]", commandType:System.Data.CommandType.StoredProcedure).ToList();
                return EventList;
            }
        }
    }
}