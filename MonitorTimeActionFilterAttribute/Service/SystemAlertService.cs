using MonitorTimeActionFilterAttribute.ActionFilter;
using MonitorTimeActionFilterAttribute.Interface;
using System;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SystemAlertService
    {
        public void Send(AlertTypes type)
        {                 
            if (type == AlertTypes.All)
            {
                foreach (PublishTypes item in Enum.GetValues(typeof(PublishTypes)))
                {
                    ISendAlert sendAlertService = GetAlertFactory.Get(item);
                    sendAlertService.Send();
                }
            }
            else
            {
                int getType = (int)type;
                ISendAlert sendAlertService = GetAlertFactory.Get((PublishTypes)getType);
                sendAlertService.Send();
            }
        }
    }
}