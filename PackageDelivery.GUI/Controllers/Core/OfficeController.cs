using PackageDelivery.Application.Contracts.DTO.CoreDTO;
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
    public class OfficeController : Controller
    {
		private IOfficeApplication _app;
		private ITownApplication _townApp;

        public OfficeController(IOfficeApplication app, ITownApplication appTown)
        {
            this._app = app;
			this._townApp = appTown;
        }

        // GET: Office
        public ActionResult Index()
        {
			var dtoList = _app.getRecordsList();
			OfficeGUIMapper mapper = new OfficeGUIMapper();
			IEnumerable<OfficeModel> model = mapper.DTOToModelMapper(dtoList);
			return View(model);
		}

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OfficeGUIMapper mapper = new OfficeGUIMapper();
			OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (officeModel == null)
			{
				return HttpNotFound();
			}
			return View(officeModel);
		}

        // GET: Office/Create
        public ActionResult Create()
        {
			this.getTownListToSelect();
            return View();
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,code,cellphone,address,latitude,longitude,idTown")] OfficeModel officeModel)
        {
			if (ModelState.IsValid)
			{
				OfficeGUIMapper mapper = new OfficeGUIMapper();
				OfficeDTO response = _app.createRecord(mapper.ModelToDTOMapper(officeModel));
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
			this.getTownListToSelect();
			return View(officeModel);
		}

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OfficeGUIMapper mapper = new OfficeGUIMapper();
			OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (officeModel == null)
			{
				return HttpNotFound();
			}
			this.getTownListToSelect();
			return View(officeModel);
		}

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,code,cellphone,address,latitude,longitude,idTown")] OfficeModel officeModel)
        {
			if (ModelState.IsValid)
			{
				OfficeGUIMapper mapper = new OfficeGUIMapper();
				OfficeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(officeModel));
				if (response != null)
				{
					return RedirectToAction("Index");
				}
			}
			ViewBag.Message = ActionMessages.errorMessage;
			this.getTownListToSelect();
			return View(officeModel);
		}

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OfficeGUIMapper mapper = new OfficeGUIMapper();
			OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
			if (officeModel == null)
			{
				return HttpNotFound();
			}
			return View(officeModel);
		}

        // POST: Office/Delete/5
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

		private void getTownListToSelect()
		{
			ViewBag.idTown = new SelectList(_townApp.getRecordsList(), "Id", "name");
		}
    }
}
