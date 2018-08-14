using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.MED;
//using Domain.POS;
using Newtonsoft.Json;

//using Domain.MED;

namespace Domain.GEN
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
           
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BornDate { get; set; }

        [Display(Name = "Género")]
        public int GenderId { get; set; }

        [Display(Name = "Nivel Escolar")]
        public int? SchoolLevelId { get; set; }

        [Display(Name = "Nacionalidad")]
        public int CountryId { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Tel { get; set; }

        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string Cel { get; set; }

        [Display(Name = "Estatus Marital")]
        public int MaritalSituationId { get; set; }

        [Display(Name = "Ocupacion")]
        public int OcupationId { get; set; }

        [Display(Name = "Religión")]
        public int ReligionId { get; set; }

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

        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual MaritalSituation MaritalSituation { get; set; }
        [JsonIgnore]
        public virtual Ocupation Ocupation { get; set; }
        [JsonIgnore]
        public virtual Religion Religion { get; set; }
        [JsonIgnore]
        public virtual Country Country { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual SchoolLevel SchoolLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Customer> Customers { get; set; }
    }
}
