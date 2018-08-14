using Domain.MED;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Backend.Areas.Medicals.Models
{
    public class LaboratoryTestView:LaboratoryTest
    {
        [MaxLength(1000, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Cabecera")]
        public string MainHeader { get; set; }

        //[Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Cabecera Superior")]
        public string Header1 { get; set; }

        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Cabecera Central")]
        public string Header2 { get; set; }

        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Cabecera Inferior")]
        public string Header3 { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Descripcion o Nombre")]
        public string Description { get; set; }
        [AllowHtml]
        [Display(Name = "Cuerpo")]
        public string Body { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Pie de Pagina")]
        public string MainFooter { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Pie de Pagina Superior")]
        public string Footer1 { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Pie de Pagina Central")]
        public string Footer2 { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Pie de Pagina Inferior")]
        public string Footer3 { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Ancho del Reporte")]
        public string Width { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Alto del Reporte")]
        public string Heigh { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Logo")]
        public string Imagen { get; set; }

        public int AuthorId { get; set; }

        public string MyDescription { get; set; }
    }
}