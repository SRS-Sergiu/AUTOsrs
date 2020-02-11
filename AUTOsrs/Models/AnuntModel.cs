using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Models
{
    public class AnuntModel
    {
        public Guid ID_Anunt { get; set; }
        public Guid? ID_User { get; set; }
        //public int ID_Model { get; set; }
        //public int ID_Caracteristica { get; set; }
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string Descriere { get; set; }
    }


    //comit
}