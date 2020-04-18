
using System.Collections.Generic;
using System.Data;

namespace CslaSampleBlazor.Dal.Security
{
    public interface INavigationDal
    {
        List<NavigationDto> FetchUserList(int navigationType, int userKey);
        List<NavigationDto> FetchList();
        NavigationDto Fetch(int navigationKey);
        DalReturn Insert(int createdByUserKey,
                        bool hasChildren,
                        bool isPrivilegeRequired,
                        string name,
                        string navigationId,
                        int navigationType,
                        int parentNavigationKey,
                        int sequence,
                        string spriteCssClass,
                        string url);
        DalReturn Update(int navigationKey,
                        bool hasChildren,
                        bool isPrivilegeRequired,
                        byte[] lastChanged,
                        int modifiedByUserKey,
                        string name,
                        string navigationId,
                        int navigationType,
                        int parentNavigationKey,
                        int sequence,
                        string spriteCssClass,
                        string url);
        void Delete(int navigationKey);
        bool Exists(string navigationId);
        int GetKey(string navigationId);
    }
}