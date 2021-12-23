using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;
using WebSell.Models;
using Newtonsoft.Json;
using PagedList;

namespace WebSell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        LoginBuss lb = new LoginBuss();
        public JsonResult GetProduct()
        {
            ProductBuss pb = new ProductBuss();
            List<Product> lp = pb.GetSanPhams();
            //@ViewBag.SoSanPham = lp.Count;
            return Json(lp, JsonRequestBehavior.AllowGet);
            //return Json(new { sp = lp }, JsonRequestBehavior.AllowGet);
        }

        ProductBuss sb = new ProductBuss();
        CategoryBuss cab = new CategoryBuss();
        [HttpGet]
        public JsonResult GetSanPham(string maloai)
        {
            List<Product> lsp = sb.LaySPTheoLoai(maloai);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamPTLoai(int pageIndex, int pageSize, string productName)
        {
            if (Session["MaLoai"] == null)
            {
                Session.Add("MaLoai", "nuts");
            }
            SanPhamList spl = sb.GetSanPham(Session["MaLoai"].ToString(), pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamPT(int pageIndex, int pageSize, string productName)
        {
            //if (Session["MaLoai"] == null)
            //{
            //    Session.Add("MaLoai", "nuts");
            //}
            SanPhamList spl = sb.GetSanPhamPT(pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCategory()
        {
            List<LoaiSP> l = cab.GetCategory();
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Logout()
        {
            Session.Remove("login");
            Session.Remove("khach");
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Login(string us, string pw, bool rp)
        {
            Customer u = lb.CheckCustomer(us, pw);

            if (u == null)
            {
                Session["login"] = 0;
                Session["khach"] = "";
            }
            else
            {
                if (!rp)
                {
                    u.Password = "";
                }
                Session["login"] = 1;
                Session["khach"] = JsonConvert.SerializeObject(u);
                Session.Timeout = 360;
            }
            return Json(new { login = "1", Khach = u }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetMenu()
        {
            var language = 0;
            if (language == 1)
                return PartialView("_Menu");
            else
                return PartialView("_MenuView");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        QuanLySanPhamEntities quanLySanPhamEntities = new QuanLySanPhamEntities();
        public ActionResult Index1(string CurrentFilter, string SearchString, int? page)
        {
            ProductBuss pb = new ProductBuss();

            var listSanPham = new List<SanPham>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds  sản phẩm theo từ khóa tìm kiếm
                listSanPham = quanLySanPhamEntities.SanPhams.Where(n => n.TenSP.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sản phẩm trong bẳng sanpham
                listSanPham = quanLySanPhamEntities.SanPhams.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listSanPham = listSanPham.OrderByDescending(n => n.MaSP).ToList();
            //var listLoaiSanPham = new ModelQAShop().LoaiQA_PhuKien.ToList();
            return View(listSanPham.ToPagedList(pageNumber, pageSize));
        }
    }
}