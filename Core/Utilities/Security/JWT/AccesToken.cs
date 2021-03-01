using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccesToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
