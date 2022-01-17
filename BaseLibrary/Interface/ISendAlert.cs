
namespace MonitorTimeActionFilterAttribute.Interface
{
    public interface ISendAlert
    {
        void Send(string subject, string context);
    }
}