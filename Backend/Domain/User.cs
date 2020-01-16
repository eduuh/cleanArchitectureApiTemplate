using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain
{

    public class User : IdentityUser
    {
        public string Token { get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public string Image { get; set; }
        public string Password { get; set; }
    }

}
