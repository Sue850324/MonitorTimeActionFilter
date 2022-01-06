using MonitorTimeActionFilterAttribute.Service;
using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;

namespace MonitorTimeActionFilterAttribute.ActionFilter
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MonitorExecutionTimeActionFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch sw = new Stopwatch();
        private AlertTypes _types { get; set; }
        private int Seconds { get; set; }
        public MonitorExecutionTimeActionFilterAttribute(AlertTypes type)
        {
            _types = type;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw.Start();
            Thread.Sleep(1000);

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData
            };
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Thread.Sleep(6000);
            sw.Stop();

            if (sw.ElapsedMilliseconds >= 5000)
            {
                SystemAlertService systemAlert = new SystemAlertService();
                systemAlert.Send(_types);
            }
        }
    }

    public enum AlertTypes
    {
        Email = 1,
        Line = 2,
        All
    }
}