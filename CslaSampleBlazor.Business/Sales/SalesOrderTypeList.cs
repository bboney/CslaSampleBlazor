using Csla;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Sales;
using System;
using System.Linq;

namespace CslaSampleBlazor.Business.Sales
{
    [Serializable()]
    public class SalesOrderTypeList : ReadOnlyListBase<SalesOrderTypeList, SalesOrderTypeInfo>
    {

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeList), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView", "ManagementOpenOrdersView", "SalespersonOpenOrdersView"));
        }

        #endregion

        public void RemoveChild(int key)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.SalesOrderTypeKey == key).FirstOrDefault();
                if (item != null)
                {
                    var index = this.IndexOf(item);
                    Remove(item);
                }
            }
            finally
            {
                IsReadOnly = iro;
            }
        }

        #region Factory Methods

        public async static System.Threading.Tasks.Task<SalesOrderTypeList> GetSalesOrderTypeListAsync()
        {
            return await DataPortal.FetchAsync<SalesOrderTypeList>();
        }

        public static SalesOrderTypeList GetSalesOrderTypeList()
        {
            return DataPortal.Fetch<SalesOrderTypeList>();
        }

        #endregion

        #region Data Access

        [Fetch]
        private void DataPortal_Fetch([Inject] ISalesOrderTypeDal dal)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            var data = dal.FetchList();
            foreach (var dto in data)
            {
                var item = DataPortal.FetchChild<SalesOrderTypeInfo>(dto);
                Add(item);
            }
            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

    }
}