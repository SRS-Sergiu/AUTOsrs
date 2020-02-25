using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Repository
{
    public class ModelAutoRepository
    {
        //injectare orm
        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;
        //initializam repo
        public ModelAutoRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }
        public ModelAutoRepository(Models.DbObjects.AUTOsrsModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*
         ----------------------
         CRUD operation
         ----------------------
         */

        //get all the resources
        //public List<ModelAuto> GettAllModelAuto()
        //{
        //    List<ModelAuto> modelAutoList = new List<ModelAuto>();
        //    foreach(Models.DbObjects.ModelAuto dbModelAuto in dbContext.ModelAutos)
        //    {
        //        modelAutoList.Add(MapDbObjectToModel(dbModelAuto));
        //    }
        //}

        //get all the ModelAuto by id
        public ModelAutoModel GetModelAutoByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.ModelAutos.FirstOrDefault(x => x.ID_Model == ID));
        }
        //insert ModelAuto
        public void InsertModelAuto(ModelAutoModel modelAutoModel)
        {
            //generate new guid id
            modelAutoModel.ID_Model = Guid.NewGuid();

            //add to orm layer
            dbContext.ModelAutos.InsertOnSubmit(MapModelsToDbObject(modelAutoModel));
            dbContext.SubmitChanges();
        }
        //update
        public void UpdateModelAuto(ModelAutoModel modelAutoModel)
        {
            //get existing record to update
            Models.DbObjects.ModelAuto existingModel = dbContext.ModelAutos.FirstOrDefault(x => x.ID_Model == modelAutoModel.ID_Model);
            if(existingModel != null)
            {
                //map updated values with keeping the orm reference
                existingModel.ID_Model = modelAutoModel.ID_Model;
                existingModel.Model = modelAutoModel.Model;
                dbContext.SubmitChanges();
            }
        }
        //delete
        public void DeleteModelAuto(Guid ID)
        {
            //get exising record to delete
            Models.DbObjects.ModelAuto recordToDelete = dbContext.ModelAutos.FirstOrDefault(x => x.ID_Model == ID);
            if(recordToDelete != null)
            {
                dbContext.ModelAutos.DeleteOnSubmit(recordToDelete);
                dbContext.SubmitChanges();
            }
        }
        // map orm to model - mapper method
        private ModelAutoModel MapDbObjectToModel(Models.DbObjects.ModelAuto dbModelAuto)
        {
            ModelAutoModel modelAuto = new ModelAutoModel();

            if (dbModelAuto != null)
            {
                modelAuto.ID_Model = dbModelAuto.ID_Model;
                modelAuto.Model = dbModelAuto.Model;

                return modelAuto;
            }
            return null;
        }

        // map Model to ORM
        private Models.DbObjects.ModelAuto MapModelsToDbObject(ModelAutoModel modelAuto)
        {
            Models.DbObjects.ModelAuto dbModelAutoModel = new Models.DbObjects.ModelAuto();
            if(dbModelAutoModel != null)
            {
                dbModelAutoModel.ID_Model = modelAuto.ID_Model;
                dbModelAutoModel.Model = modelAuto.Model;

                return dbModelAutoModel;
            }
            return null;
        }


        //viewModel
        public AdminViewModel GetAdmin(Guid modelAutoID)
        {
            AdminViewModel adminViewModel = new AdminViewModel();

            ModelAuto modelAuto = dbContext.ModelAutos.FirstOrDefault(x => x.ID_Model == modelAutoID);

            if(modelAuto != null)
            {
                adminViewModel.Model = modelAuto.Model;
            }

            return null;
        }
    }
}