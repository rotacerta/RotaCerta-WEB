using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace pfcWeb.Models
{
    public class User
    {
        [Key] public string Email;
        public string Password;

        public bool setEmail(string email)
        {
            if(email!= null)
            {
                if (verifyFormatEmail(email))
                {
                    this.Email = email;
                    return true;
                }
            }
            return false;
        }

        public string getEmail()
        {
            return this.Email;
        }

        public bool setPassword(string password)
        {
            if (password != null) {
                int sizePassword = password.Length;
                Console.WriteLine(sizePassword);
                if (sizePassword > 0 && sizePassword <= 250)
                {
                    this.Password = password;
                    return true;
                }
            }
            return false;
        }

        public string getPassword()
        {
            return this.Password;
        }


        private static bool verifyFormatEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
    }
}