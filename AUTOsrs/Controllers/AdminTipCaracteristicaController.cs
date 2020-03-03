using AUTOsrs.Models;
using AUTOsrs.Repository;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class AdminTipCaracteristicaController : Controller
    {

        private Repository.TipCaracteristicaRepository tipCaracteristicaRepository = new Repository.TipCaracteristicaRepository();



        // GET: Admin
        public ActionResult DashboardCreareTipCaracteristica()
        {
            return View();
        }


        //Post: Admin/TipCaracteristica/5
        public ActionResult SaveTipCaracteristica(AdminTipCaracteristiciViewModel model)
        {
            if (model.ID_TipCaracteristica != Guid.Empty)
            {
                TipCaracteristicaModel tipCaracteristicaModel = new TipCaracteristicaModel();
                tipCaracteristicaModel.NumeTipCaracteristica = model.NumeTipCaracteristica;
                tipCaracteristicaModel.ID_TipCaracteristica = model.ID_TipCaracteristica;
                tipCaracteristicaRepository.UpdateTipCaracteristica(tipCaracteristicaModel);
                return RedirectToAction("DashboardListaTipCaracteristica");
            }
            else
            {
                TipCaracteristicaModel tipCaracteristicaModel = new TipCaracteristicaModel();
                tipCaracteristicaModel.NumeTipCaracteristica = model.NumeTipCaracteristica;
                tipCaracteristicaRepository.InsertTipCaracteristica(tipCaracteristicaModel);
                return RedirectToAction("DashboardListaTipCaracteristica");
            }
        }


        public ActionResult DashboardListaTipCaracteristici()
        {
            List<Models.TipCaracteristicaModel> tipCaract = tipCaracteristicaRepository.GetAllTipCaracteristica();

            return View("DashboardListaTipCaracteristica", tipCaract);
        }


        // GET: Admin/Edit/5
        public ActionResult EditTipCaracteristica(Guid ID)
        {
            TipCaracteristicaModel tipCaract = tipCaracteristicaRepository.GetTipCaracteristicaByID(ID);

            AdminTipCaracteristiciViewModel tipCaractModel = new AdminTipCaracteristiciViewModel();
            tipCaractModel.ID_TipCaracteristica = ID;
            tipCaractModel.NumeTipCaracteristica = tipCaract.NumeTipCaracteristica;

            return View("DashboardListaTipCaracteristica", tipCaractModel);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteTipCaract(Guid id)
        {
            tipCaracteristicaRepository.DeleteTipCaracteristica(id);
            return RedirectToAction("DashboardListaTipCaracteristica");
        }

    }
}

