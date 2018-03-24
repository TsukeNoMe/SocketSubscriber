using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsocketSubscriber.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string DateAdded { get; set; }
    }
}