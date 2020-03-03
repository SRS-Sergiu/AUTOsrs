using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Repository
{
    public class TipCaracteristicaRepository
    {
        private Models.DbObjects.AUTOsrsModelsDataContext dbContext;

        public TipCaracteristicaRepository()
        {
            this.dbContext = new Models.DbObjects.AUTOsrsModelsDataContext();
        }

        //map orm to model
        private TipCaracteristicaModel MapDBObjectToModel(Models.DbObjects.TipCaracteristica dbTipCaracteristica)
        {
            TipCaracteristicaModel tipCaracteristica = new TipCaracteristicaModel();
            if(tipCaracteristica != null)
            {
                tipCaracteristica.ID_TipCaracteristica = dbTipCaracteristica.ID_TipCaracteristica;
                tipCaracteristica.NumeTipCaracteristica = dbTipCaracteristica.NumeTipCaracteristica;
                return tipCaracteristica;
            }
            return null;
        }

        //map model to orm
        private TipCaracteristica MapModelToDbObject(TipCaracteristicaModel tipCaracteristicaModel)
        {
            Models.DbObjects.TipCaracteristica dbTipCaracteristica = new Models.DbObjects.TipCaracteristica();
            if(dbTipCaracteristica != null)
            {
                dbTipCaracteristica.ID_TipCaracteristica = tipCaracteristicaModel.ID_TipCaracteristica;
                dbTipCaracteristica.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;
            }
            return dbTipCaracteristica;
        }




        //  Read -- aduc tip de caract dupa ID -- TipCaracteristica
        public TipCaracteristicaModel GetTipCaracteristicaByID(Guid ID)
        {
            return MapDBObjectToModel(dbContext.TipCaracteristicas.FirstOrDefault(x => x.ID_TipCaracteristica == ID));
        }


        //  List -- aduc toate tip caracteristici ca o lista -- TipCaracteristica
        public List<TipCaracteristicaModel> GetAllTipCaracteristica()
        {
         List<TipCaracteristicaModel> tipCaractList = new List<TipCaracteristicaModel>();

            foreach (Models.DbObjects.TipCaracteristica dbTipCaract in dbContext.TipCaracteristicas) {
                tipCaractList.Add(MapDBObjectToModel(dbTipCaract));
            }
            return tipCaractList;
         }


        //  Insert -- TipCaracteristica
        public void InsertTipCaracteristica(TipCaracteristicaModel tipCaracteristicaModel)
        {
            tipCaracteristicaModel.ID_TipCaracteristica = Guid.NewGuid();

            dbContext.TipCaracteristicas.InsertOnSubmit(MapModelToDbObject(tipCaracteristicaModel));
            dbContext.SubmitChanges();
        }


        //  Update -- TipCaracteristica
        public void UpdateTipCaracteristica(TipCaracteristicaModel tipCaracteristicaModel)
        {
            TipCaracteristica tipCaracteristicaExistenta = dbContext.TipCaracteristicas.FirstOrDefault(x => x.ID_TipCaracteristica == tipCaracteristicaModel.ID_TipCaracteristica);
            tipCaracteristicaExistenta.NumeTipCaracteristica = tipCaracteristicaModel.NumeTipCaracteristica;

            dbContext.SubmitChanges();
        }


        //  Delete -- TipCaracteristica
        public void DeleteTipCaracteristica(Guid ID)
        {
            dbContext.TipCaracteristicas.DeleteOnSubmit(dbContext.TipCaracteristicas.FirstOrDefault(x => x.ID_TipCaracteristica == ID));
            dbContext.SubmitChanges();
        }
    }
}