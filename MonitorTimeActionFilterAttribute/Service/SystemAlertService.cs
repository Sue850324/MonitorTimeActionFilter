using MonitorTimeActionFilterAttribute.ActionFilter;
using MonitorTimeActionFilterAttribute.Interface;
using MonitorTimeActionFilterAttribute.Models;
using System;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SystemAlertService
    {
        public void Send(AlertTypes type)
        {
            SendMessageInfo model = new SendMessageInfo();
            model.EmailFrom = "testEmail@gmail.com";//虛構
            model.EmailTo = "test2Email@gmail.com";//虛構
            model.Password = "test01234";//虛構
            model.Subject = "[系統]警告信";
            model.Body = "執行時間超過五秒";
            model.Token = "$'O0jj6eMDHf28RAu5nLWJaT92Y95at3zHCLUOSeiM69a'";
            model.Message = "監控測試:系統執行時間超過五秒";

            if (type == AlertTypes.All)
            {
                foreach (PublishTypes item in Enum.GetValues(typeof(PublishTypes)))
                {
                    ISendAlert sendAlertService = GetAlertFactory.Get(item);
                    sendAlertService.Send(model);
                }
            }
            else
            {
                int getType = (int)type;
                ISendAlert sendAlertService = GetAlertFactory.Get((PublishTypes)getType);
                sendAlertService.Send(model);
            }
        }
    }
}