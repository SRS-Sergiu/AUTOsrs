using AUTOsrs.Models;
using AUTOsrs.Repository;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class AdminController : Controller
    {

        private Repository.MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        // Post: Admin/SaveMarca/5
        public ActionResult SaveMarca(AdminViewModel model)
        {
            //MarcaAutoRepository marcaAutoRepository = new MarcaAutoRepository();
            MarcaAutoModel MarcaAutoModel = new MarcaAutoModel();
            MarcaAutoModel.Marca = model.Marca;
            marcaAutoRepository.InsertMarcaAuto(MarcaAutoModel);
            
            return View("Dashboard");
        }
        public ActionResult ViewMarca(Guid ID)
        {
            //incarcam lista cu Marca Auto
            MarcaAutoModel marcaAuto = marcaAutoRepository.GetMarcaAutoByID(ID);
            return View("Dashboard", marcaAuto);
        }
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
