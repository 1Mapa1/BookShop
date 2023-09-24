using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RoleViewModel
    {

        [Required(ErrorMessage = "Не указана роль")]
        [StringLength(99, MinimumLength = 2, ErrorMessage = "роль должна быть минимум 2 сивола")]
        public string NameRole { get; set; }
    }
}