using AUTOsrs.Models;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class AdminCaracteristicaController : Controller
    {
      
        private Repository.CaracteristiciRepository caracteristiciRepository = new Repository.CaracteristiciRepository();
        private Repository.TipCaracteristicaRepository tipCaracteristicaRepository = new Repository.TipCaracteristicaRepository();

        // GET: Admin
        public ActionResult DashboardCreareCaracteristica()
        {
            AdminCaracteristiciViewModel adminCaracteristiciViewModel = new AdminCaracteristiciViewModel();
            adminCaracteristiciViewModel.TipCaracteristici1 = tipCaracteristicaRepository.GetAllTipCaracteristica();

            return View(adminCaracteristiciViewModel);
        }

        //Post: Admin/SaveCaracteristica/5
        public ActionResult SaveCaracteristica(AdminCaracteristiciViewModel model)
        {
            if (model.ID_Caracteristica != Guid.Empty)
            {
                CaracteristiciModel caracteristiciModel = new CaracteristiciModel();
                caracteristiciModel.NumeCaracteristica = model.NumeCaracteristica1;
                caracteristiciModel.ID_Caracteristica = model.ID_Caracteristica;
                caracteristiciModel.ID_TipCaracteristica = model.ID_TipCaracteristica;
                caracteristiciRepository.UpdateCaracteristiciModel(caracteristiciModel);
                return RedirectToAction("DashboardListaCaracteristici");
            }
            else
            {
                CaracteristiciModel caracteristiciModel = new CaracteristiciModel();
                caracteristiciModel.NumeCaracteristica = model.NumeCaracteristica1;
                caracteristiciModel.ID_TipCaracteristica = model.ID_TipCaracteristica;
                caracteristiciRepository.InsertCaracteristiciModel(caracteristiciModel);
                return RedirectToAction("DashboardListaCaracteristici");
            }
        }

        public ActionResult DashboardListaCaracteristici()
        {
            //incarcam lista de caract
            List<Models.CaracteristiciModel> caracteristici = caracteristiciRepository.GetAllCaracteristici();

            foreach (var model in caracteristici)
            {
                TipCaracteristicaModel marca = tipCaracteristicaRepository.GetTipCaracteristicaByID(model.ID_TipCaracteristica);
                model.NumeTipCaracteristica = marca.NumeTipCaracteristica;
            }

            return View("DashboardListaCaracteristici", caracteristici);
        }


        // GET: Admin/Edit/5
        public ActionResult EditCaracteristica(Guid id)
        {
            CaracteristiciModel Model = caracteristiciRepository.GetCaracteristiciModelByID(id);

            AdminCaracteristiciViewModel model = new AdminCaracteristiciViewModel();
            model.TipCaracteristici1 = tipCaracteristicaRepository.GetAllTipCaracteristica();
            model.ID_Caracteristica = id;
            model.NumeCaracteristica1 = Model.NumeCaracteristica;
            model.ID_TipCaracteristica = Model.ID_TipCaracteristica;

            return View("DashboardListaCaracteristici", model);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteCaracteristici(Guid id)
        {
            caracteristiciRepository.DeleteCaracteristiciModel(id);
            return RedirectToAction("DashboardListaCaracteristici");
        }

    }
}
