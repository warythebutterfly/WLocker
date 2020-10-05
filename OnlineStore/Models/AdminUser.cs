using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public partial class AdminUser
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
