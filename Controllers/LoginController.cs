using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerBusss;
using WebSell.Models;

namespace WebSell.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        QuanLySanPhamEntities QuanLySanPhamEntities = new QuanLySanPhamEntities();

        // GET: Administrator/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(User user)
        {
            var check = QuanLySanPhamEntities.Users.Where(s => s.Email.Equals(user.Email)
            && s.PassWord.Equals(user.PassWord)).FirstOrDefault();
            if (check == null)
            {
                user.LoginErrorMessage = "Error Email or Password! Try again please!";
                return View("Index", user);
            }
            else
            {
                Session["Email"] = user.Email;
                Session["PassWord"] = user.PassWord;
                return RedirectToAction("Index", "QLSanPham");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = QuanLySanPhamEntities.Users.FirstOrDefault(s => s.Email == user.Email);
                if (check == null)
                {
                    QuanLySanPhamEntities.Configuration.ValidateOnSaveEnabled = false;
                    QuanLySanPhamEntities.Users.Add(user);
                    QuanLySanPhamEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists! User another email please!";
                    return View();
                }

            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}