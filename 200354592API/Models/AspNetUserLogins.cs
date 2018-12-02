using System;
using System.Collections.Generic;

namespace _200354592API.Models
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
