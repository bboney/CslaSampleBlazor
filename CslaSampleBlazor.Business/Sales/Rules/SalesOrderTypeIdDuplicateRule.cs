using Csla.Core;
using Csla.Rules;
using System;
using System.Collections.Generic;

namespace CslaSampleBlazor.Business.Sales.Rules
{
    public class SalesOrderTypeIdDuplicateRule : BusinessRule
    {
        public IPropertyInfo PrimaryKeyProperty { get; set; }

        public SalesOrderTypeIdDuplicateRule(IPropertyInfo primaryIdProperty, IPropertyInfo primaryKeyProperty)
            : base(primaryIdProperty)
        {
            InputProperties = new List<IPropertyInfo> { primaryIdProperty, primaryKeyProperty };
            PrimaryKeyProperty = primaryKeyProperty;
        }

        protected override void Execute(IRuleContext context)
        {
            var id = (string)context.InputPropertyValues[PrimaryProperty];
            var key = (int)context.InputPropertyValues[PrimaryKeyProperty];

            if (string.IsNullOrEmpty(id))
            {
                context.AddErrorResult("Sales Order Type Id is required.");
                return;
            }

            if (SalesOrderTypeEdit.Exists(id) == false)
            {
                context.AddSuccessResult(false);
            }
            else
            {
                var Key = SalesOrderTypeEdit.GetKey(id);
                if (Key == key)
                {
                    context.AddSuccessResult(false);
                }
                else
                {
                    context.AddErrorResult(String.Format("Sales Order Type Id: {0} already exists.", id));
                }
            }
        }
    }
}
