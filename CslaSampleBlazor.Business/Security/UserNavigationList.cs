using Csla;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaSampleBlazor.Business.Security
{
    [Serializable()]
    public class UserNavigationList : ReadOnlyListBase<UserNavigationList, NavigationInfo>
    {

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            //Csla.Rules.BusinessRules.AddRule(typeof(UserNavigationList), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "NavigationView"));
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

        public async static System.Threading.Tasks.Task<UserNavigationList> GetUserNavigationListAsync(NavigationTypeValues navigationType, int userKey)
        {
            return await DataPortal.FetchAsync<UserNavigationList>(new Criteria() { NavigationType = (int)navigationType, UserKey = userKey });
        }

        public static UserNavigationList GetUserNavigationList(NavigationTypeValues navigationType, int userKey)
        {
            return DataPortal.Fetch<UserNavigationList>(new Criteria() { NavigationType = (int)navigationType, UserKey = userKey });
        }

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] INavigationDal dal)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            var data = dal.FetchUserList(criteria.NavigationType, criteria.UserKey);
            foreach (var dto in data)
            {
                var item = DataPortal.FetchChild<NavigationInfo>(dto);
                Add(item);
            }

            
            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>     
        {
            public static readonly PropertyInfo<int> NavigationTypeProperty = RegisterProperty<int>(c => c.NavigationType);
            public int NavigationType
            {
                get { return ReadProperty(NavigationTypeProperty); }
                set { LoadProperty(NavigationTypeProperty, value); }
            }

            public static readonly PropertyInfo<int> UserKeyProperty = RegisterProperty<int>(c => c.UserKey);
            public int UserKey
            {
                get { return ReadProperty(UserKeyProperty); }
                set { LoadProperty(UserKeyProperty, value); }
            }
        }

    }
}