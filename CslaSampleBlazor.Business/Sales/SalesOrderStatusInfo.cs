
using Csla;
using Csla.Data;
using CslaSampleBlazor.Business.Security.Rules;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Sales;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CslaSampleBlazor.Business.Sales
{
    [Serializable]
    public class SalesOrderStatusInfo : ReadOnlyBase<SalesOrderStatusInfo>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> SalesOrderStatusKeyProperty = RegisterProperty<int>(nameof(SalesOrderStatusKey));
        /// <summary>Gets the SalesOrderStatusKey of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="int"/> the represents the SalesOrderStatusKey of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the SalesOrderStatusKey of this SalesOrderStatus.</remarks>
        [Key()]
        public int SalesOrderStatusKey
        {
            get { return GetProperty(SalesOrderStatusKeyProperty); }
            private set { LoadProperty(SalesOrderStatusKeyProperty, value); }
        }

        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(nameof(CreatedByUserKey));
        /// <summary>Gets the Created By User Key of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this SalesOrderStatus.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(nameof(CreatedByUserId));
        /// <summary>Gets the Created By User Id of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this SalesOrderStatus.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(nameof(CreatedOnDate), null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the date this SalesOrderStatus was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the date this SalesOrderStatus was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(nameof(ModifiedByUserKey));
        /// <summary>Gets the Modified By User Key of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this SalesOrderStatus.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(nameof(ModifiedByUserId));
        /// <summary>Gets the Modified By User Id of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this SalesOrderStatus.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(nameof(ModifiedOnDate), null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the date the SalesOrderStatus was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the date the SalesOrderStatus was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        /// <summary>Gets the Name of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the Name of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the Name of this SalesOrderStatus.</remarks>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> SalesOrderStatusIdProperty = RegisterProperty<string>(nameof(SalesOrderStatusId));
        /// <summary>Gets the SalesOrderStatusId of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the SalesOrderStatusId of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the SalesOrderStatusId of this SalesOrderStatus.</remarks>
        public string SalesOrderStatusId
        {
            get { return GetProperty(SalesOrderStatusIdProperty); }
            private set { LoadProperty(SalesOrderStatusIdProperty, value); }
        }

        public static readonly PropertyInfo<Int16> SalesOrderStatusValueProperty = RegisterProperty<Int16>(nameof(SalesOrderStatusValue));
        /// <summary>Gets the SalesOrderStatusValue of the <see cref="SalesOrderStatusInfo"/> object.</summary>
        /// <value>A <see cref="Int16"/> the represents the SalesOrderStatusValue of the <see cref="SalesOrderStatusInfo"/> object.</value>
        /// <remarks>This is the SalesOrderStatusValue of this SalesOrderStatus.</remarks>
        public Int16 SalesOrderStatusValue
        {
            get { return GetProperty(SalesOrderStatusValueProperty); }
            private set { LoadProperty(SalesOrderStatusValueProperty, value); }
        }

        #endregion

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusInfo), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods

        public static async Task<SalesOrderStatusInfo> GetSalesOrderStatusInfoAsync(int salesOrderStatusKey)
        {
            try
            {
                SalesOrderStatusInfo salesOrderStatus = await DataPortal.FetchAsync<SalesOrderStatusInfo>(new Criteria() { SalesOrderStatusKey = salesOrderStatusKey });
                return salesOrderStatus;
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

        public static SalesOrderStatusInfo GetSalesOrderStatusInfo(int salesOrderStatusKey)
        {
            return DataPortal.Fetch<SalesOrderStatusInfo>(new Criteria() { SalesOrderStatusKey = salesOrderStatusKey });
        }

        #endregion


        #endregion

        #region Data Access

#if !SILVERLIGHT && !NETFX_CORE
        [FetchChild]
        private void Child_Fetch(SalesOrderStatusDto dto)
        {
            FetchObject(dto);
        }

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] ISalesOrderStatusDal dal)
        {
            var dto = dal.Fetch(criteria.SalesOrderStatusKey);
            FetchObject(dto);
        }

        private void FetchObject(SalesOrderStatusDto dto)
        {
            DataMapper.Map(dto, this, new string[1] { "LastChanged" });
        }

#endif
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<int> SalesOrderStatusKeyProperty = RegisterProperty<int>(c => c.SalesOrderStatusKey);
            public int SalesOrderStatusKey
            {
                get { return ReadProperty(SalesOrderStatusKeyProperty); }
                set { LoadProperty(SalesOrderStatusKeyProperty, value); }
            }
        }

        #endregion

    }
}
