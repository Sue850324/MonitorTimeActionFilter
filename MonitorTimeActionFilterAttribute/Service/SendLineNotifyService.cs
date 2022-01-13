using MonitorTimeActionFilterAttribute.Interface;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SendLineNotifyService : ISendAlert
    {
        public void Send()
        {
            using (var wc = new WebClient())
            {
                var bearer = "f44L2PrjjhlRhfeXCdgx6vAFwdbWWmcWCfBC2z3P5hJ";
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Headers.Add("Authorization", $"Bearer {bearer}");
                var nv = new NameValueCollection();
                nv["message"] = "監控測試:系統執行時間超過五秒";
                var bResult = wc.UploadValues($"https://notify-api.line.me/api/notify", nv);
                var res = Encoding.UTF8.GetString(bResult);
            }
        }
    }
}