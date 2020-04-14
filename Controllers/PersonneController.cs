using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training.DAL;
using Training.Models;

namespace Training.Controllers
{
    public class PersonneController : Controller
    {
        private PersonneContext db = new PersonneContext();

        // GET: Voitures
        public ActionResult Index()
        {
            var voitures = db.Personnes.Include(v => v.Pays);
            return View(voitures.ToList());
        }

        // GET: Personnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.Personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Nom_de_Pays");
            return View();
        }

        // POST: Voitures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonneID,Nom,PaysID")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Personnes.Add(personne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Nom_de_Pays", personne.PaysID);
            return View(personne);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.Personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaysID = new SelectList(db.Pays, "PaysID", "Nom_de_Pays", personne.PaysID);
            return View(personne);
        }

        // POST: Voitures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonneID,Nom,PaysID")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaysID = new SelectList(db.Personnes, "PaysID", "Nom_de_Pays", personne.PaysID);
            return View(personne);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne voiture = db.Personnes.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personne personne = db.Personnes.Find(id);
            db.Personnes.Remove(personne);
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
