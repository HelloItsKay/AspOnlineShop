using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Services
{
    public interface IHashingService
    {
        public string Encrypt(string clearText);
        public string Decrypt(string cipherText);
    }
}
