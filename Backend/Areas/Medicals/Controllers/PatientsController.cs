namespace Backend.Areas.Medicals.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;
    using Helpers;
    using CommonTasksLib.Data;
    using Domain.GEN;
    using Domain.MED;
    using PsTools;
    using System.IO;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using Backend.Controllers;
    using Backend.ExternalLibs;

    //[Authorize(Roles = "User")]
    public class PatientsController : PsBaseController
    {
       

        #region PatientController

        //[RoleAuthorizationFilter(1, "MedHist")]
        public async Task<ActionResult> MedHist()
        {
            //var userId = await GetUserId();

            //var user = await _db.Users.FindAsync(userId);

            //if (user == null)
            //{
            //    return View("Error");
            //}

           // return View(user);
            return View();
        }

        [RoleAuthorizationFilter(1, "MedHist")]
        public async Task<ActionResult> Index()
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 1);
            var authorid = await GetAuthorId();
            var model = _db.Patients.Include(p => p.Person.Author).Include(p => p.Person.Country).Include(
                  p => p.Person.Gender).Include(p => p.Person.MaritalSituation).Include(
                  p => p.Person.SchoolLevel).Include(p => p.Person.Ocupation).Include(
                  p => p.Person.Religion).Include(p => p.Person.Status)
                .Where(p => p.Person.AuthorId == authorid && p.Person.StatusId == 1)
                .OrderByDescending(p => p.PersonId).Take(50);

            return View(await model.ToListAsync());
        }

        public async Task<ActionResult> PatientFilter(int opParam = 0, string param = "")
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 1);
            var authorid = await GetAuthorId();
            //var model = _db.Patients.Include(p => p.Person.Author).Include(p => p.Person.Country).Include(
            //      p => p.Person.Gender).Include(p => p.Person.MaritalSituation).Include(
            //      p => p.Person.SchoolLevel).Include(p => p.Person.Ocupation).Include(
            //      p => p.Person.Religion).Include(p => p.Person.Status)
            //    .Where(p => p.Person.AuthorId == authorid && p.Person.StatusId == 1);
            var model = _db.Patients.Include(p => p.Person.Gender)
              .Where(p => p.Person.AuthorId == authorid && p.Person.StatusId == 1);
            if (!response)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

            if (opParam == 1)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.Name.ToUpper().Contains(param.ToUpper()));
            }
            if (opParam == 2)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.LastName.ToUpper().Contains(param.ToUpper()));
            }
            if (opParam == 3)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.Email.ToUpper().Contains(param.ToUpper()));
            }
            if (opParam == 4)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Person.Rnc.ToUpper().Contains(param.ToUpper()));
            }
            if (opParam == 5)
            {
                model = model.Where(p => string.IsNullOrEmpty(param) || p.Record2.ToUpper().Contains(param.ToUpper()));
            }

            model = model.OrderByDescending(p => p.PersonId).Take(50);
            //  take toma la cantidad de resultados descrito
            //     skip omite la cantidad de registros
            var result = RenderRazorViewToString("_PatientsTablePartial", await model.ToListAsync());
            return Json(new { Table = result }, JsonRequestBehavior.AllowGet);
        }

        [RoleAuthorizationFilter(1, "MedHist")]
        public async Task<ActionResult> Details(int? id)
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 2);
            if (!response)
            {
                return View("Error");
            }
            if (id == null)
            {
                return View("Error");
            }

            var patient = await _db.Patients.FindAsync(id);

            if (patient == null)
            {
                return View("Error");
            }
            var autorid = await GetAuthorId();

            if (patient.Person.AuthorId != autorid)
            {
                return View("Error");
            }
            var person = await _db.People.FindAsync(patient.PersonId);

            if (person == null)
            {
                return View("Error");
            }

            ViewBag.UserId = userId;
            //  ViewBag.AuthorId = autorid;
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", person.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", person.GenderId);
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", person.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", person.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", person.ReligionId);
            //  ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", person.StatusId);
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", patient.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", patient.InsuranceId);
            //  ViewBag.PersonId = new SelectList(_db.People, "PersonId", "PersonId", patient.PersonId);
            ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name", person.SchoolLevelId);

            var view = ToView(person, patient);

            return View(view);
        }

        [RoleAuthorizationFilter(1, "MedHist")]
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 3);
            if (!response)
            {
                return View("Error");
            }
            var authorId = await GetAuthorId();
            //  ViewBag.AuthorId = authorId;
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name");
            ViewBag.GenderId = new SelectList(_db.Genders.OrderBy(o => o.GenderId), "GenderId", "Name");
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations.OrderBy(m => m.MaritalSituationId), "MaritalSituationId", "Name");
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name");
            ViewBag.ReligionId = new SelectList(_db.Religions.OrderBy(o => o.ReligionId), "ReligionId", "Name");
            //   ViewBag.StatusId = 1;
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name");
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name");
            //ViewBag.PersonId = new SelectList(_db.People, "PersonId", "PersonId");
            ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name");


            var view = new PatientView() { AuthorId = authorId };
            //var view = new PatientView();
            return View(view);
        }

        private static PatientView ToView(Person pview, Patient view)
        {
            if (pview == null) throw new ArgumentNullException(nameof(pview));
            if (view == null) throw new ArgumentNullException(nameof(view));

            var m = new PatientView(); //el tipo que vamos a devolver
            pview.Transfer(ref m);
            view.Transfer(ref m);
            m.FullName = pview.Name + " " + pview.LastName;
            return m;

            //return new PatientView()
            //{
            //    //PersonId = pview.PersonId,
            //    //AuthorId = pview.AuthorId,
            //    //Imagen = pview.Imagen,
            //    //StatusId = pview.StatusId,
            //    //Address = pview.Address,
            //    //ReligionId = pview.ReligionId,
            //    //OcupationId = pview.OcupationId,
            //    //MaritalSituationId = pview.MaritalSituationId,
            //    //Cel = pview.Cel,
            //    //Tel = pview.Tel,
            //    //Email = pview.Email,
            //    //CountryId = pview.CountryId,
            //    //GenderId = pview.GenderId,
            //    //BornDate = pview.BornDate,
            //    //LastName = pview.LastName,
            //    //Name = pview.Name,
            //    //Rnc = pview.Rnc,
            //    //PatientId = view.PatientId,
            //    //Record = view.Record,
            //    //CreationDate = view.CreationDate,
            //    //InsuranceId = view.InsuranceId,
            //    //BloodTypeId = view.BloodTypeId,
            //    //SchoolLevelId = pview.SchoolLevelId,
            //    //Age = view.Age,
            //    FullName = pview.Name + " " + pview.LastName

            //};
        }

        private static Person ToPeople(PatientView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));

            var m = new Person(); //el tipo que vamos a devolver
            view.Transfer(ref m);
            return m;

            //return new Person
            //{
            //    PersonId = view.PersonId,
            //    AuthorId = view.AuthorId,
            //    Imagen = view.Imagen,
            //    StatusId = view.StatusId,
            //    Address = view.Address,
            //    ReligionId = view.ReligionId,
            //    OcupationId = view.OcupationId,
            //    MaritalSituationId = view.MaritalSituationId,
            //    Cel = view.Cel,
            //    Tel = view.Tel,
            //    Email = view.Email,
            //    CountryId = view.CountryId,
            //    GenderId = view.GenderId,
            //    BornDate = view.BornDate,
            //    LastName = view.LastName,
            //    Name = view.Name,
            //    Rnc = view.Rnc
            //};
        }

        private static Patient ToPatient(PatientView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            var m = new Patient(); //el tipo que vamos a devolver
            view.Transfer(ref m);
            return m;
            //return new Patient()
            //{
            //    PersonId = view.PersonId,
            //    PatientId = view.PatientId,
            //    Record = view.Record,
            //    CreationDate = view.CreationDate,
            //    InsuranceId = view.InsuranceId,
            //    BloodTypeId = view.BloodTypeId,
            //    Age = view.Age

            //};
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientView view)
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 3);
            if (!response)
            {
                return View("Error");
            }
            if (ModelState.IsValid)
            {

                var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

                if (doctor == null)
                {
                    return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
                }

                var pic = string.Empty;
                const string folder = "~/Content/Patients";

                if (view.ImageFile != null)
                {
                    pic = Files.UploadPhoto(view.ImageFile, folder, "");
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var person = ToPeople(view);
                person.Imagen = pic;
                if (person.Tel != null)
                {
                    person.Tel = Strings.RemoveCharacters(person.Tel);
                }
                if (person.Cel != null)
                {
                    person.Cel = Strings.RemoveCharacters(person.Cel);
                }
                if (person.Rnc != null)
                {
                    person.Rnc = Strings.RemoveCharacters(person.Rnc);
                }

                person.AuthorId = doctor.User.AuthorId;

                person.StatusId = 1;
                _db.People.Add(person);
                await _db.SaveChangesAsync();
                var patient = ToPatient(view);

                patient.PersonId = person.PersonId;
                patient.Record = MyAppHelper.GenerateRecord(person.AuthorId);

                if (string.IsNullOrEmpty(view.Record2))
                {
                    patient.Record2 = doctor.Prefix + patient.Record.ToString("00000");
                }

                _db.Patients.Add(patient);

                
                //var customer = new Customer
                //{
                //    CreditAmount=0,DebAmount=0,WastedAmount=0,Name=view.Name,LastName=view.LastName
                //};
                //customer.PersonId = person.PersonId;
                //customer.Code = MyAppHelper.GenerateRecord(doctor.User.AuthorId, 2);

                //_db.Customers.Add(customer);
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
                return RedirectToAction(string.Format("Details/{0}",patient.PatientId));
            }

            //   ViewBag.AuthorId =  view.AuthorId;
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "NAme", view.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders.OrderBy(o => o.GenderId), "GenderId", "Name",
                view.GenderId);
            ViewBag.MaritalSituationId =
                new SelectList(_db.MaritalSituations.OrderBy(m => m.MaritalSituationId), "MaritalSituationId",
                    "Name", view.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", view.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions.OrderBy(o => o.ReligionId), "ReligionId", "Name",
                view.ReligionId);
            // ViewBag.StatusId = view.StatusId;
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", view.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", view.InsuranceId);
            // ViewBag.PersonId = view.PersonId;
            ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name",
                view.SchoolLevelId);

            return View(view);
        }

        [RoleAuthorizationFilter(1, "MedHist")]
        public async Task<ActionResult> Edit(int? id)
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 4);
            if (!response)
            {
                return View("Error");
            }
            if (id == null)
            {
                return View("Error");
            }

            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return View("Error");
            }
            var autorid = await GetAuthorId();

            if (patient.Person.AuthorId != autorid)
            {
                return View("Error");
            }

            var person = await _db.People.FindAsync(patient.PersonId);

            if (person == null)
            {
                return View("Error");
            }

            //  ViewBag.AuthorId =  person.AuthorId;
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", person.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", person.GenderId);
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", person.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", person.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", person.ReligionId);
            //    ViewBag.StatusId =  person.StatusId;
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", patient.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", patient.InsuranceId);
            //   ViewBag.PersonId =  patient.PersonId;
            ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name", person.SchoolLevelId);

            var view = ToView(person, patient);
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientView view)
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 4);
            if (!response)
            {
                return View("Error");
            }
            if (ModelState.IsValid)
            {

                var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

                if (doctor == null)
                {
                    return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
                }

                const string folder = "~/Content/Patients";

                var pic = view.Imagen;

                if (view.ImageFile != null)
                {
                    pic = Files.UploadPhoto(view.ImageFile, folder, "");
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var people = ToPeople(view);
                people.Imagen = pic;
                if (people.Tel != null)
                { people.Tel = Strings.RemoveCharacters(people.Tel); }
                if (people.Cel != null)
                { people.Cel = Strings.RemoveCharacters(people.Cel); }
                if (people.Rnc != null)
                { people.Rnc = Strings.RemoveCharacters(people.Rnc); }

                var patient = ToPatient(view);

                if (string.IsNullOrEmpty(view.Record2))
                {
                    patient.Record2 = patient.Record2 = doctor.Prefix + patient.Record.ToString("00000");
                }

                _db.Entry(people).State = EntityState.Modified;
                _db.Entry(patient).State = EntityState.Modified;

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            //   var autorid = await GetAuthorId();

            //   ViewBag.AuthorId = autorid;
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", view.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", view.GenderId);
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", view.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", view.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", view.ReligionId);
            // ViewBag.StatusId =  view.StatusId;
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", view.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", view.InsuranceId);
            //   ViewBag.PersonId =  view.PersonId;
            ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name", view.SchoolLevelId);

            return View(view);
        }

        [RoleAuthorizationFilter(1, "MedHist")]
        public async Task<ActionResult> Delete(int? id)
        {
            var userId = await GetUserId();
            var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 5);
            if (!response)
            {
                return View("Error");
            }
            if (id == null)
            {
                return View("Error");
            }
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return View("Error");
            }
            var autorid = await GetAuthorId();

            if (patient.Person.AuthorId != autorid)
            {
                return View("Error");
            }
            patient.Person.StatusId = 2;
            //if (person != null) _db.People.Remove(person);
            _db.Entry(patient).State = EntityState.Modified;
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

        #endregion
               
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Metodo utilizado para obtener un ViewResult de una pagina parcial de la aplicacion en formato
        /// string.
        /// </summary>
        ///
        /// <remarks>   Cagonzalec, 7/5/2016. </remarks>
        ///
        /// <param name="viewName"> Nombre del view a obtener. </param>
        /// <param name="model">    Datos del modelo asociado a dicho view. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
