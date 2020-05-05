using System;
using System.Collections.Generic;
using System.Text;
using System.Mvc;

namespace WPFApp.Controllers
{
    class HomeController : BaseController
    {
        public ActionResult Default()
        {
            ViewData["caption"] = "Home/Default";
            return View(DateTime.Now);
        }

        public ActionResult Contact() {
            ViewData["caption"] = "Contact ahah";
            return View(); 
        }
    }
}
