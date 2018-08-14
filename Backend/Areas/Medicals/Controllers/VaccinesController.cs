namespace Backend.Areas.Medicals.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain;
    using Domain.MED;
    using Backend.Controllers;

    public class VaccinesController : PsBaseController
    {        
        // GET: Medicals/Vaccines
        public async Task<ActionResult> Index()
        {
            return View(await _db.Vaccines.ToListAsync());
        }

        // GET: Medicals/Vaccines/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var vaccine = await _db.Vaccines.FindAsync(id);
            return vaccine == null ? View("Error") : View(vaccine);
        }

        // GET: Medicals/Vaccines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicals/Vaccines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VaccineId,Code,Name")] Vaccine vaccine)
        {
            if (!ModelState.IsValid) return View(vaccine);
            _db.Vaccines.Add(vaccine);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Medicals/Vaccines/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var vaccine = await _db.Vaccines.FindAsync(id);
            return vaccine == null ? View("Error") : View(vaccine);
        }

        // POST: Medicals/Vaccines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VaccineId,Code,Name")] Vaccine vaccine)
        {
            if (!ModelState.IsValid) return View(vaccine);
            _db.Entry(vaccine).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Medicals/Vaccines/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var vaccine = await _db.Vaccines.FindAsync(id);
            return vaccine == null ? View("Error") : View(vaccine);
        }

        // POST: Medicals/Vaccines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var vaccine = await _db.Vaccines.FindAsync(id);
            if (vaccine != null) _db.Vaccines.Remove(vaccine);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
      
    }
}
