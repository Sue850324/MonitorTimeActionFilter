using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Interface
{
    public interface ISendAlert
    {
       void Send(PublishTypes publishTypes, string subject, string context);
    }
}