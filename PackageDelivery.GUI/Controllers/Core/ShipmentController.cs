﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Core;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class ShipmentController : Controller
    {
		private IShipmentApplication _app = new ShipmentImpApplication();

		// GET: Shipment
		public ActionResult Index(long filter = 0)
        {
			var dtoList = _app.getRecordsList(filter);
			ShipmentGUIMapper mapper = new ShipmentGUIMapper();
			IEnumerable<ShipmentModel> model = mapper.DTOToModelMapper(dtoList);
			return View(model);
		}

        // GET: Shipment/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShipmentGUIMapper mapper = new ShipmentGUIMapper();
			ShipmentModel shipmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
				ShipmentGUIMapper mapper = new ShipmentGUIMapper();
				ShipmentDTO response = _app.createRecord(mapper.ModelToDTOMapper(shipmentModel));
				if (response != null)
				{
					ViewBag.ClassName = ActionMessages.successClass;
					ViewBag.Message = ActionMessages.successMessage;
					return RedirectToAction("Index");
				}
				ViewBag.ClassName = ActionMessages.warningClass;
				ViewBag.Message = ActionMessages.alreadyExistsMessage;
				return RedirectToAction("Index");
			}
			ViewBag.ClassName = ActionMessages.warningClass;
			ViewBag.Message = ActionMessages.errorMessage;
			return View(shipmentModel);
		}

        // GET: Shipment/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShipmentGUIMapper mapper = new ShipmentGUIMapper();
			ShipmentModel shipmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
				ShipmentGUIMapper mapper = new ShipmentGUIMapper();
				ShipmentDTO response = _app.updateRecord(mapper.ModelToDTOMapper(shipmentModel));
				if (response != null)
				{
					return RedirectToAction("Index");
				}
			}
			ViewBag.Message = ActionMessages.errorMessage;
			return View(shipmentModel);
		}

        // GET: Shipment/Delete/5
        public ActionResult Delete(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShipmentGUIMapper mapper = new ShipmentGUIMapper();
			ShipmentModel shipmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
			bool response = _app.deleteRecordById(id);
			if (response)
			{
				return RedirectToAction("Index");
			}
			ViewBag.Message = ActionMessages.errorMessage;
			return View();
		}
    }
}
