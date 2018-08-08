using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Backend.Helpers
{
    public class ReportThings
    {


        //public FileResultCreatePdf()
        //{
        //    MemoryStreamworkStream = newMemoryStream();
        //    StringBuilder status = newStringBuilder("");
        //    DateTimedTime = DateTime.Now;
        //    //file name to be created   
        //    stringstrPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");
        //    Document doc = newDocument();
        //    doc.SetMargins(0 f, 0 f, 0 f, 0 f);
        //    //Create PDF Table with 5 columns  
        //    PdfPTabletableLayout = newPdfPTable(5);
        //    doc.SetMargins(0 f, 0 f, 0 f, 0 f);
        //    //Create PDF Table  

        //    //file will created in this path  
        //    stringstrAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);


        //    PdfWriter.GetInstance(doc, workStream).CloseStream = false;
        //    doc.Open();

        //    //Add Content to PDF   
        //    doc.Add(Add_Content_To_PDF(tableLayout));

        //    // Closing the document  
        //    doc.Close();

        //    byte[] byteInfo = workStream.ToArray();
        //    workStream.Write(byteInfo, 0, byteInfo.Length);
        //    workStream.Position = 0;


        //    return File(workStream, "application/pdf", strPDFFileName);

        //}

        //protected PdfPTableAdd_Content_To_PDF(PdfPTabletableLayout)
        //{

        //    float[] headers = { 50, 24, 45, 35, 50 }; //Header Widths  
        //    tableLayout.SetWidths(headers); //Set the pdf headers  
        //    tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
        //    tableLayout.HeaderRows = 1;
        //    //Add Title to the PDF file at the top  

        //    List<Employee> employees = _context.employees.ToList<Employee>();



        //    tableLayout.AddCell(newPdfPCell(newPhrase("Creating Pdf using ItextSharp", newFont(Font.FontFamily.HELVETICA, 8, 1, newiTextSharp.text.BaseColor(0, 0, 0)))) {
        //        Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER
        //    });


        //    ////Add header  
        //    AddCellToHeader(tableLayout, "EmployeeId");
        //    AddCellToHeader(tableLayout, "Name");
        //    AddCellToHeader(tableLayout, "Gender");
        //    AddCellToHeader(tableLayout, "City");
        //    AddCellToHeader(tableLayout, "Hire Date");

        //    ////Add body  

        //    foreach (varempin employees)
        //    {

        //        AddCellToBody(tableLayout, emp.EmployeeId.ToString());
        //        AddCellToBody(tableLayout, emp.Name);
        //        AddCellToBody(tableLayout, emp.Gender);
        //        AddCellToBody(tableLayout, emp.City);
        //        AddCellToBody(tableLayout, emp.Hire_Date.ToString());

        //    }

        //    returntableLayout;
        //}
        //// Method to add single cell to the Header  
        //private static void AddCellToHeader(PdfPTabletableLayout, stringcellText)
        //{

        //    tableLayout.AddCell(newPdfPCell(newPhrase(cellText, newFont(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = newiTextSharp.text.BaseColor(128, 0, 0)
        //    });
        //}

        //// Method to add single cell to the body  
        //private static voidAddCellToBody(PdfPTabletableLayout, stringcellText)
        //{
        //    tableLayout.AddCell(newPdfPCell(newPhrase(cellText, newFont(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = newiTextSharp.text.BaseColor(255, 255, 255)
        //    });
        //}

    }
}