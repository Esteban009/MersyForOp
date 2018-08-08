namespace Backend.Areas.Configurations.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Backend.Models;
    using Domain.GEN;
    using Domain.SEG;
    using Helpers;
    using System.Linq;
    using Domain;
    using Domain.MED;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        public readonly DataContext Db = new DataContext();

        public async Task<ActionResult> CreateDoctorInformation(int id)
        {
            //if (id == null)
            //{
            //     return View("Error");
            //}

            var user = await Db.Users.FindAsync(id);

            if (user == null)
            {
                return View("Error");
            }

            var hasHistory = await Db.Doctors.FirstOrDefaultAsync(p => p.UserId == id);

            if (hasHistory == null)
            {
                //ViewBag.UserId = id;
                var view = new Doctor { UserId = id, };
                return View(view);
                //   return RedirectToAction($"CreateDoctorInformation/{id}");
            }

            return RedirectToAction($"EditDoctorInformation/{hasHistory.DoctorId}");
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
                Db.Doctors.Add(doctor);
                //doctor.PersonId=doctor.Users.
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsUser/{doctor.UserId}");
            }


            // ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            //  ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            //   ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);
            return View(doctor);
        }

        public async Task<ActionResult> EditDoctorInformation(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var doctor = await Db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return View("Error");
            }

            //   ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            //  ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);


            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditDoctorInformation(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(doctor).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsUser/{doctor.UserId}");
            }
            //ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", doctor.StatusId);
            ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", doctor.UserId);
            // ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == doctor.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", doctor.UserId);

            return View(doctor);
        }

        #region RolesDelUsuarioController

        public async Task<ActionResult> CreateRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await Db.Users.FindAsync(id);

            if (user == null)
            {
                return View("Error");
            }


            ViewBag.UserId = new SelectList(Db.Users, "UserId", "FirstName");
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");

            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == user.AuthorId), "RolId", "Name");
            var view = new UserRol { UserId = user.UserId, };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRolForUser(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                Db.UserRols.Add(userRol);
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsUser/{userRol.UserId}");
            }


            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", userRol.UserId);
            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == userRol.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", userRol.UserId);
            return View(userRol);
        }

        public async Task<ActionResult> EditRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userRol = await Db.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return View("Error");
            }

            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", userRol.UserId);
            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == userRol.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", userRol.UserId);


            return View(userRol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRolForUser(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(userRol).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsUser/{userRol.UserId}");
            }
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.UserId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", userRol.UserId);
            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == userRol.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", userRol.UserId);

            return View(userRol);
        }

        public async Task<ActionResult> DeleteRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userRol = await Db.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return View("Error");
            }
            Db.UserRols.Remove(userRol);
            await Db.SaveChangesAsync();
            return RedirectToAction($"DetailsUser/{userRol.UserId}");
        }

        #endregion

        #region OpcionesDelRolController

        public async Task<ActionResult> CreateOptionToRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var rol = await Db.Rols.FindAsync(id);

            if (rol == null)
            {
                return View("Error");
            }


            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");
            ViewBag.OptionId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Description");

            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == Db.Authors.FirstOrDefault().AuthorId).OrderBy(t => t.Name), "RolId", "Name");
            var view = new OptionRol
            {
                RolId = rol.RolId,
                FromDate = DateTime.Today,
                ToDate = DateTime.Today,
                Edit = true,
                Delete = true,
                Create = true,
                Undefined = true,
                Index = true,
                Details = true
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOptionToRol(OptionRol optionRol)
        {
            if (ModelState.IsValid)
            {
                Db.OptionRols.Add(optionRol);
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsRol/{optionRol.RolId}");
            }


            //ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name", rol.AuthorId);
            //ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", rol.StatusId);

            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", optionRol.StatusId);
            ViewBag.OptionId = new SelectList(Db.Options.OrderBy(t => t.Name), "OptionId", "Name", optionRol.OptionId);
            ViewBag.RolId = new SelectList(Db.Rols.Where(t => t.AuthorId == Db.Authors.FirstOrDefault().AuthorId).OrderBy(t => t.Name), "RolId", "Name", optionRol.RolId);

            //ViewBag.OptionId = new SelectList(Db.Options, "OptionId", "Name", optionRol.OptionId);
            //ViewBag.RolId = new SelectList(Db.Rols, "RolId", "Name", optionRol.RolId);
            //ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", optionRol.StatusId);
            return View(optionRol);
        }
        public async Task<ActionResult> EditOptionToRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var optionRol = await Db.OptionRols.FindAsync(id);
            if (optionRol == null)
            {
                return View("Error");
            }
            ViewBag.OptionId = new SelectList(Db.Options, "OptionId", "Name", optionRol.OptionId);
            ViewBag.RolId = new SelectList(Db.Rols, "RolId", "Name", optionRol.RolId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", optionRol.StatusId);
            return View(optionRol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOptionToRol(OptionRol optionRol)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(optionRol).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction($"DetailsRol/{optionRol.RolId}");
            }
            ViewBag.OptionId = new SelectList(Db.Options, "OptionId", "Name", optionRol.OptionId);
            ViewBag.RolId = new SelectList(Db.Rols, "RolId", "Name", optionRol.RolId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", optionRol.StatusId);
            return View(optionRol);
        }

        public async Task<ActionResult> DeleteOptionToRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var optionRol = await Db.OptionRols.FindAsync(id);
            if (optionRol == null)
            {
                return View("Error");
            }
            Db.OptionRols.Remove(optionRol);
            await Db.SaveChangesAsync();
            return RedirectToAction($"DetailsRol/{optionRol.RolId}");
        }

        #endregion

        #region RolesDelAuthorControllers

        public async Task<ActionResult> DetailsUser(int? id, string msg = "")
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await Db.Users.FindAsync(id);

            if (user == null)
            {
                return View("Error");
            }
            ViewBag.Msg = msg;
            return View(user);
        }

        public async Task<ActionResult> DetailsRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var rol = await Db.Rols.FindAsync(id);

            if (rol == null)
            {
                return View("Error");
            }

            return View(rol);
        }

        public async Task<ActionResult> CreateRolF(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var author = await Db.Authors.FindAsync(id);

            if (author == null)
            {
                return View("Error");
            }

            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name");
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");
            var view = new Rol { AuthorId = author.AuthorId, };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRolF(Rol rol)
        {
            if (ModelState.IsValid)
            {
                Db.Rols.Add(rol);
                await Db.SaveChangesAsync();
                return RedirectToAction($"Details/{rol.AuthorId}");
            }

            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name", rol.AuthorId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", rol.StatusId);
            return View(rol);
        }

        public async Task<ActionResult> EditRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var rol = await Db.Rols.FindAsync(id);
            if (rol == null)
            {
                return View("Error");
            }
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name", rol.AuthorId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", rol.StatusId);
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRol(Rol rol)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(rol).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction($"Details/{rol.AuthorId}");
            }

            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name"); ViewBag.StatusId = new SelectList(Db.Status.OrderBy(ut => ut.Name), "StatusId", "Name", rol.StatusId);
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name"); ViewBag.AuthorId = new SelectList(Db.Authors.OrderBy(ut => ut.Name), "AuthorId", "Name", rol.AuthorId);

            return View(rol);
        }

        public async Task<ActionResult> DeleteRol(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var rol = await Db.Rols.FindAsync(id);
            if (rol == null)
            {
                return View("Error");
            }
            Db.Rols.Remove(rol);
            await Db.SaveChangesAsync();
            return RedirectToAction($"Details/{rol.AuthorId}");
        }

        #endregion

        #region UsuariosDelAuthorControllers

        //public async Task<ActionResult> DetailsUser(int? id)
        //{
        //    if (id == null)
        //    {
        //         return View("Error");
        //    }
        //    User user = await Db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return View("Error");
        //    }
        //    return View(user);
        //}

        public async Task<ActionResult> CreateUser(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var author = await Db.Authors.FindAsync(id);

            if (author == null)
            {
                return View("Error");
            }

            //ViewBag.FavoriteLeagueId = new SelectList(db.Leagues.OrderBy(l => l.Name), "LeagueId", "Name");
            //ViewBag.FavoriteTeamId = new SelectList(db.Teams.Where(t => t.LeagueId == db.Leagues.FirstOrDefaultAsync).LeagueId).OrderBy(t => t.Name), "TeamId", "Name");
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name");
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");
            ViewBag.UserTypeId = new SelectList(Db.UserTypes, "UserTypeId", "Name");

            var view = new UserView { AuthorId = author.AuthorId, };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(UserView view)
        {
            if (ModelState.IsValid)
            {
                //var pic = string.Empty;
                //var folder = "~/Content/Users";

                //if (view.PictureFile != null)
                //{
                //    pic = FilesHelper.UploadPhoto(view.PictureFile, folder);
                //    pic = string.Format("{0}/{1}", folder, pic);
                //}

                var user = ToUser(view);
                // user.Picture = pic;
                user.StatusId = 1;
                Db.Users.Add(user);
                await Db.SaveChangesAsync();
                UsersHelper.CreateUserAsp(view.Email, "User", view.Password);
                return RedirectToAction($"Details/{user.AuthorId}");
            }

            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name"); ViewBag.StatusId = new SelectList(Db.Status.OrderBy(ut => ut.Name), "StatusId", "Name", view.StatusId);
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name"); ViewBag.AuthorId = new SelectList(Db.Authors.OrderBy(ut => ut.Name), "AuthorId", "Name", view.AuthorId);
            ViewBag.UserTypeId = new SelectList(Db.UserTypes, "UserTypeId", "Name"); ViewBag.UserTypeId = new SelectList(Db.UserTypes.OrderBy(ut => ut.Name), "UserTypeId", "Name", view.UserTypeId);

            return View(view);

        }

        private static User ToUser(UserView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            return new User
            {
                UserId = view.UserId,
                FirstName = view.FirstName,
                LastName = view.LastName,
                UserTypeId = view.UserTypeId,
                Picture = view.Picture,
                Email = view.Email,
                AuthorId = view.AuthorId,
                StatusId = view.StatusId,
                //  NickName = view.NickName,
                //  FavoriteTeamId = view.FavoriteTeamId,
                //  Points = view.Points,
            };
        }

        public async Task<ActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var user = await Db.Users.FindAsync(id);
            if (user == null)
            {
                return View("Error");
            }
            // ViewBag.FavoriteTeamId = new SelectList(db.Teams, "TeamId", "Name", user.FavoriteTeamId);
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name", user.AuthorId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", user.StatusId);
            ViewBag.UserTypeId = new SelectList(Db.UserTypes, "UserTypeId", "Name", user.UserTypeId);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(user).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction($"Details/{user.AuthorId}");
            }
            // ViewBag.FavoriteTeamId = new SelectList(db.Teams, "TeamId", "Name", user.FavoriteTeamId);
            ViewBag.AuthorId = new SelectList(Db.Authors, "AuthorId", "Name", user.AuthorId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", user.StatusId);
            ViewBag.UserTypeId = new SelectList(Db.UserTypes, "UserTypeId", "Name", user.UserTypeId);

            return View(user);
        }

        public async Task<ActionResult> DeleteUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await Db.Users.FindAsync(id);

            if (user == null)
            {
                return View("Error");
            }

            Db.Users.Remove(user);
            await Db.SaveChangesAsync();
            return RedirectToAction($"Details/{user.AuthorId}");
        }

        #endregion

        public async Task<ActionResult> Index()
        {
            var authors = Db.Authors.Include(a => a.Plan).Include(a => a.Status).Include(a => a.Type).OrderByDescending(p => p.AuthorId);
            return View(await authors.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var author = await Db.Authors.FindAsync(id);

            if (author == null)
            {
                return View("Error");
            }
            return View(author);
        }

        public ActionResult Create()
        {
            ViewBag.AuthorPlanId = new SelectList(Db.AuthorPlans, "AuthorPlanId", "Code");
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name");
            ViewBag.AuthorTypeId = new SelectList(Db.AuthorTypes, "AuthorTypeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                Db.Authors.Add(author);
                await Db.SaveChangesAsync();
                var user = new User
                {
                    AuthorId = author.AuthorId,
                    FirstName = author.Name,
                    LastName = author.Name,
                    UserTypeId = 1,
                    Email = author.Email,
                    StatusId = 1
                };

                Db.Users.Add(user);

                var rol = new Rol
                {
                    AuthorId = author.AuthorId,
                    Name = "Admin",
                    Description = "Administrator",
                    Level = 2,
                    StatusId = 1
                };

                Db.Rols.Add(rol);

                await Db.SaveChangesAsync();
                UsersHelper.CreateUserAsp(author.Email, "User", "824455");

                var rolForUser = new UserRol
                {
                    UserId = user.UserId,
                    RolId = rol.RolId,
                    FromDate = DateTime.Today,
                    ToDate = DateTime.Today,
                    Undefined = true,
                    StatusId = 1
                };

                Db.UserRols.Add(rolForUser);

                var doctorInf = new Doctor
                {
                    UserId = user.UserId,
                    Record = "Mi Exquartur 999",
                    CreationDate = DateTime.Today,
                    Especialidad = "Mi Especialidad",
                    Cmd = "Mi cmd 999",
                    City = "Santo Domingo, D.N.",
                    Prefix = "SG"
                };

                Db.Doctors.Add(doctorInf);

                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorPlanId = new SelectList(Db.AuthorPlans, "AuthorPlanId", "Code", author.AuthorPlanId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", author.StatusId);
            ViewBag.AuthorTypeId = new SelectList(Db.AuthorTypes, "AuthorTypeId", "Name", author.AuthorTypeId);
            return View(author);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var author = await Db.Authors.FindAsync(id);
            if (author == null)
            {
                return View("Error");
            }
            ViewBag.AuthorPlanId = new SelectList(Db.AuthorPlans, "AuthorPlanId", "Code", author.AuthorPlanId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", author.StatusId);
            ViewBag.AuthorTypeId = new SelectList(Db.AuthorTypes, "AuthorTypeId", "Name", author.AuthorTypeId);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(author).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorPlanId = new SelectList(Db.AuthorPlans, "AuthorPlanId", "Code", author.AuthorPlanId);
            ViewBag.StatusId = new SelectList(Db.Status, "StatusId", "Name", author.StatusId);
            ViewBag.AuthorTypeId = new SelectList(Db.AuthorTypes, "AuthorTypeId", "Name", author.AuthorTypeId);
            return View(author);
        }

        public async Task<ActionResult> ResetPass(int id)
        {
            try
            {

                var user = await Db.Users.FindAsync(id);

                if (user == null)
                {
                    return View("Error");
                }

                var userContext = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userAsp = userManager.FindByEmail(user.Email);
                if (userAsp == null)
                {
                    return View("Error");
                }

                //var random = new Random();
                //var newPassword = string.Format("{0}", random.Next(100000, 999999));
                // var newPassword = string.Format("{0}", random.Next(100000, 999999));
                // var response1 = 
                userManager.RemovePassword(userAsp.Id);
                var response2 = await userManager.AddPasswordAsync(userAsp.Id, "824455");
                if (response2.Succeeded)
                {
                    //        var subject = "Torneo Predicciones - Password Recovery";
                    //        var body = string.Format(@"
                    //<h1>Torneo Predicciones - Password Recovery</h1>
                    //<p>Your new password is: <strong>{0}</strong></p>
                    //<p>Please, don't forget change it for one easy remember for you.",
                    //            newPassword);

                    //        await MailHelper.SendMail(email, subject, body);
                    //        return Ok(true);

                    return RedirectToAction("DetailsUser", "Authors", new { area = "Configurations", id, msg = "Contraseña Reseteada a: 824455" });
                }
                return View("Error");

            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
