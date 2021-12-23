using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;

namespace WebSell.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        ProductBuss pb = new ProductBuss();
        [Route("/GetSanPham")]
        public JsonResult GetSanPham(string maloai)
        {
            List<Product> lsp = pb.LaySPTheoLoai(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSanPhamTheoLoai(string maloai)
        {
            List<Product> lsp = pb.GetProductCategory(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProduct()
        {
            List<Product> lp = pb.GetSanPhams();
            //@ViewBag.SoSanPham = lp.Count;
            return Json(lp, JsonRequestBehavior.AllowGet);
            //return Json(new { sp = lp }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamPTLoai(int pageIndex, int pageSize, string productName)
        {
            if (Session["MaLoai"] == null)
            {
                Session.Add("MaLoai", "nuts");
            }
            SanPhamList spl = pb.GetSanPham(Session["MaLoai"].ToString(), pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamPT(int pageIndex, int pageSize, string productName)
        {
            //if (Session["MaLoai"] == null)
            //{
            //    Session.Add("MaLoai", "nuts");
            //}
            SanPhamList spl = pb.GetSanPhamPT(pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }
    }
}