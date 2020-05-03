using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace AUTOsrs.Models
{
    public class AnuntModel
    {
        public Guid ID_Anunt { get; set; }
        public Guid? ID_User { get; set; }
        public Guid ID_Model { get; set; }
        public Guid ID_Caracteristica { get; set; }
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string Descriere { get; set; }
        public string DescriereScurta { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid ID_Marca { get; set; }
        public string Model { get; set; }
        public string Marca { get; set; }
        public Guid ID_TipCaracteristica { get; set; }
        public string NumeTipCaracteristica { get; set; }
        public string NumeCaracteristica { get; set; }




        


        //[DisplayName("Upload File")]
        public string ImagePath { get; set; }

    }


    
}