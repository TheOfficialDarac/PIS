using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIS.WebAPI.ViewModels
{
    public class UsersREST
    {
        public int? UserId { get; set; }
        [Required, MaxLength(128)]
        public string UserLoginName { get; set; }
        [MaxLength(128)]
        public string? UserName { get; set; }
        [MaxLength(128)]
        public string? UserSurname { get; set; }
        [Required, MaxLength(11)]
        public string Oib { get; set; }
    }
}
