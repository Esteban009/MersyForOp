using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class AuthorType
    {
        [Key]
        public int AuthorTypeId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(20, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AuthorType_Name_Index", IsUnique = true)]
        [Display(Name = "Tipo de Cliente Ps")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
