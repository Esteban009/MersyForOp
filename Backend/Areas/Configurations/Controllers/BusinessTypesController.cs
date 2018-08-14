namespace Backend.Areas.Configurations.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Backend.Controllers;
    using Domain.GEN;

    [Authorize(Roles = "Admin")]
    public class BusinessTypesController : PsBaseController
    {     
        public async Task<ActionResult> Index()
        {
            return View(await _db.BusinessTypes.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BusinessType businessType)
        {
            if (ModelState.IsValid)
            {
                _db.BusinessTypes.Add(businessType);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(businessType);
        }

        // GET: Configurations/BusinessTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            BusinessType businessType = await _db.BusinessTypes.FindAsync(id);
            if (businessType == null)
            {
                return View("Error");
            }
            return View(businessType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BusinessType businessType)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(businessType).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(businessType);
        }
               
    }
}
