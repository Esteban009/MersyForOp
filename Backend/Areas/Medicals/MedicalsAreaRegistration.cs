namespace Backend.Areas.Medicals
{
    using System.Web.Mvc;

    public class MedicalsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get {
                return "Medicals";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Medicals_default",
                "Medicals/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}