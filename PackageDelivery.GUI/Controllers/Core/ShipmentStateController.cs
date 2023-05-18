using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class ShipmentStateController : Controller
    {
        private IShipmentStateApplication _app = new ShipmentStateImpApplication();


        // GET: ShipmentState
        public ActionResult Index(string filter = "")
        {
            ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
            IEnumerable<ShipmentStateModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: ShipmentState/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
            ShipmentStateModel ShipmentStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (ShipmentStateModel == null)
            {
                return HttpNotFound();
            }
            return View(ShipmentStateModel);
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
        public ActionResult Create([Bind(Include = "Id,name")] ShipmentStateModel ShipmentStateModel)
        {
            if (ModelState.IsValid)
            {
                ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
                ShipmentStateDTO response = _app.createRecord(mapper.ModelToDTOMapper(ShipmentStateModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(ShipmentStateModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(ShipmentStateModel);
        }

        // GET: ShipmentState/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
            ShipmentStateModel shipmentStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
                ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
                ShipmentStateDTO response = _app.updateRecord(mapper.ModelToDTOMapper(shipmentStateModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(shipmentStateModel);
        }

        // GET: ShipmentState/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentStateGUIMapper mapper = new ShipmentStateGUIMapper();
            ShipmentStateModel shipmentStateModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
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
