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
    public class TransportTypeController : Controller
    {
        private ITransportTypeApplication _app;

        public TransportTypeController(ITransportTypeApplication app)
        {
            this._app = app;
        }

        // GET: TransportType
        public ActionResult Index()
        {
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            IEnumerable<TransportTypeModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return View(list);
        }

        // GET: TransportType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // GET: TransportType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.createRecord(mapper.ModelToDTOMapper(transportTypeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(transportTypeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(transportTypeModel);
        }

        // GET: TransportType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // POST: TransportType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] TransportTypeModel transportTypeModel)
        {
            if (ModelState.IsValid)
            {
                TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
                TransportTypeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(transportTypeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(transportTypeModel);
        }

        // GET: TransportType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportTypeGUIMapper mapper = new TransportTypeGUIMapper();
            TransportTypeModel transportTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeModel);
        }

        // POST: TransportType/Delete/5
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
