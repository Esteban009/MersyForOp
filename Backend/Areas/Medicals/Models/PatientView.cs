using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Domain.MED;

namespace Backend.Areas.Medicals.Models
{
    [NotMapped]
    public class PatientView: Patient // Person 
    {

        // public int Record { get; set; }
        // public int PatientId { get; set; }
        // [Display(Name = "Fecha de Ingreso")]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        // public DateTime? CreationDate { get; set; }

        // [Display(Name = "Seguro Principal")]
        // public int InsuranceId { get; set; }
        // [Display(Name = "Tipificacion Sanguinea")]
        // public int BloodTypeId { get; set; }

        // [Display(Name = "Edad")]
        // [MaxLength(10, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        // public string Age { get; set; }

        [Display(Name = "Nombre")]
         public string FullName { get; set; }

        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
       // public int PersonId { get; set; }

        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "RNC/Cedula")]
        public string Rnc { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        ////[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? BornDate { get; set; }
        //[Display(Name = "Fecha de Nacimiento")]
        //[DataType(DataType.Date)]
        //// [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        ////[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //public DateTime? BornDate { get; set; }

        [Display(Name = "Gnero")]
        public int GenderId { get; set; }
        [Display(Name = "Nivel Escolar")]
        public int? SchoolLevelId { get; set; }

        [Display(Name = "Nacionalidad")]
        public int CountryId { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        // [Index("Person_Email_Index", IsUnique = true)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        // [Index("Person_Tel_Index", IsUnique = true)]
        [Display(Name = "Telefono")]
        public string Tel { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        //    [Index("Person_Cel_Index", IsUnique = true)]
        [Display(Name = "Celular")]
        public string Cel { get; set; }

        [Display(Name = "Estatus Marital")]
        public int MaritalSituationId { get; set; }

        [Display(Name = "Ocupacion")]
        public int OcupationId { get; set; }

        [Display(Name = "Religión")]
        public int ReligionId { get; set; }

        // [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Display(Name = "Cliente Ps")]
        public int AuthorId { get; set; }



    }
}