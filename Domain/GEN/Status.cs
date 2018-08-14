namespace Domain.GEN
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MED;
    using SEG;
    //using TRK;
    using Newtonsoft.Json;

    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Estatus")]
        public string Name { get; set; }
        
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Tabla")]
        public string Table { get; set; }

        [JsonIgnore] public virtual ICollection<Person> Persons { get; set; }
        [JsonIgnore]
        public virtual ICollection<AuthorPlan> AuthorPlans { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRol> UserRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<OptionRol> OptionRols { get; set; }
        [JsonIgnore]
        public virtual ICollection<Option> Options { get; set; }
        [JsonIgnore]
        public virtual ICollection<ParentOption> ParentOptions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Rol> Rols { get; set; }
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Wallet> Wallets { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Account> Accounts { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<AccountType> AccountTypes { get; set; }      
        //[JsonIgnore]
        //public virtual ICollection<Analytical> Analyticals { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Admision> Admisions { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Area> Areas { get; set; }
    }
}
