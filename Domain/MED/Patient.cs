namespace Domain.MED
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.GEN;
    using Newtonsoft.Json;

    public class Patient
    {

        [Key]
        public int PatientId { get; set; }

        public int PersonId { get; set; }

        public int Record { get; set; }

        [Display(Name = "# Expediente Fis.")]
        public string Record2 { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        ////[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Seguro Principal")]
        public int InsuranceId { get; set; }

        [Display(Name = "Numero de Seguro")]
        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string InsuranceNumber { get; set; }

        [Display(Name = "Tipificacion Sanguinea")]
        public int BloodTypeId { get; set; }

        [Display(Name = "Edad")]
        [MaxLength(30, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string Age { get; set; }


        [NotMapped]
        public string Name { get; set; }


        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual BloodType BloodType { get; set; }
        [JsonIgnore]
        public virtual Insurance Insurance { get; set; }
        [JsonIgnore]
        public virtual ICollection<General> Generals { get; set; }
        [JsonIgnore]
        public virtual ICollection<GeneralAfection> GeneralAfections { get; set; }
        [JsonIgnore]
        public virtual ICollection<GeneralVisit> GeneralVisits { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Gynecology> Gynecologies { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<GynecologyVisit> GynecologyVisits { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Obstetric> Obstetrics { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ObstetricVisit> ObstetricVisits { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Cardiology> Cardiologies { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Recipe> Recipes { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<MedicalCertificate> MedicalCertificates { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<AnalyticalSheet> AnalyticalSheets { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Pediatric> Pediatrics { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<PediatricVisit> PediatricVisits { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Inmunization> Inmunizations { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Bariatric> Bariatrics { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<BariatricVisit> BariatricVisits { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<LaboratoryTest> LaboratoryTests { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<LaboratoryResult> LaboratoryResults { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Treatment> Treatments { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Urology> Urologys { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Psychiatry> Psychiatrys { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Anesthetic> Anesthetics { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Nutrition> Nutritions { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Appointment> Appointments { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Surgery> Surgeries { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Orthopedic> Orthopedics { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Analytical> Analyticals { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<PediatricGrowth> PediatricGrowths { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Admision> Admisions { get; set; }

    }
}
