using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CslaSampleBlazor.Business.Security.Rules
{
    /// <summary>
    /// HasPrivilegeClaim authorization rule.
    /// </summary>
    public class HasPrivilegeClaim : Csla.Rules.AuthorizationRule
    {
        private List<string> _privileges;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="privileges">List of allowed privileges.</param>
        public HasPrivilegeClaim(AuthorizationActions action, List<string> privileges)
      : base(action)
        {
            _privileges = privileges;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="privileges">List of allowed privileges.</param>
        public HasPrivilegeClaim(AuthorizationActions action, params string[] privileges)
      : base(action)
        {
            _privileges = new List<string>(privileges);
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="element">Member to be authorized.</param>
        /// <param name="privileges">List of allowed privileges.</param>
        public HasPrivilegeClaim(AuthorizationActions action, Csla.Core.IMemberInfo element, List<string> privileges)
      : base(action, element)
        {
            _privileges = privileges;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="action">Action this rule will enforce.</param>
        /// <param name="element">Member to be authorized.</param>
        /// <param name="privileges">List of allowed privileges.</param>
        public HasPrivilegeClaim(AuthorizationActions action, Csla.Core.IMemberInfo element, params string[] privileges)
      : base(action, element)
        {
            _privileges = new List<string>(privileges);
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(IAuthorizationContext context)
        {
            if (_privileges.Count > 0)
            {

                //var webUser = Csla.ApplicationContext.WebContextManager.GetUser();
                if (Csla.ApplicationContext.User is ClaimsPrincipal)
                {
                    ClaimsPrincipal user = (ClaimsPrincipal)Csla.ApplicationContext.User;
                    foreach (var item in _privileges)
                    {
                        if (user.HasClaim("Privilege", item))
                        {
                            context.HasPermission = true;
                            return;
                        }
                    }
                }

                if (Csla.ApplicationContext.User.Identity is ClaimsIdentity)
                {
                    ClaimsIdentity id = (ClaimsIdentity)Csla.ApplicationContext.User.Identity;
                    foreach (var item in _privileges)
                    {
                        if (id.HasClaim("Privilege", item))
                        {
                            context.HasPermission = true;
                            return;
                        }
                    }
                }

                //if (Csla.ApplicationContext.User.Identity is ICheckClaims)
                //{
                //    ICheckClaims id = (ICheckClaims)Csla.ApplicationContext.User.Identity;
                //    foreach (var item in _privileges)
                //    {
                //        if (id.HasClaim("Privilege", item))
                //        {
                //            context.HasPermission = true;
                //            return;
                //        }
                //    }
                //}
                context.HasPermission = false;
            }

            else
            {
                context.HasPermission = true;
            }
        }
    }
}
