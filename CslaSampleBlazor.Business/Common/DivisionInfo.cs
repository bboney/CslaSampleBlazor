
using Csla;
using Csla.Data;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CslaSampleBlazor.Business.Common
{
    [Serializable]
    public class DivisionInfo : ReadOnlyBase<DivisionInfo>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> DivisionKeyProperty = RegisterProperty<int>(c => c.DivisionKey);
        /// <summary>Gets the DivisionKey of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="int"/> the represents the DivisionKey of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the DivisionKey of this Division.</remarks>
        [Key()]
        public int DivisionKey
        {
            get { return GetProperty(DivisionKeyProperty); }
            private set { LoadProperty(DivisionKeyProperty, value); }
        }
        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(c => c.CreatedByUserKey);
        /// <summary>Gets the Created By User Key of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this Division.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(c => c.CreatedByUserId);
        /// <summary>Gets the Created By User Id of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this Division.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(c => c.CreatedOnDate, null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the date this Division was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the date this Division was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }
        public static readonly PropertyInfo<string> DivisionIdProperty = RegisterProperty<string>(c => c.DivisionId);
        /// <summary>Gets the DivisionId of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the DivisionId of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the DivisionId of this Division.</remarks>
        public string DivisionId
        {
            get { return GetProperty(DivisionIdProperty); }
            private set { LoadProperty(DivisionIdProperty, value); }
        }

        public static readonly PropertyInfo<int> DivisionValueProperty = RegisterProperty<int>(nameof(DivisionValue));
        public int DivisionValue
        {
            get => GetProperty(DivisionValueProperty);
            private set => LoadProperty(DivisionValueProperty, value);
        }

        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(c => c.ModifiedByUserKey);
        /// <summary>Gets the Modified By User Key of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this Division.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(c => c.ModifiedByUserId);
        /// <summary>Gets the Modified By User Id of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this Division.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(c => c.ModifiedOnDate, null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the date the Division was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the date the Division was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        /// <summary>Gets the Name of the <see cref="DivisionInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the Name of the <see cref="DivisionInfo"/> object.</value>
        /// <remarks>This is the Name of this Division.</remarks>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }
        #endregion

        #region Business Rules
        [ObjectAuthorizationRules]
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(DivisionInfo), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "DivisionView"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods

        public static async Task<DivisionInfo> GetDivisionInfoAsync(int divisionKey)
        {
            try
            {
                DivisionInfo division = await DataPortal.FetchAsync<DivisionInfo>(new Criteria() { DivisionKey = divisionKey });
                return division;
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
        public static DivisionInfo GetDivisionInfo(int divisionKey)
        {
            return DataPortal.Fetch<DivisionInfo>(new Criteria() { DivisionKey = divisionKey });
        }
#endif

        #endregion

        #endregion

        #region Data Access

#if !SILVERLIGHT && !NETFX_CORE
        [FetchChild]
        private void Child_Fetch(DivisionDto dto)
        {
            FetchObject(dto);
        }

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] IDivisionDal dal)
        {
            var dto = dal.Fetch(criteria.DivisionKey);
            FetchObject(dto);
        }

        private void FetchObject(DivisionDto dto)
        {
            DataMapper.Map(dto, this, new string[1] { "LastChanged" });
        }
#endif
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<int> DivisionKeyProperty = RegisterProperty<int>(c => c.DivisionKey);
            public int DivisionKey
            {
                get { return ReadProperty(DivisionKeyProperty); }
                set { LoadProperty(DivisionKeyProperty, value); }
            }
        }

        #endregion
    }
}
