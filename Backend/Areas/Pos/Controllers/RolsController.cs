namespace Backend.Areas.Pos.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Helpers;
    using Domain.SEG;
    using Backend.Controllers;

    public class RolsController : PsBaseController
    {
        public async Task<ActionResult> Index(string message = "")
        {
            var conectedUserid = await GetUserId();
            var conectedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserId == conectedUserid);
            var rolList = new List<Rol>();
            if (conectedUser == null)
            {
                ViewBag.StatusMessage = "Su usuario no se encontro!!!";
                return View(rolList.ToList());
            }

            if (!await UsersHelper.IsAdmin(conectedUserid))
            {
                // var user = new List<User>();
                ViewBag.StatusMessage = "Esta opcion esta Reservada para los Administradores de Sistema!!!";
                return View(rolList.ToList());
            }


            var authorid = await GetAuthorId();
            ViewBag.StatusMessage = message;
            var rols = _db.Rols.Where(p => p.AuthorId == authorid).Include(r => r.Author).Include(r => r.Status).OrderBy(p => p.StatusId);
            return View(await rols.ToListAsync());
        }

        public async Task<ActionResult> Create()
        {
            var userid = await GetUserId();
            var userConected = await _db.Users.FirstOrDefaultAsync(u => u.UserId == userid);

            if (userConected == null)
            {
                return RedirectToAction("Index", "Rols", new { area = "Pos", message = "Su usuario no se encontro!!!" });
            }

            if (!await UsersHelper.IsAdmin(userid))
            {
                return RedirectToAction("Index", "Rols", new { area = "Pos", message = "Esta opcion esta Reservada para los Administradores de Sistema!!!" });
            }

            var authorid = await GetAuthorId();
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name");
            var view = new Rol { AuthorId = authorid, Level = 5 };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                switch (rol.Level)
                {
                    case 1:
                        ModelState.AddModelError(string.Empty,
                            @"Este nivel esta reservado, para usuarios ROOT");
                        break;
                    case 0:
                        ModelState.AddModelError(string.Empty,
                            @"Debe digitar un numero distinto de 0");
                        break;
                    default:
                        rol.StatusId = 1;
                        _db.Rols.Add(rol);
                        await _db.SaveChangesAsync();
                        return RedirectToAction("Index");
                }
            }

            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", rol.StatusId);
            return View(rol);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var rol = await _db.Rols.FindAsync(id);
            if (rol == null)
            {
                return View("Error");
            }
            ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name", rol.AuthorId);
            ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.StatusId == 1 || p.StatusId == 2), "StatusId", "Name", rol.StatusId);

            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Rol rol)
        {
            switch (rol.Level)
            {
                case 1:
                    ModelState.AddModelError(string.Empty,
                        @"Este nivel esta reservado, para usuarios ROOT");
                    break;
                case 0:
                    ModelState.AddModelError(string.Empty,
                        @"Debe digitar un numero distinto de 0");
                    break;
                default:
                    _db.Entry(rol).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
            }



            ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.StatusId == 1 || p.StatusId == 2), "StatusId", "Name", rol.StatusId);
            // ViewBag.StatusId = new SelectList(_db.Status.OrderBy(ut => ut.Name), "StatusId", "Name", rol.StatusId);
            ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name"); ViewBag.AuthorId = new SelectList(_db.Authors.OrderBy(ut => ut.Name), "AuthorId", "Name", rol.AuthorId);

            return View(rol);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var rol = await _db.Rols.FindAsync(id);
            if (rol == null)
            {
                return View("Error");
            }
            _db.Rols.Remove(rol);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
