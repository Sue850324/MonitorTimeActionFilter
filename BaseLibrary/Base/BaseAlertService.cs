using BaseLibrary.Model;
using BaseLibrary.Repository;
using MonitorTimeActionFilterAttribute.Interface;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace BaseLibrary.Base
{
    public abstract class BaseAlertService: ISendAlert
    {
        protected abstract bool DoSend(string subject, string context);
        public void Send(PublishTypes publishTypes, string subject, string context)
        {
            bool isSuccessful = DoSend(subject, context);

            if (isSuccessful)
            {
                CreateLogData(publishTypes, context);
            }
        }
        private void CreateLogData(PublishTypes publishTypes, string context)
        {
            CreateLogReposiory createLog = new CreateLogReposiory();
            LogModel log = new LogModel();
            log.Context = context;
            log.Mode = (int)publishTypes;

            createLog.Create(log);
        }
    }
}
