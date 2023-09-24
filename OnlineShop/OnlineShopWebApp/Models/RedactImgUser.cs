using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Models
{
    public class RedactImgUser
    {
        public string Login { get; set; }
        public string ImgPath { get; set; }
        public IFormFile UploadedFile { get; set; }

        public RedactImgUser()
        {
        }
        public RedactImgUser(string login, string imgPath)
        {
            Login = login;
            ImgPath = imgPath;
        }
    }
}
