using MonitorTimeActionFilterAttribute.Interface;
using MonitorTimeActionFilterAttribute.Models;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SendLineNotifyService : ISendAlert
    {
        public void Send(SendMessageInfo model)
        {
            using (var wc = new WebClient())
            {
                var bearer = model.Token;
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers.Add("Authorization", $"Bearer {bearer}");
                var nv = new NameValueCollection();
                nv["message"] = model.Message;
                var bResult = wc.UploadValues($"https://notify-api.line.me/api/notify", nv);
                var res = Encoding.UTF8.GetString(bResult);
            }
        }
    }
}