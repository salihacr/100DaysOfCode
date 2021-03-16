using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogApp.Asp_Net_Web_Forms.Helpers
{
    public class Auth
    {
        public string CreatePasswordHash(string password)
        {
            using (var sha512 = new System.Security.Cryptography.SHA512Managed())
            {
                // 1
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedPassword = sha512.ComputeHash(passwordBytes);

                // or 2 => byte[] hashedPassword = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedPassword).Replace("-", String.Empty);
            }
        }
    }
}