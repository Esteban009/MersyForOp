using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.SEG
{
  public  class Option
    {
        [Key]
        public int OptionId { get; set; }

        public int ParentOptionId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(50, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Opcion")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }


        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        public string Link { get; set; }

        [MaxLength(25, ErrorMessage = "La maxima longitud para el campo es {1}")]
      public string Area { get; set; }

        [MaxLength(25, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Controlador")]
        public string Controller { get; set; }

        [MaxLength(25, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Accion")]
        public string Action { get; set; }

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

        [JsonIgnore]
        public virtual ParentOption ParentOption { get; set; }

        [JsonIgnore]
        public virtual ICollection<OptionRol> OptionRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRol> UseRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<AuthorPlanOption> AuthorPlanOptions { get; set; }
    }
}
