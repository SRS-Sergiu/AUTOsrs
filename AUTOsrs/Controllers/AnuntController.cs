using AUTOsrs.Repository;
using AUTOsrs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.Controllers
{
    [System.Runtime.InteropServices.Guid("84131BF5-C248-4834-BF78-CFB8215CBF7F")]
    public class AnuntController : Controller
    {
        //initializam repositori
        //intreaba proful
        private Repository.AnuntRepository anuntRepository = new Repository.AnuntRepository();

        // GET: Anunt
        public ActionResult Index()
        {
            //incarcam lista de anunturi
            List<Models.AnuntModel> anunturi = anuntRepository.GetAllAnunt();

            return View("Index", anunturi);
        }

        // GET: Anunt/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Anunt/Create
        public ActionResult Create()
        {
            return View("CreateAnunt");
        }

        // POST: Anunt/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //instantiem Modelul
                Models.AnuntModel anuntModel = new Models.AnuntModel();

                //incarcam datele in model
                UpdateModel(anuntModel);

                //apelam resursa care salveaz datele(insert)
                anuntRepository.InsertAnunt(anuntModel);

                //redirectam spre index in caz de succes
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //redirectare catre view-ul curent in caz de erori
                return View("CreateAnunt");
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
