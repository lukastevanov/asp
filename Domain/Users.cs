using System;
using System.Collections.Generic;

namespace EfDataAccess
{
    public partial class Users
    {
        public readonly bool isDeleted;
        public readonly bool IsDeleted;

        public int Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
