using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS.WebAPI.ViewModels
{
    public class UsersREST
    {
        public int? UserId { get; set; }
        public string? UserLoginName { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? Oib { get; set; }
    }
}
