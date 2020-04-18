
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
    public class DivisionEdit : BusinessBase<DivisionEdit>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> DivisionKeyProperty = RegisterProperty<int>(c => c.DivisionKey);
        /// <summary>Gets the DivisionKey of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the DivisionKey of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the DivisionKey of this Division.  This value is part of the primary key.</remarks>
        [Key()]
        public int DivisionKey
        {
            get { return GetProperty(DivisionKeyProperty); }
            private set { LoadProperty(DivisionKeyProperty, value); }
        }
        public static readonly PropertyInfo<int> CreatedByUserKeyProperty = RegisterProperty<int>(c => c.CreatedByUserKey);
        /// <summary>Gets the Created By User Key of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the CreatedByUserKey of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that initially created this Division.</remarks>
        public int CreatedByUserKey
        {
            get { return GetProperty(CreatedByUserKeyProperty); }
            private set { LoadProperty(CreatedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> CreatedByUserIdProperty = RegisterProperty<string>(c => c.CreatedByUserId);
        /// <summary>Gets the Created By User Id of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedByUserId of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that initially created this Division.</remarks>
        public string CreatedByUserId
        {
            get { return GetProperty(CreatedByUserIdProperty); }
            private set { LoadProperty(CreatedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> CreatedOnDateProperty = RegisterProperty<SmartDate>(c => c.CreatedOnDate, null, new SmartDate());
        /// <summary>Gets the Created On Date of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the CreatedOnDate of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the date this Division was created.</remarks>
        public string CreatedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(CreatedOnDateProperty, value); }
        }

        /// <summary>Gets the Created On Date of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the CreatedOnDate of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the date this Division was created.</remarks>
        public DateTime CreatedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(CreatedOnDateProperty, value); }
        }
        public static readonly PropertyInfo<string> DivisionIdProperty = RegisterProperty<string>(c => c.DivisionId);
        /// <summary>Gets the DivisionId of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the DivisionId of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the DivisionId of this Division.</remarks>
        [Required(ErrorMessage = "Division Id is required.")]
        [StringLength(50)]
        [Display(Name = "Division Id")]
        public string DivisionId
        {
            get { return GetProperty(DivisionIdProperty); }
            set { SetProperty(DivisionIdProperty, value); }
        }

        public static readonly PropertyInfo<int> DivisionValueProperty = RegisterProperty<int>(nameof(DivisionValue));
        [Display(Name="Division Value")]
        public int DivisionValue
        {
            get => GetProperty(DivisionValueProperty);
            set => SetProperty(DivisionValueProperty, value);
        }

        public static readonly PropertyInfo<byte[]> LastChangedProperty = RegisterProperty<byte[]>(c => c.LastChanged, "Last Changed", new byte[8]);
        /// <summary>Gets the LastChanged Timestamp of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="byte[]"/> that represents the LastChanged timestamp of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the LastModified timestamp for the Division.  This value is used by the Data Access Layer in ensure Optimistic Concurrency.</remarks>
        [ConcurrencyCheck]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] LastChanged
        {
            get { return ReadProperty(LastChangedProperty); }
            private set { LoadProperty(LastChangedProperty, value); }
        }
        public static readonly PropertyInfo<int> ModifiedByUserKeyProperty = RegisterProperty<int>(c => c.ModifiedByUserKey);
        /// <summary>Gets the Modified By User Key of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="int"/> that represents the ModifiedByUserKey of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the UserKey of the User that most recently modified this Division.</remarks>
        public int ModifiedByUserKey
        {
            get { return GetProperty(ModifiedByUserKeyProperty); }
            private set { LoadProperty(ModifiedByUserKeyProperty, value); }
        }

        public static readonly PropertyInfo<string> ModifiedByUserIdProperty = RegisterProperty<string>(c => c.ModifiedByUserId);
        /// <summary>Gets the Modified By User Id of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedByUserId of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the User Id of the User that most recently modified this Division.</remarks>
        public string ModifiedByUserId
        {
            get { return GetProperty(ModifiedByUserIdProperty); }
            private set { LoadProperty(ModifiedByUserIdProperty, value); }
        }
        public static readonly PropertyInfo<SmartDate> ModifiedOnDateProperty = RegisterProperty<SmartDate>(c => c.ModifiedOnDate, null, new SmartDate());
        /// <summary>Gets the Modified on Date of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the ModifiedOnDate of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the date the Division was most recently modified.</remarks>
        public string ModifiedOnDateString
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, string>(ModifiedOnDateProperty, value); }
        }
        /// <summary>Gets the Modified on Date of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="DateTime"/> that represents the ModifiedOnDate of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the date the Division was most recently modified.</remarks>
        public DateTime ModifiedOnDate
        {
            get { return GetPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty); }
            private set { LoadPropertyConvert<SmartDate, DateTime>(ModifiedOnDateProperty, value); }
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        /// <summary>Gets the Name of the <see cref="DivisionEdit"/> object.</summary>
        /// <value>A <see cref="string"/> that represents the Name of the <see cref="DivisionEdit"/> object.</value>
        /// <remarks>This is the Name of this Division.</remarks>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {

            base.AddBusinessRules();
            BusinessRules.AddRule(new Rules.DivisionIdDuplicateRule(DivisionIdProperty, DivisionKeyProperty));
        }

        [ObjectAuthorizationRules]
        private static void AddObjectAuthorizationRules()
        {
            Csla.Rules.BusinessRules.AddRule(typeof(DivisionEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.CreateObject, "DivisionAdd"));
            Csla.Rules.BusinessRules.AddRule(typeof(DivisionEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.GetObject, "DivisionView"));
            Csla.Rules.BusinessRules.AddRule(typeof(DivisionEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.EditObject, "DivisionEdit"));
            Csla.Rules.BusinessRules.AddRule(typeof(DivisionEdit), new HasPrivilegeClaim(Csla.Rules.AuthorizationActions.DeleteObject, "DivisionDelete"));
        }

        #endregion

        #region Factory Methods

        #region Async Factory Methods


        public static async Task<DivisionEdit> NewDivisionEditAsync()
        {
            return await DataPortal.CreateAsync<DivisionEdit>();
        }

        public static async Task<DivisionEdit> GetDivisionEditAsync(int divisionKey)
        {
            try
            {
                DivisionEdit division = await DataPortal.FetchAsync<DivisionEdit>(new Criteria { DivisionKey = divisionKey });
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

        public static async Task<bool> ExistsAsync(string divisionId)
        {
            var cmd = await DataPortal.CreateAsync<DivisionExistsCommand>(divisionId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Exists;
        }

        public static async Task<int> GetKeyAsync(string divisionId)
        {
            var cmd = await DataPortal.CreateAsync<DivisionGetKeyCommand>(divisionId);
            cmd = await DataPortal.ExecuteAsync(cmd);
            return cmd.Key;
        }

        public static async Task DeleteDivisionEditAsync(int divisionKey)
        {
            await DataPortal.DeleteAsync<DivisionEdit>(new Criteria { DivisionKey = divisionKey });
        }

        #endregion

        #region Sync Factory Methods

#if !SILVERLIGHT && !NETFX_CORE && !WINDOWS_PHONE

        public static DivisionEdit NewDivisionEdit()
        {
            return DataPortal.Create<DivisionEdit>();
        }

        public static DivisionEdit GetDivisionEdit(int divisionKey)
        {
            return DataPortal.Fetch<DivisionEdit>(new Criteria { DivisionKey = divisionKey });
        }

        public static void DeleteDivisionEdit(int divisionKey)
        {
            DataPortal.Delete<DivisionEdit>(new Criteria { DivisionKey = divisionKey });
        }

        public static bool Exists(string divisionId)
        {
            var cmd = DataPortal.Create<DivisionExistsCommand>(divisionId);
            cmd = DataPortal.Execute(cmd);
            return cmd.Exists;
        }

        public static int GetKey(string divisionId)
        {
            var cmd = DataPortal.Create<DivisionGetKeyCommand>(divisionId);
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

        [Fetch]
        private void DataPortal_Fetch(Criteria criteria, [Inject] IDivisionDal dal)
        {
            BusinessRules.CascadeOnDirtyProperties = true;
            var dto = dal.Fetch(criteria.DivisionKey);
            using (BypassPropertyChecks)
            {
                FetchObject(dto);
            }
        }

        private void FetchObject(DivisionDto dto)
        {
            DataMapper.Map(dto, this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Insert]
        private void DataPortal_Insert([Inject] IDivisionDal dal)
        {
            CreatedByUserKey = Helpers.GetCurrentUserKey();
            CreatedByUserId = Csla.ApplicationContext.User.Identity.Name;

            using (BypassPropertyChecks)
            {
                var result = dal.Insert(CreatedByUserKey,
                                        DivisionId,
                                        DivisionValue,
                                        Name);
                DivisionKey = result.Key;
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);

        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Update]
        private void DataPortal_Update([Inject] IDivisionDal dal)
        {
            ModifiedByUserKey = Helpers.GetCurrentUserKey();
            ModifiedByUserId = Csla.ApplicationContext.User.Identity.Name;

            using (BypassPropertyChecks)
            {
                var result = dal.Update(DivisionKey,
                            DivisionId,
                            DivisionValue,
                            LastChanged,
                            ModifiedByUserKey,
                            Name);
                LastChanged = result.LastChanged;
            }
            FieldManager.UpdateChildren(this);

        }
        [DeleteSelf]
        private void DataPortal_DeleteSelf([Inject] IDivisionDal dal)
        {
            using (BypassPropertyChecks)
                DataPortal_Delete(new Criteria { DivisionKey = this.DivisionKey }, dal);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        [Delete]
        private void DataPortal_Delete(Criteria criteria, [Inject] IDivisionDal dal)
        {
            dal.Delete(criteria.DivisionKey);
        }


        #endregion

        #region Get Key Command
        [Serializable]
        class DivisionGetKeyCommand : CommandBase<DivisionGetKeyCommand>
        {
            public static readonly PropertyInfo<string> DivisionIdProperty = RegisterProperty<string>(c => c.DivisionId);
            private string DivisionId
            {
                get { return ReadProperty(DivisionIdProperty); }
                set { LoadProperty(DivisionIdProperty, value); }
            }

            public static readonly PropertyInfo<int> KeyProperty = RegisterProperty<int>(c => c.Key);
            public int Key
            {
                get { return ReadProperty(KeyProperty); }
                private set { LoadProperty(KeyProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string divisionId)
            {
                DivisionId = divisionId;
            }

            [Execute]
            private void DataPortal_Execute([Inject] IDivisionDal dal)
            {
                Key = dal.GetKey(DivisionId);
            }
        }

        #endregion

        #region Exists Command
        [Serializable]
        class DivisionExistsCommand : CommandBase<DivisionExistsCommand>
        {
            public static readonly PropertyInfo<string> DivisionIdProperty = RegisterProperty<string>(c => c.DivisionId);
            private string DivisionId
            {
                get { return ReadProperty(DivisionIdProperty); }
                set { LoadProperty(DivisionIdProperty, value); }
            }

            public static readonly PropertyInfo<bool> ExistsProperty = RegisterProperty<bool>(c => c.Exists);
            public bool Exists
            {
                get { return ReadProperty(ExistsProperty); }
                private set { LoadProperty(ExistsProperty, value); }
            }

            [RunLocal]
            [Create]
            private void DataPortal_Create(string divisionId)
            {
                DivisionId = divisionId;
            }

            [Execute]
            private void DataPortal_Execute([Inject] IDivisionDal dal)
            {
                Exists = dal.Exists(DivisionId);
            }
        }

        #endregion

        #region Criteria

        [Serializable]
        public class Criteria : CriteriaBase<Criteria>
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