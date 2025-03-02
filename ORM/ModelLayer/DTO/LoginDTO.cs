using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    public class LoginDTO
    {
        public string username { get; set; }

        public string password { get; set; }
        public string ToString()
        {
            return username+":"+password;
        }
        //private static readonly Regex usernameRegex = new Regex(@"^\w{5}$");

        //public string Username
        //{
        //    get { return username; }
        //    set
        //    {
        //        if (!usernameRegex.IsMatch(value))
        //        {
        //            throw new ArgumentException("Username must be  5 characters long.");
        //        }
        //        username = value;
        //    }
        //}
    }
}
