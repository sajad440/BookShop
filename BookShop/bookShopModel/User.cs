using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bookShopModel
{
    public class User : IdentityUser
    {
        public long PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
