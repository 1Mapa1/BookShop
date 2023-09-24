using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserInfoViewModel
    {
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Некоректный номер телефона\nПример: (+7999-999-9999)")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Не указан E-mail")]
        [EmailAddress(ErrorMessage = "Введен не корректный e-mail")]
        public string Email { get; set; }
    }
}
