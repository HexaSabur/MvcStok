using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVCstokEntities4 db = new MVCstokEntities4();
        //MvcStok db = new MvcStok();
        public ActionResult Index()
        {
            var degerler = db.TblKategoriler.ToList();

            return View(degerler);
        }
        [HttpGet]//veru gelmezse veya yukleme olmadi zaman degusuklik yaomadab fister
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]/// veri gelirse yukleme olur
        public ActionResult YeniKategori(TblKategoriler p1) 
        { 
            db.TblKategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}