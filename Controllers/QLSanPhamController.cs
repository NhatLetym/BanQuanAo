using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;

namespace WebSell.Areas.Administrator.Controllers
{
    public class QLSanPhamController : Controller
    {
        ProductBuss sb = new ProductBuss();
        CategoryBuss sd = new CategoryBuss();
        // GET: Administrator/QLSanPham
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategory()
        {
            List<LoaiSP> l = sd.GetCategory();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSanPham()
        {
            List<Product> l = sb.GetSanPhams();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Upload(string masp)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/images/" + masp + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteProduct(string masp)
        {
            string st = sb.DeleteProduct(masp);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditProduct(Product sp)
        {

            string st = sb.EditProduct(sp);
            return Json(st, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult AddProduct(Product sp)
        {
            string st = sb.AddProduct(sp);
            return Json(st, JsonRequestBehavior.AllowGet);

        }
    }
}