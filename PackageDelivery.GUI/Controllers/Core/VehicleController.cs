using PackageDelivery.Application.Contracts.DTO.CoreDTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class VehicleController : Controller
    {
        private IVehicleApplication _app = new VehicleImpApplication();

        // GET: Vehicle
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] VehicleModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.createRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(documentTypeModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: Vehicle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] VehicleModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.updateRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: Vehicle/Delete/5
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
