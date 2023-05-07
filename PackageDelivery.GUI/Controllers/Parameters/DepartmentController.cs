using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class DepartmentController : Controller
    {
        private IDepartmentApplication _app = new DepartmentImpApplication();

        // GET: Department
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel departmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.createRecord(mapper.ModelToDTOMapper(departmentModel));
                if (response != null)
                {   
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(departmentModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(departmentModel);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel departmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // POST: Department/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.updateRecord(mapper.ModelToDTOMapper(departmentModel));
                if (response != null)
                {   
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(departmentModel);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel departmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // POST: Department/Delete/5
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
