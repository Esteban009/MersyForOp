using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(10, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("PaymentType_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("PaymentType_Name_Index", IsUnique = true)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

     

    }
}
