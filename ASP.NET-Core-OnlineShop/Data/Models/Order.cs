namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using static  DataConstants;
    public class Order
    {
        [BindNever]
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

        [StringLength(StateMaxLength)]
        public string State { get; set; }

        [Required(ErrorMessage = CountryErrorMassage)]
        [StringLength(CountryMaxLength)]
        public string Country { get; set; }

        [Required(ErrorMessage = PhoneErrorMassage)]
        [StringLength(PhoneNumberMaxLength)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = DisplayPhoneName)]
        public string PhoneNumber { get; set; }

        
        [StringLength(EmailMaxLength)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(EmailRegexPattern, ErrorMessage = EmailErrorMassage)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Column(TypeName = PriceType)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }


    }
}

