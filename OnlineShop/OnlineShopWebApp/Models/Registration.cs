using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Не указон логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Логин должно быть минимум 2 символа")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указон пароль")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Пароль должен быть минмум 8 исволов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указон пароль")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Пароль должен быть минмум 8 исволов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадабт")]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}
