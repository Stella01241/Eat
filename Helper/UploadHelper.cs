using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication11.Helper
{
    public class UploadHelper
    {
        private string[] _allowExts = { ".jpg", ".png", ".bmp", ".gif" };
        private string _saveFolder = "~/Uploadpic/";
        public string GetNewFileName(FileUpload fu)
        {
            if (!fu.HasFile)
                return string.Empty;


            var uFile = fu.PostedFile;
            var fileName = uFile.FileName;
            string fileExt = System.IO.Path.GetExtension(fileName);

            if (!_allowExts.Contains(fileExt.ToLower()))
                return string.Empty;

            // 命名空間Server
            string path = HttpContext.Current.Server.MapPath(_saveFolder);
            //取名為Guid
            string newFileName = Guid.NewGuid().ToString() + fileExt;
            string fullPath = System.IO.Path.Combine(path, newFileName);

            uFile.SaveAs(fullPath);
            return newFileName;
        }
    }
}