using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указон логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Логин должно быть минимум 2 символа")]
        public string LoginUser { get; set; }

        [Required(ErrorMessage = "Не указон пароль")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Пароль должен быть минмум 8 исволов")]
        public string Password { get; set; }

        public bool Remember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
