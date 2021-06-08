using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseFirstNETFramework.Models;

namespace DatabaseFirstNETFramework.Controllers
{
    public class OyuncuController : Controller
    {
        private DatabaseFirstNETEntities db = new DatabaseFirstNETEntities();

        // GET: Oyuncu
        public ActionResult Index()
        {
            var oyuncus = db.Oyuncus.Include(o => o.Mevki1).Include(o => o.Takim).Include(o => o.Ulke1);
            return View(oyuncus.ToList());
        }

        // GET: Oyuncu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oyuncu oyuncu = db.Oyuncus.Find(id);
            if (oyuncu == null)
            {
                return HttpNotFound();
            }
            return View(oyuncu);
        }

        // GET: Oyuncu/Create
        public ActionResult Create()
        {
            ViewBag.Mevki = new SelectList(db.Mevkis, "ID", "MevkiAdi");
            ViewBag.TakimID = new SelectList(db.Takims, "ID", "TakimAdi");
            ViewBag.Ulke = new SelectList(db.Ulkes, "ID", "UlkeAdi");
            return View();
        }

        // POST: Oyuncu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TakimID,Adi,Soyadi,Yasi,Mevki,Maas,SozlesmeSuresi,Ulke")] Oyuncu oyuncu)
        {
            if (ModelState.IsValid)
            {
                db.Oyuncus.Add(oyuncu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mevki = new SelectList(db.Mevkis, "ID", "MevkiAdi", oyuncu.Mevki);
            ViewBag.TakimID = new SelectList(db.Takims, "ID", "TakimAdi", oyuncu.TakimID);
            ViewBag.Ulke = new SelectList(db.Ulkes, "ID", "UlkeAdi", oyuncu.Ulke);
            return View(oyuncu);
        }

        // GET: Oyuncu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oyuncu oyuncu = db.Oyuncus.Find(id);
            if (oyuncu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mevki = new SelectList(db.Mevkis, "ID", "MevkiAdi", oyuncu.Mevki);
            ViewBag.TakimID = new SelectList(db.Takims, "ID", "TakimAdi", oyuncu.TakimID);
            ViewBag.Ulke = new SelectList(db.Ulkes, "ID", "UlkeAdi", oyuncu.Ulke);
            return View(oyuncu);
        }

        // POST: Oyuncu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TakimID,Adi,Soyadi,Yasi,Mevki,Maas,SozlesmeSuresi,Ulke")] Oyuncu oyuncu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyuncu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mevki = new SelectList(db.Mevkis, "ID", "MevkiAdi", oyuncu.Mevki);
            ViewBag.TakimID = new SelectList(db.Takims, "ID", "TakimAdi", oyuncu.TakimID);
            ViewBag.Ulke = new SelectList(db.Ulkes, "ID", "UlkeAdi", oyuncu.Ulke);
            return View(oyuncu);
        }

        // GET: Oyuncu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oyuncu oyuncu = db.Oyuncus.Find(id);
            if (oyuncu == null)
            {
                return HttpNotFound();
            }
            return View(oyuncu);
        }

        // POST: Oyuncu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oyuncu oyuncu = db.Oyuncus.Find(id);
            db.Oyuncus.Remove(oyuncu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
