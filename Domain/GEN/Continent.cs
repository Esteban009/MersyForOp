using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Continent
    {
        [Key]
        public int ContinentId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(5, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Continent_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Continent_Name_Index", IsUnique = true)]
        [Display(Name = "Continente")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(25, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Continent_Demonym_Index", IsUnique = true)]
        [Display(Name = "Gentilicio")]
        public string Demonym { get; set; }

        [JsonIgnore]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
