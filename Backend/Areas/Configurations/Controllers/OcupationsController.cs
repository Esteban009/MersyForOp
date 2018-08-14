namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Backend.Controllers;
    using Domain.GEN;

    [Authorize(Roles = "Admin")]
    public class OcupationsController : PsBaseController
    {
        public async Task<ActionResult> Index()
        {
            return View(await _db.Ocupations.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                _db.Ocupations.Add(ocupation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ocupation);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Ocupation ocupation = await _db.Ocupations.FindAsync(id);
            if (ocupation == null)
            {
                return View("Error");
            }
            return View(ocupation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ocupation).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ocupation);
        }
        
    }
}
