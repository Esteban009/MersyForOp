namespace Domain.MED
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Insurance_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Insurance_Name_Index", IsUnique = true)]
        [Display(Name = "Seguro")]
        public string Name { get; set; }

      
        [MaxLength(400, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Informacion Adicional")]
        public string AditionalInfo { get; set; }

        [JsonIgnore] public virtual ICollection<Patient> Patients { get; set; }
    }
}
