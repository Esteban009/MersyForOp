using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.SEG
{
  public   class Rol
    {

        [Key]
        public int RolId { get; set; }

        public int AuthorId { get; set; }
        

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(20, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Rol")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La maxima longitud para el campo es {1}")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }        

    
        [Display(Name = "Nivel:  2-Administradores,  3-Supervisores y Encargados,  4-Cajeros y Usuarios,  5-Usuarios de Consulta")]
        public int Level { get; set; }


        [Display(Name = "Estatus")]
        public int StatusId { get; set; }


        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }

        [JsonIgnore]
        public virtual ICollection<OptionRol> OptionRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRol> UserRols { get; set; }
    }
}
