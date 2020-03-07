using AUTOsrs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.ViewModels
{
    public class AnuntGeneralViewModel
    {
        public Guid ID_Anunt { get; set; }
        public int ID_Model { get; set; }
        public int ID_Caracteristica { get; set; }
        public int KM { get; set; }
        public int Pret { get; set; }
        public int AnFabricatie { get; set; }
        public string Descriere { get; set; }
    }

    public class UserAnuntViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class ModelAutoAnuntViewModel
    {
        public Guid ID_Model { get; set; }
        public Guid ID_Marca { get; set; }
        public string Model1 { get; set; }
        public List<MarcaAutoModel> Marci { get; set; }
    }
    public class MarcaAutoAnuntViewModel
    {
        public Guid ID_Marca { get; set; }
        public string Marca { get; set; }
    }
    public class TipCaracteristiciAnuntViewModel
    {
        public Guid ID_TipCaracteristica { get; set; }
        public string NumeTipCaracteristica { get; set; }
    }
    public class CaracteristiciAnuntViewModel
    {
        public Guid ID_Caracteristica { get; set; }
        public Guid ID_TipCaracteristica { get; set; }
        public string NumeCaracteristica1 { get; set; }

        public List<TipCaracteristicaModel> TipCaracteristici1 { get; set; }
    }


}