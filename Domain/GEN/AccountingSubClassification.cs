using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class AccountingSubClassification
    {

        [Key]
        public int AccountingSubClassificationId { get; set; }

        public int AccountingClassificationId { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(5, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //  [Index("AccountingSubClassification_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingSubClassification_Name_Index", IsUnique = true)]
        [Display(Name = "Sub Clasificacion")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual AccountingClassification AccountingClassification { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountingAccount> AccountingAccounts { get; set; }
    }
}
