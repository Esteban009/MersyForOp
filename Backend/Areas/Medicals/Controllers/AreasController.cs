namespace Backend.Areas.Medicals.Controllers
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Backend.Controllers;
    using ExternalLibs;
    using Domain.MED;
    using CommonTasksLib.Data;

    public class AreasController : PsBaseController
    {

      [RoleAuthorizationFilter(1, "Areas")]
        public async Task<ActionResult> Index()
        {
            var authorId = await GetAuthorId();
            
            var hasHistory = await _db.Areas.FirstOrDefaultAsync(p => p.AuthorId == authorId);

            if (hasHistory == null)
            {
                return RedirectToAction("Create");
            }

            var myListToReturn = _db.Areas.OrderBy(p => p.Name);

            return View(await myListToReturn.ToListAsync());

        }

        [RoleAuthorizationFilter(2, "Areas")]
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var myMainElement = await _db.Areas.FindAsync(id);
            if (myMainElement == null)
            {
                return View("Error");
            }

            ViewBag.StatusId = _db.Status.Where(p => p.Table == "ALL")
                .ToSelectListItems(p => p.Name, p => p.StatusId.ToString(), l => l.StatusId == myMainElement.StatusId);
            //value to display, clave o id (debe ser to string), un lamda con el valor seleccionado

            return View(myMainElement);

        }

     [RoleAuthorizationFilter(3, "Areas")]
        public async Task<ActionResult> Create()
        {

            ViewBag.StatusId = _db.Status.Where(p => p.Table == "ALL")
                .ToSelectListItems(p => p.Name, p => p.StatusId.ToString());
            var authorId = await GetAuthorId();

            var myMainElement = new Area
            {
                AuthorId = authorId,
                StatusId = 1
            };

            return View(myMainElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Area myMainElement)
        {
            if (ModelState.IsValid)
            {
                _db.Areas.Add(myMainElement);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = _db.Status.Where(p => p.Table == "ALL")
                .ToSelectListItems(p => p.Name, p => p.StatusId.ToString(), l => l.StatusId == myMainElement.StatusId);

            return View(myMainElement);
        }

        [RoleAuthorizationFilter(4, "Areas")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var myMainElement = await _db.Areas.FindAsync(id);

            if (myMainElement == null)
            {
                return View("Error");
            }

            ViewBag.StatusId = _db.Status.Where(p => p.Table == "ALL")
                .ToSelectListItems(p => p.Name, p => p.StatusId.ToString(), l => l.StatusId == myMainElement.StatusId);

            return View(myMainElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Area myMainElement)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(myMainElement).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = _db.Status.Where(p => p.Table == "ALL")
                .ToSelectListItems(p => p.Name, p => p.StatusId.ToString(), l => l.StatusId == myMainElement.StatusId);

            return View(myMainElement);
        }

        [RoleAuthorizationFilter(5, "Areas")]
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var myMainElement = await _db.Areas.FindAsync(id);

            if (myMainElement == null)
            {
                return View("Error");
            }

            var autorid = await GetAuthorId();

            if (myMainElement.AuthorId != autorid)
            {
                return View("Error");
            }

            myMainElement.StatusId = 2;

            _db.Entry(myMainElement).State = EntityState.Modified;

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

        public async Task<ActionResult> IndexFilter(int opParam = 0, string param = "")
        {
               var authorid = await GetAuthorId();
           // var model = _db.Areas.Include(p => p.Person.Gender)
            var model = _db.Areas  
                .Where(p => p.AuthorId == authorid && p.StatusId == 1);

            //if (!response)
            //{
            //    return Json("", JsonRequestBehavior.AllowGet);
            //}

            if (opParam == 1)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Name.ToUpper().Contains(param.ToUpper()));
            }
            //if (opParam == 2)
            //{
            //    model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.LastName.ToUpper().Contains(param.ToUpper()));
            //}
            //if (opParam == 3)
            //{
            //    model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.Email.ToUpper().Contains(param.ToUpper()));
            //}
            //if (opParam == 4)
            //{
            //    model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.Rnc.ToUpper().Contains(param.ToUpper()));
            //}
            //if (opParam == 5)
            //{
            //    model = model.Where(p => string.IsNullOrEmpty(param) || p.Record2.ToUpper().Contains(param.ToUpper()));
            //}

           // model = model.OrderByDescending(p => p.Name).Take(50);
            model = model.OrderByDescending(p => p.Name);
            //  take toma la cantidad de resultados descrito
            //     skip omite la cantidad de registros
            var result = RenderRazorViewToString("_ModelTablePartial", await model.ToListAsync());
            return Json(new { Table = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
