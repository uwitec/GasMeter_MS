using System.Web.Mvc;
using GasMeter_MS.Models;
using System.Linq;
using System.Data.Entity;

namespace GasMeter_MS.Controllers
{
    public class SystemController : Controller
    {
        // GET: SystemInfo
        [Authorize]
        public ActionResult Index()
        {
            var DB = new ApplicationDbContext();
            var model = DB.SysInfos.First();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SysInfo model)
        {
            var DB = new ApplicationDbContext();
            DB.Entry(model).State = EntityState.Modified;
            if (DB.SaveChanges() > 0)
            {
                ViewBag.message = "修改成功";
                ViewBag.color = "success";
            }
            else {
                ViewBag.message = "数据提交失败";
                ViewBag.color = "red";
            }               
            return View(model);
        }
        // GET: init data
        public ActionResult InitData()
        {
            var DB = new ApplicationDbContext();
            var model = DB.KeyValues;
            return View(model);
        }

        // GET: 多组织机构
        public ActionResult Branch()
        {
            var DB = new ApplicationDbContext();
           // var model = DB.Trees.First(m=>m.Name== "branch");
            return View();
        }
        // GET: 地址管理
        public ActionResult Address()
        {
            var DB = new ApplicationDbContext();
           // var model = DB.Trees.First(m=>m.Name== "branch");
            return View();
        }
        // GET: 用户管理
        public ActionResult Users()
        {
            var DB = new ApplicationDbContext();
            var model = DB.Users;
            return View(model);
        }
    }
}