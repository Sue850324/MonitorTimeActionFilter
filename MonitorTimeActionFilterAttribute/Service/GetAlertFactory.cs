using MonitorTimeActionFilterAttribute.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class GetAlertFactory
    {
        public enum PublishTypes
        {
            Email = 1,
            Line = 2
        }

        public static ISendAlert Get(PublishTypes publishTypes)
        {
            switch (publishTypes)
            {
                case PublishTypes.Line:
                    return new SendLineNotifyService();
                case PublishTypes.Email:
                    return new SendEmailService();
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}