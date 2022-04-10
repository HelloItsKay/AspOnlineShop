namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using static DataConstants;

    public class User : IdentityUser
    {
        [MaxLength(NameMaxLength)]
        public string FullName { get; set; }
    }
}