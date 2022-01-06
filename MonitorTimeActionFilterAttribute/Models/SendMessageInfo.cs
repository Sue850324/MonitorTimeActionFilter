namespace MonitorTimeActionFilterAttribute.Models
{
    public class SendMessageInfo
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Password { get; set; }
        public string Body { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}