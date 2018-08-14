using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.SEG;
//using Domain.TRK;
//using Domain.MED;
//using Domain.POS;
using Newtonsoft.Json;

namespace Domain.GEN
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Index("Author_Code_Index", IsUnique = true)]
        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [Index("Author_Email_Index", IsUnique = true)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Index("Author_Tel_Index", IsUnique = true)]
        [Display(Name = "Telefono")]
        public string Tel { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Plan")]
        public int AuthorPlanId { get; set; }

        [Display(Name = "Tipo")]
        public int AuthorTypeId { get; set; }

        [JsonIgnore]
        public virtual AuthorType Type { get; set; }
        [JsonIgnore]
        public virtual AuthorPlan Plan { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
        [JsonIgnore]
        public virtual ICollection<Rol> Rols { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }       
        [JsonIgnore]
        public virtual ICollection<Measure> Measures { get; set; }
        [JsonIgnore]
        public virtual ICollection<MeasureEquivalence> MeasureEquivalences { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Product> Products { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Brand> Brands { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Shop> Shops { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Supplier> Suppliers { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Wallet> Wallets { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<SaleAsosiation> SaleAsosiations { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Laboratory> Laboratories { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Area> Areas { get; set; }

       
    }
}
