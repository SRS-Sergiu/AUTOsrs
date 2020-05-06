using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AUTOsrs.Repository
{
    public class AnuntRepository
    {
        //injectam container-ul ORM
        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;



        //initializam repository-ul
        public AnuntRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }  
       


        //injectam un dbContext pt a   face repository testabil
         public AnuntRepository(Models.DbObjects.AUTOsrsModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // get all the Anunt by id
        public AnuntModel GetAnuntByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Anunts.FirstOrDefault(x => x.ID_Anunt == ID));
        }



        // get all the Anunt by id IMG --- Ddetails ViewModel
        public DetailsAnuntViewModel GetAnuntByIDImg(Guid ID)
        {
            return MapDbObjectToModelIMG(dbContext.Anunts.FirstOrDefault(x => x.ID_Anunt == ID));
        }



        // get all the Anunt by id IMG --- Dashboard ViewModel
        public DashboardViewModel GetAnuntByIdDashboard(Guid ID)
        {
            return MapDbObjectToModelDashboard(dbContext.Anunts.FirstOrDefault(x => x.ID_Anunt == ID));
        }
        public List<DashboardViewModel> GetAllAnuntDashboard()
        {
            List<DashboardViewModel> anuntList = new List<DashboardViewModel>();

            foreach (Anunt dbAnunt in dbContext.Anunts)
            {
                anuntList.Add(MapDbObjectToModelDashboard(dbAnunt));
            }

            return anuntList;
        }


        // gett all the resources
        public List<AnuntModel> GetAllAnunt()
        {
            List<AnuntModel> anuntList = new List<AnuntModel>();

            foreach (Models.DbObjects.Anunt dbAnunt in dbContext.Anunts)
            {
                anuntList.Add(MapDbObjectToModel(dbAnunt));
            }
            
            return anuntList;
        }



        //insert (nu renutrneaza nimic folosim void)
        public void InsertAnunt(AnuntModel anuntModel)
        {
            //generare id guid 
            anuntModel.ID_Anunt = Guid.NewGuid();

            // add to orm layer
            dbContext.Anunts.InsertOnSubmit(MapModelToDbObject(anuntModel));

            //commit to db
            dbContext.SubmitChanges();
        }



        //update (nu renutrneaza nimic folosim void)
        public void  UpdateAnunt(AnuntModel anuntModel)
        {
            Models.DbObjects.Anunt existingAnunt = dbContext.Anunts.FirstOrDefault(x => x.ID_Anunt == anuntModel.ID_Anunt);

            if(existingAnunt != null)
            {
                //map update values si pastram referintele orm

                existingAnunt.ID_Anunt = anuntModel.ID_Anunt;
                //existingAnunt.ID_User = anuntModel.ID_User;
                existingAnunt.ID_Model = anuntModel.ID_Model;
                existingAnunt.ID_Caracteristica = anuntModel.ID_Caracteristica;
                existingAnunt.KM = anuntModel.KM;
                existingAnunt.AnFabricatie = anuntModel.AnFabricatie;
                existingAnunt.Descriere = anuntModel.Descriere;
                existingAnunt.DescriereScurta = anuntModel.DescriereScurta;
                existingAnunt.Pret = anuntModel.Pret;
               

                dbContext.SubmitChanges();
            }
        }



        //delete
        public void DeleteAnunt(Guid ID)
        {
            Models.DbObjects.Anunt anuntToDelete = dbContext.Anunts.FirstOrDefault(x => x.ID_Anunt == ID);
            if(anuntToDelete != null)
            {
                dbContext.Anunts.DeleteOnSubmit(anuntToDelete);
                dbContext.SubmitChanges();
            }

        }



        // map ORM to Model - mapper method
        private AnuntModel MapDbObjectToModel(Anunt dbAnunt)
        {
            AnuntModel anuntModel = new AnuntModel();

            if (dbAnunt != null)
            {
                anuntModel.ID_Anunt = dbAnunt.ID_Anunt;
                anuntModel.ID_User = dbAnunt.ID_User;
                anuntModel.ID_Model = dbAnunt.ID_Model;
                anuntModel.ID_Marca = dbAnunt.ID_Marca;
                anuntModel.ID_TipCaracteristica = dbAnunt.ID_TipCaracteristica;
                anuntModel.ID_Caracteristica = dbAnunt.ID_Caracteristica;
                anuntModel.KM = dbAnunt.KM;
                anuntModel.AnFabricatie = dbAnunt.AnFabricatie;
                anuntModel.Descriere = dbAnunt.Descriere;
                anuntModel.DescriereScurta = dbAnunt.DescriereScurta;
                anuntModel.Pret = dbAnunt.Pret;
               

                return anuntModel;
            }
            return null;
        }



        // map Model to ORM - mapper method
        private Anunt MapModelToDbObject(AnuntModel anuntModel)
        {
           Anunt dbAnuntModel = new Anunt();

            if (anuntModel != null)
            {
                dbAnuntModel.ID_Anunt = anuntModel.ID_Anunt;
                dbAnuntModel.ID_Caracteristica = anuntModel.ID_Caracteristica;
                dbAnuntModel.ID_TipCaracteristica = anuntModel.ID_TipCaracteristica;
                dbAnuntModel.ID_User = anuntModel.ID_User;
                dbAnuntModel.ID_Model = anuntModel.ID_Model;
                dbAnuntModel.ID_Marca = anuntModel.ID_Marca;
                dbAnuntModel.KM = anuntModel.KM;
                dbAnuntModel.Descriere = anuntModel.Descriere;
                dbAnuntModel.DescriereScurta = anuntModel.DescriereScurta;
                dbAnuntModel.Pret = anuntModel.Pret;
                dbAnuntModel.AnFabricatie = anuntModel.AnFabricatie;
                
                return dbAnuntModel;
            }
            return null;
        }



        // ----------



        //  Product Details Page
        private DetailsAnuntViewModel MapDbObjectToModelIMG(Anunt dbAnunt)
        {
            DetailsAnuntViewModel detailsAnunt = new DetailsAnuntViewModel();

            if (dbAnunt != null)
            {
                detailsAnunt.ID_Anunt = dbAnunt.ID_Anunt;

                detailsAnunt.KM = dbAnunt.KM;
                detailsAnunt.AnFabricatie = dbAnunt.AnFabricatie;
                detailsAnunt.Descriere = dbAnunt.Descriere;
                detailsAnunt.DescriereScurta = dbAnunt.DescriereScurta;
                detailsAnunt.Pret = dbAnunt.Pret;

                MarcaAutoRepository marcaAutoRepository = new Repository.MarcaAutoRepository();
                MarcaAutoModel marca = marcaAutoRepository.GetMarcaAutoByID(dbAnunt.ID_Marca);
                if (marca != null)
                {
                    detailsAnunt.Marca = marca.Marca;
                }


                ModelAutoRepository modelAutoRepository = new Repository.ModelAutoRepository();
                ModelAutoModel model = modelAutoRepository.GetModelAutoByID(dbAnunt.ID_Model);
                if (model != null)
                {
                    detailsAnunt.Model = model.Model;
                }


                TipCaracteristicaRepository tipCaracteristica = new TipCaracteristicaRepository();
                TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristica.GetTipCaracteristicaByID(dbAnunt.ID_TipCaracteristica);
                if (tipCaracteristicaModel != null)
                {
                    detailsAnunt.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
                }


                CaracteristiciRepository caracteristicaRepo = new CaracteristiciRepository();
                CaracteristiciModel caracteristicaModel = caracteristicaRepo.GetCaracteristiciModelByID(dbAnunt.ID_Caracteristica);
                if (caracteristicaModel != null)
                {
                    detailsAnunt.NumeTipCaracteristica = caracteristicaModel.NumeTipCaracteristica;
                }


                CarImgRepository carImgRepository = new CarImgRepository();
                List<CarImgModel> listaImg = carImgRepository.GetAllCarImgByAnunt(dbAnunt.ID_Anunt);
                if (listaImg != null)
                {
                    detailsAnunt.Photos = listaImg;
                }



                return detailsAnunt;
            }
            return null;
        }



        // Dashboard Anunt 
        private DashboardViewModel MapDbObjectToModelDashboard(Anunt dbAnunt)
        {
            DashboardViewModel detailsAnunt = new DashboardViewModel();

            if (dbAnunt != null)
            {
                detailsAnunt.ID_Anunt = dbAnunt.ID_Anunt;

                detailsAnunt.KM = dbAnunt.KM;
                detailsAnunt.AnFabricatie = dbAnunt.AnFabricatie;
                detailsAnunt.DescriereScurta = dbAnunt.DescriereScurta;
                detailsAnunt.Pret = dbAnunt.Pret;

                MarcaAutoRepository marcaAutoRepository = new MarcaAutoRepository();
                MarcaAutoModel marca = marcaAutoRepository.GetMarcaAutoByID(dbAnunt.ID_Marca);
                if (marca != null)
                {
                    detailsAnunt.D_Marca = marca.Marca;
                }


                ModelAutoRepository modelAutoRepository = new ModelAutoRepository();
                ModelAutoModel model = modelAutoRepository.GetModelAutoByID(dbAnunt.ID_Model);
                if (model != null)
                {
                    detailsAnunt.D_Model = model.Model;
                }

                CarImgRepository carImgRepository = new CarImgRepository();
                List<CarImgModel> listaImg = carImgRepository.GetAllCarImgByAnunt(dbAnunt.ID_Anunt);
                if (listaImg != null)
                {
                    detailsAnunt.Photos = listaImg;
                }


                //TipCaracteristicaRepository tipCaracteristica = new TipCaracteristicaRepository();
                //TipCaracteristicaModel tipCaracteristicaModel = tipCaracteristica.GetTipCaracteristicaByID(dbAnunt.ID_TipCaracteristica);
                //if (tipCaracteristicaModel != null)
                //{
                //    detailsAnunt.NumeCaracteristica = tipCaracteristicaModel.NumeCaracteristica;
                //}


                //CaracteristiciRepository caracteristicaRepo = new CaracteristiciRepository();
                //CaracteristiciModel caracteristicaModel = caracteristicaRepo.GetCaracteristiciModelByID(dbAnunt.ID_Caracteristica);
                //if (caracteristicaModel != null)
                //{
                //    detailsAnunt.NumeTipCaracteristica = caracteristicaModel.NumeTipCaracteristica;
                //}


                return detailsAnunt;
            }
            return null;
        }
    }
}