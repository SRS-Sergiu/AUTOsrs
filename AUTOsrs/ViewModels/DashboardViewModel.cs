using AUTOsrs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AUTOsrs.ViewModels
{
    public class DashboardViewModel
    {


        public Guid ID_Anunt { get; set; }
       
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string DescriereScurta { get; set; }
        //public string Email { get; set; }
        //public string Name { get; set; }
        
       

        public Guid ID_Model { get; set; }
        public string D_Model{ get; set; }
        public Guid ID_Marca { get; set; }
        public string D_Marca { get; set; }



        public Guid ID_TipCaracteristica { get; set; }
        public string NumeTipCaracteristica { get; set; }
        public Guid ID_Caracteristica { get; set; }
        public string NumeCaracteristica { get; set; }
        public List<CarImgModel> Photos { get; set; }


        public List<CaracteristiciModel> admin_Caracteristica { get; set; }
        public List<TipCaracteristicaModel> admin_tipCaracteristica { get; set; }
        public List<ModelAutoModel> admin_Model { get; set; }
        public List<MarcaAutoModel> admin_Marca { get; set; }
   
        

    }
 
}