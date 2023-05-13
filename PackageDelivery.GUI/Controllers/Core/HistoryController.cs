using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Core;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class HistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: History
        public ActionResult Index()
        {
            return View(db.HistoryModels.ToList());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: History/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,entryDate,departureDate,description,idPackage,idWarehouse")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                db.HistoryModels.Add(historyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historyModel);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: History/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,entryDate,departureDate,description,idPackage,idWarehouse")] HistoryModel historyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historyModel);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryModel historyModel = db.HistoryModels.Find(id);
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoryModel historyModel = db.HistoryModels.Find(id);
            db.HistoryModels.Remove(historyModel);
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
