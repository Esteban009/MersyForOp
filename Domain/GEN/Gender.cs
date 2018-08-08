using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Gender_Name_Index", IsUnique = true)]
        [Display(Name = "Género")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
