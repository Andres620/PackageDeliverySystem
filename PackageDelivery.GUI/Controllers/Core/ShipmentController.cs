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
    public class ShipmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shipment
        public ActionResult Index()
        {
            return View(db.ShipmentModels.ToList());
        }

        // GET: Shipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentModel shipmentModel = db.ShipmentModels.Find(id);
            if (shipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentModel);
        }

        // GET: Shipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipment/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,shippingDate,price,idSender,idDestinationAddress,idPackage,idShipmentState,idTransportType")] ShipmentModel shipmentModel)
        {
            if (ModelState.IsValid)
            {
                db.ShipmentModels.Add(shipmentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipmentModel);
        }

        // GET: Shipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentModel shipmentModel = db.ShipmentModels.Find(id);
            if (shipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentModel);
        }

        // POST: Shipment/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,shippingDate,price,idSender,idDestinationAddress,idPackage,idShipmentState,idTransportType")] ShipmentModel shipmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipmentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipmentModel);
        }

        // GET: Shipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentModel shipmentModel = db.ShipmentModels.Find(id);
            if (shipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(shipmentModel);
        }

        // POST: Shipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipmentModel shipmentModel = db.ShipmentModels.Find(id);
            db.ShipmentModels.Remove(shipmentModel);
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
