using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;

namespace WebSell.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: loaiSP
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLoaiSP()
        {
            CategoryBuss bl = new CategoryBuss();
            List<LoaiSP> l = bl.GetLoaiSP();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}