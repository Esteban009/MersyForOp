namespace Backend.Areas.Configurations.Controllers
{
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Domain.GEN;
    using Backend.Controllers;

    [Authorize(Roles = "Admin")]
    public class AuthorPlansController : PsBaseController
    {
        #region Option

        public async Task<ActionResult> DetailsOption(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var authorPlan = await _db.AuthorPlans.FindAsync(id);
            if (authorPlan == null)
            {
                return HttpNotFound();
            }
            return View(authorPlan);
        }

        public ActionResult CreateOption(int id)
        {
            var option = new AuthorPlanOption{AuthorPlanId=id};
            ViewBag.OptionId = new SelectList(_db.Options.OrderBy(p=>p.Description), "OptionId", "Description");
                return View(option);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOption(AuthorPlanOption option)
        {
            if (ModelState.IsValid)
            {
                _db.AuthorPlanOptions.Add(option);
                await _db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}",option.AuthorPlanId));
            }

            ViewBag.OptionId = new SelectList(_db.Options.OrderBy(p => p.Description), "OptionId", "Description", option.OptionId);
            return View(option);
        }

        public async Task<ActionResult> EditOption(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var option = await _db.AuthorPlanOptions.FindAsync(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            ViewBag.OptionId = new SelectList(_db.Options.OrderBy(p => p.Description), "OptionId", "Description", option.OptionId);
            return View(option);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOption(AuthorPlanOption option)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(option).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OptionId = new SelectList(_db.Options.OrderBy(p => p.Description), "OptionId", "Description", option.OptionId);
            return View(option);
        }

        public async Task<ActionResult> DeleteOption(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var option = await _db.AuthorPlanOptions.FindAsync(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        [HttpPost, ActionName("DeleteOption")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOptionConfirmed(int id)
        {
            var option = await _db.AuthorPlanOptions.FindAsync(id);
            _db.AuthorPlanOptions.Remove(option);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region Plans

        public async Task<ActionResult> Index()
        {
            var authorPlans = _db.AuthorPlans.Include(a => a.Currency).Include(a => a.Periodicity);
            return View(await authorPlans.ToListAsync());
        }

      public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var authorPlan = await _db.AuthorPlans.FindAsync(id);
            if (authorPlan == null)
            {
                return HttpNotFound();
            }
            return View(authorPlan);
        }

        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(_db.Currencies, "CurrencyId", "Name");
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(   AuthorPlan authorPlan)
        {
            if (ModelState.IsValid)
            {
                _db.AuthorPlans.Add(authorPlan);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(_db.Currencies, "CurrencyId", "Name", authorPlan.CurrencyId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", authorPlan.PeriodicityId);
            return View(authorPlan);
        }

     public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var authorPlan = await _db.AuthorPlans.FindAsync(id);
            if (authorPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(_db.Currencies, "CurrencyId", "Name", authorPlan.CurrencyId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", authorPlan.PeriodicityId);
            return View(authorPlan);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(  AuthorPlan authorPlan)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(authorPlan).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(_db.Currencies, "CurrencyId", "Name", authorPlan.CurrencyId);
            ViewBag.PeriodicityId = new SelectList(_db.Periodicities, "PeriodicityId", "Name", authorPlan.PeriodicityId);
            return View(authorPlan);
        }

      public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var authorPlan = await _db.AuthorPlans.FindAsync(id);
            if (authorPlan == null)
            {
                return HttpNotFound();
            }
            return View(authorPlan);
        }

     [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AuthorPlan authorPlan = await _db.AuthorPlans.FindAsync(id);
            _db.AuthorPlans.Remove(authorPlan);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
              
    }
}
