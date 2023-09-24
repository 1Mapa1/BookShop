using System.ComponentModel.DataAnnotations;

namespace OnlineShop.db.Models
{
    public enum OrderStatuses
    {
        [Display(Name = "Создан")]
        Created = 1,

        [Display(Name = "Обработан")]
        Processed = 2,

        [Display(Name = "В пути")]
        Delivering = 3,

        [Display(Name = "Отменен")]
        Canceled = 4,

        [Display(Name = "Доставлен")]
        Delivered = 5
    }
}
