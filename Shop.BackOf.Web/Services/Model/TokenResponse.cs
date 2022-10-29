using System;

namespace Shop.BackOf.Web.Services.Model
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
