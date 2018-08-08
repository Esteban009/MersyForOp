using System;
using System.Data.Entity;
using System.Web.Mvc;
using Backend.Helpers;
using Backend.Models;
using Domain;
using Domain.GEN;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Backend.Controllers
{

    public class HomeController : Controller
    {
        private readonly DataContext _db = new DataContext();
        public async Task<ActionResult> Index()
        
        {
            int id;
            try
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
               // id = UsersHelper.GetUserId(currentUser.Email);
                id = await UsersHelper.GetAuthorId(currentUser.Email);
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Account");
            }
                // return View("Error");
              
           // var author = await _db.Users.FindAsync(id);
            var author = await _db.Authors.FindAsync(id);

            if (author == null)
            {
              //  return View("Error");
            }
            var reportFilter = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == id) ?? new Report();

            // var reportFilter = await  _db.Reports.FirstOrDefaultAsync( p => p.UserId == id) ?? new Report();

            return View(reportFilter);
          //  return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Mersy";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "PraySoft";

            return View();
        }
    }
}