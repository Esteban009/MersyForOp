using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.SEG;
using Newtonsoft.Json;

namespace Domain.MED
{
    public class Doctor
    {

        [Key]
        public int DoctorId { get; set; }
      //  public int PersonId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Exequartur")]
        public string Record { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        ////[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }
        
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }

        [Display(Name = "CMD")]
        public string Cmd { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Prefijo de Exp")]
        [MaxLength(3, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string Prefix { get; set; }

        //   public virtual Person Person { get; set; }
        [JsonIgnore] public virtual User User { get; set; }

        //public virtual ICollection<Gynecology> Gynecologies { get; set; }
        //public virtual ICollection<GynecologyVisit> GynecologyVisits { get; set; }
        //public virtual ICollection<Obstetric> Obstetrics { get; set; }
        //public virtual ICollection<ObstetricVisit> ObstetricVisits { get; set; }
        //public virtual ICollection<Cardiology> Cardiologies { get; set; }
        //public virtual ICollection<Recipe> Recipes { get; set; }
        //public virtual ICollection<MedicalCertificate> MedicalCertificates { get; set; }
        //public virtual ICollection<AnalyticalSheet> AnalyticalSheets { get; set; }
        //public virtual ICollection<Pediatric> Pediatrics { get; set; }
        //public virtual ICollection<PediatricVisit> PediatricVisits { get; set; }
        //public virtual ICollection<Inmunization> Inmunizations { get; set; }
        //public virtual ICollection<Bariatric> Bariatrics { get; set; }
        //public virtual ICollection<BariatricVisit> BariatricVisits { get; set; }
         //public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
