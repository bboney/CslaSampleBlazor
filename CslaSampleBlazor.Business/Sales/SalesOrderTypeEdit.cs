
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
    public class SalesOrderTypeEdit : BusinessBase<SalesOrderTypeEdit>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> SalesOrderTypeKeyProperty = RegisterProperty<int>(nameof(SalesOrderTypeKey));
        /// <summary>Gets the SalesOrderTypeKey of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the SalesOrderTypeKey of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the SalesOrderTypeKey of this SalesOrderType.  This value is part of the primary key.</remarks>
        [Key()]
        public int SalesOrderTypeKey
        {
            get { return GetProperty(SalesOrderTypeKeyProperty); }
            private set { LoadProperty(SalesOrderTypeKeyProperty, value); }
        }

        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(nameof(CreatedByUserKey));
        /// <summary>Gets the Created By User Key of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this SalesOrderType.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(nameof(CreatedByUserId));
        /// <summary>Gets the Created By User Id of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this SalesOrderType.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(nameof(CreatedOnDate), null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the date this SalesOrderType was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the date this SalesOrderType was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<byte[]> LastChangedProperty = RegisterProperty<byte[]>(nameof(LastChanged), "Last Changed", new byte[8]);
        /// <summary>Gets the LastChanged Timestamp of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="byte[]"/> that represents the LastChanged timestamp of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the LastModified timestamp for the SalesOrderType.  This value is used by the Data Access Layer in ensure Optimistic Concurrency.</remarks>
        [ConcurrencyCheck]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] LastChanged
        {
            get { return ReadProperty(LastChangedProperty); }
            private set { LoadProperty(LastChangedProperty, value); }
        }

        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(nameof(ModifiedByUserKey));
        /// <summary>Gets the Modified By User Key of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this SalesOrderType.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(nameof(ModifiedByUserId));
        /// <summary>Gets the Modified By User Id of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this SalesOrderType.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(nameof(ModifiedOnDate), null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the date the SalesOrderType was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the date the SalesOrderType was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        /// <summary>Gets the Name of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the Name of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the Name of this SalesOrderType.</remarks>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> SalesOrderTypeIdProperty = RegisterProperty<string>(nameof(SalesOrderTypeId));
        /// <summary>Gets the SalesOrderTypeId of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the SalesOrderTypeId of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the SalesOrderTypeId of this SalesOrderType.</remarks>
        [Required(ErrorMessage = "Sales Order Type Id is required.")]
        [StringLength(50)]
        [Display(Name = "Sales Order Type Id")]
        public string SalesOrderTypeId
        {
            get { return GetProperty(SalesOrderTypeIdProperty); }
            set { SetProperty(SalesOrderTypeIdProperty, value); }
        }

        public static readonly PropertyInfo<Int16> SalesOrderTypeValueProperty = RegisterProperty<Int16>(nameof(SalesOrderTypeValue));
        /// <summary>Gets the SalesOrderTypeValue of the <see cref="SalesOrderTypeEdit"/> object.</summary>
        /// <value>A <see cref="Int16"/> that represents the SalesOrderTypeValue of the <see cref="SalesOrderTypeEdit"/> object.</value>
        /// <remarks>This is the SalesOrderTypeValue of this SalesOrderType.</remarks>
        [Display(Name = "SalesOrderTypeValue")]
        public Int16 SalesOrderTypeValue
        {
            get { return GetProperty(SalesOrderTypeValueProperty); }
            set { SetProperty(SalesOrderTypeValueProperty, value); }
        }

        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {

            base.AddBusinessRules();
            BusinessRules.AddRule(new Rules.SalesOrderTypeIdDuplicateRule(SalesOrderTypeIdProperty, SalesOrderTypeKeyProperty));
        }

        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.CreateObject, "SalesOrderAdd"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.EditObject, "SalesOrderEdit"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderTypeEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.DeleteObject, "SalesOrderDelete"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods


        public static async Task<SalesOrderTypeEdit> NewSalesOrderTypeEditAsync()
        {
            return await DataPortal.CreateAsync<SalesOrderTypeEdit>();
        }

        public static async Task<SalesOrderTypeEdit> GetSalesOrderTypeEditAsync(int salesOrderTypeKey)
        {
            try
            {
                SalesOrderTypeEdit salesOrderType = await DataPortal.FetchAsync<SalesOrderTypeEdit>(new Criteria { SalesOrderTypeKey = salesOrderTypeKey });
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

        public static async Task<bool> ExistsAsync(string salesOrderTypeId)
        {
            var cmd = await DataPortal.CreateAsync<SalesOrderTypeExistsCommand>(salesOrderTypeId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Exists;
        }

        public static async Task<int> GetKeyAsync(string salesOrderTypeId)
        {
            var cmd = await DataPortal.CreateAsync<SalesOrderTypeGetKeyCommand>(salesOrderTypeId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Key;
        }

        public static async Task DeleteSalesOrderTypeEditAsync(int salesOrderTypeKey)
        {
            await DataPortal.DeleteAsync<SalesOrderTypeEdit>(new Criteria { SalesOrderTypeKey = salesOrderTypeKey });
        }

        #endregion

        #region Sync Factory Methods

#if !SILVERLIGHT && !NETFX_CORE && !WINDOWS_PHONE

        public static SalesOrderTypeEdit NewSalesOrderTypeEdit()
        {
            return DataPortal.Create<SalesOrderTypeEdit>();
        }

        public static SalesOrderTypeEdit GetSalesOrderTypeEdit(int salesOrderTypeKey)
        {
            return DataPortal.Fetch<SalesOrderTypeEdit>(new Criteria { SalesOrderTypeKey = salesOrderTypeKey });
        }

        public static void DeleteSalesOrderTypeEdit(int salesOrderTypeKey)
        {
            DataPortal.Delete<SalesOrderTypeEdit>(new Criteria { SalesOrderTypeKey = salesOrderTypeKey });
        }

        public static bool Exists(string salesOrderTypeId)
        {
            var cmd = DataPortal.Create<SalesOrderTypeExistsCommand>(salesOrderTypeId);
            cmd = DataPortal.Execute(cmd);
            return cmd.Exists;
        }

        public static int GetKey(string salesOrderTypeId)
        {
            var cmd = DataPortal.Create<SalesOrderTypeGetKeyCommand>(salesOrderTypeId);
            cmd = DataPortal.Execute(cmd);
            return cmd.Key;
        }

#endif
        #endregion

        #endregion

        #region Data Access

        [RunLocal]
        [Create]
        protected override void DataPortal_Create()
        {
            // TODO: load default values
            BusinessRules.CascadeOnDirtyProperties = true;
            base.DataPortal_Create();
        }

#if !SILVERLIGHT && !NETFX_CORE
        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] ISalesOrderTypeDal dal)
        {
            BusinessRules.CascadeOnDirtyProperties = true;
            var dto = dal.Fetch(criteria.SalesOrderTypeKey);
            FetchObject(dto);
        }

        private void FetchObject(SalesOrderTypeDto dto)
        {
            DataMapper.Map(dto, this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Insert]
        private void DataPortal_Insert([Inject] ISalesOrderTypeDal dal)
        {
            CreatedByUserKey = Helpers.GetCurrentUserKey();
            CreatedByUserId = Csla.ApplicationContext.User.Identity.Name;

            using (BypassPropertyChecks)
            {
                var result = dal.Insert(CreatedByUserKey,
                                        Name,
                                        SalesOrderTypeId,
                                        SalesOrderTypeValue);
                SalesOrderTypeKey = result.Key;
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);

        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Update]
        private void DataPortal_Update([Inject] ISalesOrderTypeDal dal)
        {
            ModifiedByUserKey = Helpers.GetCurrentUserKey();
            ModifiedByUserId = Csla.ApplicationContext.User.Identity.Name;

            using (BypassPropertyChecks)
            {
                var result = dal.Update(SalesOrderTypeKey,
                            LastChanged,
                            ModifiedByUserKey,
                            Name,
                            SalesOrderTypeId,
                            SalesOrderTypeValue);
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);

        }

        [DeleteSelf]
        private void DataPortal_DeleteSelf([Inject] ISalesOrderTypeDal dal)
        {
            using (BypassPropertyChecks)
                DataPortal_Delete(new Criteria { SalesOrderTypeKey = this.SalesOrderTypeKey }, dal);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Delete]
        private void DataPortal_Delete(Criteria criteria, [Inject] ISalesOrderTypeDal dal)
        {
            dal.Delete(criteria.SalesOrderTypeKey);
        }
#endif

        #endregion

        #region Get Key Command
        [Serializable]
        class SalesOrderTypeGetKeyCommand : CommandBase<SalesOrderTypeGetKeyCommand>
        {
            public static readonly PropertyInfo<string> SalesOrderTypeIdProperty = RegisterProperty<string>(c => c.SalesOrderTypeId);
            private string SalesOrderTypeId
            {
                get { return ReadProperty(SalesOrderTypeIdProperty); }
                set { LoadProperty(SalesOrderTypeIdProperty, value); }
            }

            public static readonly PropertyInfo<int> KeyProperty = RegisterProperty<int>(c => c.Key);
            public int Key
            {
                get { return ReadProperty(KeyProperty); }
                private set { LoadProperty(KeyProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string salesOrderTypeId)
            {
                SalesOrderTypeId = salesOrderTypeId;
            }


#if !SILVERLIGHT && !NETFX_CORE
            [Execute]
            private void DataPortal_Execute([Inject] ISalesOrderTypeDal dal)
            {
                Key = dal.GetKey(SalesOrderTypeId);
            }
#endif

        }

        #endregion

        #region Exists Command
        [Serializable]
        class SalesOrderTypeExistsCommand : CommandBase<SalesOrderTypeExistsCommand>
        {

            public static readonly PropertyInfo<string> SalesOrderTypeIdProperty = RegisterProperty<string>(c => c.SalesOrderTypeId);
            private string SalesOrderTypeId
            {
                get { return ReadProperty(SalesOrderTypeIdProperty); }
                set { LoadProperty(SalesOrderTypeIdProperty, value); }
            }

            public static readonly PropertyInfo<bool> ExistsProperty = RegisterProperty<bool>(c => c.Exists);
            public bool Exists
            {
                get { return ReadProperty(ExistsProperty); }
                private set { LoadProperty(ExistsProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string salesOrderTypeId)
            {
                SalesOrderTypeId = salesOrderTypeId;
            }

#if !SILVERLIGHT && !NETFX_CORE
            [Execute]
            private void DataPortal_Execute([Inject] ISalesOrderTypeDal dal)
            {
                Exists = dal.Exists(SalesOrderTypeId);
            }
#endif

        }

        #endregion

        #region Criteria

        [Serializable]
        public class Criteria : CriteriaBase<Criteria>
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