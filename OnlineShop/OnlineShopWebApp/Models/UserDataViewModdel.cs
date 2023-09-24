using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDataViewModdel
    {

        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string FirstName { get; set; }

        [StringLength(99, MinimumLength = 2, ErrorMessage = "Минимум 2 символа")]
        public string LastName { get; set; }

        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Некоректный номер телефона\nПример: +7999-999-9999")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Введен не корректный e-mail")]
        public string Email { get; set; }

        public string ImgPath { get; set; }
    }
}
