using AUTOsrs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    public class CarImgController : Controller
    {

        private Repository.CarImgRepository carImgRepository = new Repository.CarImgRepository();
        private Repository.AnuntRepository anuntRepository = new Repository.AnuntRepository();


        // GET: CarImg
        public ActionResult CarImgList()
        {
            List<CarImgModel> carImgModels = carImgRepository.GetAllCarImg();

         

            return View("CarImgList", carImgModels);
        }

        // GET: CarImg/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarImg/Create
        public ActionResult InsertImg()
        {
            CarImgModel carImgModel = new CarImgModel();

            return View(carImgModel);
        }

        // POST: CarImg/Create
        [HttpPost]
        public ActionResult InsertImg(CarImgModel model)
        {
            CarImgModel carImgModel = new CarImgModel();
            //carImgModel.SomeFile = model.SomeFile; 
            carImgModel.TitleFile = model.TitleFile;
            carImgModel.ExtensionFile = model.ExtensionFile;
            carImgModel.ContentFile = model.ContentFile;
            carImgModel.ID_Anunt = model.ID_Anunt;
            carImgModel.ID_CarImg = model.ID_CarImg;

            carImgRepository.InsertCarImg(carImgModel);

            return RedirectToAction("CarImgList");
        }

        // GET: CarImg/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarImg/Edit/5
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

        // GET: CarImg/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarImg/Delete/5
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
