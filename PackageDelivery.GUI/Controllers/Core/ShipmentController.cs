using Microsoft.Reporting.Map.WebForms.BingMaps;
using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class ShipmentController : Controller
    {
		private IShipmentApplication _app;
		private IPersonApplication _appPerson;
		private IAddressApplication _appAddress;
		private IPackageApplication _appPackage;
		private IShipmentStateApplication _appShipmentState;
		private ITransportTypeApplication _appTransportType;

        public ShipmentController(IShipmentApplication app, IAddressApplication appAddress, IPackageApplication appPackage, IShipmentStateApplication appShipmentState, ITransportTypeApplication appTransportType, IPersonApplication appPerson)
        {
            this._app = app;
			_appPerson = appPerson;
            _appAddress = appAddress;
            _appPackage = appPackage;
            _appShipmentState = appShipmentState;
            _appTransportType = appTransportType;
        }

        // GET: Shipment
        public ActionResult Index()
        {
			var dtoList = _app.getRecordsList();
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
            Console.WriteLine("Create que retorna la vista");
            this.getPersonListToSelect();
			this.getAddressListToSelect();
			this.getPackageListToSelect();
			this.getShipmentStateListToSelect();
			this.getTransportTypeListToSelect();
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
            this.getPersonListToSelect();
            this.getAddressListToSelect();
            this.getPackageListToSelect();
            this.getShipmentStateListToSelect();
            this.getTransportTypeListToSelect();
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
            this.getPersonListToSelect();
            this.getAddressListToSelect();
            this.getPackageListToSelect();
            this.getShipmentStateListToSelect();
            this.getTransportTypeListToSelect();
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
            this.getPersonListToSelect();
            this.getAddressListToSelect();
            this.getPackageListToSelect();
            this.getShipmentStateListToSelect();
            this.getTransportTypeListToSelect();
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

        private void getPersonListToSelect()
        {
            ViewBag.idSender = new SelectList(_appPerson.getRecordsList(), "Id", "identificationNumber");
        }

		private void getAddressListToSelect()
		{
            ViewBag.idDestinationAddress = new SelectList(_appAddress.getRecordsList(), "Id", "Id");
        }

		private void getPackageListToSelect()
		{
            ViewBag.idPackage = new SelectList(_appPackage.getRecordsList(), "Id", "Id");
        }

		private void getShipmentStateListToSelect()
		{
            ViewBag.idShipmentState = new SelectList(_appShipmentState.getRecordsList(), "Id", "name");
        }

		private void getTransportTypeListToSelect()
		{
            ViewBag.idTransportType = new SelectList(_appTransportType.getRecordsList(), "Id", "name");
        }
    }
}
