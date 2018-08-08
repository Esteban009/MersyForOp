using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(5, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Country_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Country_Name_Index", IsUnique = true)]
        [Display(Name = "Pais")]
        public string Name { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(25, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Country_Demonym_Index", IsUnique = true)]
        [Display(Name = "Gentilicio")]
        public string Demonym { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [JsonIgnore]
        public virtual Continent Continent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
