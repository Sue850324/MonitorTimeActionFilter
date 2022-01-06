using MonitorTimeActionFilterAttribute.Models;

namespace MonitorTimeActionFilterAttribute.Interface
{
    public interface ISendAlert
    {
        void Send(SendMessageInfo model);
    }
}