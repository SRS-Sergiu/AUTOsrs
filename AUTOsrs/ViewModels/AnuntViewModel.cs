using AUTOsrs.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.ComponentModel;

namespace AUTOsrs.ViewModels
{
    public class AnuntGeneralViewModel
    {
        public Guid ID_Anunt { get; set; }
       
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string Descriere { get; set; }
        public string DescriereScurta { get; set; }

        // legaturi
        public Guid ID_Model { get; set; }
        public List<ModelAutoModel> ModelAnunt { get; set; }
        public Guid ID_Marca { get; set; }
        public List<MarcaAutoModel> MarcaAnunt { get; set; }

        public Guid ID_TipCaracteristica { get; set; }
        public List<TipCaracteristicaModel> TipCaracteristicaAnunt { get; set; }

        public Guid ID_Caracteristica { get; set; }
        public List<CaracteristiciModel> CaracteristicaAnunt { get; set; }





        // img
        //public List<IFormFile> Photos { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }


    }


}