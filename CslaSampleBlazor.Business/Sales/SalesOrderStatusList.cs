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
    public class SalesOrderStatusList : ReadOnlyListBase<SalesOrderStatusList, SalesOrderStatusInfo>
    {

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusList), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView", "ManagementOpenOrdersView", "SalespersonOpenOrdersView"));
        }

        #endregion

        public void RemoveChild(int key)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.SalesOrderStatusKey == key).FirstOrDefault();
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

        public async static System.Threading.Tasks.Task<SalesOrderStatusList> GetSalesOrderStatusListAsync()
        {
            return await DataPortal.FetchAsync<SalesOrderStatusList>();
        }

        public static SalesOrderStatusList GetSalesOrderStatusList()
        {
            return DataPortal.Fetch<SalesOrderStatusList>();
        }

        #endregion

        #region Data Access

        [Fetch]
        private void DataPortal_Fetch([Inject] ISalesOrderStatusDal dal)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            var data = dal.FetchList();
            foreach (var dto in data)
            {
                var item = DataPortal.FetchChild<SalesOrderStatusInfo>(dto);
                Add(item);
            }
            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

    }
}