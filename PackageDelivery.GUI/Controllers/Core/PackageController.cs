﻿using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class PackageController : Controller
    {
		private IPackageApplication _app;
		private IOfficeApplication _officeApplication;

        public PackageController(IPackageApplication app, IOfficeApplication officeApplication)
        {
            this._app = app;
			this._officeApplication = officeApplication;
        }

        // GET: Package
        public ActionResult Index()
        {
			var dtoList = _app.getRecordsList();
			PackageGUIMapper mapper = new PackageGUIMapper();
			IEnumerable<PackageModel> model = mapper.DTOToModelMapper(dtoList);
			return View(model);
		}

        // GET: Package/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PackageGUIMapper mapper = new PackageGUIMapper();
			PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (packageModel == null)
			{
				return HttpNotFound();
			}
			return View(packageModel);
		}

        // GET: Package/Create
        public ActionResult Create()
        {
			this.getOfficeListToSelect();
            return View();
        }

        // POST: Package/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,weight,height,depth,width,idOffice")] PackageModel packageModel)
        {
			if (ModelState.IsValid)
			{
				PackageGUIMapper mapper = new PackageGUIMapper();
				PackageDTO response = _app.createRecord(mapper.ModelToDTOMapper(packageModel));
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
			this.getOfficeListToSelect();
			return View(packageModel);
		}

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PackageGUIMapper mapper = new PackageGUIMapper();
			PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (packageModel == null)
			{
				return HttpNotFound();
			}
			this.getOfficeListToSelect();
			return View(packageModel);
		}

        // POST: Package/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,weight,height,depth,width,idOffice")] PackageModel packageModel)
        {
			if (ModelState.IsValid)
			{
				PackageGUIMapper mapper = new PackageGUIMapper();
				PackageDTO response = _app.updateRecord(mapper.ModelToDTOMapper(packageModel));
				if (response != null)
				{
					return RedirectToAction("Index");
				}
			}
			ViewBag.Message = ActionMessages.errorMessage;
			this.getOfficeListToSelect();
			return View(packageModel);
		}

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PackageGUIMapper mapper = new PackageGUIMapper();
			PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (packageModel == null)
			{
				return HttpNotFound();
			}
			return View(packageModel);
		}

        // POST: Package/Delete/5
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

        private void getOfficeListToSelect()
        {
            ViewBag.idOffice = new SelectList(_officeApplication.getRecordsList(), "Id", "name");
        }
    }
}
