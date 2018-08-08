using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.MED
{
    public class BloodType
    {
        [Key]
        public int BloodTypeId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("BloodType_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("BloodType_Name_Index", IsUnique = true)]
        [Display(Name = "Tipo Sanguineo")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
