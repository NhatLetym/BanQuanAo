using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;

namespace WebSell.Controllers
{
    public class ChiTietSPController : Controller
    {
        // GET: ChiTietSP
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetProduct(string MaSP)
        {
            ProductBuss pb = new ProductBuss();
            Product p = pb.GetSanPhamCT(MaSP);
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}