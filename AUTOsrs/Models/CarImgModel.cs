using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Models
{
    public class CarImgModel
    {
        public Guid ID_CarImg { get; set; }
        public Guid ID_Anunt { get; set; }

        public byte[] ContentFile { get; set; }
        public string TitleFile { get; set; }
        public string ExtensionFile { get; set; }
    }
    
}