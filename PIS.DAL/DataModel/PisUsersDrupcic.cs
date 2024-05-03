using System;
using System.Collections.Generic;

namespace PIS.DAL.DataModel
{
    public partial class PisUsersDrupcic
    {
        public int UserId { get; set; }
        public string UserLoginName { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public int? UserLevel { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string UserCountry { get; set; }
        public string UserTel { get; set; }
        public string UserFax { get; set; }
        public int? UserApproved { get; set; }
        public int? UserBanned { get; set; }
        public string UserImage { get; set; }
        public string Oib { get; set; }
    }
}
