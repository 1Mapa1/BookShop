using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "Вы не указали имя")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Вы не заполненли заголовок")]
        [StringLength(15)]
        public string Header { get; set; }
        //комментарий можно не оставлять
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}