using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CW2237A2.Controllers
{
    public class InvoicesController : Controller
    {
        private Manager m = new Manager();

        // GET: Invoices
        public ActionResult Index()
        {
            var i = m.InvoiceGetAll();
            return View(i);
        }

        // GET: Invoice Details
        public ActionResult Details(int? id)
        {
            var i = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());

            if (i == null)
            {
                return HttpNotFound();
            }

            return View(i);
        }
    }
}