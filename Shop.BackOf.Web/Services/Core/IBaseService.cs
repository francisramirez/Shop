using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BackOf.Web.Services.Core
{
    public interface IBaseService
    {
        Task<string> GetToken();
    }
}
