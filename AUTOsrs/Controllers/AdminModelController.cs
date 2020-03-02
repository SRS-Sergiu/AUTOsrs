using AUTOsrs.Models;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class AdminModelController : Controller
    {
      
        private Repository.ModelAutoRepository modelAutoRepository = new Repository.ModelAutoRepository();
        private Repository.MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();

        // GET: Admin
        public ActionResult DashboardCreareModel()
        {
            AdminModelViewModel AdminModelViewModel = new AdminModelViewModel();
            AdminModelViewModel.Marci = marcaAutoRepository.GetAllMarca();

            return View(AdminModelViewModel);
        }

        //Post: Admin/SaveModel/5
        public ActionResult SaveModel(AdminModelViewModel model)
        {
            if (model.ID_Model != Guid.Empty)
            {
                //ModelAutoRepository ModelAutoRepository = new ModelAutoRepository();
                ModelAutoModel ModelAutoModel = new ModelAutoModel();
                ModelAutoModel.Model = model.Model1;
                ModelAutoModel.ID_Model = model.ID_Model;
                ModelAutoModel.ID_Marca = model.ID_Marca;
                modelAutoRepository.UpdateModelAuto(ModelAutoModel);
                return RedirectToAction("DashboardListaModele");
            }
            else
            {
                //ModelAutoRepository ModelAutoRepository = new ModelAutoRepository();
                ModelAutoModel ModelAutoModel = new ModelAutoModel();
                ModelAutoModel.Model = model.Model1;
                ModelAutoModel.ID_Marca = model.ID_Marca;
                modelAutoRepository.InsertModelAuto(ModelAutoModel);
                return RedirectToAction("DashboardListaModele");
            }
        }

        public ActionResult DashboardListaModele()
        {
            //incarcam lista de anunturi
            List<Models.ModelAutoModel> modele = modelAutoRepository.GetAllModel();

            foreach (var model in modele)
            {
                MarcaAutoModel marca = marcaAutoRepository.GetMarcaAutoByID(model.ID_Marca);
                model.Marca = marca.Marca;
            }

            return View("DashboardListaModele", modele);
        }


        // GET: Admin/Edit/5
        public ActionResult EditModel(Guid id)
        {
            ModelAutoModel Model = modelAutoRepository.GetModelAutoByID(id);

            AdminModelViewModel model = new AdminModelViewModel();
            model.Marci = marcaAutoRepository.GetAllMarca();
            model.ID_Model = id;
            model.Model1 = Model.Model;
            model.ID_Marca = Model.ID_Marca;

            return View("DashboardCreareModel", model);
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteModel(Guid id)
        {
            modelAutoRepository.DeleteModelAuto(id);
            return RedirectToAction("DashboardListaModele");
        }

    }
}
