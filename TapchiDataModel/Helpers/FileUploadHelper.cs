using DotNetNuke.Web.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Tapchi.Modules.TapchiDataModel.Helpers
{
    public static class FileUploadHelper
    {
        const string BASE_FILE_UPLOAD_FOLDER = "~\\uploads";

        public static string UploadFile(HttpPostedFileBase file, string type)
        {
            string relativePath = "";
            if (file != null && file.ContentLength > 0)
            {
                var originalDirectory = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(BASE_FILE_UPLOAD_FOLDER));
                
                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), type);
                string relativeDirectory = System.IO.Path.Combine(BASE_FILE_UPLOAD_FOLDER, type); 

                

                bool isExists = System.IO.Directory.Exists(pathString);

                if (!isExists)
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }
                string fileName = file.FileName;
                string realPath = string.Format("{0}\\{1}", pathString, fileName);

                int index = 0;
                while (File.Exists(realPath))
                {
                    index++;
                    
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + index.ToString() + Path.GetExtension(fileName);

                    realPath = string.Format("{0}\\{1}", pathString, fileName);
                }
                
                relativePath = string.Format("{0}\\{1}", relativeDirectory, fileName);

                file.SaveAs(realPath);
                
            }

            return relativePath;
        }

        public static string GetContentUrl(string imagePath)
        {
            if (imagePath.Trim()!="")
            {
                UrlHelper helper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                return helper.Content(imagePath.Trim());
            }

            return "";
        }
    }
}