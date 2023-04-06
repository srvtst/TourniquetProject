namespace Tourniquet.Application.Configuration.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}