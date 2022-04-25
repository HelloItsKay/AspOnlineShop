namespace ASP.NET_Core_OnlineShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IHashingService
    {
        public string Encrypt(string clearText);
        public string Decrypt(string cipherText);
    }
}
