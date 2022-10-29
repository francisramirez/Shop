using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Security.Api.Model
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
