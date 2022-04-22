using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static ASP.NET_Core_OnlineShop.Data.DataConstants;

namespace ASP.NET_Core_OnlineShop.Models.Orders
{
    public class OrdersFormViewModel
    {
     
        public string OrderId { get; set; } = Guid.NewGuid().ToString();
        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = FirstNameErrorMessage)]
        [Display(Name = DisplayFirstName)]
        [StringLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = LastNameErrorMessage)]
        [Display(Name = DisplayLasttName)]
        [StringLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = AddressErrorMessage)]
        [StringLength(AddressMaxLength)]
        [Display(Name = DisplayAddressOne)]
        public string AddressLine1 { get; set; }

        [Display(Name = DisplayAddressTwo)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = ZipCodeErrorMassage)]
        [Display(Name = ZipCodeDisplayName)]
        [StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength)]
        public string ZipCode { get; set; }
        [MinLength(StateMinLength)]
        [StringLength(StateMaxLength)]
        public string State { get; set; }

        [Required(ErrorMessage = CountryErrorMassage)]
        [MinLength(CountryMinLength)]
        [StringLength(CountryMaxLength)]
        public string Country { get; set; }

        [Required(ErrorMessage = PhoneErrorMassage)]
        [MinLength(PhoneNumberMinLength)]
        [StringLength(PhoneNumberMaxLength)]
        [Display(Name = DisplayPhoneName)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        
        
        [Column(TypeName = PriceType)]
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
