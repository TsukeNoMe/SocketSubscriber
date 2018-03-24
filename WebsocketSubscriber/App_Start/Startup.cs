using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsocketSubscriber.Functionality;

[assembly: OwinStartup(typeof(WebsocketSubscriber.App_Start.Startup))]
namespace WebsocketSubscriber.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}