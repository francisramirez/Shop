using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.HR.Controllers
{
    public class HomeController : Controller
    {

        Shop.Web.HR.HRService.HRServiceSoapClient HRServiceSoapClient;


        public HomeController()
        {
            HRServiceSoapClient = new HRService.HRServiceSoapClient();
        }

       
        public ActionResult Index()
        {
            var employees = HRServiceSoapClient.GetEmployees();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}