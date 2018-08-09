using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Backend.Helpers;
using Backend.Models;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Backend.Controllers
{
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