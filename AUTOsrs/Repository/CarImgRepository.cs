using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AUTOsrs.Repository
{
    public class CarImgRepository
    {

        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;
        
        public CarImgRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }
        public CarImgRepository(Models.DbObjects.AUTOsrsModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //insert carimg
        public void InsertCarImg(CarImgModel carImgModel)
        {
            carImgModel.ID_CarImg = Guid.NewGuid();
            dbContext.CarImgs.InsertOnSubmit(MapModelsToDbObject(carImgModel));
            dbContext.SubmitChanges();
        }

        public CarImgModel GetCarImgById(Guid id)
        {
            return MapDbObjectToModel(dbContext.CarImgs.FirstOrDefault(x=>x.ID_CarImg == id));
        }
        public CarImgModel GetCarImgByAnuntId(Guid anuntid)
        {
            return MapDbObjectToModel(dbContext.CarImgs.FirstOrDefault(x => x.ID_Anunt == anuntid));
        }
        public List<CarImgModel> GetAllCarImg()
        {
            List<CarImgModel> carImgList = new List<CarImgModel>();

            foreach(CarImg dbCarImg in dbContext.CarImgs)
            {
                carImgList.Add(MapDbObjectToModel(dbCarImg));
            }
            return carImgList;
        }

        public List<CarImgModel> GetAllCarImgByAnunt(Guid ID)
        {
            List<CarImgModel> carImgList = new List<CarImgModel>();

            foreach (CarImg dbCarImg in dbContext.CarImgs.Where(p=>p.ID_Anunt == ID))
            {
                carImgList.Add(MapDbObjectToModel(dbCarImg));
            }
            return carImgList;
        }








        // map orm to model - mapper method
        private CarImgModel MapDbObjectToModel(CarImg dbCarImg)
        {
            CarImgModel carImgModel = new CarImgModel();

            if (dbCarImg != null)
            {
                //carImgModel.SomeFile = dbCarImg.SomeFile;
                carImgModel.ID_CarImg = dbCarImg.ID_CarImg;
                carImgModel.ID_Anunt = dbCarImg.ID_Anunt;
                carImgModel.ContentFile = dbCarImg.ContentFile.ToArray();
                carImgModel.ExtensionFile = dbCarImg.ExtensionFile;
                carImgModel.TitleFile = dbCarImg.TitleFile;
                return carImgModel;
            }
            return null;
        }

        // map Model to ORM
        private CarImg MapModelsToDbObject(CarImgModel carImgModel)
        {
            CarImg dbCarImgModel = new CarImg();

            if (carImgModel != null)
            {
                
                dbCarImgModel.ID_CarImg = carImgModel.ID_CarImg;
                dbCarImgModel.ID_Anunt = carImgModel.ID_Anunt;
                dbCarImgModel.ContentFile = carImgModel.ContentFile;
                dbCarImgModel.ExtensionFile = carImgModel.ExtensionFile;
                dbCarImgModel.TitleFile = carImgModel.TitleFile;
                return dbCarImgModel;
            }
            return null;
        }


    }
}