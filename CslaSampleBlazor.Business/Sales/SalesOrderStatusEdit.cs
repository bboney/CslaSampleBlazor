
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
    public class SalesOrderStatusEdit : BusinessBase<SalesOrderStatusEdit>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> SalesOrderStatusKeyProperty = RegisterProperty<int>(nameof(SalesOrderStatusKey));
        /// <summary>Gets the SalesOrderStatusKey of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the SalesOrderStatusKey of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the SalesOrderStatusKey of this SalesOrderStatus.  This value is part of the primary key.</remarks>
        [Key()]
        public int SalesOrderStatusKey
        {
            get { return GetProperty(SalesOrderStatusKeyProperty); }
            private set { LoadProperty(SalesOrderStatusKeyProperty, value); }
        }

        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(nameof(CreatedByUserKey));
        /// <summary>Gets the Created By User Key of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this SalesOrderStatus.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(nameof(CreatedByUserId));
        /// <summary>Gets the Created By User Id of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this SalesOrderStatus.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(nameof(CreatedOnDate), null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the date this SalesOrderStatus was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the date this SalesOrderStatus was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<byte[]> LastChangedProperty = RegisterProperty<byte[]>(nameof(LastChanged), "Last Changed", new byte[8]);
        /// <summary>Gets the LastChanged Timestamp of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="byte[]"/> that represents the LastChanged timestamp of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the LastModified timestamp for the SalesOrderStatus.  This value is used by the Data Access Layer in ensure Optimistic Concurrency.</remarks>
        [ConcurrencyCheck]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] LastChanged
        {
            get { return ReadProperty(LastChangedProperty); }
            private set { LoadProperty(LastChangedProperty, value); }
        }

        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(nameof(ModifiedByUserKey));
        /// <summary>Gets the Modified By User Key of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this SalesOrderStatus.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(nameof(ModifiedByUserId));
        /// <summary>Gets the Modified By User Id of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this SalesOrderStatus.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(nameof(ModifiedOnDate), null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the date the SalesOrderStatus was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the date the SalesOrderStatus was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        /// <summary>Gets the Name of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the Name of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the Name of this SalesOrderStatus.</remarks>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> SalesOrderStatusIdProperty = RegisterProperty<string>(nameof(SalesOrderStatusId));
        /// <summary>Gets the SalesOrderStatusId of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the SalesOrderStatusId of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the SalesOrderStatusId of this SalesOrderStatus.</remarks>
        [Required(ErrorMessage = "Sales Order Status Id is required.")]
        [StringLength(50)]
        [Display(Name = "Sales Order Status Id")]
        public string SalesOrderStatusId
        {
            get { return GetProperty(SalesOrderStatusIdProperty); }
            set { SetProperty(SalesOrderStatusIdProperty, value); }
        }

        public static readonly PropertyInfo<Int16> SalesOrderStatusValueProperty = RegisterProperty<Int16>(nameof(SalesOrderStatusValue));
        /// <summary>Gets the SalesOrderStatusValue of the <see cref="SalesOrderStatusEdit"/> object.</summary>
        /// <value>A <see cref="Int16"/> that represents the SalesOrderStatusValue of the <see cref="SalesOrderStatusEdit"/> object.</value>
        /// <remarks>This is the SalesOrderStatusValue of this SalesOrderStatus.</remarks>
        [Display(Name = "SalesOrderStatusValue")]
        public Int16 SalesOrderStatusValue
        {
            get { return GetProperty(SalesOrderStatusValueProperty); }
            set { SetProperty(SalesOrderStatusValueProperty, value); }
        }

        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {

            base.AddBusinessRules();
            BusinessRules.AddRule(new Rules.SalesOrderStatusIdDuplicateRule(SalesOrderStatusIdProperty, SalesOrderStatusKeyProperty));
        }

        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.CreateObject, "SalesOrderAdd"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "SalesOrderView"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.EditObject, "SalesOrderEdit"));
            Csla.Rules.BusinessRules.AddRule(typeof(SalesOrderStatusEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.DeleteObject, "SalesOrderDelete"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods


        public static async Task<SalesOrderStatusEdit> NewSalesOrderStatusEditAsync()
        {
            return await DataPortal.CreateAsync<SalesOrderStatusEdit>();
        }

        public static async Task<SalesOrderStatusEdit> GetSalesOrderStatusEditAsync(int salesOrderStatusKey)
        {
            try
            {
                SalesOrderStatusEdit salesOrderStatus = await DataPortal.FetchAsync<SalesOrderStatusEdit>(new Criteria { SalesOrderStatusKey = salesOrderStatusKey });
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

        public static async Task<bool> ExistsAsync(string salesOrderStatusId)
        {
            var cmd = await DataPortal.CreateAsync<SalesOrderStatusExistsCommand>(salesOrderStatusId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Exists;
        }

        public static async Task<int> GetKeyAsync(string salesOrderStatusId)
        {
            var cmd = await DataPortal.CreateAsync<SalesOrderStatusGetKeyCommand>(salesOrderStatusId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Key;
        }

        public static async Task DeleteSalesOrderStatusEditAsync(int salesOrderStatusKey)
        {
            await DataPortal.DeleteAsync<SalesOrderStatusEdit>(new Criteria { SalesOrderStatusKey = salesOrderStatusKey });
        }

        #endregion

        #region Sync Factory Methods

#if !SILVERLIGHT && !NETFX_CORE && !WINDOWS_PHONE

        public static SalesOrderStatusEdit NewSalesOrderStatusEdit()
        {
            return DataPortal.Create<SalesOrderStatusEdit>();
        }

        public static SalesOrderStatusEdit GetSalesOrderStatusEdit(int salesOrderStatusKey)
        {
            return DataPortal.Fetch<SalesOrderStatusEdit>(new Criteria { SalesOrderStatusKey = salesOrderStatusKey });
        }

        public static void DeleteSalesOrderStatusEdit(int salesOrderStatusKey)
        {
            DataPortal.Delete<SalesOrderStatusEdit>(new Criteria { SalesOrderStatusKey = salesOrderStatusKey });
        }

        public static bool Exists(string salesOrderStatusId)
        {
            var cmd = DataPortal.Create<SalesOrderStatusExistsCommand>(salesOrderStatusId);
            cmd = DataPortal.Execute(cmd);
            return cmd.Exists;
        }

        public static int GetKey(string salesOrderStatusId)
        {
            var cmd = DataPortal.Create<SalesOrderStatusGetKeyCommand>(salesOrderStatusId);
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
        private void DataPortal_Fetch(Criteria criteria, [Inject] ISalesOrderStatusDal dal)
        {
            BusinessRules.CascadeOnDirtyProperties = true;
            var dto = dal.Fetch(criteria.SalesOrderStatusKey);
            FetchObject(dto);
        }

        private void FetchObject(SalesOrderStatusDto dto)
        {
            DataMapper.Map(dto, this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Insert]
        private void DataPortal_Insert([Inject] ISalesOrderStatusDal dal)
        {
            CreatedByUserKey = Helpers.GetCurrentUserKey();
            CreatedByUserId = Csla.ApplicationContext.User.Identity.Name;
            using (BypassPropertyChecks)
            {
                var result = dal.Insert(CreatedByUserKey,
                                        Name,
                                        SalesOrderStatusId,
                                        SalesOrderStatusValue);
                SalesOrderStatusKey = result.Key;
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Update]
        private void DataPortal_Update([Inject] ISalesOrderStatusDal dal)
        {
            ModifiedByUserKey = Helpers.GetCurrentUserKey();
            ModifiedByUserId = Csla.ApplicationContext.User.Identity.Name;
            using (BypassPropertyChecks)
            {
                var result = dal.Update(SalesOrderStatusKey,
                            LastChanged,
                            ModifiedByUserKey,
                            Name,
                            SalesOrderStatusId,
                            SalesOrderStatusValue);
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);
        }

        [DeleteSelf]
        private void DataPortal_DeleteSelf([Inject] ISalesOrderStatusDal dal)
        {
            using (BypassPropertyChecks)
                DataPortal_Delete(new Criteria { SalesOrderStatusKey = this.SalesOrderStatusKey }, dal);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Delete]
        private void DataPortal_Delete(Criteria criteria, [Inject] ISalesOrderStatusDal dal)
        {
            dal.Delete(criteria.SalesOrderStatusKey);
        }
#endif

        #endregion

        #region Get Key Command
        [Serializable]
        class SalesOrderStatusGetKeyCommand : CommandBase<SalesOrderStatusGetKeyCommand>
        {
            public static readonly PropertyInfo<string> SalesOrderStatusIdProperty = RegisterProperty<string>(c => c.SalesOrderStatusId);
            private string SalesOrderStatusId
            {
                get { return ReadProperty(SalesOrderStatusIdProperty); }
                set { LoadProperty(SalesOrderStatusIdProperty, value); }
            }

            public static readonly PropertyInfo<int> KeyProperty = RegisterProperty<int>(c => c.Key);
            public int Key
            {
                get { return ReadProperty(KeyProperty); }
                private set { LoadProperty(KeyProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string salesOrderStatusId)
            {
                SalesOrderStatusId = salesOrderStatusId;
            }


#if !SILVERLIGHT && !NETFX_CORE
            [Execute]
            private void DataPortal_Execute([Inject] ISalesOrderStatusDal dal)
            {
                Key = dal.GetKey(SalesOrderStatusId);
            }
#endif

        }

        #endregion

        #region Exists Command
        [Serializable]
        class SalesOrderStatusExistsCommand : CommandBase<SalesOrderStatusExistsCommand>
        {

            public static readonly PropertyInfo<string> SalesOrderStatusIdProperty = RegisterProperty<string>(c => c.SalesOrderStatusId);
            private string SalesOrderStatusId
            {
                get { return ReadProperty(SalesOrderStatusIdProperty); }
                set { LoadProperty(SalesOrderStatusIdProperty, value); }
            }

            public static readonly PropertyInfo<bool> ExistsProperty = RegisterProperty<bool>(c => c.Exists);
            public bool Exists
            {
                get { return ReadProperty(ExistsProperty); }
                private set { LoadProperty(ExistsProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string salesOrderStatusId)
            {
                SalesOrderStatusId = salesOrderStatusId;
            }

#if !SILVERLIGHT && !NETFX_CORE
            [Execute]
            private void DataPortal_Execute([Inject] ISalesOrderStatusDal dal)
            {
                Exists = dal.Exists(SalesOrderStatusId);
            }
#endif

        }

        #endregion

        #region Criteria

        [Serializable]
        public class Criteria : CriteriaBase<Criteria>
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