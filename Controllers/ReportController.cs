using CCFD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCFD.Controllers
{
    //[Authorize(Users = "Support123@ccfd.com")]
    [Authorize]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            try
            {
                ReportViewModel reportViewModel = new ReportViewModel();

                reportViewModel.FullReport = false;
                reportViewModel.FraudReport = false;
                reportViewModel.CleanReport = false;

                return View(reportViewModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Generate(ReportViewModel reportViewModel)
        {
            try
            {
                List<Transaction> transaction = new List<Transaction>();

                if (reportViewModel.FullReport&&!reportViewModel.FraudReport&&!reportViewModel.CleanReport)
                {
                    ViewBag.Message = "Full Transaction Data Report.";

                    using (var ccfdEntities = new CCFDEntities()) {
                        transaction = ccfdEntities.transactions.ToList();
                    }
                }
                else if (reportViewModel.FraudReport&&!reportViewModel.FullReport&&!reportViewModel.CleanReport)
                {
                    ViewBag.Message = "Fraud Transaction Data Report.";

                    using (var ccfdEntities = new CCFDEntities())
                    {
                        transaction = ccfdEntities.transactions
                            .Where(w => w.Status == "FAILED")
                            .ToList();
                    }
                }
                else if (reportViewModel.CleanReport&&!reportViewModel.FullReport&&!reportViewModel.FraudReport)
                {
                    ViewBag.Message = "Passed Transaction Data Report.";

                    using (var ccfdEntities = new CCFDEntities())
                    {
                        transaction = ccfdEntities.transactions
                            .Where(w => w.Status == "APPROVED" || w.Status == "AUTH_APPROVED")
                            .ToList();
                    }
                }
                else {
                    return RedirectToAction("Index", "Report");
                }

                return View(transaction);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}