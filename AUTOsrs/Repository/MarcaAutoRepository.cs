using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using AUTOsrs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Repository
{
    public class MarcaAutoRepository
    {
        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;
        public MarcaAutoRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }
        public MarcaAutoRepository(Models.DbObjects.AUTOsrsModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public MarcaAutoModel GetMarcaAutoByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.MarcaAutos.FirstOrDefault(x => x.ID_Marca == ID));
        }

        private MarcaAutoModel MapDbObjectToModel(Models.DbObjects.MarcaAuto dbMarcaAuto)
        {
            MarcaAutoModel marcaAuto = new MarcaAutoModel();
            if(marcaAuto != null)
            {
                marcaAuto.ID_Marca = dbMarcaAuto.ID_Marca;
                marcaAuto.Marca = dbMarcaAuto.Marca;

                return marcaAuto;
            }
            return null;
        }

        private MarcaAuto MapModelsToDbObject(MarcaAutoModel marcaAuto)
        {
            Models.DbObjects.MarcaAuto dbMarcaAutoModel = new Models.DbObjects.MarcaAuto();
            if(dbMarcaAutoModel != null)
            {
                dbMarcaAutoModel.Marca = marcaAuto.Marca;
                dbMarcaAutoModel.ID_Marca = marcaAuto.ID_Marca;
            }
            return dbMarcaAutoModel;
        }


        public List<MarcaAutoModel> GetAllMarca()
        {
            List<MarcaAutoModel> marcaList = new List<MarcaAutoModel>();
            foreach (Models.DbObjects.MarcaAuto dbMarca in dbContext.MarcaAutos)
            {
                marcaList.Add(MapDbObjectToModel(dbMarca));
            }
            return marcaList;
        }

        //insert MarcaAuto
        public void InsertMarcaAuto(MarcaAutoModel marcaAutoModel)
        {
            //generate new guid id
            marcaAutoModel.ID_Marca = Guid.NewGuid();

            //add to orm layer
            dbContext.MarcaAutos.InsertOnSubmit(MapModelsToDbObject(marcaAutoModel));
            dbContext.SubmitChanges();
        }

        //update MarcaAuto
        public void UpdateMarcaAuto(MarcaAutoModel marcaAutoModel)
        {
            //add to orm layer
            MarcaAuto marcaexistenta = dbContext.MarcaAutos.FirstOrDefault(x => x.ID_Marca == marcaAutoModel.ID_Marca);
            marcaexistenta.Marca = marcaAutoModel.Marca;

            dbContext.SubmitChanges();
        }

        //delete MarcaAuto
        public void DeleteMarcaAuto(Guid id)
        {
            dbContext.MarcaAutos.DeleteOnSubmit(dbContext.MarcaAutos.FirstOrDefault(x => x.ID_Marca == id));
            dbContext.SubmitChanges();
        }

        public List<MarcaAutoModel> GetAll(Guid marcaAutoID)
        {
            List<MarcaAutoModel> anuntList = new List<MarcaAutoModel>();
            foreach (MarcaAuto dbMarca in dbContext.MarcaAutos)
            {
                anuntList.Add(MapDbObjectToModel(dbMarca));
            }
            return anuntList;
        }
    }
}