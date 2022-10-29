using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Shared.Core
{
    public class ServiceReponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public ServiceReponse()
        {
            this.Success = true;
        }
    }
}
