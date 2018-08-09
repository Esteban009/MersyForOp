using Backend.Helpers;
using System.Web;
using System.Web.Mvc;

namespace Backend.ExternalLibs
{
    public class RoleAuthorizationFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public int Action { get; set; }
        public string OptionName { get; set; }
        public int TUserId { get; set; }

        public RoleAuthorizationFilterAttribute(int Action, string OptionName)
        {
            this.Action = Action;
            this.OptionName = OptionName;
        }

        protected override bool AuthorizeCore(HttpContextBase filterContext)
        {
            base.AuthorizeCore(filterContext);
            bool Authorized = true;
            TUserId = UsersHelper.GetUserId(filterContext.ApplicationInstance.Context).Result;
            if (!UsersHelper.HavePermisionToAction(TUserId, OptionName, Action).Result)
            {
                // no tiene permisos
                Authorized = false;
            }

            return Authorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
