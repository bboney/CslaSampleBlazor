
using System;
using System.Collections.Generic;

namespace CslaSampleBlazor.Dal.Sales
{
    public interface ISalesOrderStatusDal
    {
        List<SalesOrderStatusDto> FetchList();
        SalesOrderStatusDto Fetch(int salesOrderStatusKey);
        DalReturn Insert(int createdByUserKey,
             string name,
             string salesOrderStatusId,
             Int16 salesOrderStatusValue);
        DalReturn Update(int salesOrderStatusKey,
             byte[] lastChanged,
             int modifiedByUserKey,
             string name,
             string salesOrderStatusId,
             Int16 salesOrderStatusValue);
        void Delete(int salesOrderStatusKey);
        bool Exists(string salesOrderStatusId);
        int GetKey(string salesOrderStatusId);
    }
}