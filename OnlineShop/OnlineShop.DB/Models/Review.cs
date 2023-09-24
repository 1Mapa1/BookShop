using OnlineShop.db.Models;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShopWebApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Login { get; set; }
        public string Header { get; set; }
        [MaybeNull]
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}