using System;
using System.Collections.Generic;

namespace CslaSampleBlazor.Dal.Sales
{
    public interface ISalesOrderTypeDal
    {
        List<SalesOrderTypeDto> FetchList();
        SalesOrderTypeDto Fetch(int salesOrderTypeKey);
        DalReturn Insert(int createdByUserKey,
                        string name,
                        string salesOrderTypeId,
                        Int16 salesOrderTypeValue);
        DalReturn Update(int salesOrderTypeKey,
                        byte[] lastChanged,
                        int modifiedByUserKey,
                        string name,
                        string salesOrderTypeId,
                        Int16 salesOrderTypeValue);
        void Delete(int salesOrderTypeKey);
        bool Exists(string salesOrderTypeId);
        int GetKey(string salesOrderTypeId);
    }
}