using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace TapChi.Modules.TapChi_GetUsersOnline
{
    public class OnlineUsersController
    {
        
        public static StatisticsInfo GetStatistics(int portalID, bool IncludeHost)
        {
            StatisticsInfo statistics = new StatisticsInfo() ;
            IDataReader reader = null;

            try
            {
                reader = _GetStatistics(portalID, IncludeHost);
                if (reader.Read())
                {
                    statistics.AnonymousUserCount = reader.GetInt32(0);
                }
                reader.NextResult();

                if (reader.Read())
                {
                    statistics.OnlineUserCount = reader.GetInt32(0);
                }
                reader.NextResult();

                if (reader.Read())
                {
                    statistics.OnlineUserInfo.UserId = reader.GetInt32(0);
                    statistics.OnlineUserInfo.UserName = reader.GetString(1);
                    statistics.OnlineUserInfo.DisplayName = reader.GetString(2);
                    statistics.OnlineUserInfo.FirstName = reader.GetString(3);
                    statistics.OnlineUserInfo.LastName = reader.GetString(4);
                    statistics.OnlineUserInfo.FullName = reader.GetString(5);
                    statistics.OnlineUserInfo.TabID = DotNetNuke.Common.Utilities.Null.NullInteger;
                    statistics.OnlineUserInfo.TabName = DotNetNuke.Common.Utilities.Null.NullString;
                    statistics.OnlineUserInfo.TabIsSecure = DotNetNuke.Common.Utilities.Null.NullBoolean;
                }
                reader.NextResult();

                if (reader.Read())
                {
                    statistics.MembershipCount = reader.GetInt32(0);
                }
                reader.NextResult();


                if (reader.Read())
                {
                    statistics.MembershipTodayCount = reader.GetInt32(0);
                }
                reader.NextResult();

                if (reader.Read()) {
                    statistics.MembershipYesterdayCount = reader.GetInt32(0);
                }

                reader.Close();
                reader.Dispose();
                reader = null;

                statistics.OnlineTotalCount = statistics.AnonymousUserCount + statistics.OnlineUserCount;

                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
            }
            return statistics;
        }
        private static IDataReader _GetStatistics(int PortalId, bool IncludeHosts)
        {
            string constr = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            string sql = "dbo.DNNUOL_GetOnlineUserStatistics";
            return SqlHelper.ExecuteReader(constr, sql, PortalId, IncludeHosts);
        }
    }
}