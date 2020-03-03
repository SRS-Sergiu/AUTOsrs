using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Models
{
    public class CaracteristiciModel
    {

        public Guid ID_TipCaracteristica { get; set; }
        public Guid ID_Caracteristica { get; set; }
        public string NumeTipCaracteristica { get; set; }
        public string NumeCaracteristica { get; set; }
    }
}