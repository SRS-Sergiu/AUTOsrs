using AUTOsrs.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.ComponentModel;

namespace AUTOsrs.ViewModels
{
    public class DetailsAnuntViewModel
    {
        public Guid ID_Anunt { get; set; }
       
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string Descriere { get; set; }
        public string DescriereScurta { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
      

        public string Model { get; set; }
        public string Marca { get; set; }
       

        public string NumeTipCaracteristica { get; set; }
        public string NumeCaracteristica { get; set; }


       

        // img
        public List<CarImgModel> Photos { get; set; }



    }


}