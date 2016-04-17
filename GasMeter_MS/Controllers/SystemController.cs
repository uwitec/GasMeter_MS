using System.Web.Mvc;
using GasMeter_MS.Models;
using System.Linq;

namespace GasMeter_MS.Controllers
{
    public class SystemController : Controller
    {
        // GET: SystemInfo
        public ActionResult Index()
        {
            var DB = new ApplicationDbContext();
            var model = DB.SysInfos.First();
            return View(model);
        }

        // GET: init data
        public ActionResult InitData()
        {
            return View();
        }

        // GET: 多组织机构
        public ActionResult Branch()
        {
            return View();
        }

    }
}