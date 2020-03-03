using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.ViewModels
{
    public class AdminTipCaracteristiciViewModel
    {
        public Guid ID_TipCaracteristica { get; set; }
        public string NumeTipCaracteristica { get; set; }
    }
    public class AdminCaracteristiciViewModel
    {
        public Guid ID_Caracteristica { get; set; }
        public Guid ID_TipCaracteristica { get; set; }
        public string NumeCaracteristica1 { get; set; }

        public List<TipCaracteristicaModel> TipCaracteristici1 { get; set; }
    }

    
}