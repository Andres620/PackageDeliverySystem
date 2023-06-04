using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class HistoryController : Controller
    {
        private IHistoryApplication _app;
        private IPackageApplication _appPackage;
        private IWarehouseApplication _appWarehouse;

        public HistoryController(IHistoryApplication app, IPackageApplication appPackage, IWarehouseApplication appWarehouse)
        {
            this._app = app;
            this._appPackage = appPackage;
            this._appWarehouse = appWarehouse;
        }

        // GET: History
        public ActionResult Index()
        {
            var dtoList = _app.getRecordsList();
            HistoryGUIMapper mapper = new HistoryGUIMapper();
            IEnumerable<HistoryModel> model = mapper.DTOToModelMapper(dtoList);
            return View(model);
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			HistoryGUIMapper mapper = new HistoryGUIMapper();
            HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            return View(historyModel);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            this.getPackageListToSelect();
            this.getWarehouseListToSelect();
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
				HistoryGUIMapper mapper = new HistoryGUIMapper();
                HistoryDTO response = _app.createRecord(mapper.ModelToDTOMapper(historyModel));
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
            this.getPackageListToSelect();
            this.getWarehouseListToSelect();
			return View(historyModel);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			HistoryGUIMapper mapper = new HistoryGUIMapper();
			HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (historyModel == null)
            {
                return HttpNotFound();
            }
            this.getPackageListToSelect();
            this.getWarehouseListToSelect();
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
				HistoryGUIMapper mapper = new HistoryGUIMapper();
				HistoryDTO response = _app.updateRecord(mapper.ModelToDTOMapper(historyModel));
                if (response != null)
                {
					return RedirectToAction("Index");
				}
            }
			ViewBag.Message = ActionMessages.errorMessage;
            this.getPackageListToSelect();
            this.getWarehouseListToSelect();
			return View(historyModel);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			HistoryGUIMapper mapper = new HistoryGUIMapper();
			HistoryModel historyModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
			bool response = _app.deleteRecordById(id);
			if (response)
			{
				return RedirectToAction("Index");
			}
			ViewBag.Message = ActionMessages.errorMessage;
			return View();
		}

        private void getPackageListToSelect()
        {
            ViewBag.idPackage = new SelectList(_appPackage.getRecordsList(), "Id", "Id");
        }

        private void getWarehouseListToSelect()
        {
            ViewBag.idWarehouse = new SelectList(_appWarehouse.getRecordsList(), "Id", "name");
        }
    }
}
