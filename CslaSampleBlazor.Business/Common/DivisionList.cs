using Csla;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Common;
using System;
using System.Linq;

namespace CslaSampleBlazor.Business.Common
{
    [Serializable()]
    public class DivisionList : ReadOnlyListBase<DivisionList, DivisionInfo>
    {

        #region Business Rules
        [ObjectAuthorizationRules]
        private static void AddObjectAuthorizationRules()
        {
            //Csla.Rules.BusinessRules.AddRule(typeof(DivisionList), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "DivisionView", "SalespersonOpenOrdersView", "ManagementOpenOrdersView"));
        }

        #endregion
        public void RemoveChild(int key)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.DivisionKey == key).FirstOrDefault();
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

        public async static System.Threading.Tasks.Task<DivisionList> GetDivisionListAsync()
        {
            return await DataPortal.FetchAsync<DivisionList>();
        }

        public static DivisionList GetDivisionList()
        {
            return DataPortal.Fetch<DivisionList>();
        }

        [Fetch]
        private void DataPortal_Fetch([Inject] IDivisionDal dal)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            var data = dal.FetchList();
            foreach (var dto in data)
            {
                var item = DataPortal.FetchChild<DivisionInfo>(dto);
                Add(item);
            }

            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }
    }
}