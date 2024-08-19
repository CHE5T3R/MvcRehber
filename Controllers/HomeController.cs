using DocumentFormat.OpenXml.Spreadsheet;
using MvcRehber2.Models;
using Rehber.Models;
using Rehber.Models.Context;
using Rehber.Models.Entities;
using Rehber.Models.rehberModel;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcRehber2.Controllers
{
    public class HomeController : Controller
    {
        dbContext db = new dbContext();


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string kullanıcıadı = fc["userName"];
            string password = fc["password"];
            var users = db.users.ToList();

            foreach (var user1 in users)
            {
                if (kullanıcıadı == user1.userName && password == user1.password)
                {
                    Session["yetki"] = user1.Id.ToString();
                    return Redirect("/Rehber/Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(user user)
        {
            try
            {
                db.users.Add(user);
                db.SaveChanges();

                TempData["Başarılı"] = "Kayıt olma işlemi başarılı";
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                TempData["Başarısız"] = "Kayıt olma işlemi başarısız";
                return View();
            }

           
        }

        public ActionResult Index()
        {
            List<user> users = db.users.ToList();
            return View(users);
        }

        
    }
}