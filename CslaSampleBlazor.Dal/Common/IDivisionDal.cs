
using System.Collections.Generic;
using System.Data;

namespace CslaSampleBlazor.Dal.Common
{
    public interface IDivisionDal
    {
        List<DivisionDto> FetchList();
        DivisionDto Fetch(int divisionKey);
        DalReturn Insert(int createdByUserKey,
                        string divisionId,
                        int divisionValue,
                        string name);
        DalReturn Update(int divisionKey,
                        string divisionId,
                        int divisionValue,
                        byte[] lastChanged,
                        int modifiedByUserKey,
                        string name);
        void Delete(int divisionKey);
        bool Exists(string divisionId);
        int GetKey(string divisionId);
    }
}