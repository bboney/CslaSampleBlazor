
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
    public class SalesOrderTypeInfo : ReadOnlyBase<SalesOrderTypeInfo>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> SalesOrderTypeKeyProperty = RegisterProperty<int>(nameof(SalesOrderTypeKey));
        /// <summary>Gets the SalesOrderTypeKey of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="int"/> the represents the SalesOrderTypeKey of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the SalesOrderTypeKey of this SalesOrderType.</remarks>
        [Key()]
        public int SalesOrderTypeKey
        {
            get { return GetProperty(SalesOrderTypeKeyProperty); }
            private set { LoadProperty(SalesOrderTypeKeyProperty, value); }
        }

        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(nameof(CreatedByUserKey));
        /// <summary>Gets the Created By User Key of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this SalesOrderType.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(nameof(CreatedByUserId));
        /// <summary>Gets the Created By User Id of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this SalesOrderType.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(nameof(CreatedOnDate), null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the date this SalesOrderType was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the date this SalesOrderType was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(nameof(ModifiedByUserKey));
        /// <summary>Gets the Modified By User Key of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this SalesOrderType.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(nameof(ModifiedByUserId));
        /// <summary>Gets the Modified By User Id of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this SalesOrderType.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(nameof(ModifiedOnDate), null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the date the SalesOrderType was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the date the SalesOrderType was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        /// <summary>Gets the Name of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the Name of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the Name of this SalesOrderType.</remarks>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> SalesOrderTypeIdProperty = RegisterProperty<string>(nameof(SalesOrderTypeId));
        /// <summary>Gets the SalesOrderTypeId of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="string"/> the represents the SalesOrderTypeId of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the SalesOrderTypeId of this SalesOrderType.</remarks>
        public string SalesOrderTypeId
        {
            get { return GetProperty(SalesOrderTypeIdProperty); }
            private set { LoadProperty(SalesOrderTypeIdProperty, value); }
        }

        public static readonly PropertyInfo<Int16> SalesOrderTypeValueProperty = RegisterProperty<Int16>(nameof(SalesOrderTypeValue));
        /// <summary>Gets the SalesOrderTypeValue of the <see cref="SalesOrderTypeInfo"/> object.</summary>
        /// <value>A <see cref="Int16"/> the represents the SalesOrderTypeValue of the <see cref="SalesOrderTypeInfo"/> object.</value>
        /// <remarks>This is the SalesOrderTypeValue of this SalesOrderType.</remarks>
        public Int16 SalesOrderTypeValue
        {
            get { return GetProperty(SalesOrderTypeValueProperty); }
            private set { LoadProperty(SalesOrderTypeValueProperty, value); }
        }

        #endregion

        #region Business Rules
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeInfo), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods

        public static async Task<SalesOrderTypeInfo> GetSalesOrderTypeInfoAsync(int salesOrderTypeKey)
        {
            try
            {
                SalesOrderTypeInfo salesOrderType = await DataPortal.FetchAsync<SalesOrderTypeInfo>(new Criteria() { SalesOrderTypeKey = salesOrderTypeKey });
                return salesOrderType;
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

        public static SalesOrderTypeInfo GetSalesOrderTypeInfo(int salesOrderTypeKey)
        {
            return DataPortal.Fetch<SalesOrderTypeInfo>(new Criteria() { SalesOrderTypeKey = salesOrderTypeKey });
        }

        #endregion


        #endregion

        #region Data Access

#if !SILVERLIGHT && !NETFX_CORE
        [FetchChild]
        private void Child_Fetch(SalesOrderTypeDto dto)
        {
            FetchObject(dto);
        }

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] ISalesOrderTypeDal dal)
        {
            var dto = dal.Fetch(criteria.SalesOrderTypeKey);
            FetchObject(dto);
        }

        private void FetchObject(SalesOrderTypeDto dto)
        {
            DataMapper.Map(dto, this, new string[1] { "LastChanged" });
        }
#endif
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public static readonly PropertyInfo<int> SalesOrderTypeKeyProperty = RegisterProperty<int>(c => c.SalesOrderTypeKey);
            public int SalesOrderTypeKey
            {
                get { return ReadProperty(SalesOrderTypeKeyProperty); }
                set { LoadProperty(SalesOrderTypeKeyProperty, value); }
            }
        }

        #endregion

    }
}
