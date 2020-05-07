using AUTOsrs.Models;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class AdminMarcaController : Controller
    {

        private Repository.MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();
        


        // GET: Admin
        [HttpGet]
        public ActionResult DashboardCreareMarca()
        {
            return View();
        }

        //Post: Admin/SaveMarca/5
        [HttpPost]
        public ActionResult SaveMarca(AdminMarcaViewModel model)
        {
            if (model.ID_Marca != Guid.Empty)
            {
                //MarcaAutoRepository marcaAutoRepository = new MarcaAutoRepository();
                MarcaAutoModel MarcaAutoModel = new MarcaAutoModel();
                MarcaAutoModel.Marca = model.Marca;
                MarcaAutoModel.ID_Marca = model.ID_Marca;
                marcaAutoRepository.UpdateMarcaAuto(MarcaAutoModel);
                return RedirectToAction("DashboardListaMarci");
            }
            else
            {
                //MarcaAutoRepository marcaAutoRepository = new MarcaAutoRepository();
                MarcaAutoModel MarcaAutoModel = new MarcaAutoModel();
                MarcaAutoModel.Marca = model.Marca;
                marcaAutoRepository.InsertMarcaAuto(MarcaAutoModel);
                return RedirectToAction("DashboardListaMarci");
            }
        }

        public ActionResult DashboardListaMarci()
        {
            //incarcam lista de marci
            List<Models.MarcaAutoModel> marci = marcaAutoRepository.GetAllMarca();
            return View("DashboardListaMarci", marci);
        }


        // GET: Admin/Edit/5
        public ActionResult EditMarca(Guid id)
        {
            MarcaAutoModel marca = marcaAutoRepository.GetMarcaAutoByID(id);

            AdminMarcaViewModel model = new AdminMarcaViewModel();
            model.ID_Marca = id;
            model.Marca = marca.Marca;

            return View("DashboardCreareMarca", model);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteMarca(Guid id)
        {
            marcaAutoRepository.DeleteMarcaAuto(id);
            return RedirectToAction("DashboardListaMarci");
        }

    }
}
