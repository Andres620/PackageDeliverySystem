using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class TownController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Town
        public ActionResult Index()
        {
            return View(db.TownModels.ToList());
        }

        // GET: Town/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownModel townModel = db.TownModels.Find(id);
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // GET: Town/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Town/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,IdDepartment")] TownModel townModel)
        {
            if (ModelState.IsValid)
            {
                db.TownModels.Add(townModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(townModel);
        }

        // GET: Town/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownModel townModel = db.TownModels.Find(id);
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // POST: Town/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,IdDepartment")] TownModel townModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(townModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(townModel);
        }

        // GET: Town/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownModel townModel = db.TownModels.Find(id);
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // POST: Town/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TownModel townModel = db.TownModels.Find(id);
            db.TownModels.Remove(townModel);
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
