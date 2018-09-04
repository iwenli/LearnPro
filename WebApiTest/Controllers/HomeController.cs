using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = "张三";
            ViewBag.Ticket = "A123BCDE12398072340329EHBAKUSDH";
            return View();
        }
    }
}
