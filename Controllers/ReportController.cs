using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCFD.Controllers
{
    //[Authorize(Users = "Support123@ccfd.com")]
    //[Authorize]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}