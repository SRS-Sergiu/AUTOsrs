using AUTOsrs.Models;
using System;

using System.Web.Mvc;

namespace PL.Controllers
{
    
    public class FileController : Controller
    {        
        readonly string notFoundImage = "~/Content/img/srs-logo.png";
        public ActionResult AnuntFile(string ID)
        {
            try
            {
                if (ID != "")
                {
                    AUTOsrs.Repository.CarImgRepository imgRepository = new AUTOsrs.Repository.CarImgRepository();

                    CarImgModel carImgModel = imgRepository.GetCarImgByAnuntId(new Guid(ID));                    
                    if (carImgModel != null)
                    {
                        byte[] contentFile = carImgModel.ContentFile;
                     
                        return File(contentFile, GetContentType(carImgModel.ExtensionFile));

                    }
                }
            }
            catch { }

            //not Found Image                  
            return File(notFoundImage, GetContentType(".jpg"));
        }

        public ActionResult AnuntMultipleFile(string ID)
        {
            try
            {
                if (ID != "")
                {
                    AUTOsrs.Repository.CarImgRepository imgRepository = new AUTOsrs.Repository.CarImgRepository();

                    CarImgModel carImgModel = imgRepository.GetCarImgById(new Guid(ID));
                    if (carImgModel != null)
                    {
                        byte[] contentFile = carImgModel.ContentFile;

                        return File(contentFile, GetContentType(carImgModel.ExtensionFile));

                    }
                }
            }
            catch { }

            //not Found Image                  
            return File(notFoundImage, GetContentType(".jpg"));
        }


        public ActionResult NotFound(string catchall)
        {
            //not Found Image
            return File(notFoundImage, GetContentType(".png"));
        }

        public static string GetContentType(string extension)
        {
            switch (extension)
            {
                case ".bmp": return "image/bmp";
                case ".gif": return "image/gif";
                case ".jpg": return "image/jpeg";
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".pdf": return "application/pdf";
                case ".doc": return "application/msword";
                case ".docx": return "application/msword";
                case ".xlsx": return "application/ms-excel";
                default: return "";
            }
        }
    }
}
