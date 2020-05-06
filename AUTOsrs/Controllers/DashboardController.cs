using AUTOsrs.Models;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class DashboardController : Controller
    {


        private Repository.AnuntRepository anuntRepository = new Repository.AnuntRepository();
        private Repository.CarImgRepository imgRepository = new Repository.CarImgRepository();
        private Repository.CaracteristiciRepository caracteristiciRepository = new Repository.CaracteristiciRepository();
        private Repository.TipCaracteristicaRepository tipCaracteristicaRepository = new Repository.TipCaracteristicaRepository();
        private Repository.ModelAutoRepository modelAutoRepository = new Repository.ModelAutoRepository();
        private Repository.MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();




        // GET: Dashboard
      
        public ActionResult Index()
        {
           
            List<DashboardViewModel> admin_anunt = anuntRepository.GetAllAnuntDashboard();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            //dashboardViewModel.admin_Caracteristica = caracteristiciRepository.GetAllCaracteristici();
            //dashboardViewModel.admin_tipCaracteristica = tipCaracteristicaRepository.GetAllTipCaracteristica();
            //dashboardViewModel.admin_Model = modelAutoRepository.GetAllModel();
            //dashboardViewModel.admin_Marca = marcaAutoRepository.GetAllMarca();

           
            
            return View("Index", admin_anunt);
        }
        public ActionResult PartialAnuntView()
        {

            List<DashboardViewModel> dashboardViewModels = anuntRepository.GetAllAnuntDashboard();
            foreach (var anunt in dashboardViewModels)
            {
                MarcaAutoModel marcaAutoModel = marcaAutoRepository.GetMarcaAutoByID(anunt.ID_Marca);
                ModelAutoModel modelAutoModel = modelAutoRepository.GetModelAutoByID(anunt.ID_Model);
                //CaracteristiciModel caracteristiciModel = caracteristiciRepository.GetCaracteristiciModelByID(anunt.ID_Caracteristica);
                //TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristicaRepository.GetTipCaracteristicaByID(anunt.ID_TipCaracteristica);
                anunt.D_Marca = marcaAutoModel.Marca;
                anunt.D_Model = modelAutoModel.Model;
                //anunt.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;
                //anunt.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
            }


            return PartialView("PartialAnuntView", dashboardViewModels);
        }

        public ActionResult PartialAnuntView5()
        {


          
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            List<DashboardViewModel> dashboardViewModels = anuntRepository.GetAllAnuntDashboard();
            foreach (var anunt in dashboardViewModels)
            {
                MarcaAutoModel marcaAutoModel = marcaAutoRepository.GetMarcaAutoByID(anunt.ID_Marca);
                ModelAutoModel modelAutoModel = modelAutoRepository.GetModelAutoByID(anunt.ID_Model);
                //CaracteristiciModel caracteristiciModel = caracteristiciRepository.GetCaracteristiciModelByID(anunt.ID_Caracteristica);
                //TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristicaRepository.GetTipCaracteristicaByID(anunt.ID_TipCaracteristica);
                dashboardViewModel.D_Marca = marcaAutoModel.Marca;
                dashboardViewModel.D_Model = modelAutoModel.Model;
                //dashboardViewModel.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;
                //dashboardViewModel.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
            }
            

            return PartialView("PartialAnuntView5", dashboardViewModels);
        }
    }
}