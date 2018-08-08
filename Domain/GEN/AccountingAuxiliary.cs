using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class AccountingAuxiliary
    {

        [Key]
        public int AccountingAuxiliaryId { get; set; }

        public int AccountingAccountId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(10, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingAuxiliary_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingAuxiliary_Name_Index", IsUnique = true)]
        [Display(Name = "Auxiliar")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual AccountingAccount AccountingAccount { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountingSubAuxiliary> AcoAccountingSubAuxiliaries { get; set; }
    }
}
