using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace csp_manager.UploadImage
{
    class Imgur
    {
        //private string Client_ID = "e3ceb3492ab989f";
        //private string Client_secret = "7bd00c04f8a051c9f1e4754017367f4a201181de";

        private string access_token = "3c373ccca908274966051fcfa0ad8fe0ba9c3feb";
        //private string refresh_token = "9e8f569d3e7bbcab053c60a71fbab33cca6c6aef";

        private string album_hash = "l4ZMoAR";

        public string Token { get => access_token; }
        public string Upload(string image)
        {
            WebClient w = new WebClient();
            w.Headers.Add("Authorization", "Bearer " + access_token);
            //w.Headers.Add("Authorization", "Client-ID " + Client_ID);
            NameValueCollection Keys = new NameValueCollection();
            try
            {
                if (image.Contains("file:///")) image = new Uri(image).LocalPath;
                // Mã hoá ảnh thành chuỗi base64
                Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image)));
                // Chuỗi base64 mẫu / ảnh gif nền đen
                //Keys.Add("image", "R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7");
                // Kiểm tra có album để up không
                if (album_hash.Length > 0) Keys.Add("album", album_hash);
                byte[] responseArray = w.UploadValues("https://api.imgur.com/3/image", Keys);
                dynamic result = Encoding.ASCII.GetString(responseArray);

                Regex reg = new Regex("link\":\"(.*?)\"");
                Match match = reg.Match(result);
                string url = match.ToString().Replace("link\":\"", "").Replace("\"", "").Replace("\\/", "/");
                return url;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public bool Delete(string image)
        {
            if (image.Contains("file:///")) image = new Uri(image).LocalPath;
            if (!image.Contains("imgur.com")) return false;
            image = image.Replace("https://i.imgur.com/", "").Split('.')[0];
            WebClient w = new WebClient();
            w.Headers.Add("Authorization", "Bearer " + access_token);
            try
            {
                byte[] responseArray = w.UploadValues("https://api.imgur.com/3/image/" + image, "DELETE", new NameValueCollection());
                dynamic result = Encoding.ASCII.GetString(responseArray);

                Regex reg = new Regex("success\":(true|false),");
                Match match = reg.Match(result);
                string url = match.ToString().Replace("success\":", "").Replace(",", "");
                return url == "true" ? true : false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
