using System;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.SEG
{
    public  class OptionRol
    {
        [Key]
        public int OptionRolId { get; set; }

        public int OptionId { get; set; }

        public int RolId { get; set; }

        [Display(Name = "Desde")]
        [DataType(DataType.DateTime)]
        public DateTime FromDate { get; set; }

        [Display(Name = "Hasta")]
        [DataType(DataType.DateTime)]
        public DateTime ToDate { get; set; }

       


        [Display(Name = "Indefinido ?")]
        public bool Undefined { get; set; }


        [Display(Name = "Ver Lista ?")]
        public bool Index { get; set; }

        [Display(Name = "Eliminar Registros?")]
        public bool Delete { get; set; }

        [Display(Name = "Crear Registros?")]
        public bool Create { get; set; }

        [Display(Name = "Editar Registros ?")]
        public bool Edit { get; set; }

        [Display(Name = "Ver Detalle ?")]
        public bool Details { get; set; }


        [Display(Name = "Estatus")]
        public int StatusId { get; set; }


        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual Rol Rol { get; set; }
        [JsonIgnore]
        public virtual Option Option { get; set; }

      
    }
}
