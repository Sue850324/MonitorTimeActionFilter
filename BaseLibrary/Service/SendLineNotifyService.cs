using BaseLibrary.Base;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SendLineNotifyService : BaseAlertService
    {
        protected override bool DoSend(string subject, string context)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var bearer = "f44L2PrjjhlRhfeXCdgx6vAFwdbWWmcWCfBC2z3P5hJ";
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    wc.Headers.Add("Authorization", $"Bearer {bearer}");
                    var nv = new NameValueCollection();
                    nv["message"] = context;
                    var bResult = wc.UploadValues($"https://notify-api.line.me/api/notify", nv);
                    var res = Encoding.UTF8.GetString(bResult);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}