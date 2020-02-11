using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                existingAnunt.ID_User = anuntModel.ID_User;
                ///existingAnunt.ID_Model = anuntModel.ID_Model;
                ////////////////////////existingAnunt.ID_Caracteristica = anuntModel.ID_Caracteristica;
                existingAnunt.KM = anuntModel.KM;
                existingAnunt.AnFabricatie = anuntModel.AnFabricatie;
                existingAnunt.Descriere = anuntModel.Descriere;
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
        private AnuntModel MapDbObjectToModel(Models.DbObjects.Anunt dbAnunt)
        {
            AnuntModel anuntModel = new AnuntModel();

            if (dbAnunt != null)
            {
                anuntModel.ID_Anunt = dbAnunt.ID_Anunt;
                anuntModel.ID_User = dbAnunt.ID_User;
                //anuntModel.ID_Model = dbAnunt.ID_Model;
                //anuntModel.ID_Caracteristica = dbAnunt.ID_Caracteristica;
                anuntModel.KM = dbAnunt.KM;
                anuntModel.AnFabricatie = dbAnunt.AnFabricatie;
                anuntModel.Descriere = dbAnunt.Descriere;
                anuntModel.Pret = dbAnunt.Pret;

                return anuntModel;
            }
            return null;
        }

        // map Model to ORM - mapper method
        private Models.DbObjects.Anunt MapModelToDbObject(AnuntModel anuntModel)
        {
            Models.DbObjects.Anunt dbAnuntModel = new Models.DbObjects.Anunt();

            if (anuntModel != null)
            {
                dbAnuntModel.ID_Anunt = anuntModel.ID_Anunt;
                //dbAnuntModel.ID_Caracteristica = anuntModel.ID_Caracteristica;
                //dbAnuntModel.ID_User = anuntModel.ID_User;
                //dbAnuntModel.ID_Model = anuntModel.ID_Model;
                dbAnuntModel.KM = anuntModel.KM;
                dbAnuntModel.Descriere = anuntModel.Descriere;
                dbAnuntModel.Pret = anuntModel.Pret;
                dbAnuntModel.AnFabricatie = anuntModel.AnFabricatie;

                return dbAnuntModel;
            }
            return null;
        }
    }
}