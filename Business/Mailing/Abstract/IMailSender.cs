namespace BusinessLayer.Mailing.Abstract
{
    public interface IMailSender
    {
        void SendMail(string fromAddress,string body);
    }
}