using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Domain.TRK;
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(10, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Currency_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Currency_Name_Index", IsUnique = true)]
        [Display(Name = "Moneda")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<AuthorPlan> AuthorPlans { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Account> Accounts { get; set; }
    }
}
