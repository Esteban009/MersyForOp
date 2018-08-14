namespace Backend.Areas.Medicals.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Domain.MED;
    using Backend.Controllers;

    public class InsurancesController : PsBaseController
    {
               // GET: Medicals/Insurances
        public async Task<ActionResult> Index()
        {
            return View(await _db.Insurances.ToListAsync());
        }

        // GET: Medicals/Insurances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var insurance = await _db.Insurances.FindAsync(id);
            return insurance == null ? View("Error") : View(insurance);
        }

        // GET: Medicals/Insurances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicals/Insurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InsuranceId,Code,Name,AditionalInfo")] Insurance insurance)
        {
            if (!ModelState.IsValid) return View(insurance);
            _db.Insurances.Add(insurance);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Medicals/Insurances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var insurance = await _db.Insurances.FindAsync(id);
            return insurance == null ? View("Error") : View(insurance);
        }

        // POST: Medicals/Insurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InsuranceId,Code,Name,AditionalInfo")] Insurance insurance)
        {
            if (!ModelState.IsValid) return View(insurance);
            _db.Entry(insurance).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Medicals/Insurances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var insurance = await _db.Insurances.FindAsync(id);
            return insurance == null ? View("Error") : View(insurance);
        }

        // POST: Medicals/Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var insurance = await _db.Insurances.FindAsync(id);
            if (insurance != null) _db.Insurances.Remove(insurance);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
               
    }
}
