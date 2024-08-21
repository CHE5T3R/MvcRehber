using DocumentFormat.OpenXml.Office2013.Excel;
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
using WebApplication2.Migrations;

namespace MvcRehber2.Controllers
{
    public class HomeController : Controller
    {
        dbContext db = new dbContext();


        [HttpGet]
        public ActionResult Login()
        {
            var users = db.users.ToList();

            if (Session["yetki"] != null)
            {
                foreach (var model in users)
                {
                    if (Session["yetki"] == model.Id.ToString())
                    {
                        TempData["Başarısız"] = $"{model.userName} online, önce çıkış yapın";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string userName = fc["userName"];
            string password = fc["password"];
            var users = db.users.ToList();
            try
            {
                foreach (var model in users)
                {
                    if (userName == model.userName && password == model.password)
                    {
                        Session["yetki"] = model.Id.ToString();
                        return Redirect("/Rehber/Index");
                    }
                }
                TempData["Başarısız"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            catch (Exception)
            {
                TempData["Başarısız"] = "Giriş yapılamadı";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Signup()
        {
            var users = db.users.ToList();

            if (Session["yetki"] != null)
            {
                foreach (var model in users)
                {
                    if (Session["yetki"] == model.Id.ToString())
                    {
                        TempData["Başarısız"] = $"{model.userName} online, önce çıkış yapın";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(user user)
        {
            var users = db.users.ToList();

            foreach (var model in users)
            {
                if (user.userName == model.userName)
                {
                    TempData["Başarısız"] = "Kullanıcı adı zaten mevcut";
                    return View();
                }
            }
            if (user.password != user.passwordControl)
            {
                TempData["Başarısız"] = "Hatalı şifre";
                return View();
            }
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
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["yetki"] == null)
            {
                TempData["Başarısız"] = "Hesaba giriş yapılmadı";
                return RedirectToAction("Index");
            }
            Session["yetki"] = null;
            TempData["Başarılı"] = "Çıkış başarılı";
            return RedirectToAction("Index");
        }
    }
}