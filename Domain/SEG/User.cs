using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.GEN;
using Domain.MED;
//using Domain.POS;
//using Domain.TRK;
using Newtonsoft.Json;

namespace Domain.SEG
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Tipo")]
        public int UserTypeId { get; set; }
        //[Display(Name = "Nivel")]
        //public int? Level { get; set; }

        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [DataType(DataType.EmailAddress)]
        //[Index("User_Email_Index", IsUnique = true)]
        public string Email { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Cliente Ps")]
        public int AuthorId { get; set; }


        [JsonIgnore]
        public virtual UserType UserType { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRol> UserRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
        [JsonIgnore]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserEmailSetting> UserEmailSettings { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Sale> Sales { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ShopUser> ShopUsers { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<CashierDetail> CashierDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Tag> Tags { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Budget> Budgets { get; set; }

    }

}
