using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Backend.Areas.Medicals.Models;
using Backend.Helpers;
using Backend.Models;
using CommonTasksLib.Data;
using Domain;
using Domain.GEN;
using Domain.MED;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PsTools;

namespace Backend.Areas.Medicals.Controllers
{
    [Authorize(Roles = "User")]
    public class ReportsController : Controller
    {
        private readonly DataContext _db = new DataContext();

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
