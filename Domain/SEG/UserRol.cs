using System;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.SEG
{
   public  class UserRol
    {

        [Key]
        public int UserRolId { get; set; }

       public int RolId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Desde")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [Display(Name = "Hasta")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Indefinido ?")]
        public bool Undefined { get; set; }


        [Display(Name = "Estatus")]
        public int StatusId { get; set; }
        
        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual Rol Rol { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }


    }
}
