using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtakuStore.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return RedirectToAction("Http404Page");
        }

        public ActionResult Http404Page()
        {
            return View();
        }
        public ActionResult noneCartCheckOut()
        {
            return View();
        }
    }
}