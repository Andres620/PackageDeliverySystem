﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class WarehouseController : Controller
    {
        private IWarehouseApplication _app;
        private ITownApplication _appTown;

        public WarehouseController(IWarehouseApplication app, ITownApplication townApplication)
        {
            this._app = app;
            this._appTown = townApplication;
        }

        // GET: Warehouse
        public ActionResult Index()
        {
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return View(list);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            this.getTownListToSelect();
            return View();
        }

        // POST: Warehouse/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,code,address,latitude,longitude,idTown")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.createRecord(mapper.ModelToDTOMapper(warehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(warehouseModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            this.getTownListToSelect();
            return View(warehouseModel);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            this.getTownListToSelect();
            return View(warehouseModel);
        }

        // POST: Warehouse/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,code,address,latitude,longitude,idTown")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.updateRecord(mapper.ModelToDTOMapper(warehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            this.getTownListToSelect();
            return View(warehouseModel);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel warehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                ViewBag.ClassName = ActionMessages.successClass;
                ViewBag.Message = ActionMessages.successMessage;
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View();
        }

        private void getTownListToSelect()
        {
            ViewBag.idTown = new SelectList(_appTown.getRecordsList(), "Id", "name");
        }
    }
}
