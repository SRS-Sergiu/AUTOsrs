using AUTOsrs.Models;
using AUTOsrs.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AUTOsrs.ViewModels
{
    public class AdminMarcaViewModel
    {
        public Guid ID_Marca { get; set; }
        public string Marca { get; set; }
    }

    public class AdminModelViewModel
    {
        public Guid ID_Model { get; set; }
        public Guid ID_Marca { get; set; }
        public string Model1 { get; set; }
        public List<MarcaAutoModel> Marci {get; set;}
    }
}