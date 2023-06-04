using Microsoft.Ajax.Utilities;
using PackageDelivery.Application.Contracts.DTO.ParametersDTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class TownController : Controller
    {
        private ITownApplication _app;
        private IDepartmentApplication _appDepartment;
        DepartmentGUIMapper departmentGUIMapper = new DepartmentGUIMapper();

        public TownController(ITownApplication app, IDepartmentApplication appDepartment)
        {
            this._app = app;
            this._appDepartment = appDepartment;
        }

        // GET: Town
        public ActionResult Index(string filter = "")
        {
            TownGUIMapper mapper = new TownGUIMapper();
            

            departmentGUIMapper.DTOToModelMapper(_appDepartment.getRecordsList(filter))
                .ForEach(d => ViewData.Add(d.Id.ToString(), d.name));

            IEnumerable <TownModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Town/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel townModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // GET: Town/Create
        public ActionResult Create()
        {
            var deparmentList = departmentGUIMapper.DTOToModelMapper(_appDepartment.getRecordsList(""))
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.name });

            ViewData["Deparments"] = deparmentList;
            return View();
        }

        // POST: Town/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,IdDepartment")] TownModel townModel)
        {
            if(ModelState.IsValid)
            {
                TownGUIMapper mapper = new TownGUIMapper();
                TownDTO response = _app.createRecord(mapper.ModelToDTOMapper(townModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(townModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(townModel);
        }

        // GET: Town/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel townModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // POST: Town/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,IdDepartment")] TownModel townModel)
        {
            if (ModelState.IsValid)
            {
                TownGUIMapper mapper = new TownGUIMapper();
                TownDTO response = _app.updateRecord(mapper.ModelToDTOMapper(townModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(townModel);
        }

        // GET: Town/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TownGUIMapper mapper = new TownGUIMapper();
            TownModel townModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (townModel == null)
            {
                return HttpNotFound();
            }
            return View(townModel);
        }

        // POST: Town/Delete/5
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
