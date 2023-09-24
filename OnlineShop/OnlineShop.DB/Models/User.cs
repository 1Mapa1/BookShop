using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.db.Models
{
    public class User : IdentityUser
    {
        [MaybeNull]
        public string FirstName { get; set; }

        [MaybeNull]
        public string LastName { get; set; }

        [MaybeNull]
        public string ImgPath { get; set; }
    }
}
