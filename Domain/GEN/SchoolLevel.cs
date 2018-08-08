using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class SchoolLevel
    {
        [Key]
        public int SchoolLevelId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("SchoolLevel_Name_Index", IsUnique = true)]
        [Display(Name = "Nivel Escolar")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
