using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.MED
{
    public class GeneralVisit
    {
        
        [Key]
        public int GeneralVisitId { get; set; }
        public int GeneralAfectionId { get; set; }
        public int PatientId { get; set; }

        [Display(Name = "Fecha de Consulta/Visita")]
        ////[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? VisitDate { get; set; }

        [Display(Name = "Motivo de Visita")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Required(ErrorMessage = "El Campo es requerido")]
        [DataType(DataType.MultilineText)]
        public string VisitReason { get; set; }

        [Display(Name = "Revision Actual de Organos y Sistemas")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Revision { get; set; }

        [Display(Name = "Signos Vitales")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string VitalSign { get; set; }

        //Biometria

        [Display(Name = "Presion Arterial Sist.")]
        public int PresionArterialSist { get; set; }
        [Display(Name = "Presion Arterial Diast")]
        public int PresionArterialDiast { get; set; }

        [Display(Name = "Pulsaciones")]
        public int Pulsaciones { get; set; }

        [Display(Name = "Ritmo Respiratorio")]
        public int RitmoResp { get; set; }

        [Display(Name = "Temperatura (Grados)")]
        public int Temp { get; set; }

        [Display(Name = "Altura")]
        public string Altura { get; set; }
        [Display(Name = "Peso")]
        public int Peso { get; set; }

        [Display(Name = "IMC")]
        public int PresionArterial { get; set; }

        //[Display(Name = "Signos Vitales")]
        //[MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[DataType(DataType.MultilineText)]
        //public string VitalSign { get; set; }

        [Display(Name = "Examen Fisico")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string PhysicalExam { get; set; }

        [Display(Name = "Laboratorios y Estudios Especiales")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Labs { get; set; }

        [Display(Name = "Hallazgos Relevantes de Examenes y Procedimientos Diagnosticos")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Diagnostic { get; set; }

        [Display(Name = "Resumen de Evolucion y Complicaciones")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Conclusion { get; set; }

        [Display(Name = "Indicaciones/Tratamiento")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Indications { get; set; }

        [Display(Name = "Notas u Observaciones de la Consulta")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [JsonIgnore] public virtual GeneralAfection GeneralAfection { get; set; }

        [JsonIgnore] public virtual Patient Patient { get; set; }


    }
}
