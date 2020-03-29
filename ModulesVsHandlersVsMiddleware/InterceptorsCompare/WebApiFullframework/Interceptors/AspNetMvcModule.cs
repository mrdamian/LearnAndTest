using System;
using System.Diagnostics;
using System.Web;
using System.Linq;

namespace WebApiFullframework
{
    /// <summary>
    /// Works only when deployed using IIS
    /// </summary>
    public class AspNetMvcModule : IHttpModule
    {
        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest; ;
            context.RequestCompleted += Context_RequestCompleted;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
           var path = HttpContext.Current.Request.Path;
            Trace.WriteLine("ASP.NET HttpModule BeginRequest event fired for: " + path);
        }

        void Context_RequestCompleted(object sender, EventArgs e)
        {
            Trace.WriteLine("ASP.NET HttpModule RequestCompleted event fired");
        }
    }
}