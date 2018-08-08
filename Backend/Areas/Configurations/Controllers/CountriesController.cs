namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain;
    using Domain.GEN;

    [Authorize(Roles = "Admin")]
    public class CountriesController : Controller
    {
        private readonly DataContext _db = new DataContext();

        // GET: Configurations/Countries
        public async Task<ActionResult> Index()
        {
            return View(await _db.Countries.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _db.Countries.Add(country);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var country = await _db.Countries.FindAsync(id);
            if (country == null)
            {
                return View("Error");
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Country country)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(country).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(country);
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
