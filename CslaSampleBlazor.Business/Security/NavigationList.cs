using Csla;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Security;
using System;
using System.Linq;

namespace CslaSampleBlazor.Business.Security
{
    [Serializable()]
    public class NavigationList : ReadOnlyListBase<NavigationList, NavigationInfo>
    {

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(NavigationList), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "NavigationView"));
        }

        #endregion
        public void RemoveChild(int key)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.NavigationKey == key).FirstOrDefault();
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

#if !WINDOWS_PHONE
        public async static System.Threading.Tasks.Task<NavigationList> GetNavigationListAsync()
        {
            return await DataPortal.FetchAsync<NavigationList>();
        }
#endif
#if !SILVERLIGHT && !NETFX_CORE
        public static NavigationList GetNavigationList()
        {
            return DataPortal.Fetch<NavigationList>();
        }

        [Fetch]
        private void DataPortal_Fetch([Inject] INavigationDal dal)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            var data = dal.FetchList();
            foreach (var dto in data)
            {
                var item = DataPortal.FetchChild<NavigationInfo>(dto);
                Add(item);
            }
            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }
#endif
    }
}