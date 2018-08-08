using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.MED
{
    public class General
    {

        [Key]
        public int GeneralId { get; set; }
        public int PatientId { get; set; }

        [Display(Name = "Antecedentes Familiares")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string AntFamiliar { get; set; }
        
        [Display(Name = "Antecedentes Personales")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string AntPersonales { get; set; }

        [Display(Name = "Diabetes")]
        public bool Diabetes { get; set; }
        [Display(Name = "Drogas")]
        public bool Drugs { get; set; }
        [Display(Name = "Tabaco")]
        public bool Tobaco { get; set; }
        [Display(Name = "Alcohol")]
        public bool Alcohol { get; set; }
        
        [Display(Name = "Deporte")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Sports { get; set; }
        [Display(Name = "Pasatiempos")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Pasatiempos { get; set; }
        [Display(Name = "Trabajo")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Work { get; set; }
        [Display(Name = "Dieta")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Food { get; set; }

        [Display(Name = "Accidentes")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Accidents { get; set; }
        [Display(Name = "Traumatismos")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Traumatismos { get; set; }
        [Display(Name = "Fracturas")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Fracturas { get; set; }
        [Display(Name = "Alergias")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Alergys { get; set; }

        [Display(Name = "Cirugias")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Sugeries { get; set; }
        [Display(Name = "Incapacidades")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Incapacidades { get; set; }

        [Display(Name = "Menstruacion")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Menstruacion { get; set; }

        [Display(Name = "Respiracion")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Respiracion { get; set; }

        [Display(Name = "Piel")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Piel { get; set; }

        [Display(Name = "Urinarias")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Urinarias { get; set; }

        [Display(Name = "Psiquiatria")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Psiquiatria { get; set; }
        
        [Display(Name = "Enfermedades de la Infancia")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string InfanciaEnferma { get; set; }
        [Display(Name = "Enfermedades no quirurgicas")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string NoQuirurgicas { get; set; }
       
        [Display(Name = "Medicamentos Frecuentes")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Medicaments { get; set; }
        
        [Display(Name = "Enfermedades Cronicas")]
        [MaxLength(500, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Enfermedades { get; set; }

        [Display(Name = "Observaciones")]
        [MaxLength(2000, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Observations { get; set; }

        [JsonIgnore] public virtual Patient Patient { get; set; }

      //  public virtual ICollection<GeneralAfection> GeneralAfections { get; set; }


    }
}
