namespace ASP.NET_Core_OnlineShop.Data
{
    public class DataConstants
    {
        public const string PriceType = "money";

        public const string CategoryName = "Category";
        //--------------Drink Constants
        public const int DrinkNameMaxLenght = 30;
        public const int DrinkNameMinLength = 3;
        public const string DrinkNameErrorMassage = "  The name of the drink is required and  must be between 3 and 30 characters long";

        public const int ShortDescriptionMinLength = 20;
        public const int ShortDescriptionMaxLength = 50;
        public const string ShortDescriptionErrorMassage = "The short description is required and must be between 20 and 50 characters long";

        public const int LongDescriptionMinLength = 20;
        public const int LongDescriptionMaxLength = 500;

        public const string LongDescriptionErrorMassage = "The long description is required must be between 20 and 500 characters long";
       

        public const double PriceMinValue = 0.5;
        public const double PriceMaxValue = 1000;
 public const string PriceError = "The price is required must be between 0.05 and 1000.";
        
        //-------------Order Constants
        public const int NameMaxLength = 50;
        public const string FirstNameErrorMessage = "Please enter your first name";
        public const string DisplayFirstName = "First name";

        public const string LastNameErrorMessage = "Please enter your last name";
        public const string DisplayLasttName = "Last name";

        public const int AddressMaxLength = 100;
        public const string AddressErrorMessage = "Please enter your address";
        public const string DisplayAddressOne = "Address Line 1";
        public const string DisplayAddressTwo = "Address Line 2";

        public const string ZipCodeErrorMassage = "Please enter your zip code";
        public const string ZipCodeDisplayName = "Zip code";
        public const int ZipCodeMinLength = 4;
        public const int ZipCodeMaxLength = 10;

        public const int StateMaxLength = 10;
        public const int StateMinLength = 4;

        public const string CountryErrorMassage = "Please enter your country";
        public const string DisplayPhoneName = "Phone number";
        public const int CountryMaxLength = 50;
        public const int CountryMinLength = 4;

        public const string PhoneErrorMassage = "Please enter your phone number";
        public const int PhoneNumberMaxLength = 50;
        public const int PhoneNumberMinLength = 7;

        public const int EmailMaxLength = 50;
        public const string EmailErrorMassage = "The email address is not entered in a correct format";

        public const string EmailRegexPattern =
            @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";



    }
}
