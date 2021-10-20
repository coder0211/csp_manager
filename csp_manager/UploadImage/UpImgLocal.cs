using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager.UploadImage
{
    class UpImgLocal
    {
        public string Upload(string srcImg, string name = "")
        {
            if (srcImg.Contains("Res/"))
            {
                return "";
            }
            else
            {
                Func f = new Func();
                // Chuyển Uri Path thành Local Path
                if (srcImg.Contains("file:///")) srcImg = new Uri(srcImg).LocalPath;
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\Upload");
                // Tự đặt tên ngẫu nhiên nếu không có tên truyền vào
                if (string.IsNullOrEmpty(name)) name = f.RandomString(7);
                string fName = name + System.IO.Path.GetExtension(srcImg);
                string destFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"Upload\", fName);
                File.Copy(srcImg, destFile, true);
                return fName;
            }
        }
    }
}
