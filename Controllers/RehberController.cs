using ClosedXML.Excel;
using MvcRehber2.Models;
using Rehber.Models.Context;
using Rehber.Models.Entities;
using Rehber.Models.rehberModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace MvcRehber2.Controllers
{
    public class RehberController : Controller
    {
        dbContext db = new dbContext();
        

        public ActionResult Index()
        {
            object session = Session["yetki"];
            if (session != null)
            {
                var model = new rehberIndexViewModel
                {
                    rehbers = db.rehbers.Where(x=>x.userId.ToString() == session).ToList(),
                    sehirs = db.sehirs.ToList()
                };
                return View(model);
            }
            return Redirect("/Home/Login");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            object session = Session["yetki"];
            if (session != null)
            {
                var model = new rehberEkleViewModel
                {
                    rehber = new rehber(),
                    sehirs = db.sehirs.ToList()
                }; 
                return View(model);
            }
            return Redirect("/Home/Login");
        }
        [HttpPost]
        public ActionResult Ekle(rehber rehber) 
        {
            object session = Session["yetki"];
            if (session != null)
            {
                try
                {
                    rehber.userId = Convert.ToInt32(session);
                    db.rehbers.Add(rehber);
                    db.SaveChanges();

                    TempData["Başarılı"] = "Ekleme işlemi başarılı";
                }
                catch (Exception)
                {
                    TempData["Başarısız"] = "Ekleme işlemi başarısız";
                }


                return RedirectToAction("Index");
            }
            return Redirect("/Home/Login");
        }
        [HttpGet]
        public ActionResult Güncelle(int Id)
        {
            object session = Session["yetki"];
            if (session != null)
            {
                var rehber = db.rehbers.Find(Id);
                if (rehber == null)
                {
                    TempData["Başarısız"] = "Güncellemek istediğiniz kayıt bulunamadı";
                    return RedirectToAction("Index");
                }
                var model = new rehberGüncelleViewModel
                {
                    rehber = rehber,
                    sehirs = db.sehirs.ToList()
                };

                ViewBag.sehirs = new SelectList(db.sehirs.ToList(), "Id", "sehirName");
                return View(model);
            }
            return Redirect("/Home/Login");
        }
        [HttpPost]
        public ActionResult Güncelle(rehber rehber)
        {

            object session = Session["yetki"];
            if (session != null)
            {
                var eskiKayıt = db.rehbers.Find(rehber.Id);
                if (eskiKayıt == null)
                {
                    TempData["Başarısız"] = "Güncellemek istenen kayıt bulunamadı";
                    return RedirectToAction("Index");
                }

                eskiKayıt.name = rehber.name;
                eskiKayıt.surname = rehber.surname;
                eskiKayıt.phoneNumber = rehber.phoneNumber;
                eskiKayıt.email = rehber.email;
                eskiKayıt.adres = rehber.adres;
                eskiKayıt.sehirId = rehber.sehirId;

                db.SaveChanges();

                TempData["Başarılı"] = "Kayıt güncellendi";
                return RedirectToAction("Index");
            }
            return Redirect("/Home/Login");
        }
        [HttpGet]
        public ActionResult Detaylar(int Id)
        {
            object session = Session["yetki"];
            if (session != null)
            {
                var rehber = db.rehbers.Find(Id);
                if (rehber == null)
                {
                    TempData["Başarısız"] = "Aradığınız kayıt bulunamadı";
                    return RedirectToAction("Index");
                }
                var model = new rehberDetayViewModel
                {
                    rehber = rehber,
                    sehirs = db.sehirs.ToList()
                };

                return View(model);
            }
            return Redirect("/Home/Login");
        
        }
        [HttpGet]
        public ActionResult Sil(int Id)
        {
                object session = Session["yetki"];
                if (session != null)
                {
                    var silinecekKayıt = db.rehbers.Find(Id);
            if (silinecekKayıt == null)
            {
                TempData["Başarısız"] = "Aradığınız kayıt bulunamadı";
                return RedirectToAction("Index");
            }
            db.rehbers.Remove(silinecekKayıt);
            db.SaveChanges();


            return RedirectToAction("Index");
            }
            return Redirect("/Home/Login");
        }

        public ActionResult ExportExcelList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("rehber");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "name";
                worksheet.Cell(1, 3).Value = "surname";
                worksheet.Cell(1, 4).Value = "phoneNumber";
                worksheet.Cell(1, 5).Value = "email";
                worksheet.Cell(1, 6).Value = "adres";
                worksheet.Cell(1, 7).Value = "sehirId";

                int rowCount = 2;
                foreach (var item in GetRehberList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.IdList;
                    worksheet.Cell(rowCount, 2).Value = item.nameList;
                    worksheet.Cell(rowCount, 3).Value = item.surnameList;
                    worksheet.Cell(rowCount, 4).Value = item.phoneNumberList;
                    worksheet.Cell(rowCount, 5).Value = item.emailList;
                    worksheet.Cell(rowCount, 6).Value = item.adresList;
                    worksheet.Cell(rowCount, 7).Value = item.sehirIdList;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Rehber1.xlsx");
                }
            }
        }
        public List<rehberList> GetRehberList()
        {
            List<rehberList> rl = new List<rehberList>();
            using (var db1 = new dbContext())
            {
                rl = db1.rehbers.Select(x => new rehberList
                {
                    IdList = x.Id,
                    nameList = x.name,
                    surnameList = x.surname,
                    phoneNumberList = x.phoneNumber,
                    emailList = x.email,
                    adresList = x.adres,
                    sehirIdList = x.sehirId,
                }).ToList();
            }
            return rl;
        }

    }
}