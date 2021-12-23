using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using ComputerObject;
using Newtonsoft.Json;

namespace WebSell.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ReadCustomer()
        {
            string l = "0";
            if (Session["login"] != null)
            {
                l = Session["login"].ToString();
            }
            Customer k = null;
            //string p = "";
            if (l == "1")
            {
                k = JsonConvert.DeserializeObject(Session["khach"].ToString()) as Customer;

            }
            return Json(new { login = l, khach = k }, JsonRequestBehavior.AllowGet);
        }
    }
}