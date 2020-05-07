using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Repository
{
    public class CaracteristiciRepository
    {
        //injectare orm
        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;
        //initializam repo
        public CaracteristiciRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }
        public CaracteristiciRepository(Models.DbObjects.AUTOsrsModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }




        /*
         ----------------------
         CRUD operation
         ----------------------
         */

        //get all the resources
        public List<CaracteristiciModel> GetAllCaracteristici()
        {
            List<CaracteristiciModel> caracteristiciModelList = new List<CaracteristiciModel>();
            foreach (Caracteristici dbCaract in dbContext.Caracteristicis)
            {
                caracteristiciModelList.Add(MapDbObjectToModel(dbCaract));
            }
            return caracteristiciModelList;
        }

        // Dashboard get list of caract
        //public DashboardViewModel GettAllCaractForAdminById(Guid ID)
        //{
        //    return MapDbObjectToModel(dbContext.Caracteristicis.FirstOrDefault(x => x.ID_Caracteristica == ID));
        //}




        //get all the CaracteristiciModel by id
        public CaracteristiciModel GetCaracteristiciModelByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Caracteristicis.FirstOrDefault(x => x.ID_Caracteristica == ID));
        }
        //insert CaracteristiciModel
        public void InsertCaracteristiciModel(CaracteristiciModel caracteristiciModel)
        {
            //generate new guid id
            caracteristiciModel.ID_Caracteristica = Guid.NewGuid();

            //add to orm layer
            dbContext.Caracteristicis.InsertOnSubmit(MapModelsToDbObject(caracteristiciModel));
            dbContext.SubmitChanges();
        }
        //update
        public void UpdateCaracteristiciModel(CaracteristiciModel caracteristiciModel)
        {
            //get existing record to update
            Models.DbObjects.Caracteristici existingModel = dbContext.Caracteristicis.FirstOrDefault(x => x.ID_Caracteristica == caracteristiciModel.ID_Caracteristica);
            if (existingModel != null)
            {
                //map updated values with keeping the orm reference
                existingModel.ID_Caracteristica = caracteristiciModel.ID_Caracteristica;
                existingModel.ID_TipCaracteristica = caracteristiciModel.ID_TipCaracteristica;
                existingModel.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;
                dbContext.SubmitChanges();
            }
        }
        //delete
        public void DeleteCaracteristiciModel(Guid ID)
        {
            //get exising record to delete
            Models.DbObjects.Caracteristici recordToDelete = dbContext.Caracteristicis.FirstOrDefault(x => x.ID_Caracteristica == ID);
            if (recordToDelete != null)
            {
                dbContext.Caracteristicis.DeleteOnSubmit(recordToDelete);
                dbContext.SubmitChanges();
            }
        }
        // map orm to model - mapper method
        private CaracteristiciModel MapDbObjectToModel(Models.DbObjects.Caracteristici dbCaracteristici)
        {
            CaracteristiciModel caracteristiciModel = new CaracteristiciModel();

            if (dbCaracteristici != null)
            {
                caracteristiciModel.ID_Caracteristica = dbCaracteristici.ID_Caracteristica;
                caracteristiciModel.ID_TipCaracteristica = dbCaracteristici.ID_TipCaracteristica;
                caracteristiciModel.NumeCaracteristica = dbCaracteristici.NumeCaracteristica;

                return caracteristiciModel;
            }
            return null;
        }

        // map Model to ORM
        private Models.DbObjects.Caracteristici MapModelsToDbObject(CaracteristiciModel caracteristiciModel)
        {
            Models.DbObjects.Caracteristici dbCaracteristiciModel = new Models.DbObjects.Caracteristici();
            if (dbCaracteristiciModel != null)
            {
                dbCaracteristiciModel.ID_Caracteristica = caracteristiciModel.ID_Caracteristica;
                dbCaracteristiciModel.ID_TipCaracteristica = caracteristiciModel.ID_TipCaracteristica;
                dbCaracteristiciModel.NumeCaracteristica = caracteristiciModel.NumeCaracteristica;

                return dbCaracteristiciModel;
            }
            return null;
        }


      // dashboard caract view

    }
}