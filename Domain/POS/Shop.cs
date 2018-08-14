using System;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.POS
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        // [Index("Shop_Name_Index", IsUnique = true)]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Sucursal")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [EmailAddress(ErrorMessage = "Porfavor, entroduzca un email valido")]
        public string Email { get; set; }

        [MaxLength(75, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
       
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Entroduzca una pagina web valida")]
        [Display(Name = "Web")]
        public string WebAddress { get; set; }

        [MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        // [Index("Person_Tel_Index", IsUnique = true)]
        [Display(Name = "Telefono")]
        public string Tel { get; set; }

        [Display(Name = "Fecha de Creacion")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }

        // public virtual ICollection<Customer> Customers { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Sale> Sales { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Cashier> Cashiers { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Purchase> Purchases { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Inventory> Inventories { get; set; }
      

    }
}
