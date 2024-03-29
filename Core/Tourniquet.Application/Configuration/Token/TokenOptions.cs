﻿namespace Tourniquet.Application.Configuration.Token
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public double TokenExpiration { get; set; }
    }
}