using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Domain.CPO;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class AccountingClassification
    {
        [Key]
        public int AccountingClassificationId { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(5, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingClassification_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingClassification_Name_Index", IsUnique = true)]
        [Display(Name = "Clasificacion de Cuenta")]
        public string Name { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [Display(Name = "Origen")]
        public int Origin { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountingSubClassification> AccountingSubClassifications { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<BusinessSubClassification> BusinessSubClassifications { get; set; }
    }
}
