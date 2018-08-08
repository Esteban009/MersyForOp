using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.SEG
{
    public class ParentOption
    {

        [Key]
        public int ParentOptionId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(20, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Menu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

     
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Orden")]
        public int? Order { get; set; }

        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Icon { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }


        [JsonIgnore]
        public virtual Status Status { get; set; }

    }
}
