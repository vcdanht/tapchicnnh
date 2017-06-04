using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TapChi.Modules.TapChi_GetUsersOnline
{
    public class StatisticsInfo
    {
        
        public int AnonymousUserCount { get; set; }
        public int OnlineTotalCount { get; set; }
        public int OnlineUserCount { get; set; }
        public OnlineUserInfor OnlineUserInfo { get; set; }
        public int MembershipCount { get; set; }

        public int MembershipTodayCount { get; set; }

        public int MembershipYesterdayCount { get; set; }

    }
    public class OnlineUserInfor
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int TabID { get; set; }
        public string TabName { get; set; }
        public bool TabIsSecure { get; set; }
    }
}