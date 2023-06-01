using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class VehicleController : Controller
    {
        private IVehicleApplication _app;

        public VehicleController(IVehicleApplication app)
        {
            this._app = app;
        }

        // GET: Vehicle
        public ActionResult Index(string filter = "")
        {
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            IEnumerable<VehicleModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,plate,idTransportType")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.createRecord(mapper.ModelToDTOMapper(vehicleModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(vehicleModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(vehicleModel);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: Vehicle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,plate,idTransportType")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.updateRecord(mapper.ModelToDTOMapper(vehicleModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(vehicleModel);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel vehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: Vehicle/Delete/5
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
    }
}
