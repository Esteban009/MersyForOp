namespace Backend.Areas.Medicals.Controllers
{
    using Domain.GEN;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using Domain.MED;
    using System;
    using System.Linq;
    using Backend.Controllers;

    [Authorize(Roles = "User")]
    public class LaboratoriesController : PsBaseController
    {

        public async Task<JsonResult> GetLabTests(int id)
        {
            var authorId = await GetAuthorId();
            _db.Configuration.ProxyCreationEnabled = false;
            var dbList = _db.Laboratories.Where(m => m.AuthorId == authorId).OrderBy(p=>p.Name);

            var rtList = dbList.Select(item => new GenericList
                {
                    Id = item.LaboratoryId,
                    Name = item.Name
                })
                .ToList();
            //foreach (var item in dbList)
            //{
            //    var element = new GenericList
            //    {
            //        Id = item.LaboratoryId,
            //        Name = item.Name
            //    };
            //    rtList.Add(element);
            //}
            return Json(rtList);
        }
        public JsonResult GetLabPosibleResults(int id)
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var dbList = _db.LaboratoryDetails.Where(m => m.LaboratoryId == id).OrderBy(p => p.Result);

            var rtList = dbList.Select(item => new GenericList
                {
                    Id = item.LaboratoryDetailId,
                    Name = item.Result
                })
                .ToList();
            return Json(rtList);
        }

        public async Task<ActionResult> CreateResult(int id, int patientId = 0, bool fromCreate = false)
        {
            var authorId = await GetAuthorId();
            var laboratory = await _db.Laboratories.FindAsync(id);
            if (laboratory != null && laboratory.AuthorId != authorId)
            {
                return View("Error");
            }
            // var labRes = new LaboratoryDetail { LaboratoryId = id, PatientId = patientId, FromCreate = fromCreate, AuthorId = authorId };
            var labRes = new LaboratoryDetail { LaboratoryId = id, PatientId = patientId, FromCreate = fromCreate };

            return View(labRes);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateResult(LaboratoryDetail laboratory)
        {
            if (!ModelState.IsValid) return View(laboratory);
            var authorId = await GetAuthorId();

            var lab = await _db.Laboratories.FindAsync(laboratory.LaboratoryId);
            if (lab != null && lab.AuthorId != authorId)
            {
                return View("Error");
            }
            _db.LaboratoryDetails.Add(laboratory);
            await _db.SaveChangesAsync();

            if (laboratory.PatientId == 0)
                return RedirectToAction(string.Format("Details/{0}", laboratory.LaboratoryId));
            return laboratory.FromCreate ? RedirectToAction("CreateAnalyticals", "Patients", new { area = "Medicals", id = laboratory.PatientId }) : RedirectToAction("EditLaboratoryResults", "Patients", new { area = "Medicals", id = laboratory.LaboratoryDetailId });
        }

        public async Task<ActionResult> EditResult(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laboratory = await _db.LaboratoryDetails.FindAsync(id);
            if (laboratory == null)
            {
                return View("Error");
            }
            var authorId = await GetAuthorId();
            var lab = await _db.Laboratories.FindAsync(laboratory.LaboratoryId);
            if (lab != null && lab.AuthorId != authorId)
            {
                return View("Error");
            }
            return View(laboratory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditResult(LaboratoryDetail laboratory)
        {
            if (!ModelState.IsValid) return View(laboratory);
            var authorId = await GetAuthorId();
            var lab = await _db.Laboratories.FindAsync(laboratory.LaboratoryId);
            if (lab != null && lab.AuthorId != authorId)
            {
                return View("Error");
            }
            _db.Entry(laboratory).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", laboratory.LaboratoryId));
        }

        public async Task<ActionResult> DeleteResult(int? id)
        {
            var authorId = await GetAuthorId();
            var laboratory = await _db.LaboratoryDetails.FindAsync(id);
            if (laboratory != null)
            {
                var lab = await _db.Laboratories.FindAsync(laboratory.LaboratoryId);
                if (lab != null && lab.AuthorId != authorId)
                {
                    return View("Error");
                }
            }
            if (laboratory == null) return View("Error");
            _db.LaboratoryDetails.Remove(laboratory);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("Error");
            }

            return RedirectToAction(string.Format("Details/{0}", laboratory.LaboratoryId));
        }

        public async Task<ActionResult> AddResult(string id, int patientId = 0, bool fromCreate = false)
        {
            if (id == "")
            {
                return View("Error");
            }
            var laboratory = await _db.Laboratories.FirstOrDefaultAsync(p => p.Name == id);
            return laboratory == null ? RedirectToAction("Create") : RedirectToAction("CreateResult", new { id = laboratory.LaboratoryId, patientId, fromCreate });
        }

        public async Task<ActionResult> Index()
        {
            var authorId = await GetAuthorId();
            var labs = _db.Laboratories.Where(p => p.AuthorId == authorId).OrderBy(p => p.Name);
            // var labs = _db.Laboratories.OrderBy(p => p.Name);
            return View(labs);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var laboratory = await _db.Laboratories.FindAsync(id);
            if (laboratory == null)
            {
                return View("Error");
            }
            return View(laboratory);
        }

        public async Task<ActionResult> Create()
        {
            // var authorId = await GetAuthorId();
            //var lab = new Laboratory { AuthorId = authorId };
            var authorId = await GetAuthorId();
            var lab = new Laboratory { AuthorId = authorId };
            ViewBag.LabClasificationId = new SelectList(_db.LabClasifications, "LabClasificationId", "Name");

            return View(lab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Laboratory laboratory)
        {
            if (!ModelState.IsValid) return View(laboratory);
            var authorId = await GetAuthorId();
            if (laboratory.AuthorId != authorId)
            {
                return View("Error");
            }
            _db.Laboratories.Add(laboratory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return View("Error");
            var laboratory = await _db.Laboratories.FindAsync(id);
            if (laboratory == null) return View("Error");
            var authorId = await GetAuthorId();
            ViewBag.LabClasificationId = new SelectList(_db.LabClasifications, "LabClasificationId", "Name",laboratory.LabClasificationId);

            return laboratory.AuthorId != authorId ? View("Error") : View(laboratory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Laboratory laboratory)
        {
            if (!ModelState.IsValid) return View(laboratory);
            var authorId = await GetAuthorId();
            if (laboratory.AuthorId != authorId)
            {
                return View("Error");
            }
            _db.Entry(laboratory).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            var laboratory = await _db.Laboratories.FindAsync(id);
            if (laboratory != null) _db.Laboratories.Remove(laboratory);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("Error");
            }

            return RedirectToAction("Index");

        }       

    }
}
