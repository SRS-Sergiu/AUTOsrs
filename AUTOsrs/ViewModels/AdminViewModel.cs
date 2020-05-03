using AUTOsrs.Models;
using System;
using System.Collections.Generic;

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