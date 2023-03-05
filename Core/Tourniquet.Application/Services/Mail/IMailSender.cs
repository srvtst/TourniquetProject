namespace Tourniquet.Application.Services.Mail
{
    public interface IMailSender
    {
        void SendMail(string fromAddress, string body);
    }
}