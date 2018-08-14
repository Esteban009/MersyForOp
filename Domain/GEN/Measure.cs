using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Domain.CPO;
//using Domain.POS;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Measure
    {
        [Key]
        public int MeasureId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Measure_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
         
        [Display(Name = "Unidad de Medida")]
        public string Name { get; set; }

        public int AuthorId { get; set; }
        
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual ICollection<MeasureEquivalence> MeasureMasters { get; set; }
        [JsonIgnore]
        public virtual ICollection<MeasureEquivalence> MeasureSlaves { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<BusinessInventory> Inventories { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
