using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Backend.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Backend.Models;
using Domain;
using Domain.MED;
using Domain.SEG;
using Microsoft.AspNet.Identity.EntityFramework;
using PsTools;

namespace Backend.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ManageController : Controller
    {
        private readonly DataContext _db = new DataContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
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

        public async Task<ActionResult> CreateSmtp()
        {
            //if (id == null)
            //{
            //     return View("Error");
            //}

            var userId = await GetUserId();
            var user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var hasSmtpSethings = await _db.UserEmailSettings.FirstOrDefaultAsync(p => p.UserId == userId);

            if (hasSmtpSethings != null) return RedirectToAction($"EditSmtp/{hasSmtpSethings.UserId}");

            var view = new UserEmailSetting { UserId = userId, };
            return View(view);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSmtp(UserEmailSetting userEmailSetting)
        {
            if (ModelState.IsValid)
            {
                userEmailSetting.Password = Strings.EncodeKrypt(userEmailSetting.Password);
                _db.UserEmailSettings.Add(userEmailSetting);
                //doctor.PersonId=doctor.Users.
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            // ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            //  ViewBag.UserId = new SelectList(_db.Users.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            //   ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);
            return View(userEmailSetting);
        }

        public async Task<ActionResult> EditSmtp(int id)
        {
           
            var userEmailSettings = await _db.UserEmailSettings.FindAsync(id);
            if (userEmailSettings == null)
            {
                return View("Error");
            }
         
            return View(userEmailSettings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditSmtp(UserEmailSetting userEmailSetting)
        {
            if (ModelState.IsValid)
            {
                userEmailSetting.Password = Strings.EncodeKrypt(userEmailSetting.Password);
                _db.Entry(userEmailSetting).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            // ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            // ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);

            return View(userEmailSetting);
        }

        //public async Task<int> GetUserIdx()
        //{
        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //    var currentUser = manager.FindById(User.Identity.GetUserId());
        //    return await UsersHelper.GetUserId(currentUser.Email);
        //}

        //private async Task<ActionResult> CreateDoctorInformation()
        //{
        //    var userId = GetUserId();
        //    //  var user = await _db.Doctors.FindAsync(userId);

        //    //  if (user == null)
        //    //  {
        //    //      return View("Error");
        //    //  }

        //    var hasHistory = _db.Doctors.FirstOrDefaultAsyncp => p.UserId == userId);

        //    if (hasHistory != null) return RedirectToAction($"EditDoctorInformation");
        //    var view = new Doctor { UserId = userId, };
        //    return View(view);
        //}

        public async Task<ActionResult> CreateDoctorInformation()
        {
            //if (id == null)
            //{
            //     return View("Error");
            //}

            var userId = await GetUserId();
            var user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var hasHistory = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

            if (hasHistory != null) return RedirectToAction($"EditDoctorInformation/{hasHistory.DoctorId}");
            //ViewBag.UserId = id;
            var view = new Doctor { UserId = userId, };
            return View(view);
            //   return RedirectToAction($"CreateDoctorInformation/{id}");

            //  var docInf = Db.Doctors.Include(o => o.Users).Where(p => p.UserId == id);
            //  ViewBag.UserId = id;
            //  return View(await docInf.ToListAsync());

            // ViewBag.UserId = new SelectList(Db.Users, "UserId", "FirstName");
            // ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");

            // ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == user.AuthorId), "RolId", "Name");
            //  var view = new Doctor { UserId = user.UserId, };

            // return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDoctorInformation(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(doctor);
                //doctor.PersonId=doctor.Users.
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            // ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            //  ViewBag.UserId = new SelectList(_db.Users.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            //   ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);
            return View(doctor);
        }

        public async Task<ActionResult> EditDoctorInformation()
        {

            var userId = await GetUserId();
            //var user = await _db.Doctors.FindAsync(userId);

            //if (user == null)
            //{
            //    return View("Error");
            //}

            var hasHistory = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

            if (hasHistory == null)
            {
                var view = new Doctor { UserId = userId, };
                return View(view);
            }


            var doctor = await _db.Doctors.FindAsync(hasHistory.DoctorId);
            if (doctor == null)
            {
                return View("Error");
            }

            //   ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            // ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            //  ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);


            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditDoctorInformation(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(doctor).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            // ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            // ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);

            return View(doctor);
        }
    
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

       public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        //private bool HasPhoneNumber()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PhoneNumber != null;
        //    }
        //    return false;
        //}

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}