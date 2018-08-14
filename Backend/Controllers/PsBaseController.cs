namespace Backend.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Backend.Helpers;
    using Backend.Models;
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public abstract class PsBaseController : Controller
    {
        protected DataContext _db;
        protected int CurrentUserId;

        protected override void Initialize(RequestContext requestContext)
        {
            _db = new DataContext();
            Seed();
           // CurrentUserId = UsersHelper.GetUserId(requestContext.HttpContext.ApplicationInstance.Context);
            base.Initialize(requestContext);
        }
        protected virtual void Seed()
        {

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if(Request.IsAjaxRequest)
            base.OnException(filterContext);
        }

        public PsBaseController()
        {

        }        

        public async Task<int> GetAuthorId()
        {
            if (Session["AuthorId"] != null && Convert.ToInt32(Session["AuthorId"]) != 0) return Convert.ToInt32(Session["AuthorId"]);
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            Session["AuthorId"] = await UsersHelper.GetAuthorId(currentUser.Email);
            return Convert.ToInt32(Session["AuthorId"]);
        }

        public async Task<int> GetUserId()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) != 0) return Convert.ToInt32(Session["UserId"]);
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            Session["UserId"] = await UsersHelper.GetUserId(currentUser.Email);
            return Convert.ToInt32(Session["UserId"]);
        }

        public async Task<int> UserIdByEmail(string email)
        {
            // var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //  var currentUser = manager.FindById(User.Identity.GetUserId());

            return await UsersHelper.GetUserId(email);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Metodo utilizado para obtener un ViewResult de una pagina parcial de la aplicacion en formato
        /// string.
        /// </summary>
        ///
        /// <remarks>   Cagonzalec, 7/5/2016. </remarks>
        ///
        /// <param name="viewName"> Nombre del view a obtener. </param>
        /// <param name="model">    Datos del modelo asociado a dicho view. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }




    }





}