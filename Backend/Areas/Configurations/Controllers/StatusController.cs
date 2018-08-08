namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain;
    using Domain.GEN;

    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        private readonly DataContext _db = new DataContext();

        // GET: Configurations/Status
        public async Task<ActionResult> Index()
        {
            return View(await _db.Status.ToListAsync());
        }
        
        // GET: Configurations/Status/Create
        public  ActionResult  Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Status status)
        {
            if (ModelState.IsValid)
            {
                _db.Status.Add(status);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(status);
        }

          public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                 return View("Error");
            }
            Status status = await _db.Status.FindAsync(id);
            if (status == null)
            {
                return View("Error");
            }
            return View(status);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Status status)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(status).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(status);
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
