using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using MonitorTimeActionFilterAttribute.Resource;
using MonitorTimeActionFilterAttribute.Service;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.ActionFilter
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MonitorExecutionTimeActionFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch sw = new Stopwatch();
        private AlertTypes _types { get; set; }
        public MonitorExecutionTimeActionFilterAttribute(AlertTypes type)
        {
            _types = type;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw.Start();
            Thread.Sleep(1000);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Thread.Sleep(6000);
            sw.Stop();

            if (sw.ElapsedMilliseconds >= 5000)
            {
                SystemAlertService systemAlert = new SystemAlertService();
                systemAlert.Send(_types, EmailElement.AlertSubject, EmailElement.AlertContent);                
            }
        }
    }
}