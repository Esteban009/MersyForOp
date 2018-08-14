using Domain.GEN;

namespace Domain.MED
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Analytical
    {

        [Key]
        public int AnalyticalId { get; set; }

        public int PatientId { get; set; }

        [Display(Name = "Prueba No.")]
        public int RefNumber { get; set; }

        [Display(Name = "Fecha de Muestra")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? RealizationDate { get; set; }

        [Display(Name = "Fecha de Resultados")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ResultDate { get; set; }

        [Display(Name = "Fecha Entregado")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveredDate { get; set; }

        [Display(Name = "Medico")]
        public string MedRef { get; set; }

        [Display(Name = "Notas u Observaciones de las Pruebas")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        public int StatusId { get; set; }

        [NotMapped]
        public int AuthorId { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }

        [JsonIgnore]
        public virtual Status Starus { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<AnalyticalDetail> AnalyticalDetails { get; set; }

    }
}
