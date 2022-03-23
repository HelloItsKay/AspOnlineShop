namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    

    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string FullName { get; set; }
    }
}