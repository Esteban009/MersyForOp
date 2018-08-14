namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Domain.SEG;
    using Backend.Controllers;

    [Authorize(Roles = "Admin")]
    public class OptionsController : PsBaseController
    {        
        public async Task<ActionResult> Index()
        {
            var options = _db.Options.Include(o => o.ParentOption).Include(o => o.Status);
            return View(await options.ToListAsync());
        }
        
        public ActionResult Create()
        {
            ViewBag.ParentOptionId = new SelectList(_db.ParentOptions, "ParentOptionId", "Name");
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Option option)
        {
            if (ModelState.IsValid)
            {
                _db.Options.Add(option);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParentOptionId = new SelectList(_db.ParentOptions, "ParentOptionId", "Name", option.ParentOptionId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", option.StatusId);
            return View(option);
        }
        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = await _db.Options.FindAsync(id);
            if (option == null)
            {
                return View("Error");
            }
            ViewBag.ParentOptionId = new SelectList(_db.ParentOptions, "ParentOptionId", "Name", option.ParentOptionId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", option.StatusId);
            return View(option);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Option option)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(option).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ParentOptionId = new SelectList(_db.ParentOptions, "ParentOptionId", "Name", option.ParentOptionId);
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", option.StatusId);
            return View(option);
        }        
       
    }
}
