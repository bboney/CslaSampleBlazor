using System;

namespace CslaSampleBlazor.Dal
{
    public static class DalHelpers
    {

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
