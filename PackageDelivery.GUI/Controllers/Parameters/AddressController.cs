using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class AddressController : Controller
    {
        private IAddressApplication _app = new AddressImpApplication();

        // GET: Address
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] AddressModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.createRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(documentTypeModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: Address/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] AddressModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.updateRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: Address/Delete/5
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
