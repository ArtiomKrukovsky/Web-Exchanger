using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace WebStore.Auth.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // creator   
        public string Audience { get; set; } // for whom
        public string Secret { get; set; } // secret string for encoding process
        public double TokenLifetime { get; set; } //seconds

        /// <summary>
        /// Method for generating an encryption key from a secret
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }

    }
}
