using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Ocupation
    {
        [Key]
        public int OcupationId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Ocupation_Name_Index", IsUnique = true)]
        [Display(Name = "Ocupacion")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
