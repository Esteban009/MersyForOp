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
    //using Domain.POS;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using Backend.Controllers;
    using Backend.ExternalLibs;

    [Authorize(Roles = "User")]
    public class PatientsController : PsBaseController
    {        

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public async Task<JsonResult> GetChartWeight(int Id)
        //{
        //    var Sales = await _db.PediatricGrowths.Where(p=>p.PediatricId == Id).ToListAsync();

        //    var chartData = new object[Sales.Count + 1];

        //    var alt = new TablaCrecimiento();

        //    chartData[0] = new object[]{
        //        "Meses",
        //        "Altura",
        //        "95%","75%"
        //    };

        //    int j = 0;
        //    foreach (var i in Sales)
        //    {
        //        j++;
        //        chartData[j] = new object[]
        //        {
        //            i.MonthCountId,
        //            i.Estatura,
        //            alt.Altura(i.MonthCountId),
        //            alt.Altura2(i.MonthCountId)
        //        };
        //    }


        //    return Json(chartData, JsonRequestBehavior.AllowGet);
        //}

        //#region AnalyticalDetailVisitsController
        //public async Task<ActionResult> CreateAnalyticalDetails(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalDetail", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //if (id == null)
        //    //{
        //    //    return View("Error");
        //    //}
        //    var analyticalDetailVisit = await _db.Analyticals.FindAsync(id);
        //    if (analyticalDetailVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalDetailVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    // var productList = _db.LaboratoryDetails.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name).ToList();
        //    //ViewBag.Products = productList;

        //    ViewBag.LaboratoryId = new SelectList(_db.Laboratories.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name), "LaboratoryId", "Name");

        //    ViewBag.LaboratoryDetailId = new SelectList(_db.LaboratoryDetails.OrderBy(p => p.Result), "LaboratoryDetailId", "Result");
        //    var view = new AnalyticalDetail { AnalyticalId = id };
        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAnalyticalDetails(AnalyticalDetail analyticalDetail)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalDetail", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(analyticalDetail);
        //    _db.AnalyticalDetails.Add(analyticalDetail);
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", AnalyticalDetailVisit.PatientId);
        //    // return RedirectToAction($"DetailsAnalyticalDetails/{AnalyticalDetailVisit.PatientId}");
        //    return RedirectToAction($"DetailsAnalyticals/{analyticalDetail.AnalyticalId}");
        //    // return View(AnalyticalDetail);
        //}

        //public async Task<ActionResult> EditAnalyticalDetails(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalDetail", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalDetailVisit = await _db.AnalyticalDetails.FindAsync(id);
        //    if (analyticalDetailVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalDetailVisit.Analytical.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    // var productList = _db.LaboratoryDetails.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name).ToList();
        //    //ViewBag.Products = productList;

        //    ViewBag.LaboratoryId = new SelectList(_db.Laboratories.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name), "LaboratoryId", "Name", analyticalDetailVisit.LaboratoryDetail.LaboratoryId);

        //    ViewBag.LaboratoryDetailId = new SelectList(_db.LaboratoryDetails.Where(p => p.LaboratoryId == analyticalDetailVisit.LaboratoryDetail.LaboratoryId).OrderBy(p => p.Result), "LaboratoryDetailId", "Result", analyticalDetailVisit.LaboratoryDetailId);

        //    return View(analyticalDetailVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAnalyticalDetails(AnalyticalDetail analyticalDetail)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalDetail", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(analyticalDetail);
        //    _db.Entry(analyticalDetail).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", AnalyticalDetailVisit.PatientId);
        //    // return RedirectToAction($"DetailsAnalyticalDetails/{AnalyticalDetailVisit.PatientId}");
        //    return RedirectToAction($"DetailsAnalyticals/{analyticalDetail.AnalyticalId}");
        //    // return View(AnalyticalDetail);
        //}

        //public async Task<ActionResult> DeleteAnalyticalDetails(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalDetail", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalDetails = await _db.AnalyticalDetails.FindAsync(id);
        //    if (analyticalDetails == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalDetails.Analytical.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.AnalyticalDetails.Remove(analyticalDetails);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsAnalyticals/{analyticalDetails.AnalyticalId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region AnalyticalsController

        //public async Task<ActionResult> AnalyticalsA4(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalsA4", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var lab = await _db.Analyticals.FindAsync(id);

        //    if (lab == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (lab.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, lab);

        //    ViewBag.RealizationDate = string.Format("{0:dd/MM/yyyy}", lab.RealizationDate);
        //    ViewBag.ResultDate = string.Format("{0:dd/MM/yyyy}", lab.ResultDate);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> AnalyticalsA4Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalsA4", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var lab = await _db.Analyticals.FindAsync(id);

        //    if (lab == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (lab.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, lab);

        //    ViewBag.RealizationDate = string.Format("{0:dd/MM/yyyy}", lab.RealizationDate);
        //    ViewBag.ResultDate = string.Format("{0:dd/MM/yyyy}", lab.ResultDate);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //private static AnalyticalsView ToView(Report rview, Analytical view)
        //{
        //    if (rview == null) throw new ArgumentNullException(nameof(rview));
        //    if (view == null) throw new ArgumentNullException(nameof(view));

        //    var m = new AnalyticalsView(); //el tipo que vamos a devolver
        //    rview.Transfer(ref m);
        //    view.Transfer(ref m);

        //    return m;

        //}

        //public async Task<ActionResult> IndexAnalyticals(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Analyticals.FirstOrDefaultAsync(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    if (hasHistory == null)
        //    {

        //        return RedirectToAction($"CreateAnalyticals/{id}");
        //    }

        //    var Analyticals = _db.Analyticals.Include(o => o.Patient).Where(p => p.PatientId == id).OrderByDescending(p => p.AnalyticalId);
        //    //ViewBag.PatientId = id;
        //    return View(await Analyticals.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsAnalyticals(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analytical = await _db.Analyticals.FindAsync(id);
        //    if (analytical == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analytical.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.Table == "Analitical"), "StatusId", "Name", analytical.StatusId);
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", Analytical.PatientId);
        //    return View(analytical);
        //}
        //[HttpGet]
        //public async Task<JsonResult> GetLaboratoryInfo(int id)
        //{
        //    // var shopId = await GetShopId();
        //    var pp = new string[4];
        //    // var purchase = _db.Products.FirstOrDefaultAsyncx => x.BarCode == id && x.AuthorId == authorid);
        //    var purchase = await _db.Laboratories.FirstOrDefaultAsync(x => x.LaboratoryId == id);

        //    if (purchase == null) return Json(pp, JsonRequestBehavior.AllowGet);

        //    // var getDiscount = 0;// crear una funcion para conseguir los descuentos

        //    pp[0] = purchase.Code.ToString();
        //    // pp[0] = purchase.ProductId.ToString();
        //    pp[1] = purchase.Unids.ToString();
        //    pp[2] = purchase.Methods.ToString();
        //    pp[3] = purchase.Reference.ToString();
        //    return Json(pp, JsonRequestBehavior.AllowGet);
        //}
        //public async Task<ActionResult> CreateAnalyticals(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var view = new Analytical { PatientId = patient.PatientId, AuthorId = autorid, RealizationDate = DateTime.Today };

        //    var productList = _db.Laboratories.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name).ToList();
        //    ViewBag.Products = productList;
        //    var clasificationList = _db.LabClasifications.OrderBy(p => p.Name).ToList();
        //    ViewBag.Clasifications = clasificationList;

        //    return View(view);
        //}
        //[HttpPost]
        //public async Task<JsonResult> SaveOrder(Analytical objAnalitical)
        //{

        //    bool status;
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var item in objAnalitical.AnalyticalDetails)
        //        {
        //            if (item.LaboratoryDetailId == 0)
        //            {
        //                var obj = _db.LaboratoryDetails.Where(p => p.Result == item.ResultText && p.LaboratoryId == item.LaboratoryId).FirstOrDefault();

        //                if (obj == null)
        //                {
        //                    var lDetail = new LaboratoryDetail
        //                    {
        //                        LaboratoryId = item.LaboratoryId,
        //                        Result = item.ResultText
        //                    };
        //                    _db.LaboratoryDetails.Add(lDetail);
        //                    await _db.SaveChangesAsync();
        //                    item.LaboratoryDetailId = lDetail.LaboratoryDetailId;
        //                }
        //                else
        //                {
        //                    item.LaboratoryDetailId = obj.LaboratoryDetailId;
        //                }


        //            }

        //        }

        //        var analiticalsList = new List<AnalyticalDetail>();
        //        objAnalitical.StatusId = 9;
        //        objAnalitical.RefNumber = MyAppHelper.GenerateRecord(objAnalitical.AuthorId, 1);
        //        _db.Analyticals.Add(objAnalitical);

        //        try
        //        {
        //            await _db.SaveChangesAsync();
        //            status = true;
        //            // return RedirectToAction($"DetailsAnalyticals/{objAnalitical.AnalyticalId}");
        //        }
        //        catch (Exception ex)
        //        {
        //            status = false;
        //        }
        //        // }
        //    }
        //    else
        //    {
        //        status = false;
        //    }

        //    return new JsonResult { Data = new { status } };
        //}

        //[HttpPost]
        //public async Task<JsonResult> SaveLaboratoryTest(Laboratory objlaboratory)
        //{

        //    bool status;
        //    if (ModelState.IsValid)
        //    {
        //        var authorId = await GetAuthorId();
        //        objlaboratory.AuthorId = authorId;
        //        _db.Laboratories.Add(objlaboratory);

        //        try
        //        {
        //            await _db.SaveChangesAsync();
        //            status = true;
        //            // return RedirectToAction($"DetailsAnalyticals/{objAnalitical.AnalyticalId}");
        //        }
        //        catch (Exception ex)
        //        {
        //            status = false;
        //        }
        //        // }
        //    }
        //    else
        //    {
        //        status = false;
        //    }

        //    return new JsonResult { Data = new { status } };
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAnalyticals(Analytical Analyticals)
        //{
        //    var userId = await GetUserId();
        //    //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 3);
        //    //    if (!response)
        //    //    {
        //    //        return View("Error");
        //    //    }
        //    //    if (ModelState.IsValid)
        //    //    {

        //    //        _db.Analyticals.Add(Analyticals);
        //    //        await _db.SaveChangesAsync();

        //    //        return RedirectToAction($"DetailsAnalyticals/{Analyticals.AnalyticalId}");
        //    //        //return RedirectToAction($"IndexAnalyticals/{Analyticals.PatientId}");
        //    //    }

        //    //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", Analyticals.PatientId);
        //    return View(Analyticals);

        //}

        //public async Task<ActionResult> EditAnalyticals(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticals = await _db.Analyticals.FindAsync(id);
        //    if (analyticals == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticals.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    if (analyticals.StatusId == 11)
        //    {
        //        return View("Error", "No se pueden editar unos resultados que fueron entregadas");
        //    }
        //    ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.Table == "Analitical"), "StatusId", "Name", analyticals.StatusId);
        //    return View(analyticals);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAnalyticals(Analytical analyticals)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(analyticals).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexAnalyticals/{Analyticals.PatientId}");
        //        return RedirectToAction($"DetailsAnalyticals/{analyticals.AnalyticalId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", Analyticals.PatientId);
        //    ViewBag.StatusId = new SelectList(_db.Status.Where(p => p.Table == "Analitical"), "StatusId", "Name", analyticals.StatusId);
        //    return View(analyticals);

        //}

        //public async Task<ActionResult> DeleteAnalyticals(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticals = await _db.Analyticals.FindAsync(id);
        //    if (analyticals == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticals.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var details = _db.AnalyticalDetails.Where(p => p.AnalyticalId == id).ToList();

        //    foreach (var item in details)
        //    {
        //        _db.AnalyticalDetails.Remove(item);
        //    }

        //    _db.Analyticals.Remove(analyticals);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexAnalyticals/{analyticals.PatientId}");

        //}

        //public async Task<ActionResult> DeliverAnalyticals(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Analytical", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticals = await _db.Analyticals.FindAsync(id);
        //    if (analyticals == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticals.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //var details = _db.AnalyticalDetails.Where(p => p.AnalyticalId == id).ToList();

        //    //foreach (var item in details)
        //    //{
        //    //    _db.AnalyticalDetails.Remove(item);
        //    //}
        //    //9,10,11
        //    analyticals.StatusId = 11;
        //    _db.Entry(analyticals).State = EntityState.Modified;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"DetailsAnalyticals/{analyticals.AnalyticalId}");

        //}

        //#endregion

        //#region Reports

        //public async Task<ActionResult> AppointmentMail(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var appointment = await _db.Appointments.FindAsync(id);

        //    if (appointment == null)
        //    {
        //        return View("Error");
        //    }

        //    var autorid = await GetAuthorId();

        //    if (appointment.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var userid = await GetUserId();
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }
        //    //*/*/*/*/*/*/*/enviar el correo
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(appointment.Patient.Person.Email))
        //        {
        //            var subject = $@"Recordatorio de Cita con el Doctor(a):  {
        //                    appointment.Doctor.User.FirstName + " " + appointment.Doctor.User.LastName
        //                }";
        //            var body = string.Format(@"
        //    <h1>Hola:&nbsp {0}</h1>
        //    <p>Este es un recordatorio de la cita que tienes el dia: <strong>{1:dd/MM/yyyy}</strong></p>
        //    <p>Para:&nbsp {2} </p><br> 
        //    <p> &nbsp {3} </p><br><br>
        //    Se despide cordialmente: &nbsp {4}<br><hr><p><span style='color: #0000ff;'>Has recibido esta Notificaci&oacute;n enviada desde el <strong>Sistema de Expedientes M&eacute;dicos</strong> <strong>MersyRD</strong>, ya que uno de nuestros clientes te tiene registrado como su paciente, si entiendes que esto es un error, favor notif&iacute;calo escribiendo un mail a: <strong><a href='mailto:sgermosen@praysoft.net'>sgermosen@praysoft.net</a></strong> con el asunto : '<strong>Removerme de Mersy</strong>'</span></p> <p> <br> Visita nuestra pagina web para mas información <a href = 'http://mersy.praysoft.net/'><strong> www.mersy.praysoft.net </strong ></a></p> ",
        //                appointment.Patient.Person.Name + " " + appointment.Patient.Person.LastName, Dates.FormatedDateDo(appointment.VisitDate.ToString()), appointment.VisitReason, appointment.Notes,
        //                appointment.Doctor.User.FirstName + " " + appointment.Doctor.User.LastName);

        //            var smtp = await _db.UserEmailSettings.FirstOrDefaultAsync(p => p.UserId == userid);

        //            if (smtp == null)
        //            {
        //                await Emails.SendMail(appointment.Patient.Person.Email, subject, body);
        //            }
        //            else
        //            {
        //                await Emails.SendMail(appointment.Patient.Person.Email, subject, body, smtp.Email, smtp.Password, smtp.HostNameSmtp, smtp.Port);
        //            }

        //            ViewBag.Msg = "Correo Enviado Satisfactoriamente";
        //        }
        //        else
        //        {
        //            ViewBag.Msg = "Este paciente no tiene correo electronico";
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Msg = "Ocurrio un error al intentar enviar el correo electronico";
        //    }



        //    // var view = ToView(report, appointment);

        //    return View();
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> AppointmentMailAll()
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", id = autorid });
        //    }


        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }

        //    var qry = await (from p in _db.Appointments
        //                     where p.DoctorId == doctor.DoctorId
        //                     select new { p }).ToListAsync();

        //    var results = (from item in qry
        //                   where item.p.VisitDate >= DateTime.Now.AddHours(-24)
        //                   select new Appointment
        //                   {
        //                       VisitDate = item.p.VisitDate,
        //                       VisitReason = item.p.VisitReason,
        //                       Notes = item.p.Notes,
        //                       WasSend = item.p.WasSend,
        //                       DoctorId = item.p.DoctorId,
        //                       PatientId = item.p.PatientId,
        //                       AppointmentId = item.p.AppointmentId,
        //                       Patient = item.p.Patient,
        //                       Doctor = item.p.Doctor
        //                   }).ToList();

        //    foreach (var item in results)
        //    {
        //        try
        //        {
        //            if (string.IsNullOrEmpty(item.Patient.Person.Email)) continue;
        //            if (item.WasSend == false)
        //            {
        //                var subject =
        //                    $@"Recordatorio de Cita con el Doctor(a):   {
        //                            item.Doctor.User.FirstName + " " + item.Doctor.User.LastName
        //                        }";
        //                var body = string.Format(@"
        //    <h1>Hola:&nbsp {0}</h1>
        //    <p>Este es un recordatorio de la cita que tienes el dia: <strong>{1:dd/MM/yyyy}</strong></p>
        //    <p>Para:&nbsp <strong> {2} </strong></p><br> 
        //    <p> &nbsp {3} </p><br><br>
        //    Se despide cordialmente: &nbsp {4}<br><hr><p><span style='color: #0000ff;'>Has recibido esta Notificaci&oacute;n enviada desde el <strong>Sistema de Expedientes M&eacute;dicos</strong> <strong>MersyRD</strong>, ya que uno de nuestros clientes te tiene registrado como su paciente, si entiendes que esto es un error, favor notif&iacute;calo escribiendo un mail a: <strong><a href='mailto:sgermosen@praysoft.net'>sgermosen@praysoft.net</a></strong> con el asunto : '<strong>Removerme de Mersy</strong>'</span></p> <p> <br> Visita nuestra pagina web para mas información <a href = 'http://mersy.praysoft.net/'><strong> www.mersy.praysoft.net </strong ></a></p> ",
        //                    item.Patient.Person.Name + " " + item.Patient.Person.LastName, Dates.FormatedDateDo(item.VisitDate.ToString()), item.VisitReason, item.Notes,
        //                    item.Doctor.User.FirstName + " " + item.Doctor.User.LastName);

        //                //var body = string.Format(@"
        //                //    <h1>Hola: {0}</h1>
        //                //    <p>Este es un recordatorio de la cita que tienes el dia: <strong>{1}</strong></p>
        //                //    <p>Para: {2} </p><br> 
        //                //    <p> {3} </p><br><br>
        //                //    Se despide cordialmente:{4}",
        //                //    item.Patient.Person.Name + " " + item.Patient.Person.LastName,
        //                //    item.VisitDate, item.VisitReason, item.Notes,
        //                //    item.Doctor.User.FirstName + " " + item.Doctor.User.LastName);

        //                var smtp = await _db.UserEmailSettings.FirstOrDefaultAsync(p => p.UserId == userId);

        //                if (smtp == null)
        //                {
        //                    await Emails.SendMail(item.Patient.Person.Email, subject, body);
        //                }
        //                else
        //                {
        //                    await Emails.SendMail(item.Patient.Person.Email, subject, body, smtp.Email, smtp.Password, smtp.HostNameSmtp, smtp.Port);
        //                }
        //                item.WasSend = true;
        //                //_db.Entry(item).State = EntityState.Modified;
        //                //  await _db.SaveChangesAsync();
        //            }
        //            await _db.SaveChangesAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Msg = "Ocurrio un error al intentar enviar el correo electronico";
        //        }

        //    }
        //    ViewBag.Msg = "Correos Enviados Satisfactoriamente";
        //    return View();
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> AnaliticalSheetA4(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var analiticalSheet = await _db.AnalyticalSheets.FindAsync(id);

        //    if (analiticalSheet == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analiticalSheet.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }
        //    //  var report = await _db.Reports.FindAsync(autorid);
        //    // var report = await _db.Reports.FindAsync(analiticalSheet.Patient.Person.AuthorId);

        //    //if (report == null)
        //    //{
        //    //    return RedirectToAction("Create", "Reports", new { area = "Configurations", id });
        //    //}

        //    var view = ToView(report, analiticalSheet);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> AnaliticalSheetA4Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var analiticalSheet = await _db.AnalyticalSheets.FindAsync(id);

        //    if (analiticalSheet == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analiticalSheet.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }
        //    //  var report = await _db.Reports.FindAsync(autorid);
        //    // var report = await _db.Reports.FindAsync(analiticalSheet.Patient.Person.AuthorId);

        //    //if (report == null)
        //    //{
        //    //    return RedirectToAction("Create", "Reports", new { area = "Configurations", id });
        //    //}

        //    var view = ToView(report, analiticalSheet);

        //    return View(view);
        //    //  return View(reportFilter);
        //}
        //public async Task<ActionResult> RecipeA4(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var recipe = await _db.Recipes.FindAsync(id);

        //    if (recipe == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (recipe.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, recipe);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> RecipeA6Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var recipe = await _db.Recipes.FindAsync(id);

        //    if (recipe == null)
        //    {
        //        return View("Error");
        //    }

        //    //var report = await _db.Reports.FindAsync(recipe.Patient.Person.AuthorId);
        //    var autorid = await GetAuthorId();

        //    if (recipe.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, recipe);

        //    return View(view);
        //    //  return View(reportFilter);
        //}
        //public async Task<ActionResult> RecipeA4Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var recipe = await _db.Recipes.FindAsync(id);

        //    if (recipe == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (recipe.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, recipe);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> RecipeA6(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var recipe = await _db.Recipes.FindAsync(id);

        //    if (recipe == null)
        //    {
        //        return View("Error");
        //    }

        //    //var report = await _db.Reports.FindAsync(recipe.Patient.Person.AuthorId);
        //    var autorid = await GetAuthorId();

        //    if (recipe.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, recipe);

        //    return View(view);
        //    //  return View(reportFilter);
        //}
        //public async Task<ActionResult> MedicalCertA4Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCert = await _db.MedicalCertificates.FindAsync(id);

        //    if (medicalCert == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCert.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //var report = await _db.Reports.FindAsync(medicalCert.Patient.Person.AuthorId);

        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, medicalCert);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> MedicalCertA6Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCert = await _db.MedicalCertificates.FindAsync(id);

        //    if (medicalCert == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCert.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    // var report = await _db.Reports.FindAsync(medicalCert.Patient.Person.AuthorId);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, medicalCert);

        //    return View(view);
        //    //  return View(reportFilter);
        //}
        //public async Task<ActionResult> MedicalCertA4(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCert = await _db.MedicalCertificates.FindAsync(id);

        //    if (medicalCert == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCert.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //var report = await _db.Reports.FindAsync(medicalCert.Patient.Person.AuthorId);

        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, medicalCert);

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> MedicalCertA6(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCert = await _db.MedicalCertificates.FindAsync(id);

        //    if (medicalCert == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCert.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    // var report = await _db.Reports.FindAsync(medicalCert.Patient.Person.AuthorId);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, medicalCert);

        //    return View(view);
        //    //  return View(reportFilter);
        //}
        ////private static AppointmentView ToView(Report rview, Appointment view)
        ////{
        ////    if (rview == null) throw new ArgumentNullException(nameof(rview));
        ////    if (view == null) throw new ArgumentNullException(nameof(view));

        ////    var m = new AppointmentView(); //el tipo que vamos a devolver
        ////    rview.Transfer(ref m);
        ////    view.Transfer(ref m);

        ////    return m;

        ////}
        //private static AnaliticalSheetView ToView(Report rview, AnalyticalSheet view)
        //{
        //    if (rview == null) throw new ArgumentNullException(nameof(rview));
        //    if (view == null) throw new ArgumentNullException(nameof(view));

        //    var m = new AnaliticalSheetView(); //el tipo que vamos a devolver
        //    rview.Transfer(ref m);
        //    view.Transfer(ref m);

        //    return m;

        //}

        //private static RecipeView ToView(Report rview, Recipe view)
        //{
        //    if (rview == null) throw new ArgumentNullException(nameof(rview));
        //    if (view == null) throw new ArgumentNullException(nameof(view));

        //    var m = new RecipeView(); //el tipo que vamos a devolver
        //    rview.Transfer(ref m);
        //    view.Transfer(ref m);

        //    return m;

        //}

        //private static MedicalCertificateView ToView(Report rview, MedicalCertificate view)
        //{
        //    if (rview == null) throw new ArgumentNullException(nameof(rview));
        //    if (view == null) throw new ArgumentNullException(nameof(view));

        //    var m = new MedicalCertificateView(); //el tipo que vamos a devolver
        //    rview.Transfer(ref m);
        //    view.Transfer(ref m);

        //    return m;

        //}

        //// GET: Medicals/Reports/Details/5
        //public async Task<ActionResult> DetailsReport(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Reports", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);
        //    if (report == null)
        //    {
        //        return View("Error");
        //    }
        //    return View(report);
        //}


        //#endregion

        //#region AppointmentsController
        //public async Task<ActionResult> IndexAppointmentsAll(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }

        //    var qry = await (from p in _db.Appointments
        //                     where p.DoctorId == doctor.DoctorId
        //                     select new { p }).ToListAsync();

        //    var results = (from item in qry
        //                   where item.p.VisitDate >= DateTime.Now.AddHours(-24)
        //                   select new Appointment
        //                   {
        //                       VisitDate = item.p.VisitDate,
        //                       VisitReason = item.p.VisitReason,
        //                       Notes = item.p.Notes,
        //                       WasSend = item.p.WasSend,
        //                       DoctorId = item.p.DoctorId,
        //                       PatientId = item.p.PatientId,
        //                       AppointmentId = item.p.AppointmentId,
        //                       Patient = item.p.Patient

        //                   }).ToList();

        //    return View(results.ToList()); //nombre, modelo

        //}
        //public async Task<ActionResult> IndexAppointments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Appointments.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateAppointments/{id}");
        //    }

        //    var appointments = _db.Appointments.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await appointments.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsAppointments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var appointment = await _db.Appointments.FindAsync(id);
        //    var autorid = await GetAuthorId();

        //    if (appointment.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    return appointment == null ? View("Error") : View(appointment);
        //    //  //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", appointment.PatientId);
        //}
        //public async Task<ActionResult> CreateAppointments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }

        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Appointment { PatientId = patient.PatientId, DoctorId = doctor.DoctorId };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAppointments(Appointment appointments)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(appointments);
        //    _db.Appointments.Add(appointments);
        //    await _db.SaveChangesAsync();

        //    return RedirectToAction($"DetailsAppointments/{appointments.AppointmentId}");
        //    //return RedirectToAction($"IndexAppointments/{Appointments.PatientId}");

        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", appointments.PatientId);
        //}
        //public async Task<ActionResult> EditAppointments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();


        //    var appointments = await _db.Appointments.FindAsync(id);
        //    if (appointments.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    return appointments == null ? View("Error") : View(appointments);
        //    //   //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", appointments.PatientId);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAppointments(Appointment appointments)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(appointments);
        //    _db.Entry(appointments).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    // return RedirectToAction($"IndexAppointments/{Appointments.PatientId}");
        //    return RedirectToAction($"DetailsAppointments/{appointments.AppointmentId}");
        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", appointments.PatientId);
        //}
        //public async Task<ActionResult> DeleteAppointments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Appointments", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var appointments = await _db.Appointments.FindAsync(id);
        //    if (appointments == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (appointments.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //  return View(Appointments);

        //    // var Appointments = await _db.Appointments.FindAsync(id);
        //    _db.Appointments.Remove(appointments);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }

        //    return RedirectToAction($"IndexAppointments/{appointments.PatientId}");

        //}

        //#endregion

        //#region OrthopedicsController

        //public async Task<ActionResult> IndexOrthopedics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Orthopedics.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateOrthopedics/{id}");
        //    }

        //    var orthopedics = _db.Orthopedics.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await orthopedics.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsOrthopedics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var orthopedic = await _db.Orthopedics.FindAsync(id);
        //    if (orthopedic == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (orthopedic.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", orthopedic.PatientId);
        //    return View(orthopedic);
        //}

        //public async Task<ActionResult> CreateOrthopedics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Orthopedic { PatientId = patient.PatientId, };

        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateOrthopedics(Orthopedic orthopedics)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Orthopedics.Add(orthopedics);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsOrthopedics/{orthopedics.OrthopedicId}");
        //        //return RedirectToAction($"IndexOrthopedics/{Orthopedics.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", orthopedics.PatientId);
        //    return View(orthopedics);

        //}

        //public async Task<ActionResult> EditOrthopedics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var orthopedics = await _db.Orthopedics.FindAsync(id);
        //    if (orthopedics == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (orthopedics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", orthopedics.PatientId);
        //    return View(orthopedics);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditOrthopedics(Orthopedic orthopedics)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(orthopedics).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexOrthopedics/{Orthopedics.PatientId}");
        //        return RedirectToAction($"DetailsOrthopedics/{orthopedics.OrthopedicId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", orthopedics.PatientId);

        //    return View(orthopedics);

        //}

        //public async Task<ActionResult> DeleteOrthopedics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Orthopedics", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var orthopedics = await _db.Orthopedics.FindAsync(id);
        //    if (orthopedics == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (orthopedics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }


        //    if (orthopedics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //  return View(Orthopedics);

        //    // var Orthopedics = await _db.Orthopedics.FindAsync(id);
        //    _db.Orthopedics.Remove(orthopedics);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexOrthopedics/{orthopedics.PatientId}");

        //}

        //#endregion

        //#region SurgeriesController

        //public async Task<ActionResult> IndexSurgeries(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Surgeries.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateSurgeries/{id}");
        //    }

        //    var surgeries = _db.Surgeries.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await surgeries.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsSurgeries(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var surgery = await _db.Surgeries.FindAsync(id);
        //    if (surgery == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (surgery.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", surgery.PatientId);
        //    return View(surgery);
        //}

        //public async Task<ActionResult> CreateSurgeries(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Surgery { PatientId = patient.PatientId, };

        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateSurgeries(Surgery surgeries)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Surgeries.Add(surgeries);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsSurgeries/{surgeries.SurgeryId}");
        //        //return RedirectToAction($"IndexSurgeries/{Surgeries.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", surgeries.PatientId);
        //    return View(surgeries);

        //}

        //public async Task<ActionResult> EditSurgeries(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var surgeries = await _db.Surgeries.FindAsync(id);
        //    if (surgeries == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (surgeries.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", surgeries.PatientId);
        //    return View(surgeries);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditSurgeries(Surgery surgeries)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(surgeries).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexSurgeries/{Surgeries.PatientId}");
        //        return RedirectToAction($"DetailsSurgeries/{surgeries.SurgeryId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", surgeries.PatientId);

        //    return View(surgeries);

        //}

        //public async Task<ActionResult> DeleteSurgeries(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Surgeries", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var surgeries = await _db.Surgeries.FindAsync(id);
        //    if (surgeries == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (surgeries.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.Surgeries.Remove(surgeries);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexSurgeries/{surgeries.PatientId}");

        //}

        //#endregion

        //#region AnestheticsController
        //public async Task<ActionResult> IndexAnesthetics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Anesthetics.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateAnesthetics/{id}");
        //    }

        //    var anesthetics = _db.Anesthetics.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await anesthetics.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsAnesthetics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var anesthetic = await _db.Anesthetics.FindAsync(id);
        //    if (anesthetic == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (anesthetic.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", anesthetic.PatientId);
        //    return View(anesthetic);
        //}
        //public async Task<ActionResult> CreateAnesthetics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Anesthetic { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAnesthetics(Anesthetic anesthetics)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Anesthetics.Add(anesthetics);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsAnesthetics/{anesthetics.AnestheticId}");
        //        //return RedirectToAction($"IndexAnesthetics/{Anesthetics.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", anesthetics.PatientId);
        //    return View(anesthetics);

        //}
        //public async Task<ActionResult> EditAnesthetics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var anesthetics = await _db.Anesthetics.FindAsync(id);
        //    if (anesthetics == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (anesthetics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", anesthetics.PatientId);
        //    return View(anesthetics);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAnesthetics(Anesthetic anesthetics)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(anesthetics).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexAnesthetics/{Anesthetics.PatientId}");
        //        return RedirectToAction($"DetailsAnesthetics/{anesthetics.AnestheticId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", anesthetics.PatientId);

        //    return View(anesthetics);

        //}
        //public async Task<ActionResult> DeleteAnesthetics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Anesthetics", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var anesthetics = await _db.Anesthetics.FindAsync(id);
        //    if (anesthetics == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (anesthetics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.Anesthetics.Remove(anesthetics);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexAnesthetics/{anesthetics.PatientId}");

        //}

        //#endregion

        //#region PsychiatrysController
        //public async Task<ActionResult> IndexPsychiatrys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }//patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Psychiatrys.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreatePsychiatrys/{id}");
        //    }

        //    var psychiatrys = _db.Psychiatrys.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await psychiatrys.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsPsychiatrys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var psychiatry = await _db.Psychiatrys.FindAsync(id);
        //    if (psychiatry == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (psychiatry.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", psychiatry.PatientId);
        //    return View(psychiatry);
        //}
        //public async Task<ActionResult> CreatePsychiatrys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Psychiatry { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreatePsychiatrys(Psychiatry psychiatrys)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Psychiatrys.Add(psychiatrys);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsPsychiatrys/{psychiatrys.PsychiatryId}");
        //        //return RedirectToAction($"IndexPsychiatrys/{Psychiatrys.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", psychiatrys.PatientId);
        //    return View(psychiatrys);

        //}
        //public async Task<ActionResult> EditPsychiatrys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var psychiatrys = await _db.Psychiatrys.FindAsync(id);
        //    if (psychiatrys == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (psychiatrys.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", psychiatrys.PatientId);
        //    return View(psychiatrys);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditPsychiatrys(Psychiatry psychiatrys)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(psychiatrys).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexPsychiatrys/{Psychiatrys.PatientId}");
        //        return RedirectToAction($"DetailsPsychiatrys/{psychiatrys.PsychiatryId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", psychiatrys.PatientId);

        //    return View(psychiatrys);

        //}
        //public async Task<ActionResult> DeletePsychiatrys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Psychiatrys", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var psychiatrys = await _db.Psychiatrys.FindAsync(id);
        //    if (psychiatrys == null)
        //    {
        //        return View("Error");
        //    }

        //    var autorid = await GetAuthorId();

        //    if (psychiatrys.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.Psychiatrys.Remove(psychiatrys);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexPsychiatrys/{psychiatrys.PatientId}");

        //}

        //#endregion

        //#region UrologysController
        //public async Task<ActionResult> IndexUrologys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Urologys.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateUrologys/{id}");
        //    }

        //    var urologys = _db.Urologys.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await urologys.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsUrologys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var urology = await _db.Urologys.FindAsync(id);
        //    if (urology == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (urology.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", urology.PatientId);
        //    return View(urology);
        //}
        //public async Task<ActionResult> CreateUrologys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Urology { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateUrologys(Urology urologys)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Urologys.Add(urologys);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsUrologys/{urologys.UrologyId}");
        //        //return RedirectToAction($"IndexUrologys/{Urologys.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", urologys.PatientId);
        //    return View(urologys);

        //}

        //public async Task<ActionResult> EditUrologys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var urologys = await _db.Urologys.FindAsync(id);
        //    if (urologys == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (urologys.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", urologys.PatientId);
        //    return View(urologys);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditUrologys(Urology urologys)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(urologys).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexUrologys/{Urologys.PatientId}");
        //        return RedirectToAction($"DetailsUrologys/{urologys.UrologyId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", urologys.PatientId);

        //    return View(urologys);

        //}

        //public async Task<ActionResult> DeleteUrologys(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Urologys", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var urologys = await _db.Urologys.FindAsync(id);
        //    if (urologys == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (urologys.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.Urologys.Remove(urologys);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexUrologys/{urologys.PatientId}");

        //}

        //#endregion

        //#region TreatmentVisitsController

        //public async Task<ActionResult> CreateTreatmentVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var treatment = await _db.Treatments.FindAsync(id);

        //    if (treatment == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatment.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var view = new TreatmentVisit { TreatmentId = treatment.TreatmentId, PatientId = treatment.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateTreatmentVisits(TreatmentVisit treatmentVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(treatmentVisit);
        //    _db.TreatmentVisits.Add(treatmentVisit);
        //    await _db.SaveChangesAsync();

        //    var treatment = await _db.Treatments.FindAsync(treatmentVisit.TreatmentId);
        //    if (treatment == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatment.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //  return RedirectToAction($"DetailsTreatment/{Treatment.PatientId}");
        //    return RedirectToAction($"DetailsTreatments/{treatmentVisit.TreatmentId}");
        //}

        //public async Task<ActionResult> EditTreatmentVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var treatmentVisit = await _db.TreatmentVisits.FindAsync(id);
        //    if (treatmentVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatmentVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", treatmentVisit.PatientId);
        //    ViewBag.TreatmentId = new SelectList(_db.Treatments, "TreatmentId", "TreatmentId", treatmentVisit.TreatmentId);
        //    return View(treatmentVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditTreatmentVisits(TreatmentVisit treatmentVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(treatmentVisit);
        //    _db.Entry(treatmentVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", treatmentVisit.PatientId);
        //    // return RedirectToAction($"DetailsTreatments/{TreatmentVisit.PatientId}");
        //    return RedirectToAction($"DetailsTreatments/{treatmentVisit.TreatmentId}");
        //    // return View(Treatment);
        //}

        //public async Task<ActionResult> DeleteTreatmentVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var treatmentVisits = await _db.TreatmentVisits.FindAsync(id);
        //    if (treatmentVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatmentVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.TreatmentVisits.Remove(treatmentVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsTreatment/{treatmentVisits.PatientId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region TreatmentsController
        //public async Task<ActionResult> IndexTreatments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Treatments.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateTreatments/{id}");
        //    }

        //    var treatments = _db.Treatments.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await treatments.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsTreatments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var treatment = await _db.Treatments.FindAsync(id);
        //    if (treatment == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatment.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", treatment.PatientId);
        //    return View(treatment);
        //}
        //public async Task<ActionResult> CreateTreatments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Treatment { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateTreatments(Treatment treatments)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Treatments.Add(treatments);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsTreatments/{treatments.TreatmentId}");
        //        //return RedirectToAction($"IndexTreatments/{Treatments.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", treatments.PatientId);
        //    return View(treatments);

        //}

        //public async Task<ActionResult> EditTreatments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var treatments = await _db.Treatments.FindAsync(id);
        //    if (treatments == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatments.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", treatments.PatientId);
        //    return View(treatments);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditTreatments(Treatment treatments)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(treatments).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexTreatments/{Treatments.PatientId}");
        //        return RedirectToAction($"DetailsTreatments/{treatments.TreatmentId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", treatments.PatientId);

        //    return View(treatments);

        //}

        //public async Task<ActionResult> DeleteTreatments(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Treatment", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var treatments = await _db.Treatments.FindAsync(id);
        //    if (treatments == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (treatments.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.Treatments.Remove(treatments);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexTreatments/{treatments.PatientId}");

        //}

        //#endregion

        //#region GeneralVisitsController

        //public async Task<ActionResult> CreateGeneralVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var generalAfection = await _db.GeneralAfections.FindAsync(id);

        //    if (generalAfection == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalAfection.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ////ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // ViewBag.GeneralAfectionId = new SelectList(_db.GeneralAfections, "GeneralAfectionId", "GeneralAfectionId");

        //    var view = new GeneralVisit { GeneralAfectionId = generalAfection.GeneralAfectionId, PatientId = generalAfection.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateGeneralVisits(GeneralVisit generalVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(generalVisit);
        //    _db.GeneralVisits.Add(generalVisit);
        //    await _db.SaveChangesAsync();

        //    var generalAfection = await _db.GeneralAfections.FindAsync(generalVisit.GeneralAfectionId);
        //    if (generalAfection == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalAfection.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //  return RedirectToAction($"DetailsGeneralAfection/{generalAfection.PatientId}");
        //    return RedirectToAction($"DetailsGeneralAfections/{generalVisit.GeneralAfectionId}");
        //}

        //public async Task<ActionResult> EditGeneralVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var generalVisit = await _db.GeneralVisits.FindAsync(id);
        //    if (generalVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", generalVisit.PatientId);
        //    ViewBag.GeneralAfectionId = new SelectList(_db.GeneralAfections, "GeneralAfectionId", "GeneralAfectionId", generalVisit.GeneralAfectionId);
        //    return View(generalVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditGeneralVisits(GeneralVisit generalVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(generalVisit);
        //    _db.Entry(generalVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", generalVisit.PatientId);
        //    // return RedirectToAction($"DetailsGeneralAfections/{generalVisit.PatientId}");
        //    return RedirectToAction($"DetailsGeneralAfections/{generalVisit.GeneralAfectionId}");
        //    // return View(GeneralAfection);
        //}

        //public async Task<ActionResult> DeleteGeneralVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var generalVisits = await _db.GeneralVisits.FindAsync(id);
        //    if (generalVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.GeneralVisits.Remove(generalVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsGeneralAfection/{generalVisits.PatientId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region GeneralAfectionsController
        //public async Task<ActionResult> IndexGeneralAfections(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.GeneralAfections.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateGeneralAfections/{id}");
        //    }

        //    var generalAfections = _db.GeneralAfections.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await generalAfections.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsGeneralAfections(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var generalAfection = await _db.GeneralAfections.FindAsync(id);
        //    if (generalAfection == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalAfection.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", generalAfection.PatientId);
        //    return View(generalAfection);
        //}
        //public async Task<ActionResult> CreateGeneralAfections(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new GeneralAfection { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateGeneralAfections(GeneralAfection generalAfections)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.GeneralAfections.Add(generalAfections);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsGeneralAfections/{generalAfections.GeneralAfectionId}");
        //        //return RedirectToAction($"IndexGeneralAfections/{GeneralAfections.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", generalAfections.PatientId);
        //    return View(generalAfections);

        //}

        //public async Task<ActionResult> EditGeneralAfections(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var generalAfections = await _db.GeneralAfections.FindAsync(id);
        //    if (generalAfections == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (generalAfections.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", generalAfections.PatientId);
        //    return View(generalAfections);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditGeneralAfections(GeneralAfection generalAfections)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(generalAfections).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexGeneralAfections/{GeneralAfections.PatientId}");
        //        return RedirectToAction($"DetailsGeneralAfections/{generalAfections.GeneralAfectionId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", generalAfections.PatientId);

        //    return View(generalAfections);

        //}

        //public async Task<ActionResult> DeleteGeneralAfections(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var generalAfections = await _db.GeneralAfections.FindAsync(id);
        //    if (generalAfections == null)
        //    {
        //        return View("Error");
        //    }

        //    var autorid = await GetAuthorId();

        //    if (generalAfections.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.GeneralAfections.Remove(generalAfections);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexGeneralAfections/{generalAfections.PatientId}");

        //}

        //#endregion

        //#region GeneralController

        //public async Task<ActionResult> DetailsGeneral(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var hasHistory = await _db.Generals.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        //create
        //        //return View("Error");
        //        //  return RedirectToAction("Index");
        //        //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", patient.PersonId);
        //        return RedirectToAction($"CreateGeneral/{id}");
        //    }

        //    var his = await _db.Generals.FindAsync(hasHistory.GeneralId);

        //    if (his == null)
        //    {
        //        return View("Error");
        //    }


        //    return View(his);

        //}

        //public async Task<ActionResult> CreateGeneral(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new General { PatientId = patient.PatientId, };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateGeneral(General general)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(general);
        //    _db.Generals.Add(general);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsGeneral/{general.PatientId}");
        //}

        //public async Task<ActionResult> EditGeneral(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var general = await _db.Generals.FindAsync(id);
        //    if (general == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (general.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", general.PatientId);
        //    return View(general);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditGeneral(General general)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "General", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(general);
        //    _db.Entry(general).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", general.PatientId);
        //    return RedirectToAction($"DetailsGeneral/{general.PatientId}");
        //    // return View(General);
        //}

        //#endregion

        //#region EndocrinesController
        //public async Task<ActionResult> IndexEndocrines(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Endocrines.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateEndocrines/{id}");
        //    }

        //    var endocrines = _db.Endocrines.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await endocrines.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsEndocrines(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var endocrine = await _db.Endocrines.FindAsync(id);
        //    if (endocrine == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (endocrine.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", endocrine.PatientId);
        //    return View(endocrine);
        //}
        //public async Task<ActionResult> CreateEndocrines(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Endocrine { PatientId = patient.PatientId, };

        //    return View(view);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateEndocrines(Endocrine endocrines)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Endocrines.Add(endocrines);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsEndocrines/{endocrines.EndocrineId}");
        //        //return RedirectToAction($"IndexEndocrines/{Endocrines.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", endocrines.PatientId);
        //    return View(endocrines);

        //}
        //public async Task<ActionResult> EditEndocrines(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var endocrines = await _db.Endocrines.FindAsync(id);
        //    if (endocrines == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (endocrines.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", endocrines.PatientId);
        //    return View(endocrines);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditEndocrines(Endocrine endocrines)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(endocrines).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexEndocrines/{Endocrines.PatientId}");
        //        return RedirectToAction($"DetailsEndocrines/{endocrines.EndocrineId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", endocrines.PatientId);

        //    return View(endocrines);

        //}
        //public async Task<ActionResult> DeleteEndocrines(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Endocrines", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var endocrines = await _db.Endocrines.FindAsync(id);
        //    if (endocrines == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (endocrines.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    // var Endocrines = await _db.Endocrines.FindAsync(id);
        //    _db.Endocrines.Remove(endocrines);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexEndocrines/{endocrines.PatientId}");

        //}

        //#endregion

        //#region LaboratoryResultController

        //public string ReturnReference(int reference)
        //{
        //    if (reference == 1)
        //    {
        //        return "DetailsBariatric";
        //    }

        //    return "Details";
        //}

        //public async Task<ActionResult> DetailsLaboratoryResultsOld(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.LaboratoryResults.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);

        //    return View(analyticalSheets);
        //}
        //public async Task<ActionResult> IndexLaboratoryResultsOld(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }//patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.LaboratoryResults.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateLaboratoryResultsOld/{id}");
        //    }

        //    var analyticalSheets = _db.LaboratoryResults.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await analyticalSheets.ToListAsync());

        //}
        //public async Task<ActionResult> CreateLaboratoryResultsOld(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    if (reference != null)
        //    {
        //        Session["MasterId"] = masterId;
        //        Session["Reference"] = reference;

        //    }
        //    else
        //    {
        //        Session["MasterId"] = 0;
        //        Session["Reference"] = 0;
        //    }

        //    var view = new LaboratoryResult { PatientId = patient.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateLaboratoryResultsOld(LaboratoryResult laboratoryResult)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(laboratoryResult);
        //    _db.LaboratoryResults.Add(laboratoryResult);
        //    await _db.SaveChangesAsync();

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("DetailsLaboratoryResultsOld/" + laboratoryResult.LaboratoryResultId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //public async Task<ActionResult> EditLaboratoryResultsOld(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var laboratoryResult = await _db.LaboratoryResults.FindAsync(id);

        //    if (laboratoryResult == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (laboratoryResult.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    if (reference != null)
        //    {
        //        Session["MasterId"] = masterId;
        //        Session["Reference"] = reference;

        //    }
        //    else
        //    {
        //        Session["MasterId"] = 0;
        //        Session["Reference"] = 0;
        //    }
        //    //var view = new LaboratoryResult { PatientId = laboratoryResult.PatientId, LaboratoryResultId=laboratoryResult.LaboratoryResultId};

        //    //   //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", laboratoryResult.PatientId);
        //    // return View(laboratoryResult);
        //    return View(laboratoryResult);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditLaboratoryResultsOld(LaboratoryResult laboratoryResult)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View();
        //    _db.Entry(laboratoryResult).State = EntityState.Modified;

        //    await _db.SaveChangesAsync();

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("DetailsLaboratoryResultsOld/" + laboratoryResult.LaboratoryResultId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //public async Task<ActionResult> DeleteLaboratoryResultsOld(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsOld", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var laboratoryResult = await _db.LaboratoryResults.FindAsync(id);

        //    if (laboratoryResult == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (laboratoryResult.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.LaboratoryResults.Remove(laboratoryResult);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("IndexLaboratoryResultsOld/" + laboratoryResult.PatientId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //#endregion

        //#region LaboratoryTestController

        //public async Task<ActionResult> LaboratoryResultsA4(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsA4", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var lab = await _db.LaboratoryTests.FindAsync(id);

        //    if (lab == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (lab.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, lab);

        //    ViewBag.Hb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hb).Result?.Result;

        //    ViewBag.Albumina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Albumina).Result?.Result;

        //    ViewBag.Hto = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hto).Result?.Result;

        //    ViewBag.Gb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Gb).Result?.Result;

        //    ViewBag.Gr = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Gr).Result?.Result;

        //    ViewBag.Tp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tp).Result?.Result;

        //    ViewBag.Grs = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Grs).Result?.Result;

        //    ViewBag.Vcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vcm).Result?.Result;

        //    ViewBag.Hcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hcm).Result?.Result;

        //    ViewBag.Chcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Chcm).Result?.Result;

        //    ViewBag.Tpt = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tpt).Result?.Result;

        //    ViewBag.Segmentados = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Segmentados).Result?.Result;

        //    ViewBag.Linfocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Linfocitos).Result?.Result;

        //    ViewBag.Eosinofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Eosinofilos).Result?.Result;

        //    ViewBag.Banda = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Banda).Result?.Result;

        //    ViewBag.Monocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Monocitos).Result?.Result;

        //    ViewBag.Basofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Basofilos).Result?.Result;

        //    ViewBag.CelJuveniles = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelJuveniles).Result?.Result;

        //    ViewBag.CelFalciformes = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelFalciformes).Result?.Result;

        //    ViewBag.Eritrosedimentacion = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Eritrosedimentacion).Result?.Result;

        //    ViewBag.TdeSangria = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TdeSangria).Result?.Result;

        //    ViewBag.TdeCoagulacion = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TdeCoagulacion).Result?.Result;

        //    ViewBag.CdePlaquetas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdePlaquetas).Result?.Result;

        //    ViewBag.CdeEosinofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdeEosinofilos).Result?.Result;

        //    ViewBag.CdeReticulocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdeReticulocitos).Result?.Result;

        //    ViewBag.Hematozoarios = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hematozoarios).Result?.Result;

        //    ViewBag.ExtdeSangPeriferica = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ExtdeSangPeriferica).Result?.Result;

        //    ViewBag.Color = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Color).Result?.Result;

        //    ViewBag.Olor = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Olor).Result?.Result;

        //    ViewBag.Aspecto = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Aspecto).Result?.Result;

        //    ViewBag.Densidad = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Densidad).Result?.Result;

        //    ViewBag.Ph = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ph).Result?.Result;

        //    ViewBag.Glucosa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glucosa).Result?.Result;

        //    ViewBag.Albúmina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Albumina).Result?.Result;

        //    ViewBag.Acetona = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Acetona).Result?.Result;

        //    ViewBag.SangOculta = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SangOculta).Result?.Result;

        //    ViewBag.Bilirrubina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bilirrubina).Result?.Result;

        //    ViewBag.Urobilinogeno = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Urobilinogeno).Result?.Result;

        //    ViewBag.Nitrito = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Nitrito).Result?.Result;

        //    ViewBag.GBlancos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.GBlancos).Result?.Result;

        //    ViewBag.GRojos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.GRojos).Result?.Result;

        //    ViewBag.CelEpiteliales = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelEpiteliales).Result?.Result;

        //    ViewBag.Bacterias = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bacterias).Result?.Result;

        //    ViewBag.Cristales = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Cristales).Result?.Result;

        //    ViewBag.FibMucosas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FibMucosas).Result?.Result;

        //    ViewBag.Cilindros = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Cilindros).Result?.Result;

        //    ViewBag.Levaduras = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Levaduras).Result?.Result;

        //    ViewBag.Parasitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Parasitos).Result?.Result;

        //    ViewBag.Huevos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Huevos).Result?.Result;

        //    ViewBag.InvdeAmebas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.InvdeAmebas).Result?.Result;

        //    ViewBag.SangOcultaCop = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SangOcultaCop).Result?.Result;

        //    ViewBag.OtrosCop = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.OtrosCop).Result?.Result;

        //    ViewBag.HIV = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hiv).Result?.Result;

        //    ViewBag.VDRL = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vdrl).Result?.Result;

        //    ViewBag.FactorReumatoide = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FactorReumatoide).Result?.Result;

        //    ViewBag.ASO = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Aso).Result?.Result;

        //    ViewBag.TSanguinea = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TSanguinea).Result?.Result;

        //    ViewBag.FactorRH = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FactorRH).Result?.Result;

        //    ViewBag.Hvc = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hvc).Result?.Result;

        //    ViewBag.Pcr = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Pcr).Result?.Result;

        //    ViewBag.ToxoIGG = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ToxoIGG).Result?.Result;

        //    ViewBag.ToxoIGM = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ToxoIGM).Result?.Result;

        //    ViewBag.HepatitisB = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HepatitisB).Result?.Result;

        //    ViewBag.HepatitisC = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HepatitisC).Result?.Result;

        //    ViewBag.PruebdeEmbarazo = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.PruebdeEmbarazo).Result?.Result;

        //    ViewBag.SalmonelaThupiO = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SalmonelaThupiO).Result?.Result;

        //    ViewBag.SalmonelaTyphiH = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SalmonelaTyphiH).Result?.Result;

        //    ViewBag.ParatyphiA = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ParatyphiA).Result?.Result;

        //    ViewBag.ParatyphiB = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ParatyphiB).Result?.Result;

        //    ViewBag.BrucelaAbortus = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.BrucelaAbortus).Result?.Result;

        //    ViewBag.ProteusOxig = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ProteusOxig).Result?.Result;

        //    ViewBag.Glicemia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glicemia).Result?.Result;

        //    ViewBag.Colesterol = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Colesterol).Result?.Result;

        //    ViewBag.Trigliceridos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Trigliceridos).Result?.Result;

        //    ViewBag.Urea = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Urea).Result?.Result;

        //    ViewBag.Creatinina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Creatinina).Result?.Result;

        //    ViewBag.Sgot = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Sgot).Result?.Result;

        //    ViewBag.Sgtp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Sgtp).Result?.Result;

        //    ViewBag.AcUrico = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AcUrico).Result?.Result;

        //    ViewBag.Bil = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bil).Result?.Result;

        //    ViewBag.Directa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Directa).Result?.Result;

        //    ViewBag.Indirecta = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Indirecta).Result?.Result;

        //    ViewBag.Total = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Total).Result?.Result;

        //    ViewBag.HPilory = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HPilory).Result?.Result;

        //    ViewBag.Ck = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ck).Result?.Result;

        //    ViewBag.Hdl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hdl).Result?.Result;

        //    ViewBag.Ldl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ldl).Result?.Result;

        //    ViewBag.Vldl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vldl).Result?.Result;

        //    ViewBag.Amilasa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Amilasa).Result?.Result;

        //    ViewBag.Lipasa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Lipasa).Result?.Result;

        //    ViewBag.FosfatasaAcida = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FosfatasaAcida).Result?.Result;

        //    ViewBag.FosfatasaAlcalina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FosfatasaAlcalina).Result?.Result;

        //    ViewBag.HbGlucosilada = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HbGlucosilada).Result?.Result;

        //    ViewBag.ProteinaTotal = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ProteinaTotal).Result?.Result;

        //    ViewBag.AlbuminaQ = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AlbuminaQ).Result?.Result;

        //    ViewBag.Globulina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Globulina).Result?.Result;

        //    ViewBag.RelacionAG = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.RelacionAG).Result?.Result;

        //    ViewBag.Ldh = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ldh).Result?.Result;

        //    ViewBag.Ckmb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ckmb).Result?.Result;

        //    ViewBag.RtoGb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.RtoGb).Result?.Result;

        //    ViewBag.Fal = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Fal).Result?.Result;

        //    ViewBag.Tgo = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tgo).Result?.Result;

        //    ViewBag.Tgp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tgp).Result?.Result;

        //    ViewBag.Proteinas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Proteinas).Result?.Result;

        //    ViewBag.Glucemia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glucemia).Result?.Result;

        //    ViewBag.Insulina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Insulina).Result?.Result;

        //    ViewBag.Homa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Homa).Result?.Result;

        //    ViewBag.HbA1C = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HbA1C).Result?.Result;

        //    ViewBag.Tg = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tg).Result?.Result;

        //    ViewBag.Tsh = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tsh).Result?.Result;

        //    ViewBag.Calcio = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Calcio).Result?.Result;

        //    ViewBag.Pth = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Pth).Result?.Result;

        //    ViewBag.VitD = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.VitD).Result?.Result;

        //    ViewBag.Magnesio = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Magnesio).Result?.Result;

        //    ViewBag.AcFolico = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AcFolico).Result?.Result;

        //    ViewBag.Ferremia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ferremia).Result?.Result;

        //    ViewBag.B1 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B1).Result?.Result;

        //    ViewBag.B6 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B6).Result?.Result;

        //    ViewBag.B12 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B12).Result?.Result;

        //    ViewBag.Zinc = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Zinc).Result?.Result;



        //    ViewBag.RealizationDate = string.Format("{0:dd/MM/yyyy}", lab.RealizationDate);
        //    ViewBag.ResultDate = string.Format("{0:dd/MM/yyyy}", lab.ResultDate);

        //    // _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb).Result;
        //    // 

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //public async Task<ActionResult> LaboratoryResultsA4Empty(int id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResultsA4", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var lab = await _db.LaboratoryTests.FindAsync(id);

        //    if (lab == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (lab.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var report = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == autorid);

        //    if (report == null)
        //    {
        //        return RedirectToAction("Create", "Reports", new { area = "Configurations", autorid });
        //    }

        //    var view = ToView(report, lab);

        //    ViewBag.Hb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hb).Result?.Result;

        //    ViewBag.Albumina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Albumina).Result?.Result;

        //    ViewBag.Hto = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hto).Result?.Result;

        //    ViewBag.Gb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Gb).Result?.Result;

        //    ViewBag.Gr = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Gr).Result?.Result;

        //    ViewBag.Tp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tp).Result?.Result;

        //    ViewBag.Grs = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Grs).Result?.Result;

        //    ViewBag.Vcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vcm).Result?.Result;

        //    ViewBag.Hcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hcm).Result?.Result;

        //    ViewBag.Chcm = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Chcm).Result?.Result;

        //    ViewBag.Tpt = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tpt).Result?.Result;

        //    ViewBag.Segmentados = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Segmentados).Result?.Result;

        //    ViewBag.Linfocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Linfocitos).Result?.Result;

        //    ViewBag.Eosinofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Eosinofilos).Result?.Result;

        //    ViewBag.Banda = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Banda).Result?.Result;

        //    ViewBag.Monocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Monocitos).Result?.Result;

        //    ViewBag.Basofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Basofilos).Result?.Result;

        //    ViewBag.CelJuveniles = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelJuveniles).Result?.Result;

        //    ViewBag.CelFalciformes = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelFalciformes).Result?.Result;

        //    ViewBag.Eritrosedimentacion = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Eritrosedimentacion).Result?.Result;

        //    ViewBag.TdeSangria = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TdeSangria).Result?.Result;

        //    ViewBag.TdeCoagulacion = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TdeCoagulacion).Result?.Result;

        //    ViewBag.CdePlaquetas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdePlaquetas).Result?.Result;

        //    ViewBag.CdeEosinofilos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdeEosinofilos).Result?.Result;

        //    ViewBag.CdeReticulocitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CdeReticulocitos).Result?.Result;

        //    ViewBag.Hematozoarios = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hematozoarios).Result?.Result;

        //    ViewBag.ExtdeSangPeriferica = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ExtdeSangPeriferica).Result?.Result;

        //    ViewBag.Color = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Color).Result?.Result;

        //    ViewBag.Olor = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Olor).Result?.Result;

        //    ViewBag.Aspecto = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Aspecto).Result?.Result;

        //    ViewBag.Densidad = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Densidad).Result?.Result;

        //    ViewBag.Ph = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ph).Result?.Result;

        //    ViewBag.Glucosa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glucosa).Result?.Result;

        //    ViewBag.Albúmina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Albumina).Result?.Result;

        //    ViewBag.Acetona = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Acetona).Result?.Result;

        //    ViewBag.SangOculta = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SangOculta).Result?.Result;

        //    ViewBag.Bilirrubina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bilirrubina).Result?.Result;

        //    ViewBag.Urobilinogeno = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Urobilinogeno).Result?.Result;

        //    ViewBag.Nitrito = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Nitrito).Result?.Result;

        //    ViewBag.GBlancos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.GBlancos).Result?.Result;

        //    ViewBag.GRojos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.GRojos).Result?.Result;

        //    ViewBag.CelEpiteliales = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.CelEpiteliales).Result?.Result;

        //    ViewBag.Bacterias = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bacterias).Result?.Result;

        //    ViewBag.Cristales = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Cristales).Result?.Result;

        //    ViewBag.FibMucosas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FibMucosas).Result?.Result;

        //    ViewBag.Cilindros = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Cilindros).Result?.Result;

        //    ViewBag.Levaduras = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Levaduras).Result?.Result;

        //    ViewBag.Parasitos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Parasitos).Result?.Result;

        //    ViewBag.Huevos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Huevos).Result?.Result;

        //    ViewBag.InvdeAmebas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.InvdeAmebas).Result?.Result;

        //    ViewBag.SangOcultaCop = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SangOcultaCop).Result?.Result;

        //    ViewBag.OtrosCop = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.OtrosCop).Result?.Result;

        //    ViewBag.HIV = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hiv).Result?.Result;

        //    ViewBag.VDRL = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vdrl).Result?.Result;

        //    ViewBag.FactorReumatoide = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FactorReumatoide).Result?.Result;

        //    ViewBag.ASO = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Aso).Result?.Result;

        //    ViewBag.TSanguinea = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.TSanguinea).Result?.Result;

        //    ViewBag.FactorRH = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FactorRH).Result?.Result;

        //    ViewBag.Hvc = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hvc).Result?.Result;

        //    ViewBag.Pcr = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Pcr).Result?.Result;

        //    ViewBag.ToxoIGG = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ToxoIGG).Result?.Result;

        //    ViewBag.ToxoIGM = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ToxoIGM).Result?.Result;

        //    ViewBag.HepatitisB = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HepatitisB).Result?.Result;

        //    ViewBag.HepatitisC = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HepatitisC).Result?.Result;

        //    ViewBag.PruebdeEmbarazo = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.PruebdeEmbarazo).Result?.Result;

        //    ViewBag.SalmonelaThupiO = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SalmonelaThupiO).Result?.Result;

        //    ViewBag.SalmonelaTyphiH = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.SalmonelaTyphiH).Result?.Result;

        //    ViewBag.ParatyphiA = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ParatyphiA).Result?.Result;

        //    ViewBag.ParatyphiB = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ParatyphiB).Result?.Result;

        //    ViewBag.BrucelaAbortus = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.BrucelaAbortus).Result?.Result;

        //    ViewBag.ProteusOxig = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ProteusOxig).Result?.Result;

        //    ViewBag.Glicemia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glicemia).Result?.Result;

        //    ViewBag.Colesterol = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Colesterol).Result?.Result;

        //    ViewBag.Trigliceridos = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Trigliceridos).Result?.Result;

        //    ViewBag.Urea = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Urea).Result?.Result;

        //    ViewBag.Creatinina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Creatinina).Result?.Result;

        //    ViewBag.Sgot = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Sgot).Result?.Result;

        //    ViewBag.Sgtp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Sgtp).Result?.Result;

        //    ViewBag.AcUrico = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AcUrico).Result?.Result;

        //    ViewBag.Bil = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Bil).Result?.Result;

        //    ViewBag.Directa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Directa).Result?.Result;

        //    ViewBag.Indirecta = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Indirecta).Result?.Result;

        //    ViewBag.Total = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Total).Result?.Result;

        //    ViewBag.HPilory = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HPilory).Result?.Result;

        //    ViewBag.Ck = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ck).Result?.Result;

        //    ViewBag.Hdl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Hdl).Result?.Result;

        //    ViewBag.Ldl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ldl).Result?.Result;

        //    ViewBag.Vldl = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Vldl).Result?.Result;

        //    ViewBag.Amilasa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Amilasa).Result?.Result;

        //    ViewBag.Lipasa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Lipasa).Result?.Result;

        //    ViewBag.FosfatasaAcida = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FosfatasaAcida).Result?.Result;

        //    ViewBag.FosfatasaAlcalina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.FosfatasaAlcalina).Result?.Result;

        //    ViewBag.HbGlucosilada = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HbGlucosilada).Result?.Result;

        //    ViewBag.ProteinaTotal = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.ProteinaTotal).Result?.Result;

        //    ViewBag.AlbuminaQ = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AlbuminaQ).Result?.Result;

        //    ViewBag.Globulina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Globulina).Result?.Result;

        //    ViewBag.RelacionAG = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.RelacionAG).Result?.Result;

        //    ViewBag.Ldh = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ldh).Result?.Result;

        //    ViewBag.Ckmb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ckmb).Result?.Result;

        //    ViewBag.RtoGb = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.RtoGb).Result?.Result;

        //    ViewBag.Fal = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Fal).Result?.Result;

        //    ViewBag.Tgo = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tgo).Result?.Result;

        //    ViewBag.Tgp = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tgp).Result?.Result;

        //    ViewBag.Proteinas = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Proteinas).Result?.Result;

        //    ViewBag.Glucemia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Glucemia).Result?.Result;

        //    ViewBag.Insulina = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Insulina).Result?.Result;

        //    ViewBag.Homa = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Homa).Result?.Result;

        //    ViewBag.HbA1C = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.HbA1C).Result?.Result;

        //    ViewBag.Tg = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tg).Result?.Result;

        //    ViewBag.Tsh = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Tsh).Result?.Result;

        //    ViewBag.Calcio = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Calcio).Result?.Result;

        //    ViewBag.Pth = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Pth).Result?.Result;

        //    ViewBag.VitD = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.VitD).Result?.Result;

        //    ViewBag.Magnesio = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Magnesio).Result?.Result;

        //    ViewBag.AcFolico = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.AcFolico).Result?.Result;

        //    ViewBag.Ferremia = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Ferremia).Result?.Result;

        //    ViewBag.B1 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B1).Result?.Result;

        //    ViewBag.B6 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B6).Result?.Result;

        //    ViewBag.B12 = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.B12).Result?.Result;

        //    ViewBag.Zinc = _db.LaboratoryDetails.FirstOrDefaultAsync(p => p.LaboratoryDetailId == lab.Zinc).Result?.Result;



        //    ViewBag.RealizationDate = string.Format("{0:dd/MM/yyyy}", lab.RealizationDate);
        //    ViewBag.ResultDate = string.Format("{0:dd/MM/yyyy}", lab.ResultDate);

        //    // _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb).Result;
        //    // 

        //    return View(view);
        //    //  return View(reportFilter);
        //}

        //private static LaboratoryTestView ToView(Report rview, LaboratoryTest view)
        //{
        //    if (rview == null) throw new ArgumentNullException(nameof(rview));
        //    if (view == null) throw new ArgumentNullException(nameof(view));

        //    var m = new LaboratoryTestView(); //el tipo que vamos a devolver
        //    rview.Transfer(ref m);
        //    view.Transfer(ref m);

        //    return m;

        //}
        //public async Task<ActionResult> DetailsLaboratoryResults(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.LaboratoryTests.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);
        //    ViewBag.Albumina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albumina" && p.Laboratory.AuthorId == autorid)
        //               .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue

        //    ViewBag.Hb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb" && p.Laboratory.AuthorId == autorid)
        //                .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hto" && p.Laboratory.AuthorId == autorid)
        //               .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Gb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "G.B." && p.Laboratory.AuthorId == autorid)
        //              .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Gr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "GR" && p.Laboratory.AuthorId == autorid)
        //             .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Grs = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Grs" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Vcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Chcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "C.H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tpt = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TPT" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Segmentados = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Segmentados" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Linfocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Linfocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Eosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Banda = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Banda" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Monocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Monocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Basofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Basofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelJuveniles = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Juveniles" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelFalciformes = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Falciformes" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Eritrosedimentacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eritrosedimentacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TdeSangria = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Sangria" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TdeCoagulacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Coagulacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdePlaquetas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Plaquetas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdeEosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdeReticulocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Reticulocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hematozoarios = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hematozoarios" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ExtdeSangPeriferica = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ext de Sangre Periferica" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Color = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Color" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Olor = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Olor" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Aspecto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Aspecto" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Densidad = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Densidad" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ph = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ph" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glucosa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucosa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Albúmina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Acetona = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acetona" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SangOculta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bilirrubina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Urobilinogeno = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urobilinogeno" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Nitrito = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Nitrito" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.GBlancos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Blancos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.GRojos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Rojos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelEpiteliales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Epiteliales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bacterias = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bacterias" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Cristales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cristales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FibMucosas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fibras Mucosas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Cilindros = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cilindros" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Levaduras = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Levaduras" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Parasitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Parasitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Huevos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Huevos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.InvdeAmebas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Investigacion de Amebas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SangOcultaCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.OtrosCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Otros Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HIV = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.I.V" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.VDRL = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.D.R.L." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FactorReumatoide = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor Reumatoide" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ASO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "A.S.O." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TSanguinea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tipificacion Sanguinea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FactorRH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor RH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hvc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HVC" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Pcr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "P.C.R." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.G." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGM = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.M." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisC = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis C" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.PruebdeEmbarazo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Prueba de Embarazo" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaThupiO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Thupi O" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaTyphiH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Typhi H" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiA = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi A" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.BrucelaAbortus = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Brucela Abortus" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ProteusOxig = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteus Oxig" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glicemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glicemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Colesterol = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Colesterol" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Trigliceridos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Trigliceridos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Urea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Creatinina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Creatinina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Sgot = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.O.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Sgtp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.P.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AcUrico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acido úrico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bil = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "BILIRRUBINA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Directa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Directa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Indirecta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Indirecta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Total = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HPilory = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H. Pilory" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ck = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hdl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Vldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "VLDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Amilasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Amilasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Lipasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Lipasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAcida = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Acida" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAlcalina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Alcalina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HbGlucosilada = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb Glucosilada" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ProteinaTotal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteína Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AlbuminaQ = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina Q" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Globulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.RelacionAG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Relacion A/G" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ldh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ckmb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK-MB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.RtoGb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Rto GB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Fal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "FAL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tgo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGO" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tgp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Proteinas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteínas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glucemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Insulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Insulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Homa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HOMA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HbA1C = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb A1c" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tg = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TG" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tsh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TSH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Calcio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Calcio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Pth = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "PTH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.VitD = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Vit. D" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Magnesio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Magnesio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AcFolico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ac. Fólico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ferremia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ferremia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B1 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B1" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B6 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B6" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B12 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B12" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Zinc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Zinc" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue

        //    return View(analyticalSheets);
        //}

        //public async Task<ActionResult> IndexLaboratoryResults(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }//patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.LaboratoryTests.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateLaboratoryResults/{id}");
        //    }

        //    var analyticalSheets = _db.LaboratoryTests.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await analyticalSheets.ToListAsync());

        //}

        //public async Task<ActionResult> CreateLaboratoryResults(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    if (reference != null)
        //    {
        //        Session["MasterId"] = masterId;
        //        Session["Reference"] = reference;

        //    }
        //    else
        //    {
        //        Session["MasterId"] = 0;
        //        Session["Reference"] = 0;
        //    }

        //    var view = new LaboratoryTest { PatientId = patient.PatientId };

        //    ViewBag.Albumina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albumina" && p.Laboratory.AuthorId == autorid)
        //                .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue

        //    ViewBag.Hb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb" && p.Laboratory.AuthorId == autorid)
        //                .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hto" && p.Laboratory.AuthorId == autorid)
        //               .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Gb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "G.B." && p.Laboratory.AuthorId == autorid)
        //              .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Gr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "GR" && p.Laboratory.AuthorId == autorid)
        //             .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Grs = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Grs" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Vcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Chcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "C.H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tpt = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TPT" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Segmentados = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Segmentados" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Linfocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Linfocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Eosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Banda = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Banda" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Monocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Monocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Basofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Basofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelJuveniles = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Juveniles" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelFalciformes = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Falciformes" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Eritrosedimentacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eritrosedimentacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TdeSangria = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Sangria" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TdeCoagulacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Coagulacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdePlaquetas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Plaquetas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdeEosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CdeReticulocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Reticulocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hematozoarios = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hematozoarios" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ExtdeSangPeriferica = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ext de Sangre Periferica" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Color = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Color" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Olor = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Olor" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Aspecto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Aspecto" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Densidad = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Densidad" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ph = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ph" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glucosa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucosa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Albúmina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Acetona = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acetona" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SangOculta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bilirrubina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Urobilinogeno = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urobilinogeno" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Nitrito = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Nitrito" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.GBlancos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Blancos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.GRojos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Rojos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.CelEpiteliales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Epiteliales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bacterias = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bacterias" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Cristales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cristales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FibMucosas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fibras Mucosas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Cilindros = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cilindros" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Levaduras = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Levaduras" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Parasitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Parasitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Huevos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Huevos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.InvdeAmebas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Investigacion de Amebas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SangOcultaCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.OtrosCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Otros Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HIV = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.I.V" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.VDRL = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.D.R.L." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FactorReumatoide = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor Reumatoide" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ASO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "A.S.O." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.TSanguinea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tipificacion Sanguinea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FactorRH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor RH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hvc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HVC" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Pcr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "P.C.R." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.G." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGM = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.M." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisC = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis C" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.PruebdeEmbarazo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Prueba de Embarazo" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaThupiO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Thupi O" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaTyphiH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Typhi H" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiA = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi A" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.BrucelaAbortus = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Brucela Abortus" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ProteusOxig = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteus Oxig" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glicemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glicemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Colesterol = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Colesterol" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Trigliceridos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Trigliceridos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Urea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Creatinina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Creatinina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Sgot = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.O.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Sgtp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.P.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AcUrico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acido úrico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Bil = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "BILIRRUBINA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Directa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Directa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Indirecta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Indirecta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Total = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HPilory = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H. Pilory" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ck = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Hdl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Vldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "VLDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Amilasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Amilasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Lipasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Lipasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAcida = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Acida" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAlcalina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Alcalina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HbGlucosilada = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb Glucosilada" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.ProteinaTotal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteína Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AlbuminaQ = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina Q" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Globulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.RelacionAG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Relacion A/G" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ldh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ckmb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK-MB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.RtoGb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Rto GB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Fal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "FAL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tgo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGO" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tgp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Proteinas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteínas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Glucemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Insulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Insulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Homa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HOMA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.HbA1C = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb A1c" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tg = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TG" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Tsh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TSH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Calcio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Calcio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Pth = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "PTH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.VitD = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Vit. D" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Magnesio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Magnesio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.AcFolico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ac. Fólico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Ferremia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ferremia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B1 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B1" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B6 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B6" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.B12 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B12" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue
        //    ViewBag.Zinc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Zinc" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString()); //el primer corresponde al textfield y lue

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateLaboratoryResults(LaboratoryTest laboratoryResult)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(laboratoryResult);
        //    _db.LaboratoryTests.Add(laboratoryResult);
        //    await _db.SaveChangesAsync();

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("DetailsLaboratoryResults/" + laboratoryResult.LaboratoryTestId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //public async Task<ActionResult> EditLaboratoryResults(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var laboratoryResult = await _db.LaboratoryTests.FindAsync(id);

        //    if (laboratoryResult == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (laboratoryResult.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    if (reference != null)
        //    {
        //        Session["MasterId"] = masterId;
        //        Session["Reference"] = reference;

        //    }
        //    else
        //    {
        //        Session["MasterId"] = 0;
        //        Session["Reference"] = 0;
        //    }
        //    //var view = new LaboratoryResult { PatientId = laboratoryResult.PatientId, LaboratoryResultId=laboratoryResult.LaboratoryResultId};

        //    //   //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", laboratoryResult.PatientId);
        //    // return View(laboratoryResult);

        //    ViewBag.Albumina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albumina" && p.Laboratory.AuthorId == autorid)
        //            .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Albumina); //el primer corresponde al textfield y lue
        //    ViewBag.Hb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb" && p.Laboratory.AuthorId == autorid)
        //                .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hb); //el primer corresponde al textfield y lue
        //    ViewBag.Hto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hto" && p.Laboratory.AuthorId == autorid)
        //               .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hto); //el primer corresponde al textfield y lue
        //    ViewBag.Gb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "G.B." && p.Laboratory.AuthorId == autorid)
        //              .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Gb); //el primer corresponde al textfield y lue
        //    ViewBag.Gr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "GR" && p.Laboratory.AuthorId == autorid)
        //             .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Gr); //el primer corresponde al textfield y lue
        //    ViewBag.Tp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tp); //el primer corresponde al textfield y lue
        //    ViewBag.Grs = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Grs" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Grs); //el primer corresponde al textfield y lue
        //    ViewBag.Vcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Vcm); //el primer corresponde al textfield y lue
        //    ViewBag.Hcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hcm); //el primer corresponde al textfield y lue
        //    ViewBag.Chcm = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "C.H.C.M" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Chcm); //el primer corresponde al textfield y lue
        //    ViewBag.Tpt = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TPT" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tpt); //el primer corresponde al textfield y lue
        //    ViewBag.Segmentados = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Segmentados" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Segmentados); //el primer corresponde al textfield y lue
        //    ViewBag.Linfocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Linfocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Linfocitos); //el primer corresponde al textfield y lue
        //    ViewBag.Eosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Eosinofilos); //el primer corresponde al textfield y lue
        //    ViewBag.Banda = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Banda" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Banda); //el primer corresponde al textfield y lue
        //    ViewBag.Monocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Monocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Monocitos); //el primer corresponde al textfield y lue
        //    ViewBag.Basofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Basofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Basofilos); //el primer corresponde al textfield y lue
        //    ViewBag.CelJuveniles = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Juveniles" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CelJuveniles); //el primer corresponde al textfield y lue
        //    ViewBag.CelFalciformes = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Falciformes" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CelFalciformes); //el primer corresponde al textfield y lue
        //    ViewBag.Eritrosedimentacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Eritrosedimentacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Eritrosedimentacion); //el primer corresponde al textfield y lue
        //    ViewBag.TdeSangria = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Sangria" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.TdeSangria); //el primer corresponde al textfield y lue
        //    ViewBag.TdeCoagulacion = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tiempo de Coagulacion" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.TdeCoagulacion); //el primer corresponde al textfield y lue
        //    ViewBag.CdePlaquetas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Plaquetas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CdePlaquetas); //el primer corresponde al textfield y lue
        //    ViewBag.CdeEosinofilos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Eosinofilos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CdeEosinofilos); //el primer corresponde al textfield y lue
        //    ViewBag.CdeReticulocitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Conteo de Reticulocitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CdeReticulocitos); //el primer corresponde al textfield y lue
        //    ViewBag.Hematozoarios = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hematozoarios" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hematozoarios); //el primer corresponde al textfield y lue
        //    ViewBag.ExtdeSangPeriferica = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ext de Sangre Periferica" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ExtdeSangPeriferica); //el primer corresponde al textfield y lue
        //    ViewBag.Color = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Color" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Color); //el primer corresponde al textfield y lue
        //    ViewBag.Olor = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Olor" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Olor); //el primer corresponde al textfield y lue
        //    ViewBag.Aspecto = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Aspecto" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Aspecto); //el primer corresponde al textfield y lue
        //    ViewBag.Densidad = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Densidad" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Densidad); //el primer corresponde al textfield y lue
        //    ViewBag.Ph = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ph" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ph); //el primer corresponde al textfield y lue
        //    ViewBag.Glucosa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucosa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Glucosa); //el primer corresponde al textfield y lue
        //    ViewBag.Albúmina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Albumina); //el primer corresponde al textfield y lue
        //    ViewBag.Acetona = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acetona" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Acetona); //el primer corresponde al textfield y lue
        //    ViewBag.SangOculta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.SangOculta); //el primer corresponde al textfield y lue
        //    ViewBag.Bilirrubina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Bilirrubina); //el primer corresponde al textfield y lue
        //    ViewBag.Urobilinogeno = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urobilinogeno" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Urobilinogeno); //el primer corresponde al textfield y lue
        //    ViewBag.Nitrito = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Nitrito" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Nitrito); //el primer corresponde al textfield y lue
        //    ViewBag.GBlancos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Blancos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.GBlancos); //el primer corresponde al textfield y lue
        //    ViewBag.GRojos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulos Rojos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.GRojos); //el primer corresponde al textfield y lue
        //    ViewBag.CelEpiteliales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Celulas Epiteliales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.CelEpiteliales); //el primer corresponde al textfield y lue
        //    ViewBag.Bacterias = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bacterias" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Bacterias); //el primer corresponde al textfield y lue
        //    ViewBag.Cristales = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cristales" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Cristales); //el primer corresponde al textfield y lue
        //    ViewBag.FibMucosas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fibras Mucosas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.FibMucosas); //el primer corresponde al textfield y lue
        //    ViewBag.Cilindros = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Cilindros" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Cilindros); //el primer corresponde al textfield y lue
        //    ViewBag.Levaduras = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Levaduras" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Levaduras); //el primer corresponde al textfield y lue
        //    ViewBag.Parasitos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Parasitos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Parasitos); //el primer corresponde al textfield y lue
        //    ViewBag.Huevos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Huevos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Huevos); //el primer corresponde al textfield y lue
        //    ViewBag.InvdeAmebas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Investigacion de Amebas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.InvdeAmebas); //el primer corresponde al textfield y lue
        //    ViewBag.SangOcultaCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Sangre Oculta Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.SangOcultaCop); //el primer corresponde al textfield y lue
        //    ViewBag.OtrosCop = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Otros Coop" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.OtrosCop); //el primer corresponde al textfield y lue
        //    ViewBag.HIV = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H.I.V" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hiv); //el primer corresponde al textfield y lue
        //    ViewBag.VDRL = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "V.D.R.L." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Vdrl); //el primer corresponde al textfield y lue
        //    ViewBag.FactorReumatoide = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor Reumatoide" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.FactorReumatoide); //el primer corresponde al textfield y lue
        //    ViewBag.ASO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "A.S.O." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Aso); //el primer corresponde al textfield y lue
        //    ViewBag.TSanguinea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Tipificacion Sanguinea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.TSanguinea); //el primer corresponde al textfield y lue
        //    ViewBag.FactorRH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Factor RH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.FactorRH); //el primer corresponde al textfield y lue
        //    ViewBag.Hvc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HVC" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hvc); //el primer corresponde al textfield y lue
        //    ViewBag.Pcr = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "P.C.R." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Pcr); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.G." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ToxoIGG); //el primer corresponde al textfield y lue
        //    ViewBag.ToxoIGM = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Toxoplasmosis I.G.M." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ToxoIGM); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.HepatitisB); //el primer corresponde al textfield y lue
        //    ViewBag.HepatitisC = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hepatitis C" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.HepatitisC); //el primer corresponde al textfield y lue
        //    ViewBag.PruebdeEmbarazo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Prueba de Embarazo" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.PruebdeEmbarazo); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaThupiO = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Thupi O" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.SalmonelaThupiO); //el primer corresponde al textfield y lue
        //    ViewBag.SalmonelaTyphiH = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Salmonela Typhi H" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.SalmonelaTyphiH); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiA = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi A" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ParatyphiA); //el primer corresponde al textfield y lue
        //    ViewBag.ParatyphiB = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Paratyphi B" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ParatyphiB); //el primer corresponde al textfield y lue
        //    ViewBag.BrucelaAbortus = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Brucela Abortus" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.BrucelaAbortus); //el primer corresponde al textfield y lue
        //    ViewBag.ProteusOxig = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteus Oxig" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ProteusOxig); //el primer corresponde al textfield y lue
        //    ViewBag.Glicemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glicemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Glicemia); //el primer corresponde al textfield y lue
        //    ViewBag.Colesterol = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Colesterol" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Colesterol); //el primer corresponde al textfield y lue
        //    ViewBag.Trigliceridos = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Trigliceridos" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Trigliceridos); //el primer corresponde al textfield y lue
        //    ViewBag.Urea = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Urea" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Urea); //el primer corresponde al textfield y lue
        //    ViewBag.Creatinina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Creatinina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Creatinina); //el primer corresponde al textfield y lue
        //    ViewBag.Sgot = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.O.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Sgot); //el primer corresponde al textfield y lue
        //    ViewBag.Sgtp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "S.G.P.T." && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Sgtp); //el primer corresponde al textfield y lue
        //    ViewBag.AcUrico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Acido úrico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.AcUrico); //el primer corresponde al textfield y lue
        //    ViewBag.Bil = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "BILIRRUBINA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Bil); //el primer corresponde al textfield y lue
        //    ViewBag.Directa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Directa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Directa); //el primer corresponde al textfield y lue
        //    ViewBag.Indirecta = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Indirecta" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Indirecta); //el primer corresponde al textfield y lue
        //    ViewBag.Total = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Bilirrubina Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Total); //el primer corresponde al textfield y lue
        //    ViewBag.HPilory = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "H. Pilory" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.HPilory); //el primer corresponde al textfield y lue
        //    ViewBag.Ck = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ck); //el primer corresponde al textfield y lue
        //    ViewBag.Hdl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Hdl); //el primer corresponde al textfield y lue
        //    ViewBag.Ldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ldl); //el primer corresponde al textfield y lue
        //    ViewBag.Vldl = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "VLDL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Vldl); //el primer corresponde al textfield y lue
        //    ViewBag.Amilasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Amilasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Amilasa); //el primer corresponde al textfield y lue
        //    ViewBag.Lipasa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Lipasa" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Lipasa); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAcida = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Acida" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.FosfatasaAcida); //el primer corresponde al textfield y lue
        //    ViewBag.FosfatasaAlcalina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Fosfatasa Alcalina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.FosfatasaAlcalina); //el primer corresponde al textfield y lue
        //    ViewBag.HbGlucosilada = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb Glucosilada" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.HbGlucosilada); //el primer corresponde al textfield y lue
        //    ViewBag.ProteinaTotal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteína Total" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.ProteinaTotal); //el primer corresponde al textfield y lue
        //    ViewBag.AlbuminaQ = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Albúmina Q" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.AlbuminaQ); //el primer corresponde al textfield y lue
        //    ViewBag.Globulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Globulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Globulina); //el primer corresponde al textfield y lue
        //    ViewBag.RelacionAG = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Relacion A/G" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.RelacionAG); //el primer corresponde al textfield y lue
        //    ViewBag.Ldh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "LDH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ldh); //el primer corresponde al textfield y lue
        //    ViewBag.Ckmb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "CK-MB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ckmb); //el primer corresponde al textfield y lue
        //    ViewBag.RtoGb = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Rto GB" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.RtoGb); //el primer corresponde al textfield y lue
        //    ViewBag.Fal = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "FAL" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Fal); //el primer corresponde al textfield y lue
        //    ViewBag.Tgo = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGO" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tgo); //el primer corresponde al textfield y lue
        //    ViewBag.Tgp = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TGP" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tgp); //el primer corresponde al textfield y lue
        //    ViewBag.Proteinas = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Proteínas" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Proteinas); //el primer corresponde al textfield y lue
        //    ViewBag.Glucemia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Glucemia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Glucemia); //el primer corresponde al textfield y lue
        //    ViewBag.Insulina = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Insulina" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Insulina); //el primer corresponde al textfield y lue
        //    ViewBag.Homa = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "HOMA" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Homa); //el primer corresponde al textfield y lue
        //    ViewBag.HbA1C = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Hb A1c" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.HbA1C); //el primer corresponde al textfield y lue
        //    ViewBag.Tg = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TG" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tg); //el primer corresponde al textfield y lue
        //    ViewBag.Tsh = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "TSH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Tsh); //el primer corresponde al textfield y lue
        //    ViewBag.Calcio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Calcio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Calcio); //el primer corresponde al textfield y lue
        //    ViewBag.Pth = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "PTH" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Pth); //el primer corresponde al textfield y lue
        //    ViewBag.VitD = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Vit. D" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.VitD); //el primer corresponde al textfield y lue
        //    ViewBag.Magnesio = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Magnesio" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Magnesio); //el primer corresponde al textfield y lue
        //    ViewBag.AcFolico = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ac. Fólico" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.AcFolico); //el primer corresponde al textfield y lue
        //    ViewBag.Ferremia = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Ferremia" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Ferremia); //el primer corresponde al textfield y lue
        //    ViewBag.B1 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B1" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.B1); //el primer corresponde al textfield y lue
        //    ViewBag.B6 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B6" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.B6); //el primer corresponde al textfield y lue
        //    ViewBag.B12 = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "B12" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.B12); //el primer corresponde al textfield y lue
        //    ViewBag.Zinc = _db.LaboratoryDetails.Where(p => p.Laboratory.Name == "Zinc" && p.Laboratory.AuthorId == autorid)
        //                         .ToSelectListItems(p => p.Result, p => p.LaboratoryDetailId.ToString(), l => l.LaboratoryDetailId == laboratoryResult.Zinc); //el primer corresponde al textfield y lue


        //    return View(laboratoryResult);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditLaboratoryResults(LaboratoryTest laboratoryResult)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View();
        //    _db.Entry(laboratoryResult).State = EntityState.Modified;

        //    await _db.SaveChangesAsync();

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("DetailsLaboratoryResults/" + laboratoryResult.LaboratoryTestId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //public async Task<ActionResult> DeleteLaboratoryResults(int? id, int? reference, int? masterId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "LaboratoryResults", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var laboratoryResult = await _db.LaboratoryTests.FindAsync(id);

        //    if (laboratoryResult == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (laboratoryResult.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.LaboratoryTests.Remove(laboratoryResult);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }

        //    return Convert.ToInt32(Session["MasterId"]) == 0 ? RedirectToAction("IndexLaboratoryResults/" + laboratoryResult.PatientId) : RedirectToAction(string.Format(ReturnReference(Convert.ToInt32(Session["MasterId"])) + "/" + Convert.ToInt32(Session["MasterId"])));
        //}

        //#endregion

        //#region BariatricVisitsController

        //public async Task<ActionResult> CreateBariatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var bariatric = await _db.Bariatrics.FindAsync(id);

        //    if (bariatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var view = new BariatricVisit { BariatricId = bariatric.BariatricId, PatientId = bariatric.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateBariatricVisits(BariatricVisit bariatricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(bariatricVisit);
        //    _db.BariatricVisits.Add(bariatricVisit);
        //    await _db.SaveChangesAsync();

        //    var bariatric = await _db.Bariatrics.FindAsync(bariatricVisit.BariatricId);
        //    if (bariatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    return RedirectToAction($"DetailsBariatric/{bariatric.BariatricId}");
        //}

        //public async Task<ActionResult> EditBariatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var bariatricVisit = await _db.BariatricVisits.FindAsync(id);
        //    if (bariatricVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatricVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", bariatricVisit.PatientId);
        //    ViewBag.BariatricId = new SelectList(_db.Bariatrics, "BariatricId", "BariatricId", bariatricVisit.BariatricId);
        //    return View(bariatricVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditBariatricVisits(BariatricVisit bariatricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(bariatricVisit);
        //    _db.Entry(bariatricVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsBariatric/{bariatricVisit.BariatricId}");

        //}

        //public async Task<ActionResult> DeleteBariatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var bariatricVisits = await _db.BariatricVisits.FindAsync(id);
        //    if (bariatricVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatricVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    _db.BariatricVisits.Remove(bariatricVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsBariatric/{bariatricVisits.BariatricId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region BariatricController

        //public async Task<ActionResult> IndexBariatrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }//patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Bariatrics.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateBariatric/{id}");
        //    }

        //    var bariatric = _db.Bariatrics.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await bariatric.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsBariatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var bariatrics = await _db.Bariatrics.FindAsync(id);
        //    if (bariatrics == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatrics.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", bariatrics.PatientId);
        //    //   ViewBag.BloodTypeId = new SelectList(_db.BloodTypes.Where(p => p.BloodTypeId == bariatrics.Patient.BloodTypeId), "BloodTypeId", "Name");
        //    return View(bariatrics);






        //}

        //public async Task<ActionResult> CreateBariatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Bariatric { PatientId = patient.PatientId, };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateBariatric(Bariatric bariatric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(bariatric);
        //    _db.Bariatrics.Add(bariatric);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsBariatric/{bariatric.BariatricId}");
        //}

        //public async Task<ActionResult> EditBariatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var bariatric = await _db.Bariatrics.FindAsync(id);
        //    if (bariatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (bariatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", bariatric.PatientId);
        //    return View(bariatric);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditBariatric(Bariatric bariatric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Bariatrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(bariatric);
        //    _db.Entry(bariatric).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsBariatric/{bariatric.BariatricId}");
        //}

        //#endregion

        //#region InmunizationsController

        //public async Task<ActionResult> CreateInmunizations(int? id, int? pediatricId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Inmunizations", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.PediatricId = pediatricId ?? 0;


        //    ViewBag.VaccineId = new SelectList(_db.Vaccines, "VaccineId", "Name");
        //    var view = new Inmunization { PatientId = patient.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateInmunizations(Inmunization inmunization)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Inmunizations", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(inmunization);
        //    _db.Inmunizations.Add(inmunization);
        //    await _db.SaveChangesAsync();

        //    //var patient = await _db.Patients.FindAsync(inmunization.PatientId);
        //    //if (patient == null)
        //    //{
        //    //   return View("Error");
        //    //}
        //    return RedirectToAction(ViewBag.PediatricId == 0 ? $"DetailsPatient/{inmunization.PatientId}" : $"DetailsPediatric/{inmunization.PatientId}");
        //}

        //public async Task<ActionResult> EditInmunizations(int? id, int? pediatricId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Inmunizations", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var inmunization = await _db.Inmunizations.FindAsync(id);
        //    if (inmunization == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (inmunization.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.PediatricId = pediatricId ?? 0;
        //    ViewBag.VaccineId = new SelectList(_db.Vaccines, "VaccineId", "Name", inmunization.VaccineId);
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", inmunization.PatientId);
        //    return View(inmunization);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditInmunizations(Inmunization inmunization)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Inmunizations", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(inmunization);
        //    _db.Entry(inmunization).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", inmunization.PatientId);
        //    ViewBag.VaccineId = new SelectList(_db.Vaccines, "VaccineId", "Name", inmunization.VaccineId);
        //    //return RedirectToAction($"DetailsPatient/{inmunization.PatientId}");
        //    return RedirectToAction(ViewBag.PediatricId == 0 ? $"DetailsPatient/{inmunization.PatientId}" : $"DetailsPediatric/{inmunization.PatientId}");

        //    // return View(Patient);
        //}

        //public async Task<ActionResult> DeleteInmunizations(int? id, int? pediatricId)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Inmunizations", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var inmunizations = await _db.Inmunizations.FindAsync(id);
        //    if (inmunizations == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (inmunizations.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.Inmunizations.Remove(inmunizations);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }

        //    return RedirectToAction(ViewBag.PediatricId == 0 ? $"DetailsPatient/{inmunizations.PatientId}" : $"DetailsPediatric/{inmunizations.PatientId}");

        //    //return view();

        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region PediatricGrowthsController

        //public async Task<ActionResult> CreatePediatricGrowths(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var pediatric = await _db.Pediatrics.FindAsync(id);

        //    if (pediatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var rtList = new List<GenericList>();
        //    for (int i = 0; i < 61; i++)
        //    {
        //        var element = new GenericList
        //        {
        //            Id = i,
        //            Name = i + " Meses"
        //        };
        //        rtList.Add(element);
        //    }

        //    ViewBag.MonthCountId = new SelectList(rtList, "Id", "Name");

        //    //foreach (var item in dbList)
        //    //{
        //    //    var element = new GenericList
        //    //    {
        //    //        Id = item.LaboratoryId,
        //    //        Name = item.Name
        //    //    };
        //    //    rtList.Add(element);
        //    //}
        //    var view = new PediatricGrowth { PediatricId = pediatric.PediatricId, PatientId = pediatric.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreatePediatricGrowths(PediatricGrowth pediatricGrowth)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatricGrowth);
        //    _db.PediatricGrowths.Add(pediatricGrowth);
        //    await _db.SaveChangesAsync();

        //    var pediatric = await _db.Pediatrics.FindAsync(pediatricGrowth.PediatricId);
        //    if (pediatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    return RedirectToAction($"DetailsPediatric/{pediatric.PatientId}");
        //}

        //public async Task<ActionResult> EditPediatricGrowths(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var pediatricGrowth = await _db.PediatricGrowths.FindAsync(id);
        //    if (pediatricGrowth == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatricGrowth.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var rtList = new List<GenericList>();
        //    for (int i = 0; i < 61; i++)
        //    {
        //        var element = new GenericList
        //        {
        //            Id = i,
        //            Name = i + " Meses"
        //        };
        //        rtList.Add(element);
        //    }

        //    ViewBag.MonthCountId = new SelectList(rtList, "Id", "Name", pediatricGrowth.MonthCountId);
        //    ViewBag.PediatricId = new SelectList(_db.Pediatrics, "PediatricId", "PediatricId", pediatricGrowth.PediatricId);
        //    return View(pediatricGrowth);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditPediatricGrowths(PediatricGrowth pediatricGrowth)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatricGrowth);
        //    _db.Entry(pediatricGrowth).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsPediatric/{pediatricGrowth.PatientId}");

        //}

        //public async Task<ActionResult> DeletePediatricGrowths(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var pediatricGrowths = await _db.PediatricGrowths.FindAsync(id);
        //    if (pediatricGrowths == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatricGrowths.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.PediatricGrowths.Remove(pediatricGrowths);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsPediatric/{pediatricGrowths.PatientId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region PediatricVisitsController

        //public async Task<ActionResult> CreatePediatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var pediatric = await _db.Pediatrics.FindAsync(id);

        //    if (pediatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ////ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // ViewBag.PediatricId = new SelectList(_db.Pediatrics, "PediatricId", "PediatricId");

        //    var view = new PediatricVisit { PediatricId = pediatric.PediatricId, PatientId = pediatric.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreatePediatricVisits(PediatricVisit pediatricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatricVisit);
        //    _db.PediatricVisits.Add(pediatricVisit);
        //    await _db.SaveChangesAsync();

        //    var pediatric = await _db.Pediatrics.FindAsync(pediatricVisit.PediatricId);
        //    if (pediatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    return RedirectToAction($"DetailsPediatric/{pediatric.PatientId}");
        //}

        //public async Task<ActionResult> EditPediatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var pediatricVisit = await _db.PediatricVisits.FindAsync(id);
        //    if (pediatricVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatricVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", pediatricVisit.PatientId);
        //    ViewBag.PediatricId = new SelectList(_db.Pediatrics, "PediatricId", "PediatricId", pediatricVisit.PediatricId);
        //    return View(pediatricVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditPediatricVisits(PediatricVisit pediatricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatricVisit);
        //    _db.Entry(pediatricVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", pediatricVisit.PatientId);
        //    return RedirectToAction($"DetailsPediatric/{pediatricVisit.PatientId}");
        //    // return View(Pediatric);
        //}

        //public async Task<ActionResult> DeletePediatricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var pediatricVisits = await _db.PediatricVisits.FindAsync(id);
        //    if (pediatricVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatricVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.PediatricVisits.Remove(pediatricVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsPediatric/{pediatricVisits.PatientId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region PediatricController

        //public async Task<ActionResult> DetailsPediatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Pediatrics.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        //create
        //        //return View("Error");
        //        //  return RedirectToAction("Index");
        //        //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", patient.PersonId);
        //        return RedirectToAction($"CreatePediatric/{id}");
        //    }

        //    var his = await _db.Pediatrics.FindAsync(hasHistory.PediatricId);

        //    if (his == null)
        //    {
        //        return View("Error");
        //    }

        //    // var view = new Pediatric { PediatricId = hasHistory.PediatricId, };
        //    // return RedirectToAction($"EditPediatric/{hasHistory.PediatricId}");
        //    //return View(view);
        //    return View(his);

        //}

        //public async Task<ActionResult> CreatePediatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Pediatric { PatientId = patient.PatientId, };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreatePediatric(Pediatric pediatric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatric);
        //    _db.Pediatrics.Add(pediatric);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsPediatric/{pediatric.PatientId}");
        //}

        //public async Task<ActionResult> EditPediatric(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var pediatric = await _db.Pediatrics.FindAsync(id);
        //    if (pediatric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (pediatric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", pediatric.PatientId);
        //    return View(pediatric);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditPediatric(Pediatric pediatric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Pediatric", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(pediatric);
        //    _db.Entry(pediatric).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", pediatric.PatientId);
        //    return RedirectToAction($"DetailsPediatric/{pediatric.PatientId}");
        //    // return View(Pediatric);
        //}

        //#endregion

        //#region CardiologiesController
        //public async Task<ActionResult> IndexCardiologies(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Cardiologies.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateCardiologies/{id}");
        //    }

        //    var cardiologies = _db.Cardiologies.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await cardiologies.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsCardiologies(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var cardiology = await _db.Cardiologies.FindAsync(id);
        //    if (cardiology == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (cardiology.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", cardiology.PatientId);
        //    return View(cardiology);
        //}

        //public async Task<ActionResult> CreateCardiologies(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Cardiology { PatientId = patient.PatientId, };

        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateCardiologies(Cardiology cardiologies)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Cardiologies.Add(cardiologies);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsCardiologies/{cardiologies.CardiologyId}");
        //        //return RedirectToAction($"IndexCardiologies/{Cardiologies.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", cardiologies.PatientId);
        //    return View(cardiologies);

        //}

        //public async Task<ActionResult> EditCardiologies(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var cardiologies = await _db.Cardiologies.FindAsync(id);
        //    if (cardiologies == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (cardiologies.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", cardiologies.PatientId);
        //    return View(cardiologies);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditCardiologies(Cardiology cardiologies)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(cardiologies).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexCardiologies/{Cardiologies.PatientId}");
        //        return RedirectToAction($"DetailsCardiologies/{cardiologies.CardiologyId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", cardiologies.PatientId);

        //    return View(cardiologies);

        //}

        //public async Task<ActionResult> DeleteCardiologies(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Cardiologies", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var cardiologies = await _db.Cardiologies.FindAsync(id);
        //    if (cardiologies == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (cardiologies.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.Cardiologies.Remove(cardiologies);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexCardiologies/{cardiologies.PatientId}");

        //}

        //#endregion

        //#region AnalyticalSheetsBController
        //public async Task<ActionResult> IndexAnalyticalSheetsB(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.AnalyticalSheets.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateAnalyticalSheetsB/{id}");
        //    }

        //    var analyticalSheets = _db.AnalyticalSheets.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await analyticalSheets.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsAnalyticalSheetsB(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.AuthorId = analyticalSheets.Patient.Person.AuthorId;
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);
        //    return View(analyticalSheets);
        //}

        //public async Task<ActionResult> CreateAnalyticalSheetsB(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // var view = new AnalyticalSheet { PatientId = patient.PatientId, };

        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }
        //    var view = new AnalyticalSheet { PatientId = patient.PatientId, DoctorText = doctor.User.FirstName + " " + doctor.User.LastName, PatientName = patient.Person.Name + " " + patient.Person.LastName };


        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAnalyticalSheetsB(AnalyticalSheet analyticalSheets)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.AnalyticalSheets.Add(analyticalSheets);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsAnalyticalSheetsB/{analyticalSheets.AnalyticalSheetId}");
        //        //return RedirectToAction($"IndexAnalyticalSheets/{AnalyticalSheets.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", analyticalSheets.PatientId);
        //    return View(analyticalSheets);

        //}

        //public async Task<ActionResult> EditAnalyticalSheetsB(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);
        //    return View(analyticalSheets);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAnalyticalSheetsB(AnalyticalSheet analyticalSheets)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(analyticalSheets).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexAnalyticalSheets/{AnalyticalSheets.PatientId}");
        //        return RedirectToAction($"DetailsAnalyticalSheetsB/{analyticalSheets.AnalyticalSheetId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);

        //    return View(analyticalSheets);

        //}

        //public async Task<ActionResult> DeleteAnalyticalSheetsB(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.AnalyticalSheets.Remove(analyticalSheets);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexAnalyticalSheetsB/{analyticalSheets.PatientId}");

        //}

        //#endregion

        //#region AnalyticalSheetsController
        //public async Task<ActionResult> IndexAnalyticalSheets(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.AnalyticalSheets.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateAnalyticalSheets/{id}");
        //    }

        //    var analyticalSheets = _db.AnalyticalSheets.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await analyticalSheets.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsAnalyticalSheets(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.AuthorId = analyticalSheets.Patient.Person.AuthorId;
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);
        //    return View(analyticalSheets);
        //}

        //public async Task<ActionResult> CreateAnalyticalSheets(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // var view = new AnalyticalSheet { PatientId = patient.PatientId, };

        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }
        //    var view = new AnalyticalSheet { PatientId = patient.PatientId, DoctorText = doctor.User.FirstName + " " + doctor.User.LastName, PatientName = patient.Person.Name + " " + patient.Person.LastName };


        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateAnalyticalSheets(AnalyticalSheet analyticalSheets)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.AnalyticalSheets.Add(analyticalSheets);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsAnalyticalSheets/{analyticalSheets.AnalyticalSheetId}");
        //        //return RedirectToAction($"IndexAnalyticalSheets/{AnalyticalSheets.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", analyticalSheets.PatientId);
        //    return View(analyticalSheets);

        //}

        //public async Task<ActionResult> EditAnalyticalSheets(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);
        //    return View(analyticalSheets);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditAnalyticalSheets(AnalyticalSheet analyticalSheets)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(analyticalSheets).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexAnalyticalSheets/{AnalyticalSheets.PatientId}");
        //        return RedirectToAction($"DetailsAnalyticalSheets/{analyticalSheets.AnalyticalSheetId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", analyticalSheets.PatientId);

        //    return View(analyticalSheets);

        //}

        //public async Task<ActionResult> DeleteAnalyticalSheets(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "AnalyticalSheets", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var analyticalSheets = await _db.AnalyticalSheets.FindAsync(id);
        //    if (analyticalSheets == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (analyticalSheets.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.AnalyticalSheets.Remove(analyticalSheets);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexAnalyticalSheets/{analyticalSheets.PatientId}");

        //}

        //#endregion

        //#region MedicalCertificatesController
        //public async Task<ActionResult> IndexMedicalCertificates(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.MedicalCertificates.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateMedicalCertificates/{id}");
        //    }

        //    var medicalCertificates = _db.MedicalCertificates.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await medicalCertificates.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsMedicalCertificates(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCertificate = await _db.MedicalCertificates.FindAsync(id);
        //    if (medicalCertificate == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCertificate.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", medicalCertificate.PatientId);
        //    ViewBag.AuthorId = medicalCertificate.Patient.Person.AuthorId;
        //    return View(medicalCertificate);
        //}

        //public async Task<ActionResult> CreateMedicalCertificates(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }


        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new MedicalCertificate { PatientId = patient.PatientId, DoctorText = doctor.User.FirstName + " " + doctor.User.LastName, Exequartur = doctor.Record, PatientName = patient.Person.Name + " " + patient.Person.LastName, Place = doctor.City, Cmd = doctor.Cmd };

        //    return View(view);




        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateMedicalCertificates(MedicalCertificate medicalCertificates)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.MedicalCertificates.Add(medicalCertificates);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsMedicalCertificates/{medicalCertificates.MedicalCertificateId}");
        //        //return RedirectToAction($"IndexMedicalCertificates/{MedicalCertificates.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", medicalCertificates.PatientId);
        //    return View(medicalCertificates);

        //}

        //public async Task<ActionResult> EditMedicalCertificates(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCertificates = await _db.MedicalCertificates.FindAsync(id);
        //    if (medicalCertificates == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    return medicalCertificates.Patient.Person.AuthorId != autorid ? View("Error") : View(medicalCertificates);
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", medicalCertificates.PatientId);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditMedicalCertificates(MedicalCertificate medicalCertificates)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(medicalCertificates).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexMedicalCertificates/{MedicalCertificates.PatientId}");
        //        return RedirectToAction($"DetailsMedicalCertificates/{medicalCertificates.MedicalCertificateId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", medicalCertificates.PatientId);

        //    return View(medicalCertificates);

        //}

        //public async Task<ActionResult> DeleteMedicalCertificates(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "MedicalCertificates", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var medicalCertificates = await _db.MedicalCertificates.FindAsync(id);
        //    if (medicalCertificates == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (medicalCertificates.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.MedicalCertificates.Remove(medicalCertificates);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexMedicalCertificates/{medicalCertificates.PatientId}");

        //}

        //#endregion

        //#region RecipesController
        //public async Task<ActionResult> IndexRecipes(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Recipes.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateRecipes/{id}");
        //    }

        //    var recipes = _db.Recipes.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await recipes.ToListAsync());

        //}
        //public async Task<ActionResult> DetailsRecipes(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var recipe = await _db.Recipes.FindAsync(id);
        //    if (recipe == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (recipe.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", recipe.PatientId);
        //    ViewBag.AuthorId = recipe.Patient.Person.AuthorId;
        //    return View(recipe);
        //}


        //public async Task<ActionResult> CreateRecipes(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    // //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // var view = new Recipe { PatientId = patient.PatientId, };


        //    var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (doctor == null)
        //    {
        //        return RedirectToAction("CreateDoctorInformation", "Authors", new { area = "Configurations" });
        //    }

        //    var view = new Recipe { PatientId = patient.PatientId, DoctorText = doctor.User.FirstName + " " + doctor.User.LastName, PatientName = patient.Person.Name + " " + patient.Person.LastName, Place = doctor.City };

        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateRecipes(Recipe recipes)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Recipes.Add(recipes);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsRecipes/{recipes.RecipeId}");
        //        //return RedirectToAction($"IndexRecipes/{Recipes.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", recipes.PatientId);
        //    return View(recipes);

        //}

        //public async Task<ActionResult> EditRecipes(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var recipes = await _db.Recipes.FindAsync(id);
        //    if (recipes == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    return recipes.Patient.Person.AuthorId != autorid ? View("Error") : View(recipes);
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", recipes.PatientId);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditRecipes(Recipe recipes)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {

        //        _db.Entry(recipes).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexRecipes/{Recipes.PatientId}");
        //        return RedirectToAction($"DetailsRecipes/{recipes.RecipeId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", recipes.PatientId);

        //    return View(recipes);

        //}

        //public async Task<ActionResult> DeleteRecipes(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Recipes", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var recipes = await _db.Recipes.FindAsync(id);
        //    if (recipes == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (recipes.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    // var Recipes = await _db.Recipes.FindAsync(id);
        //    _db.Recipes.Remove(recipes);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexRecipes/{recipes.PatientId}");

        //}

        //#endregion

        //#region CbstetricVisitsController

        //public async Task<ActionResult> CreateObstetricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var obstetric = await _db.Obstetrics.FindAsync(id);

        //    if (obstetric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    var view = new ObstetricVisit { ObstetricId = obstetric.ObstetricId, PatientId = obstetric.PatientId };
        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateObstetricVisits(ObstetricVisit obstetricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(obstetricVisit);

        //    var obstetric = await _db.Obstetrics.FindAsync(obstetricVisit.ObstetricId);

        //    if (obstetric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var days = Convert.ToDateTime(obstetricVisit.VisitDate) - Convert.ToDateTime(obstetric.Fum);
        //    var weeks = days.Days;
        //    weeks = weeks / 7;
        //    obstetricVisit.GestationalAge = weeks + " Semanas";

        //    _db.ObstetricVisits.Add(obstetricVisit);
        //    await _db.SaveChangesAsync();

        //    return RedirectToAction($"DetailsObstetrics/{obstetricVisit.ObstetricId}");
        //}

        //public async Task<ActionResult> EditObstetricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var obstetricVisit = await _db.ObstetricVisits.FindAsync(id);
        //    if (obstetricVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetricVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", obstetricVisit.PatientId);
        //    return View(obstetricVisit);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditObstetricVisits(ObstetricVisit obstetricVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(obstetricVisit);
        //    _db.Entry(obstetricVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", obstetricVisit.PatientId);
        //    return RedirectToAction($"DetailsObstetrics/{obstetricVisit.ObstetricId}");
        //    // return View(obstetric);
        //}

        //public async Task<ActionResult> DeleteObstetricVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var obstetricVisits = await _db.ObstetricVisits.FindAsync(id);
        //    if (obstetricVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetricVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.ObstetricVisits.Remove(obstetricVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsObstetrics/{obstetricVisits.ObstetricId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region ObstericController
        //public async Task<ActionResult> IndexObstetrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 1);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    //patient id
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var hasHistory = await _db.Obstetrics.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        ViewBag.PatientId = id;
        //        return RedirectToAction($"CreateObstetrics/{id}");
        //    }

        //    var obstetrics = _db.Obstetrics.Include(o => o.Patient).Where(p => p.PatientId == id);
        //    ViewBag.PatientId = id;
        //    return View(await obstetrics.ToListAsync());

        //}

        //public async Task<ActionResult> DetailsObstetrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var obstetric = await _db.Obstetrics.FindAsync(id);
        //    if (obstetric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", obstetric.PatientId);
        //    ViewBag.BloodTypeId = new SelectList(_db.BloodTypes.Where(p => p.BloodTypeId == obstetric.Patient.BloodTypeId), "BloodTypeId", "Name");
        //    return View(obstetric);
        //}

        //public async Task<ActionResult> CreateObstetrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    ViewBag.BloodTypeId = new SelectList(_db.BloodTypes.Where(p => p.BloodTypeId == patient.BloodTypeId), "BloodTypeId", "Name");
        //    var view = new Obstetric { PatientId = patient.PatientId, };

        //    return View(view);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateObstetrics(Obstetric obstetric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var fpp = Convert.ToDateTime(obstetric.Fum);

        //        var addYears = fpp.AddYears(1);
        //        var addMonths = addYears.AddMonths(-3);
        //        var addDays = addMonths.AddDays(7);

        //        obstetric.Fpp = addDays;

        //        _db.Obstetrics.Add(obstetric);
        //        await _db.SaveChangesAsync();

        //        return RedirectToAction($"DetailsObstetrics/{obstetric.ObstetricId}");
        //        //return RedirectToAction($"IndexObstetrics/{obstetric.PatientId}");
        //    }

        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", obstetric.PatientId);
        //    return View(obstetric);

        //}

        //public async Task<ActionResult> EditObstetrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var obstetric = await _db.Obstetrics.FindAsync(id);
        //    if (obstetric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", obstetric.PatientId);
        //    ViewBag.BloodTypeId = new SelectList(_db.BloodTypes.Where(p => p.BloodTypeId == obstetric.Patient.BloodTypeId), "BloodTypeId", "Name");
        //    return View(obstetric);

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditObstetrics(Obstetric obstetric)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var fpp = Convert.ToDateTime(obstetric.Fum);

        //        var addYears = fpp.AddYears(1);
        //        var addMonths = addYears.AddMonths(-3);
        //        var addDays = addMonths.AddDays(7);

        //        obstetric.Fpp = addDays;
        //        _db.Entry(obstetric).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        // return RedirectToAction($"IndexObstetrics/{obstetric.PatientId}");
        //        return RedirectToAction($"DetailsObstetrics/{obstetric.ObstetricId}");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", obstetric.PatientId);
        //    ViewBag.BloodTypeId = new SelectList(_db.BloodTypes.Where(p => p.BloodTypeId == obstetric.Patient.BloodTypeId), "BloodTypeId", "Name");

        //    return View(obstetric);
        //    //if (ModelState.IsValid)
        //    //{
        //    //    const string folder = "~/Content/Patients";

        //    //    var pic = view.Imagen;

        //    //    if (view.ImageFile != null)
        //    //    {
        //    //        pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
        //    //        pic = string.Format("{0}/{1}", folder, pic);
        //    //    }

        //    //    var people = ToPeople(view);
        //    //    people.Imagen = pic;
        //    //    if (people.Tel != null)
        //    //    { people.Tel = StringHelper.RemoveCharacters(people.Tel); }
        //    //    if (people.Cel != null)
        //    //    { people.Cel = StringHelper.RemoveCharacters(people.Cel); }
        //    //    if (people.Rnc != null)
        //    //    { people.Rnc = StringHelper.RemoveCharacters(people.Rnc); }

        //    //    var patient = ToPatient(view);

        //    //    _db.Entry(people).State = EntityState.Modified;
        //    //    _db.Entry(patient).State = EntityState.Modified;
        //    //    await _db.SaveChangesAsync();
        //    //    return RedirectToAction("Index");

        //    //}

        //    //ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name", view.AuthorId);
        //    //ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", view.CountryId);
        //    //ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", view.GenderId);
        //    //ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", view.MaritalSituationId);
        //    //ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", view.OcupationId);
        //    //ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", view.ReligionId);
        //    //ViewBag.StatusId = new SelectList(_db.Status, "StatusId", "Name", view.StatusId);
        //    //ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", view.BloodTypeId);
        //    //ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", view.InsuranceId);
        //    //ViewBag.PersonId = new SelectList(_db.People, "PersonId", "PersonId", view.PersonId);
        //    //ViewBag.SchoolLevelId = new SelectList(_db.SchoolLevels, "SchoolLevelId", "Name", view.SchoolLevelId);

        //    //return View(view);
        //}

        //public async Task<ActionResult> DeleteObstetrics(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Obstetrics", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var obstetric = await _db.Obstetrics.FindAsync(id);
        //    if (obstetric == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (obstetric.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //  return View(obstetric);

        //    // var obstetric = await _db.Obstetrics.FindAsync(id);
        //    _db.Obstetrics.Remove(obstetric);
        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"IndexObstetrics/{obstetric.PatientId}");




        //    //if (id == null)
        //    //{
        //    //    return View("Error");
        //    //}
        //    //var patient = await _db.Patients.FindAsync(id);
        //    //if (patient == null)
        //    //{
        //    //   return View("Error");
        //    //}
        //    //patient.Person.StatusId = 2;
        //    ////if (person != null) _db.People.Remove(person);
        //    //_db.Entry(patient).State = EntityState.Modified;
        //    //await _db.SaveChangesAsync();
        //    //return RedirectToAction("Index");

        //}

        //#endregion

        //#region GynecologyVisitsController

        //public async Task<ActionResult> CreateGynecologyVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var gynecology = await _db.Gynecologies.FindAsync(id);

        //    if (gynecology == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (gynecology.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    ////ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    // ViewBag.GynecologyId = new SelectList(_db.Gynecologies, "GynecologyId", "GynecologyId");

        //    var view = new GynecologyVisit { GynecologyId = gynecology.GynecologyId, PatientId = gynecology.PatientId };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateGynecologyVisits(GynecologyVisit gynecologyVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(gynecologyVisit);
        //    _db.GynecologyVisits.Add(gynecologyVisit);
        //    await _db.SaveChangesAsync();

        //    var gynecology = await _db.Gynecologies.FindAsync(gynecologyVisit.GynecologyId);
        //    if (gynecology == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (gynecology.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction($"DetailsGynecology/{gynecology.PatientId}");
        //}

        //public async Task<ActionResult> EditGynecologicalVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var gynecologyVisit = await _db.GynecologyVisits.FindAsync(id);
        //    if (gynecologyVisit == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (gynecologyVisit.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", gynecologyVisit.PatientId);
        //    return View(gynecologyVisit);
        //    //if (id == null)
        //    //{
        //    //    return View("Error");
        //    //}

        //    ////var patient = await _db.Patients.FindAsync(id);

        //    ////if (patient == null)
        //    ////{
        //    ////   return View("Error");
        //    ////}

        //    ////var gynecology =   _db.Gynecologies.FirstOrDefaultAsyncp=>p.PatientId== patient.PatientId);
        //    //var gynecology = _db.Gynecologies.FirstOrDefaultAsyncp => p.GynecologyId == id);

        //    //if (gynecology == null)
        //    //{
        //    //   return View("Error");
        //    //}
        //    ////ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", gynecology.PatientId);
        //    //var view = new Gynecology { GynecologyId = gynecology.GynecologyId };
        //    //return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditGynecologicalVisits(GynecologyVisit gynecologyVisit)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(gynecologyVisit);
        //    _db.Entry(gynecologyVisit).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", gynecologyVisit.PatientId);
        //    return RedirectToAction($"DetailsGynecology/{gynecologyVisit.PatientId}");
        //    // return View(gynecology);
        //}

        //public async Task<ActionResult> DeleteGynecologyVisits(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 5);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var gynecologyVisits = await _db.GynecologyVisits.FindAsync(id);
        //    if (gynecologyVisits == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (gynecologyVisits.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }

        //    _db.GynecologyVisits.Remove(gynecologyVisits);

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //    //return view();
        //    return RedirectToAction($"DetailsGynecology/{gynecologyVisits.PatientId}");
        //    //  return RedirectToAction("Index");

        //}

        //#endregion

        //#region GynecologyController

        //public async Task<ActionResult> DetailsGynecology(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 2);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    var hasHistory = await _db.Gynecologies.FirstOrDefaultAsync(p => p.PatientId == id);

        //    if (hasHistory == null)
        //    {
        //        //create
        //        //return View("Error");
        //        //  return RedirectToAction("Index");
        //        //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", patient.PersonId);
        //        return RedirectToAction($"CreateGynecology/{id}");
        //    }

        //    var his = await _db.Gynecologies.FindAsync(hasHistory.GynecologyId);

        //    return his == null ? View("Error") : View(his);
        //}

        //public async Task<ActionResult> CreateGynecology(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }

        //    var patient = await _db.Patients.FindAsync(id);

        //    if (patient == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
        //    var view = new Gynecology { PatientId = patient.PatientId, };

        //    return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateGynecology(Gynecology gynecology)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 3);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(gynecology);
        //    _db.Gynecologies.Add(gynecology);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction($"DetailsGynecology/{gynecology.PatientId}");
        //}

        //public async Task<ActionResult> EditGynecology(int? id)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (id == null)
        //    {
        //        return View("Error");
        //    }
        //    var gynecology = await _db.Gynecologies.FindAsync(id);
        //    if (gynecology == null)
        //    {
        //        return View("Error");
        //    }
        //    var autorid = await GetAuthorId();

        //    if (gynecology.Patient.Person.AuthorId != autorid)
        //    {
        //        return View("Error");
        //    }
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Age", gynecology.PatientId);
        //    return View(gynecology);
        //    //if (id == null)
        //    //{
        //    //    return View("Error");
        //    //}

        //    ////var patient = await _db.Patients.FindAsync(id);

        //    ////if (patient == null)
        //    ////{
        //    ////   return View("Error");
        //    ////}

        //    ////var gynecology =   _db.Gynecologies.FirstOrDefaultAsyncp=>p.PatientId== patient.PatientId);
        //    //var gynecology = _db.Gynecologies.FirstOrDefaultAsyncp => p.GynecologyId == id);

        //    //if (gynecology == null)
        //    //{
        //    //   return View("Error");
        //    //}
        //    ////ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", gynecology.PatientId);
        //    //var view = new Gynecology { GynecologyId = gynecology.GynecologyId };
        //    //return View(view);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditGynecology(Gynecology gynecology)
        //{
        //    var userId = await GetUserId();
        //    var response = await UsersHelper.HavePermisionToAction(userId, "Gynecology", 4);
        //    if (!response)
        //    {
        //        return View("Error");
        //    }
        //    if (!ModelState.IsValid) return View(gynecology);
        //    _db.Entry(gynecology).State = EntityState.Modified;
        //    await _db.SaveChangesAsync();
        //    //ModelState.AddModelError(string.Empty,
        //    //    "Registro Guardado");
        //    //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId", gynecology.PatientId);
        //    return RedirectToAction($"DetailsGynecology/{gynecology.PatientId}");
        //    // return View(gynecology);
        //}

        //#endregion

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
           // var userId = await GetUserId();
            //var response = await UsersHelper.HavePermisionToAction(userId, "Patients", 1);
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

     
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "NAme", view.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders.OrderBy(o => o.GenderId), "GenderId", "Name",
                view.GenderId);
            ViewBag.MaritalSituationId =
                new SelectList(_db.MaritalSituations.OrderBy(m => m.MaritalSituationId), "MaritalSituationId",
                    "Name", view.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", view.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions.OrderBy(o => o.ReligionId), "ReligionId", "Name",
                view.ReligionId);
           
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", view.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", view.InsuranceId);
         
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

          
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", person.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", person.GenderId);
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", person.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", person.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", person.ReligionId);
          
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", patient.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", patient.InsuranceId);
         
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
          
            ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", view.CountryId);
            ViewBag.GenderId = new SelectList(_db.Genders, "GenderId", "Name", view.GenderId);
            ViewBag.MaritalSituationId = new SelectList(_db.MaritalSituations, "MaritalSituationId", "Name", view.MaritalSituationId);
            ViewBag.OcupationId = new SelectList(_db.Ocupations, "OcupationId", "Name", view.OcupationId);
            ViewBag.ReligionId = new SelectList(_db.Religions, "ReligionId", "Name", view.ReligionId);
       
            ViewBag.BloodTypeId = new SelectList(_db.BloodTypes, "BloodTypeId", "Name", view.BloodTypeId);
            ViewBag.InsuranceId = new SelectList(_db.Insurances, "InsuranceId", "Name", view.InsuranceId);
        
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

    }
}
