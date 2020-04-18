
using Csla;
using Csla.Data;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Security;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CslaSampleBlazor.Business.Security
{
    [Serializable]
    public class NavigationInfo : ReadOnlyBase<NavigationInfo>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> NavigationKeyProperty = RegisterProperty<int>(c => c.NavigationKey);
        /// <summary>Gets the NavigationKey of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="int"/> the represents the NavigationKey of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the NavigationKey of this Navigation.</remarks>
        [Key()]
        public int NavigationKey
        {
            get { return GetProperty(NavigationKeyProperty); }
            private set { LoadProperty(NavigationKeyProperty, value); }
        }
        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(c => c.CreatedByUserKey);
        /// <summary>Gets the Created By User Key of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this Navigation.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(c => c.CreatedByUserId);
        /// <summary>Gets the Created By User Id of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this Navigation.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(c => c.CreatedOnDate, null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the date this Navigation was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the date this Navigation was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<bool> ExpandedProperty = RegisterProperty<bool>(nameof(Expanded));
        public bool Expanded
        {
            get => GetProperty(ExpandedProperty);
            private set => LoadProperty(ExpandedProperty, value);
        }

        public static readonly PropertyInfo<bool> HasChildrenProperty = RegisterProperty<bool>(nameof(HasChildren));
        public bool HasChildren
        {
            get => GetProperty(HasChildrenProperty);
            private set => LoadProperty(HasChildrenProperty, value);
        }

        public static readonly PropertyInfo<bool> IsPrivilegeRequiredProperty = RegisterProperty<bool>(c => c.IsPrivilegeRequired);
        /// <summary>Gets the IsPrivilegeRequired of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="bool"/> the represents the IsPrivilegeRequired of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the IsPrivilegeRequired of this Navigation.</remarks>
        public bool IsPrivilegeRequired
        {
            get { return GetProperty(IsPrivilegeRequiredProperty); }
            private set { LoadProperty(IsPrivilegeRequiredProperty, value); }
        }
        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(c => c.ModifiedByUserKey);
        /// <summary>Gets the Modified By User Key of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this Navigation.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(c => c.ModifiedByUserId);
        /// <summary>Gets the Modified By User Id of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this Navigation.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(c => c.ModifiedOnDate, null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the date the Navigation was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the date the Navigation was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        /// <summary>Gets the Name of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the Name of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the Name of this Navigation.</remarks>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }
        public static readonly PropertyInfo<string> NavigationIdProperty = RegisterProperty<string>(c => c.NavigationId);
        /// <summary>Gets the NavigationId of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the NavigationId of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the NavigationId of this Navigation.</remarks>
        public string NavigationId
        {
            get { return GetProperty(NavigationIdProperty); }
            private set { LoadProperty(NavigationIdProperty, value); }
        }
        public static readonly PropertyInfo<NavigationTypeValues> NavigationTypeProperty = RegisterProperty<NavigationTypeValues>(c => c.NavigationType);
        /// <summary>Gets the NavigationType of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="NavigationTypeValues"/> the represents the NavigationType of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the NavigationType of this Navigation.</remarks>
        public NavigationTypeValues NavigationType
        {
            get { return GetProperty(NavigationTypeProperty); }
            private set { LoadProperty(NavigationTypeProperty, value); }
        }
        public static readonly PropertyInfo<int?> ParentNavigationKeyProperty = RegisterProperty<int?>(c => c.ParentNavigationKey);
        /// <summary>Gets the ParentNavigationKey of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="int?"/> the represents the ParentNavigationKey of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the ParentNavigationKey of this Navigation.</remarks>
        public int? ParentNavigationKey
        {
            get { return GetProperty(ParentNavigationKeyProperty); }
            private set { LoadProperty(ParentNavigationKeyProperty, value); }
        }
        public static readonly PropertyInfo<int> SequenceProperty = RegisterProperty<int>(c => c.Sequence);
        /// <summary>Gets the Sequence of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="int"/> the represents the Sequence of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the Sequence of this Navigation.</remarks>
        public int Sequence
        {
            get { return GetProperty(SequenceProperty); }
            private set { LoadProperty(SequenceProperty, value); }
        }
        public static readonly PropertyInfo<string> SpriteCssClassProperty = RegisterProperty<string>(c => c.SpriteCssClass);
        /// <summary>Gets the SpriteCssClass of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the SpriteCssClass of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the SpriteCssClass of this Navigation.</remarks>
        public string SpriteCssClass
        {
            get { return GetProperty(SpriteCssClassProperty); }
            private set { LoadProperty(SpriteCssClassProperty, value); }
        }
        public static readonly PropertyInfo<string> UrlProperty = RegisterProperty<string>(c => c.Url);
        /// <summary>Gets the Url of the <see cref="NavigationInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the Url of the <see cref="NavigationInfo"/> object.</value>
        /// <remarks>This is the Url of this Navigation.</remarks>
        public string Url
        {
            get { return GetProperty(UrlProperty); }
            private set { LoadProperty(UrlProperty, value); }
        }
        #endregion

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(NavigationInfo), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "NavigationView"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods

        public static async Task<NavigationInfo> GetNavigationInfoAsync(int navigationKey)
        {
            try
            {
                NavigationInfo navigation = await DataPortal.FetchAsync<NavigationInfo>(new Criteria() { NavigationKey = navigationKey });
                return navigation;
            }
            catch (Csla.DataPortalException ex)
            {
                if (ex.InnerException.InnerException is DataNotFoundException)
                    return null;
                else
                    throw ex;
            }
        }

        #endregion

        #region Sync Factory Methods

#if !SILVERLIGHT && !NETFX_CORE && !WINDOWS_PHONE
        public static NavigationInfo GetNavigationInfo(int navigationKey)
        {
            return DataPortal.Fetch<NavigationInfo>(new Criteria() { NavigationKey = navigationKey });
        }
#endif

        #endregion

        #endregion

        #region Data Access

#if !SILVERLIGHT && !NETFX_CORE
        [FetchChild]
        private void Child_Fetch(NavigationDto data)
        {
            FetchObject(data);
        }

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] INavigationDal dal)
        {
            var dto = dal.Fetch(criteria.NavigationKey);
            FetchObject(dto);         
        }

        private void FetchObject(NavigationDto dto)
        {
            DataMapper.Map(dto, this, new string[1] { "LastChanged" });
            Expanded = false;
        }
#endif
        #endregion

        #region Criteria

        [Serializable()]
        public class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<int> NavigationKeyProperty = RegisterProperty<int>(c => c.NavigationKey);
            public int NavigationKey
            {
                get { return ReadProperty(NavigationKeyProperty); }
                set { LoadProperty(NavigationKeyProperty, value); }
            }
        }

        #endregion
    }
}
