using Csla.Rules;
using System;
using System.Collections.Generic;

namespace CslaSampleBlazor.Business.Common.Rules
{
    public class DivisionIdDuplicateRule : Csla.Rules.BusinessRule
    {
        public Csla.Core.IPropertyInfo PrimaryKeyProperty { get; set; }

        public DivisionIdDuplicateRule(Csla.Core.IPropertyInfo primaryIdProperty, Csla.Core.IPropertyInfo primaryKeyProperty)
            : base(primaryIdProperty)
        {
            InputProperties = new List<Csla.Core.IPropertyInfo> { primaryIdProperty, primaryKeyProperty };
            PrimaryKeyProperty = primaryKeyProperty;
        }

        protected override void Execute(IRuleContext context)
        {
            var id = (string)context.InputPropertyValues[PrimaryProperty];
            var key = (int)context.InputPropertyValues[PrimaryKeyProperty];

            if (string.IsNullOrEmpty(id))
            {
                context.AddErrorResult("Division Id is required.");
                return;
            }

            if (DivisionEdit.Exists(id) == false)
            {
                context.AddSuccessResult(false);
            }
            else
            {
                var Key = DivisionEdit.GetKey(id);
                if (Key == key)
                {
                    context.AddSuccessResult(false);
                }
                else
                {
                    context.AddErrorResult(String.Format("Division Id: {0} already exists.", id));
                }
            }
        }
    }
}
