using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.GEN;
using Newtonsoft.Json;

namespace Domain.POS
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Codigo")]
        public int Code { get; set; }

        public int PersonId { get; set; }

        [NotMapped]
        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [NotMapped]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [EmailAddress(ErrorMessage = "Porfavor, entroduzca un email valido")]
        public string Email { get; set; }

        [NotMapped]
        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Tel { get; set; }
        
        [Display(Name = "Monto Adeudado")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal DebAmount { get; set; }

        [Display(Name = "Saldo a Favor")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal CreditAmount { get; set; }

        [Display(Name = "Monto Gastado")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal WastedAmount { get; set; }

        [JsonIgnore]
        public virtual Person Person { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Sale> Sales { get; set; }
   

    }
}
