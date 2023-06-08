using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.GUI.Reportes;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class PersonController : Controller
    {
        private IPersonApplication _app;
        private IAddressApplication _IdAddressApp;
        private IDocumentTypeApplication _documentTypeApp;

        public PersonController(IPersonApplication app, IDocumentTypeApplication documentTypeApp, IAddressApplication IdAddressApp)
        {
            this._app = app;
            this._documentTypeApp = documentTypeApp;
            this._IdAddressApp = IdAddressApp;
        }

        // GET: Person
        public ActionResult Index()
        {
            PersonGUIMapper mapper = new PersonGUIMapper();
            IEnumerable<PersonModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {   
            this.getIdAddressListToSelect();
            this.getDocumentTypeListToSelect();
            return View();
        }

        // POST: Person/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdAddress,IdDocumentType")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                PersonDTO response = _app.createRecord(mapper.ModelToDTOMapper(personModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(personModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            this.getIdAddressListToSelect();
            this.getDocumentTypeListToSelect();
            return View(personModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (personModel == null)
            {
                return HttpNotFound();
            }
            this.getIdAddressListToSelect();
            this.getDocumentTypeListToSelect();
            return View(personModel);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdAddress,IdDocumentType")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                PersonDTO response = _app.updateRecord(mapper.ModelToDTOMapper(personModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            this.getIdAddressListToSelect();
            this.getDocumentTypeListToSelect();
            return View(personModel);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: Person/Delete/5
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

        private void getIdAddressListToSelect()
        {
            ViewBag.IdAddress = new SelectList(_IdAddressApp.getRecordsList(), "Id", "streetType");
        }

        private void getDocumentTypeListToSelect()
        {
            ViewBag.IdDocumentType = new SelectList(_documentTypeApp.getRecordsList(), "Id", "name");
        }

        public ActionResult Report(string type)
        {
            PersonGUIMapper mapper = new PersonGUIMapper();
            var report = General.RenderReports(
                Server.MapPath("~/Reportes/Personas.rdlc"),
                new List<string> { "Personas" },
                new List<object> { mapper.DTOToModelMapper(_app.getRecordsList()) },
                type
                );
            return File(report.Item1, report.Item2);
        }

    }
}
