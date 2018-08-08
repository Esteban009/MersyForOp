using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class AccountingAccount
    {
        [Key]
        public int AccountingAccountId { get; set; }

        public int AccountingSubClassificationId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(6, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingAccount_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        // [Index("AccountingAccount_Name_Index", IsUnique = true)]
        [Display(Name = "Cuenta")]
        public string Name { get; set; }


        [JsonIgnore]
        public virtual AccountingSubClassification AccountingSubClassification { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountingAuxiliary> AccountingAuxiliaries { get; set; }
    }
}
