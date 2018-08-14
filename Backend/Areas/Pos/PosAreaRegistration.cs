namespace Backend.Areas.Pos
{
    using System.Web.Mvc;

    public class PosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get {
                return "Pos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pos_default",
                "Pos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}