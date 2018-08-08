using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.MED
{
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
      

    }
}
