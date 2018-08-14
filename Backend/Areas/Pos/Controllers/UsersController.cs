namespace Backend.Areas.Pos.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Backend.Helpers;
    using Domain.SEG;
    using Backend.Models;
   // using Domain.POS;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PsTools;
    using Backend.Controllers;

    public class UsersController : PsBaseController
    {

        public async Task<ActionResult> OptionsList()
        {
            var userId = await GetUserId();

            var user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            return View(user);
        }

        public async Task<ActionResult> CreateRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return View("Error");
            }


            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName");
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name");

            ViewBag.RolId = new SelectList(_db.Rols.Where(t => t.AuthorId == user.AuthorId), "RolId", "Name");
            var view = new UserRol { UserId = user.UserId, };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRolForUser(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                // var rol = await _db.UserRols.FindAsync(userRol.RolId);
                var userRols = await _db.UserRols.FirstOrDefaultAsync(x => x.UserId == userRol.UserId && x.UserRolId == userRol.RolId);
                if (userRols != null)
                {
                    ModelState.AddModelError(string.Empty,
                        @"Este Usuario ya tiene asignado este Rol");
                }
                else
                {
                    _db.UserRols.Add(userRol);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexRolForUser/" + userRol.UserId);
                }

            }


            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", userRol.UserId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.RolId = new SelectList(_db.Rols, "RolId", "Name", userRol.RolId);
            //var view = new UserRol { UserId = user.UserId, };

            //return View(view);
            //ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", userRol.StatusId);
            //ViewBag.UserId = new SelectList(_db.Options.OrderBy(t => t.Name), "OptionId", "Name", userRol.UserId);
            //ViewBag.RolId = new SelectList(_db.Rols.Where(t => t.AuthorId == userRol.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", userRol.UserId);
            return View(userRol);
        }

        public async Task<ActionResult> EditRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userRol = await _db.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return View("Error");
            }

            //ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", userRol.StatusId);
            //ViewBag.UserId = new SelectList(_db.Options.OrderBy(t => t.Name), "OptionId", "Name", userRol.UserId);
            //ViewBag.RolId = new SelectList(_db.Rols.Where(t => t.AuthorId == userRol.User.AuthorId).OrderBy(t => t.Name), "RolId", "Name", userRol.UserId);

            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", userRol.UserId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.RolId = new SelectList(_db.Rols, "RolId", "Name", userRol.RolId);

            return View(userRol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRolForUser(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                //var userRols = _db.UserRols.FirstOrDefaultAsyncx => x.UserId == userRol.UserId && x.UserRolId == userRol.RolId);
                //if (userRols != null)
                //{
                //    ModelState.AddModelError(string.Empty,
                //        @"Este Usuario ya tiene asignado este Rol");
                //}

                _db.Entry(userRol).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("IndexRolForUser/" + userRol.UserId);
            }

            ViewBag.UserId = new SelectList(_db.Users, "UserId", "FirstName", userRol.UserId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", userRol.StatusId);
            ViewBag.RolId = new SelectList(_db.Rols, "RolId", "Name", userRol.RolId);

            return View(userRol);
        }

        public async Task<ActionResult> DeleteRolForUser(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var userRol = await _db.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return View("Error");
            }
            _db.UserRols.Remove(userRol);
            await _db.SaveChangesAsync();
            return RedirectToAction("IndexRolForUser/" + userRol.UserId);
        }

        public async Task<ActionResult> IndexRolForUser(int? id)
        {

            var userid = await GetUserId();
            //ViewBag.FavoriteLeagueId = new SelectList(db.Leagues.OrderBy(l => l.Name), "LeagueId", "Name");
            //ViewBag.FavoriteTeamId = new SelectList(db.Teams.Where(t => t.LeagueId == db.Leagues.FirstOrDefaultAsync).LeagueId).OrderBy(t => t.Name), "TeamId", "Name");        
            //ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name");
            // var user = _db.Users.FirstOrDefaultAsync(p=>p.UserId==userid);
            // var user = _db.Users.FindAsync( userid);
            var userConected = await _db.Users.FirstOrDefaultAsync(u => u.UserId == userid);

            if (userConected == null)
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Su usuario no se encontro!!!" });
            }

            if (!await UsersHelper.IsAdmin(userid))
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Esta opcion esta Reservada para los Administradores de Sistema!!!" });
            }

            if (id == null)
            {
                return View("Error");
            }
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return View("Error");
            }
            //var authorid = GetAuthorId();
            ViewBag.UserId = id;
            var userRols = _db.UserRols.Where(p => p.UserId == id).Include(u => u.Status).OrderBy(p => p.StatusId);
            return View(await userRols.ToListAsync());
        }

        public async Task<ActionResult> Index(string message = "")
        {
            var conectedUserid = await GetUserId();
            var conectedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserId == conectedUserid);
            var user = new List<User>();
            if (conectedUser == null)
            {
                ViewBag.StatusMessage = "Su usuario no se encontro!!!";
                return View(user.ToList());
            }

            if (!await UsersHelper.IsAdmin(conectedUserid))
            {
                // var user = new List<User>();
                ViewBag.StatusMessage = "Esta opcion esta Reservada para los Administradores de Sistema!!!";
                return View(user.ToList());
            }

            var authorid = await GetAuthorId();
            ViewBag.StatusMessage = message;
            var users = _db.Users.Where(p => p.AuthorId == authorid).Include(u => u.Author).Include(u => u.Status).Include(u => u.UserType).OrderBy(p => p.StatusId);
            return View(await users.ToListAsync());

        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return View("Error");
            }
            return View(user);
        }

        public async Task<ActionResult> Create()
        {
            var userid = await GetUserId();
           
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == userid);

            if (user == null)
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Su usuario no se encontro!!!" });
            }

            if (!await UsersHelper.IsAdmin(userid))
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Esta opcion esta Reservada para los Administradores de Sistema!!!" });
            }

            var authorid = await GetAuthorId();

            ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "Name");
           // ViewBag.ShopId = new SelectList(_db.Shops.Where(p => p.AuthorId == authorid), "ShopId", "Name");

            var view = new UserView { AuthorId = authorid };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserView view)
        {
            if (ModelState.IsValid)
            {
               
                var emailExist = await UserIdByEmail(view.Email);
                if (emailExist != 0)
                {
                    ModelState.AddModelError(string.Empty,
                        @"Este Email ya estan en uso, escoja uno diferente");
                }
                else
                {

                 
                    var guid = Guid.NewGuid().ToString();
                    var file = string.Format("{0}.jpg", guid);
                    var folder = "~/Content/Users";
                   
                    var pic = string.Empty;
               

                    if (view.PictureFile != null)
                    {
                        pic = Files.UploadPhoto(view.PictureFile, folder, file);
                        pic = string.Format("{0}/{1}", folder, pic);
                    }

                 


                    var user = ToUser(view);
                    user.Picture = pic;

                    user.StatusId = 1;
                    _db.Users.Add(user);

                    //var shopUser = new ShopUser
                    //{
                    //    ShopId = view.ShopId,
                    //    UserId = view.UserId
                    //};

                    //_db.ShopUsers.Add(shopUser);

                    await _db.SaveChangesAsync();
                    UsersHelper.CreateUserAsp(view.Email, "User", view.Password);
                    return RedirectToAction("Index");
                }


            }

               ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "Name"); ViewBag.UserTypeId = new SelectList(_db.UserTypes.OrderBy(ut => ut.Name), "UserTypeId", "Name", view.UserTypeId);

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
                StatusId = view.StatusId
            };
        }
        private static UserView ToView(User user)
        {
            return new UserView()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserTypeId = user.UserTypeId,
                Picture = user.Picture,
                Email = user.Email,
                StatusId = user.StatusId,
                AuthorId = user.AuthorId,
            };
        }

        public async Task<ActionResult> Edit(int? id)
        {
            var conectedUserid = await GetUserId();
            var conectedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserId == conectedUserid);

            if (conectedUser == null)
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Su usuario no se encontro!!!" });
            }

            if (!await UsersHelper.IsAdmin(conectedUserid))
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Esta opcion esta Reservada para los Administradores de Sistema!!!" });
            }

            if (id == null)
            {
                return View("Error");
            }
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return View("Error");
            }

            var authorid = await GetAuthorId();
           ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
             var shop = await _db.ShopUsers.FirstOrDefaultAsync(p => p.UserId == id);
            var shopid = shop?.ShopId ?? 0;

            //ViewBag.ShopId = new SelectList(_db.Shops.Where(p => p.AuthorId == authorid), "ShopId", "Name", shopid);

            ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.StatusId == 1 || p.StatusId == 2), "StatusId", "Name", user.StatusId);

            var view = ToView(user);
            view.Password = "123456";
            view.PasswordConfirm = "123456";
        
            return View(view);
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserView view)
        {
            if (ModelState.IsValid)
            {
                const string folder = "~/Content/Users";

                var pic = view.Picture;

                if (view.PictureFile != null)
                {
                 
                    var guid = Guid.NewGuid().ToString();
                    var file = string.Format("{0}.jpg", guid);

                   

                    pic = Files.UploadPhoto(view.PictureFile, folder, file);
                    pic = string.Format("{0}/{1}", folder, pic);

                }

                var user = ToUser(view);
                user.Picture = pic;
                _db.Entry(user).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                //var shopUser = new ShopUser
                //{
                //    ShopId = view.ShopId,
                //    UserId = view.UserId
                //};
                //try
                //{
                //    _db.Entry(shopUser).State = EntityState.Modified;
                //    await _db.SaveChangesAsync();
                //}
                //catch (Exception)
                //{
                //    _db.ShopUsers.Add(shopUser);
                //    await _db.SaveChangesAsync();
                //}

                return RedirectToAction("Index");
            }
             ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.StatusId == 1 || p.StatusId == 2), "StatusId", "Name", view.StatusId);

            ViewBag.UserTypeId = new SelectList(_db.UserTypes, "UserTypeId", "Name", view.UserTypeId);
            return View(view);
        }

        public async Task<ActionResult> ResetPass(int id)
        {
            var conectedUserid = await GetUserId();
            var conectedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserId == conectedUserid);

            if (conectedUser == null)
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Su usuario no se encontro!!!" });
            }

            if (!await UsersHelper.IsAdmin(conectedUserid))
            {
                return RedirectToAction("Index", "Users", new { area = "Pos", message = "Esta opcion esta Reservada para los Administradores de Sistema!!!" });
            }
            try
            {
                


                var user = await _db.Users.FindAsync(id);

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

              
                var response1 = userManager.RemovePassword(userAsp.Id);
                var response2 = await userManager.AddPasswordAsync(userAsp.Id, "824455");
                if (response2.Succeeded)
                {
                    

                    return RedirectToAction("Index", "Users", new { area = "Pos", message = "Contraseña Cambiada Satisfactoriamente a: 824455" });
                }
                return View("Error");
               

            }
            catch (Exception)
            {
                return View("Error");
              
            }
        }

       

    }
}
