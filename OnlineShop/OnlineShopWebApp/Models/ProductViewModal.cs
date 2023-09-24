using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModal
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя продукта")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан автор")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Не указан жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Не указана цена продукта")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание продукта")]
        public string Description { get; set; }

        public string ImgPath { get; set; }

        public IFormFile UploadedFile { get; set; }

        public List<ReviewViewModel> Reviews = new List<ReviewViewModel>();

        public double Rating()
        {
            if (Reviews.Count() == 0) return 0;
            return Reviews.Average(r => r.Rating);
        }

        public ProductViewModal()
        { }

    }
}