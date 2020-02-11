using AUTOsrs.Models;
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

        private Models.DbObjects.MarcaAuto MapModelsToDbObject(MarcaAutoModel marcaAuto)
        {
            Models.DbObjects.MarcaAuto dbMarcaAutoModel = new Models.DbObjects.MarcaAuto();
            if(dbMarcaAutoModel != null)
            {
                dbMarcaAutoModel.Marca = marcaAuto.Marca;
                dbMarcaAutoModel.ID_Marca = marcaAuto.ID_Marca;
            }
            return null;
        }
    }
}