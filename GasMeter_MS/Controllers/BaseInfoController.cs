using GasMeter_MS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        // GET: 气价信息编辑
        [HttpPost]
        public int PriceEdit(Price model)
        {
            model.UpdateDateTime = DateTime.Now;
            var DB = new ApplicationDbContext();
            int success = model.Id;
            DB.Entry(model).State = EntityState.Modified;
            if (DB.SaveChanges() <= 0)
            {
                success = -1;
            }
            return success;
        }
        // GET: 气价信息添加
        [HttpPost]
        public int PriceAdd(Price model)
        {
            model.UpdateDateTime = DateTime.Now;
            model.StartDateTime = DateTime.Now;
            var DB = new ApplicationDbContext();
            var newId=-1;
            DB.Price.Add(model);
            if (DB.SaveChanges() > 0)
            {
                newId = DB.Price.ToList().Last().Id;
            }
            return newId;
        }
        // GET: 气价信息删除
        [HttpPost]
        public bool PriceDelete(Price model)
        {
            var DB = new ApplicationDbContext();
            bool success = true;
            DB.Price.Remove(model);
            DB.Entry(model).State = EntityState.Deleted;
            if (DB.SaveChanges() <= 0)
            {
                success = false;
            }
            return success;
        }
    }
}