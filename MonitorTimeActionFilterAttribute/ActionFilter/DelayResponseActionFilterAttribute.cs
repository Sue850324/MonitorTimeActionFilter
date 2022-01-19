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
    public class DelayResponseActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Thread.Sleep(1000);
        }
    }
}