namespace Tourniquet.Application.Dtos.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}