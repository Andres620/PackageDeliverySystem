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
    public class ShipmentStateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipmentState
        public ActionResult Index()
        {
            return View(db.ShipmentStateModels.ToList());
        }

        // GET: ShipmentState/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateModel shipmentStateModel = db.ShipmentStateModels.Find(id);
            if (shipmentStateModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentStateModel);
        }

        // GET: ShipmentState/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipmentState/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] ShipmentStateModel shipmentStateModel)
        {
            if (ModelState.IsValid)
            {
                db.ShipmentStateModels.Add(shipmentStateModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipmentStateModel);
        }

        // GET: ShipmentState/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateModel shipmentStateModel = db.ShipmentStateModels.Find(id);
            if (shipmentStateModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentStateModel);
        }

        // POST: ShipmentState/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] ShipmentStateModel shipmentStateModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipmentStateModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipmentStateModel);
        }

        // GET: ShipmentState/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateModel shipmentStateModel = db.ShipmentStateModels.Find(id);
            if (shipmentStateModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentStateModel);
        }

        // POST: ShipmentState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipmentStateModel shipmentStateModel = db.ShipmentStateModels.Find(id);
            db.ShipmentStateModels.Remove(shipmentStateModel);
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
