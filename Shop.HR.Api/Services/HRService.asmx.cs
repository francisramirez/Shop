using Shop.HR.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Shop.HR.Api.Services
{
    /// <summary>
    /// Summary description for HRService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    /// [System.Web.Script.Services.ScriptService]
    public class HRService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Model.EmployeeResust> GetEmployees()
        {
            List<Model.EmployeeResust> result = new List<Model.EmployeeResust>();

           
            using (HREntities context = new HREntities())
            {
                result = context.Employees.Select(cd => new Model.EmployeeResust()
                {
                    empid = cd.empid,
                    firstname = cd.firstname,
                    lastname = cd.lastname,
                    title = cd.title,
                    titleofcourtesy = cd.titleofcourtesy
                }).ToList();
            }
            return result;
        }
    }
}
