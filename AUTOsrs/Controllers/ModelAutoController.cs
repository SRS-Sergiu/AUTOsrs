using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class ModelAutoController : Controller
    {
        private Repository.ModelAutoRepository marcaAutoRepository = new Repository.ModelAutoRepository();

        // GET: ModelAuto
        public ActionResult Index()
        {
            return View();
        }

        // GET: ModelAuto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelAuto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelAuto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModelAuto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelAuto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModelAuto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelAuto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
