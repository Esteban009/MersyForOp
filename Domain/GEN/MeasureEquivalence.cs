using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class MeasureEquivalence
    {

        [Key]
        public int MeasureEquivalenceId { get; set; }

        [Display(Name = "Unidad de Medida Principal")]
        public int MeasureMasterId { get; set; }

        [Display(Name = "Unidad de Medida Inferior")]
        public int MeasureSlaveId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Equivalencia")]
        public decimal Equivalence { get; set; }

        public int AuthorId { get; set; }

        [JsonIgnore]
        public virtual Measure MeasureMaster { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual Measure MeasureSlave { get; set; }
    }
}
