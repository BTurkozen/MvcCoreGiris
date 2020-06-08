using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCoreGiris.Controllers
{
    public class KisilerController : Controller
    {
        private readonly OkulDbContex _db;
        public KisilerController(OkulDbContex db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_db.Kisiler.ToList());
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _db.Add(kisi);
                _db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\"  adlı kişi başarıyla eklenmiştir.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Duzenle(int? id)
        {
            var kisi = _db.Kisiler.Find(id);

            if (kisi != null)
            {
                return View(kisi);     
            }
            return NotFound();
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                //_db.Entry(kisi).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Altaki yontemin yerinede kullanılabılır.
                _db.Update(kisi);
                _db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişi başarıyla düzenlenmiştir.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sil(int? id)
        {
            var kisi = _db.Kisiler.Find(id);

            if (kisi != null)
            {
                _db.Remove(kisi);
                _db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\"  adlı kişi başarıyla silinmiştir.";
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
