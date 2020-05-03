using AUTOsrs.Models;
using AUTOsrs.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using FormCollection = Microsoft.AspNetCore.Http.FormCollection;

namespace AUTOsrs.Controllers
{
    [System.Runtime.InteropServices.Guid("84131BF5-C248-4834-BF78-CFB8215CBF7F")]

    public class AnuntController : Controller
    {

        private Repository.AnuntRepository anuntRepository = new Repository.AnuntRepository();
        private Repository.CarImgRepository imgRepository = new Repository.CarImgRepository();
        private Repository.CaracteristiciRepository caracteristiciRepository = new Repository.CaracteristiciRepository();
        private Repository.TipCaracteristicaRepository tipCaracteristicaRepository = new Repository.TipCaracteristicaRepository();
        private Repository.ModelAutoRepository modelAutoRepository = new Repository.ModelAutoRepository();
        private Repository.MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();

        //initializam repositori
        //intreaba proful


        // afisare anunt
        // GET: Anunt
        public ActionResult IndexAnunt()
        {
           List<AnuntModel> anunturi = anuntRepository.GetAllAnunt();
            foreach (var anunt in anunturi)
            {
                MarcaAutoModel marcaAutoModel = marcaAutoRepository.GetMarcaAutoByID(anunt.ID_Marca);
                ModelAutoModel modelAutoModel = modelAutoRepository.GetModelAutoByID(anunt.ID_Model);
                CaracteristiciModel caracteristiciModel = caracteristiciRepository.GetCaracteristiciModelByID(anunt.ID_Caracteristica);
                TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristicaRepository.GetTipCaracteristicaByID(anunt.ID_TipCaracteristica);
                anunt.Marca = marcaAutoModel.Marca;
                anunt.Model = modelAutoModel.Model;
                anunt.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;
                anunt.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
            }

            return View("IndexAnunt", anunturi);
        }
    



        public ActionResult DetailsAnunt(string ID)
        {
            DetailsAnuntViewModel anunt = anuntRepository.GetAnuntByIDImg(new Guid(ID));
            return View("DetailsAnunt", anunt);
        }




        //afisarea paginii unde se creaza anuntul
        [HttpGet]
        public ActionResult CreateAnunt()
        {
            AnuntGeneralViewModel anuntGeneralViewModel = new AnuntGeneralViewModel();
            anuntGeneralViewModel.ModelAnunt = modelAutoRepository.GetAllModel();
            anuntGeneralViewModel.MarcaAnunt = marcaAutoRepository.GetAllMarca();
            anuntGeneralViewModel.CaracteristicaAnunt = caracteristiciRepository.GetAllCaracteristici();
            anuntGeneralViewModel.TipCaracteristicaAnunt = tipCaracteristicaRepository.GetAllTipCaracteristica();

            return View(anuntGeneralViewModel);
        }

        //public AnuntController(IHostingEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}
        //private readonly IHostingEnvironment _hostingEnvironment;

       

        [HttpPost]
        public ActionResult CreateAnunt(AnuntGeneralViewModel model)
        {
            if (model.ID_Anunt != Guid.Empty)
            {
                AnuntModel anuntModel = new AnuntModel();
                anuntModel.ID_Anunt = model.ID_Anunt;
                anuntModel.ID_Caracteristica = model.ID_Caracteristica;
                anuntModel.ID_Model = model.ID_Model;
                anuntModel.ID_Marca = model.ID_Marca;
                anuntModel.ID_TipCaracteristica = model.ID_TipCaracteristica;
                anuntModel.KM = model.KM;
                anuntModel.Pret = model.Pret;
                anuntModel.Descriere = model.Descriere;
                anuntModel.AnFabricatie = model.AnFabricatie;

                anuntRepository.UpdateAnunt(anuntModel);
                return RedirectToAction("IndexAnunt");
            }
            else
            {

                if (model != null)
                {
                    AnuntModel anuntModel = new AnuntModel();
                    anuntModel.ImagePath = model.ImagePath;
                    anuntModel.ID_Caracteristica = model.ID_Caracteristica;
                    anuntModel.ID_Model = model.ID_Model;
                    anuntModel.ID_Marca = model.ID_Marca;
                    anuntModel.ID_TipCaracteristica = model.ID_TipCaracteristica;
                    anuntModel.KM = model.KM;
                    anuntModel.Pret = model.Pret;
                    anuntModel.Descriere = model.Descriere;
                    anuntModel.DescriereScurta = model.DescriereScurta;
                    anuntModel.AnFabricatie = model.AnFabricatie;
                    anuntRepository.InsertAnunt(anuntModel);


                    //foreach
                    CarImgModel carImgModel = new CarImgModel();

                    if (model.ImageFile != null)
                    {

                        //Use Namespace called :  System.IO  
                        carImgModel.TitleFile = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

                        //To Get File Extension  
                        carImgModel.ExtensionFile = Path.GetExtension(model.ImageFile.FileName);

                        //To copy and save file into server.  
                        using (var memoryStream = new MemoryStream())
                        {
                            model.ImageFile.InputStream.CopyTo(memoryStream);
                            carImgModel.ContentFile = memoryStream.ToArray();
                        }
                    }

                    carImgModel.ID_Anunt = anuntModel.ID_Anunt;

                    imgRepository.InsertCarImg(carImgModel);
                }                

                return RedirectToAction("IndexAnunt");
            }
        }
     




        // GET: Anunt/Edit/5
        public ActionResult EditAnunt(Guid ID)
        {
            AnuntModel anuntModel = anuntRepository.GetAnuntByID(ID);

            anuntModel.ID_Anunt = ID;

            return View("ListaAnunturi", anuntModel);
        }



        // GET: Anunt/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Anunt/Delete/5
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
