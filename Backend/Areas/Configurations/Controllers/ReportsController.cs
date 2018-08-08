namespace Backend.Areas.Configurations.Controllers
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;
    using Helpers;
    using Backend.Models;
    using Domain;
    using Domain.GEN;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PsTools;

    [Authorize(Roles = "User")]
    public class ReportsController : Controller
    {
        private readonly DataContext _db = new DataContext();

        public async Task<ActionResult> Pdf(int id)
        {
            var authorid = await GetAuthorId();

            var report = await _db.Reports.FindAsync(authorid);

            if (report == null)
            {
                return RedirectToAction($"Create/{authorid}");
            }
            return RedirectToAction($"CreatePdf/{id}");
            //var customers = new List<SalesDetail>();

            //  for (int i = 1; i <= 10; i++)
            //  {
            //      SalesDetail customer = new SalesDetail
            //      {
            //          SalesId = i,
            //          ProductId =1,
            //          Quantity = 1
            //      };
            //      customers.Add(customer);
            //  }

            //  return new RazorPDF.PdfResult(customers, "PDF");
        }


        public async Task<FileResult> CreatePdf(int id)
        {
            var workStream = new MemoryStream();
            var workStream2 = new MemoryStream();
            //var status = new StringBuilder("");
            var dTime = DateTime.Now;
            //file name to be created   
            var strPdfFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
            var envelope = new Rectangle(Convert.ToInt32(ConfigurationManager.AppSettings["PaperPoints"]), 14400);//margenes
            // Document doc = new Document(envelope, 0, 0, 0, 0);
            var doc = new Document(envelope, 0, 0, 0, 0);
            //Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            var tableLayout = new PdfPTable(5);
            var tableLayout2 = new PdfPTable(5);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
           // var strAttachment = Server.MapPath("~/Downloadss/" + strPdfFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(await Add_Content_To_PDF(tableLayout, id));
            var pointsValue = Utilities.MillimetersToPoints(80);
            var height = tableLayout.TotalHeight;
            var r = new Rectangle(pointsValue, height);
            doc.Close();
            var doc2 = new Document(r, 0, 0, 0, 0);
            doc2.SetMargins(0f, 0f, 0f, 0f);
            doc2.SetMargins(0f, 0f, 0f, 0f);
            PdfWriter.GetInstance(doc2, workStream2).CloseStream = false;
            doc2.Open();
            doc2.Add(await Add_Content_To_PDF(tableLayout2, id));


            doc2.Close();
            /*
             * you __MUST__ call SetPageSize() __BEFORE__ calling NewPage()
             * AND __BEFORE__ adding the image to the document
             */
            //doc.SetPageSize(r);
            //doc.NewPage();
            // Closing the document  


            byte[] byteInfo = workStream2.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            //
            // Summary:
            //     Creates a FileStreamResult object using the Stream object, the content type,
            //     and the target file name.
            //
            // Parameters:
            //   fileStream:
            //     The stream to send to the response.
            //
            //   contentType:
            //     The content type (MIME type)
            //
            //   fileDownloadName:
            //     The file name to use in the file-download dialog box that is displayed in the
            //     browser.
            //
            // Returns:
            //     The file-stream result object.
            //protected internal virtual FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName);
            return File(workStream, "application/pdf", strPdfFileName);

        }
        public async Task<int> GetAuthorId()
        {
            if (Session["AuthorId"] != null && Convert.ToInt32(Session["AuthorId"]) != 0) return Convert.ToInt32(Session["AuthorId"]);
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            Session["AuthorId"] = await UsersHelper.GetAuthorId(currentUser.Email);
            return Convert.ToInt32(Session["AuthorId"]);
        }
        protected async Task<PdfPTable> Add_Content_To_PDF(PdfPTable tableLayout, int id)
        {
            // float[] headers = { 50, 24, 45, 35, 50 }; //Header Widths 
            float[] headers = { 105, 45, 45, 0, 0 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            //var salesDetails = _db.SalesDetails.ToList<SalesDetail>();
            var salesDetails = _db.SalesDetails.Where(p=>p.SalesId==id).ToList();
            var salesDetails2 = await _db.SalesDetails.FirstOrDefaultAsync(x => x.SalesId == id);
            var authorid = await GetAuthorId();

            var report = await _db.Reports.FirstOrDefaultAsync(x => x.AuthorId == authorid);

            if (report == null)
            {
                // return RedirectToAction($"Create/{id}");
            }
            //HEADER BEGINS
            if (report != null)
            {
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Header1, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Header2, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Header3, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                //HEADER ENDS
                //Sales Details Begins
                tableLayout.AddCell(new PdfPCell(new Phrase("_________________________________________", new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                if (salesDetails2 != null)
                {
                    tableLayout.AddCell(new PdfPCell(new Phrase(" No. Factura.........:  " + salesDetails2.Sales.SalesInvoiceNo, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Cliente.................:  " + salesDetails2.Sales.Remarks, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Estatus Factura..:  " + salesDetails2.Sales.Status.Name, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Fecha Compra....:  " + salesDetails2.Sales.SalesDate.ToString().Substring(0,10), new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    //Sales Details Ends
                    tableLayout.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });

                    ////Add header  
                    AddCellToHeader(tableLayout, "Producto");
                    AddCellToHeader(tableLayout, "Cantidad");
                    AddCellToHeader(tableLayout, "Precio");
                    AddCellToHeader(tableLayout, "");
                    AddCellToHeader(tableLayout, "");
                    //tableLayout.AddCell(new PdfPCell(new Phrase("Producto", new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                    //{
                    //    HorizontalAlignment = Element.ALIGN_LEFT,
                    //    Padding = 5,
                    //    BackgroundColor = new BaseColor(255, 255, 255)
                    //});
                    //tableLayout.AddCell(new PdfPCell(new Phrase("Cantidad", new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                    //{
                    //    HorizontalAlignment = Element.ALIGN_LEFT,
                    //    Padding = 5,
                    //    BackgroundColor = new BaseColor(255, 255, 255)
                    //});
                    //tableLayout.AddCell(new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                    //{
                    //    HorizontalAlignment = Element.ALIGN_LEFT,
                    //    Padding = 5,
                    //    BackgroundColor = new BaseColor(255, 255, 255)
                    //});
                    //tableLayout.AddCell(new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                    //{
                    //    HorizontalAlignment = Element.ALIGN_LEFT,
                    //    Padding = 5,
                    //    BackgroundColor = new BaseColor(255, 255, 255)
                    //});
                    //tableLayout.AddCell(new PdfPCell(new Phrase("Precio", new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                    //{
                    //    HorizontalAlignment = Element.ALIGN_LEFT,
                    //    Padding = 5,
                    //    BackgroundColor = new BaseColor(255, 255, 255)
                    //});
                    ////Add body  

                    foreach (var emp in salesDetails)
                    {

                        //AddCellToBody(tableLayout, emp.SalesDetailId.ToString());
                        AddCellToBody(tableLayout, emp.Product.Name);
                        AddCellToBody(tableLayout, emp.Quantity.ToString("C2"));
                        AddCellToBody(tableLayout, emp.Product.SellPrice.ToString("C2"));
                        AddCellToBody(tableLayout, "");
                        AddCellToBody(tableLayout, "");
                        //tableLayout.AddCell(new PdfPCell(new Phrase(emp.Product.Name, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                        //{
                        //    HorizontalAlignment = Element.ALIGN_LEFT,
                        //    Padding = 5,
                        //    BackgroundColor = new BaseColor(255, 255, 255)
                        //});
                        //tableLayout.AddCell(new PdfPCell(new Phrase(emp.Quantity.ToString(), new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                        //{
                        //    HorizontalAlignment = Element.ALIGN_LEFT,
                        //    Padding = 5,
                        //    BackgroundColor = new BaseColor(255, 255, 255)
                        //});
                        //tableLayout.AddCell(new PdfPCell(new Phrase(emp.Product.SellPrice.ToString(), new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                        //{
                        //    HorizontalAlignment = Element.ALIGN_LEFT,
                        //    Padding = 5,
                        //    BackgroundColor = new BaseColor(255, 255, 255)
                        //});
                        //  AddCellToBody(tableLayout, emp.SubTotal.ToString());

                    }

                    tableLayout.AddCell(new PdfPCell(new Phrase(" Sub Total...............:  " + salesDetails2.Sales.SubTotal, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Descuentos...........:  " + salesDetails2.Sales.TotalDiscount, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Cargos...................:  " + salesDetails2.Sales.TotalCharges, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Total a Pagar.........:  " + salesDetails2.Sales.Total, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Monto Pagado.......:  " + salesDetails2.Sales.PaidAmount, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                    tableLayout.AddCell(new PdfPCell(new Phrase(" Monto Adeudado..:  " + salesDetails2.Sales.DebtAmount, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                    {
                        Colspan = 12,
                        Border = 0,
                        PaddingBottom = 5,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    });
                }
                tableLayout.AddCell(new PdfPCell(new Phrase("_________________________________________", new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Footer1, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Footer2, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                tableLayout.AddCell(new PdfPCell(new Phrase(report.Footer3, new Font(Font.FontFamily.HELVETICA, 8, 1, new BaseColor(0, 0, 0))))
                {
                    Colspan = 12,
                    Border = 0,
                    PaddingBottom = 5,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
            }

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
           // font header = new Font(Font.FontFamily.TIMES_ROMAN, 15f, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 9,1| Font.BOLD, BaseColor.BLUE)))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 5,
                // BackgroundColor = new BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new BaseColor(255, 255, 255)
            });
        }

        [ValidateInput(false)]
        public async Task<ActionResult> InvoicePrint(string body, int id, string description)
        {

            var authorReport = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == id);
            if (authorReport == null)
            {
                return RedirectToAction($"Create/{id}");
            }

            //var reportFilter = await _db.Reports.FirstOrDefaultAsync(p => p.UserId == author.UserId);

            //if (reportFilter == null)
            //{
            //    return RedirectToAction($"Create/{author.UserId}");
            //}


            ViewBag.MyDescription = description;
            ViewBag.MyBody = body;


            // var document = new Document();
            // Document document = new Document(PageSize.DL, 36, 36, 36, 36);
            //As you can see: I use 36 as value for half an inch, because 1 inch = 72 user units in PDF.

            //    If you want to define another page size, you can do so by using one of the other values available in the PageSize class, for instance:

            // Document document = new Document(PageSize.LETTER);

            //PageSize.A4 and PageSize.LETTER are instances of the Rectangle class, so if you need a page size that isn't defined in PageSize, then you can create your own rectangle. For instance:

            //6 inch x 72 points = 432 points(the width)
            //3.5 inch x 252 points = 252 points(the height)
            // Rectangle envelope = new Rectangle(432, 252);
            // Rectangle envelope = new Rectangle(216, 252);
            //  Document document = new Document(envelope, 0, 0, 0, 0);
            //Where do these values come from? Let's do the Math:


            // return View(reportFilter);
            return new RazorPDF.PdfResult(body, "PDF");
            //return View(authorReport);


        }

        [ValidateInput(false)]
        public async Task<ActionResult> BankCheckPrint(int id)
        {


            //var author = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == id);
            //if (author == null)
            //{
            //    return View("Error");
            //}

            var reportFilter = await _db.BankChecks.FirstOrDefaultAsync(p => p.BankCheckId == id);

            if (reportFilter == null)
            {
                return View("Error");
            }



            return View(reportFilter);

        }

        [ValidateInput(false)]
        public async Task<ActionResult> DetailsPrint(string body, int id, string description)
        {

            // var author = await _db.Users.FindAsync(id);
            var authorReport = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == id);
            if (authorReport == null)
            {
                return RedirectToAction($"Create/{id}");
            }

            // var reportFilter = await _db.Reports.FirstOrDefaultAsync(p => p.UserId == author.UserId);

            //if (reportFilter == null)
            //{
            //    return RedirectToAction($"Create/{author.UserId}");
            //}


            ViewBag.MyDescription = description;
            ViewBag.MyBody = body;

            return View(authorReport);
            //  return View(reportFilter);
        }


        public async Task<ActionResult> Details(int? id, string body, string description)
        {
            int myId;
            if (id == null)
            {
                // return View("Error");
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                // id =   UsersHelper.GetUserId(currentUser.Email);
                myId = await UsersHelper.GetAuthorId(currentUser.Email);

            }
            else
            {
                myId = Convert.ToInt32(id);
            }

            // var user =   _db.Users.FirstOrDefaultAsync(p => p.UserId == myId);// author.UserId);
            // var user =  _db.Users.FindAsync(myId);
           // var user = await _db.Users.FindAsync(myId);

            //if (user == null)
            //{
            //    return View("Error");
            //}
            //int authorid = 0;
            //authorid = user.AuthorId;

            //var author = await _db.Authors.FindAsync(authorid);
            //if (author == null)
            //{
            //    return View("Error");
            //}

            var reportFilter = await _db.Reports.FirstOrDefaultAsync(p => p.AuthorId == myId);// author.UserId);
            //   var reportFilter = await _db.Reports.FirstOrDefaultAsync(p => p.UserId == user.UserId);// author.UserId);

            if (reportFilter == null)
            {
                TempData["AuthorID"] = myId; //author.AuthorId;
                return RedirectToAction($"Create/{myId}");
                // return RedirectToAction($"Create/{user.UserId}");
            }


            ViewBag.MyDescription = description;
            ViewBag.MyBody = body;

            return View(reportFilter);

        }

        public async Task< ActionResult> Create(int id)
        {
            //int userId = 0; 
            // var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //  var currentUser = manager.FindById(User.Identity.GetUserId());
            // id =   UsersHelper.GetUserId(currentUser.Email);
            //   userId = UsersHelper.GetUserId(currentUser.Email);
            // ViewBag.UserId = new SelectList(_db.Users, "UserId", "Code", id);
            //var view = new ReportView { UserId = id, AuthorId=Convert.ToInt32(TempData["AuthorID"]) };
            var autorid = await GetAuthorId();
            var view = new ReportView { AuthorId = autorid };

            return View(view);

            //var patient = await _db.Patients.FindAsync(id);

            //if (patient == null)
            //{
            //    return View("Error");
            //}
            //ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "PatientId");
            //var view = new Report { AuthorId = patient.PatientId, };

            //return View(view);
        }

        private static Report ToReport(ReportView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            return new Report()
            {
                MainHeader = view.MainHeader,
                ReportId = view.ReportId,
                Header1 = view.Header1,
                Header2 = view.Header2,
                Header3 = view.Header3,
                Description = view.Description,
                MainFooter = view.MainFooter,
                Footer1 = view.Footer1,
                Footer2 = view.Footer2,
                Footer3 = view.Footer3,
                Width = view.Width,
                Heigh = view.Heigh,
                Imagen = view.Imagen,
                AuthorId = view.AuthorId,
                //  UserId = view.UserId
            };
        }

        private static ReportView ToView(Report report)
        {
            if (report == null) throw new ArgumentNullException(nameof(report));
            return new ReportView()
            {
                MainHeader = report.MainHeader,
                ReportId = report.ReportId,
                Header1 = report.Header1,
                Header2 = report.Header2,
                Header3 = report.Header3,
                Description = report.Description,
                MainFooter = report.MainFooter,
                Footer1 = report.Footer1,
                Footer2 = report.Footer2,
                Footer3 = report.Footer3,
                Width = report.Width,
                Heigh = report.Heigh,
                Imagen = report.Imagen,
                AuthorId = report.AuthorId,
                //UserId = report.UserId
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReportView view)
        {
            if (!ModelState.IsValid) return View(view);
            var pic = string.Empty;
            var folder = "~/Content/Logos";

            if (view.ImageFile != null)
            {
                pic = Files.UploadPhoto(view.ImageFile, folder, "");
                pic = string.Format("{0}/{1}", folder, pic);
            }

            var report = ToReport(view);
            report.Imagen = pic;
            _db.Reports.Add(report);
            await _db.SaveChangesAsync();
            // return RedirectToAction($"Details/{report.UserId}");
            return RedirectToAction($"Details/{report.AuthorId}");

            //  ViewBag.UserId = new SelectList(_db.Users, "UserId", "Code", view.UserId);
        }

        public async Task<ActionResult> Edit(int id)
        {

            var report = await _db.Reports.FindAsync(id);
            if (report == null)
            {
                return View("Error");
            }
            //ViewBag.UserId = new SelectList(_db.Users, "UserId", "Code", report.UserId);

            var view = ToView(report);

            return View(view);
            // return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReportView view)
        {
            if (!ModelState.IsValid) return View(view);
            const string folder = "~/Content/Logos";

            var pic = view.Imagen;

            if (view.ImageFile != null)
            {
                pic = Files.UploadPhoto(view.ImageFile, folder, "");
                pic = string.Format("{0}/{1}", folder, pic);
            }

            var report = ToReport(view);
            report.Imagen = pic;

            _db.Entry(report).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            // return RedirectToAction($"Details/{report.UserId}");
            return RedirectToAction($"Details/{report.AuthorId}");
            //ViewBag.UserId = new SelectList(_db.Users, "UserId", "Code", view.UserId);
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
