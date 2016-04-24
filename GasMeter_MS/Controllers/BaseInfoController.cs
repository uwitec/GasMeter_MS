using GasMeter_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GasMeter_MS.Controllers
{
    public class BaseInfoController : Controller
    {
        // GET: BaseInfo
        public ActionResult Index()
        {
            return View();
        }
        // GET: 气价信息
        public ActionResult Price()
        {
            var DB = new ApplicationDbContext();
            var model = DB.Price;
            return View(model);
        }
    }
}