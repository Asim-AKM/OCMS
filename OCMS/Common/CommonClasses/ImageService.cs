using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OCMS.Common.CommonClasses
{
    public static class ImageService
    {

        public static string SaveAndReturnPath(HttpPostedFileBase StdImageFile)
        {
            // Step 1: Check if StdImageFile is null FIRST
            if (StdImageFile == null)
            {
                return null; // If the file object itself is null, return null
            }

            // Step 2: Now check its properties (like ContentLength)
            // If ContentLength is 0, it means no file was uploaded or it's an empty file.
            if (StdImageFile.ContentLength == 0)
            {
                return null; // If file is empty, return null
            }

            // Unique File Name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(StdImageFile.FileName);

            // Upload Folder Path
            string UploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

            // If Folder Not Exist Then Make IT
            if (!Directory.Exists(UploadPath))
            {
                Directory.CreateDirectory(UploadPath);
            }

            string FullPath = Path.Combine(UploadPath, fileName);

            // SaveImage
            StdImageFile.SaveAs(FullPath);

            // Return Relative Path to store in DataBase
            return "/Uploads/" + fileName; // Added a slash here for correct path
        }

        public static bool DeleteImageFile(string imageUrl)
        {

            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }
            string fullPath = HttpContext.Current.Server.MapPath(imageUrl);
            if (File.Exists(imageUrl))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
            //File.Delete(imageUrl);
        }

    }

}