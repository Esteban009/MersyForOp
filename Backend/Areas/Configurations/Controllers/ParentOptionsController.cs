namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Domain;
    using Domain.SEG;
    using Backend.Controllers;

    [Authorize(Roles = "Admin")]
    public class ParentOptionsController : PsBaseController
    {       
        public async Task<ActionResult> Index()
        {
            var parentOptions = _db.ParentOptions.Include(p => p.Status);
            return View(await parentOptions.ToListAsync());
        }
        
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name");
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( ParentOption parentOption)
        {
            if (ModelState.IsValid)
            {
                _db.ParentOptions.Add(parentOption);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", parentOption.StatusId);
            return View(parentOption);
        }

        // GET: Configurations/ParentOptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var parentOption = await _db.ParentOptions.FindAsync(id);
            if (parentOption == null)
            {
                return View("Error");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", parentOption.StatusId);
            return View(parentOption);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( ParentOption parentOption)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(parentOption).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", parentOption.StatusId);
            return View(parentOption);
        }
               
    }
}
