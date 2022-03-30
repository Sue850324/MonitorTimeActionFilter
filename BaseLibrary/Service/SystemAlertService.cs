using MonitorTimeActionFilterAttribute.Interface;
using System;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SystemAlertService
    {
        public void SendAlert(AlertTypes type, string subject, string context)
        {                 
            if (type == AlertTypes.All)
            {
                foreach (PublishTypes item in Enum.GetValues(typeof(PublishTypes)))
                {
                    ISendAlert sendAlertService = GetAlertFactory.Get(item);
                    sendAlertService.Send(item,subject, context);
                }
            }
            else
            {
                int getType = (int)type;
                ISendAlert sendAlertService = GetAlertFactory.Get((PublishTypes)getType);
                sendAlertService.Send((PublishTypes)getType,subject, context);
            }           
        }
    }

    public enum  AlertTypes
    {
        Email = 1,
        Line = 2,
        All 
    }
}