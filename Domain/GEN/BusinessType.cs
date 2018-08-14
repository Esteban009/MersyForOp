using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Domain.CPO;
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class BusinessType
    {
        [Key]
        public int BusinessTypeId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("BusinessType_Name_Index", IsUnique = true)]
        [Display(Name = "Tipo Negocio")]
        public string Name { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Business> Business { get; set; }
    }
}
