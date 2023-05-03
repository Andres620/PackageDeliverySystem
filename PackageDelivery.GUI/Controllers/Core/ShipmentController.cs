using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class ShipmentController : Controller
    {
        private IShipmentApplication _app = new ShipmentImpApplication();

        // GET: Shipment
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Shipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentGUIMapper mapper = new ShipmentGUIMapper();
            ShipmentModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] ShipmentModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                ShipmentGUIMapper mapper = new ShipmentGUIMapper();
                ShipmentDTO response = _app.createRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(documentTypeModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Shipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentGUIMapper mapper = new ShipmentGUIMapper();
            ShipmentModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: Shipment/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] ShipmentModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                ShipmentGUIMapper mapper = new ShipmentGUIMapper();
                ShipmentDTO response = _app.updateRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Shipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentGUIMapper mapper = new ShipmentGUIMapper();
            ShipmentModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
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
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View();
        }
    }
}
