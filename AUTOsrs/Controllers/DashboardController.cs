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
            List<AnuntModel> admin_anunt1 = anuntRepository.GetAllAnunt();
            DashboardViewModel admin_anunt = new DashboardViewModel();
            admin_anunt.admin_anuntVM = admin_anunt1;
            admin_anunt.admin_Caracteristica = caracteristiciRepository.GetAllCaracteristici();
            admin_anunt.admin_tipCaracteristica = tipCaracteristicaRepository.GetAllTipCaracteristica();
            admin_anunt.admin_Model = modelAutoRepository.GetAllModel();
            admin_anunt.admin_Marca = marcaAutoRepository.GetAllMarca();

            foreach (var item in admin_anunt1)
            {
                admin_anunt.Marca = item.Marca;
            }
            
            return View("Index", admin_anunt);
        }
        public ActionResult PartialAnuntView()
        {

            List<AnuntModel> admin_anunt1 = new List<AnuntModel>();
            DashboardViewModel admin_anunt = new DashboardViewModel();
            admin_anunt.admin_anuntVM = admin_anunt1;
            //foreach (var anunt in admin_anunt.admin_anuntVM)
            //{
            //    MarcaAutoModel marcaAutoModel = marcaAutoRepository.GetMarcaAutoByID(anunt.ID_Marca);
            //    ModelAutoModel modelAutoModel = modelAutoRepository.GetModelAutoByID(anunt.ID_Model);
            //    CaracteristiciModel caracteristiciModel = caracteristiciRepository.GetCaracteristiciModelByID(anunt.ID_Caracteristica);
            //    TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristicaRepository.GetTipCaracteristicaByID(anunt.ID_TipCaracteristica);
            //    anunt.Marca = marcaAutoModel.Marca;
            //    anunt.Model = modelAutoModel.Model;
            //    anunt.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;
            //    anunt.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
            //}



            return PartialView("PartialAnuntView");
        }
    }
}