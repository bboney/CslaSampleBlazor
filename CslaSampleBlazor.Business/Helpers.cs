using System;
using System.Linq;
using System.Security.Claims;

namespace CslaSampleBlazor.Business
{
    public static class Helpers
    {
        public static int GetCurrentUserKey()
        {
            if (Csla.ApplicationContext.User != null)
            {
                if (Csla.ApplicationContext.User is ClaimsPrincipal)
                {
                    ClaimsPrincipal user = (ClaimsPrincipal)Csla.ApplicationContext.User;
                    var userKey = user.Claims.Where(c => c.Type == "UserKey").Select(c => c.Value).SingleOrDefault();
                    if (userKey != null)
                        return Convert.ToInt32(userKey);
                }
            }
            return 0;
        }

        public static TimeZoneInfo GetCurrentUserTimeZoneInfo()
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time");
            }
            catch (System.Exception)
            {
                return TimeZoneInfo.Local;
            }
            
        }
    }
    
}
