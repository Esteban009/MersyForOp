using Backend.Helpers;
using System.Threading.Tasks;
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
            var resultid =Task.Run(async()=>await UsersHelper.GetUserId(filterContext.ApplicationInstance.Context));
            TUserId = resultid.Result;
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
