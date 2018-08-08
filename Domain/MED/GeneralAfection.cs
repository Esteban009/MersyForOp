using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.MED
{
    public class GeneralAfection
    {
        [Key]
        public int GeneralAfectionId { get; set; }
       // public int GeneralId { get; set; }
        public int PatientId { get; set; }

        [Display(Name = "Fecha de Evaluacion")]
        ////[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VisitDate { get; set; }

        [Display(Name = "Motivo de Consulta/Afeccion Diagnosticada")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Required(ErrorMessage = "El Campo es requerido")]
        [DataType(DataType.MultilineText)]
        public string VisitReason { get; set; }

        [Display(Name = "Sintomas/Anamnesis")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Symptoms { get; set; }

        //[Display(Name = "Revision Actual de Organos y Sistemas")]
        //[MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[DataType(DataType.MultilineText)]
        //public string Revision { get; set; }

        [Display(Name = "Examen Fisico")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string PhysicalExam { get; set; }

        [Display(Name = "Laboratorios y Estudios Especiales Realizados")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Labs { get; set; }

        [Display(Name = "Conclusion, Diagnostico")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Conclusion { get; set; }

        [Display(Name = "Indicaciones/Tratamiento")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Indications { get; set; }

        [Display(Name = "Notas u Observaciones de la Afeccion")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        // public virtual General General { get; set; }

        [JsonIgnore] public virtual Patient Patient { get; set; }
        [JsonIgnore] public virtual ICollection<GeneralVisit> GeneralVisits { get; set; }

    }
}
