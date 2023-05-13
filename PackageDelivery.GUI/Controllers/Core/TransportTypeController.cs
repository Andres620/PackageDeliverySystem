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
    public class TransportTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransportType
        public ActionResult Index()
        {
            return View(db.TransportTypeModels.ToList());
        }

        // GET: TransportType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeModel transportTypeModel = db.TransportTypeModels.Find(id);
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // GET: TransportType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.TransportTypeModels.Add(transportTypeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportTypeModel);
        }

        // GET: TransportType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeModel transportTypeModel = db.TransportTypeModels.Find(id);
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // POST: TransportType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportTypeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportTypeModel);
        }

        // GET: TransportType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeModel transportTypeModel = db.TransportTypeModels.Find(id);
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // POST: TransportType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportTypeModel transportTypeModel = db.TransportTypeModels.Find(id);
            db.TransportTypeModels.Remove(transportTypeModel);
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
