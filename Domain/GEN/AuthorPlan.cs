using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace Domain.GEN
{
    public class AuthorPlan
    {
        [Key]
        public int AuthorPlanId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AuthorPlan_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("AuthorPlan_Name_Index", IsUnique = true)]
        [Display(Name = "Plan")]
        public string Name { get; set; }

        [Display(Name = "Moneda")]
        public int CurrencyId { get; set; }

        [Display(Name = "Periodicidad")]
        public int PeriodicityId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Monto")]
        public decimal Amount { get; set; }

        [Display(Name = "Moneda")]
        public int? StatusId { get; set; }

        [JsonIgnore]
        public virtual Currency Currency { get; set; }
        [JsonIgnore]
        public virtual Periodicity Periodicity { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }
        [JsonIgnore]
        public virtual ICollection<AuthorPlanOption> AuthorPlanOptions { get; set; }
    }
}
