using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class AccountingSubAuxiliary
    {

        [Key]
        public int AccountingSubAuxiliaryId { get; set; }

        public int AccountingAuxiliaryId { get; set; }

        //  [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(5, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingSubAuxiliary_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AccountingSubAuxiliary_Name_Index", IsUnique = true)]
        [Display(Name = "Sub Auxiliar")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual AccountingAuxiliary AccountingAuxiliary { get; set; }
    }
}
