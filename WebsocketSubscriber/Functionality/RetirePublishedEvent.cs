using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebsocketSubscriber.Data;
using WebsocketSubscriber.Models;
using Dapper;

namespace WebsocketSubscriber.Functionality
{
    public static class RetirePublishedEvent
    {
        public static void RetireEvents(List<Events> EventPool)
        {
            using (var Connection = new DatabaseHelper().ConnectionProvider())
            {
                var DT = new DataTable();
                DT.Columns.Add("EventId", typeof(int));
                foreach(var Event in EventPool)
                {
                    DT.Rows.Add(Event.Id);
                }

                Connection.Execute(@"[Events].[ArchiveEvents]", new { Events = DT.AsTableValuedParameter("EventPool") }, commandType:CommandType.StoredProcedure);
                
            }
        }
    }
}