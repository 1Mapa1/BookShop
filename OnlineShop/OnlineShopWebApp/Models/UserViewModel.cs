using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
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

        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string FirstName { get; set; }

        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string LastName { get; set; }

        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Некоректный номер телефона\nПример: +7999-999-9999")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Введен не корректный e-mail")]
        public string Email { get; set; }

        public string Role { get; set; }

        public UserViewModel()
        { }
    }
}