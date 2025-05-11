using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCstokEntities4 db = new MVCstokEntities4();
        public ActionResult Index()
        {
            var degerler = db.TblUrunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from x in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;//tasisma islemi
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TblUrunler p1)
        {
            var ktg = db.TblKategoriler.Where(m => m.KategoriID == p1.TblKategoriler.KategoriID).FirstOrDefault();
            p1.TblKategoriler = ktg;
            db.TblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}