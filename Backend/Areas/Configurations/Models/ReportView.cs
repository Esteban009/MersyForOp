using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Domain.GEN;

namespace Backend.Areas.Configurations.Models
{
    [NotMapped]
    public class ReportView: Report
    {
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}