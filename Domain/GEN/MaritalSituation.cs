using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class MaritalSituation
    {
        [Key]
        public int MaritalSituationId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Index("MaritalSituation_Name_Index", IsUnique = true)]
        [Display(Name = "Estatus Marital")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
