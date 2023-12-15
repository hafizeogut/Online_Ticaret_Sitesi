using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret_sitesi.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}