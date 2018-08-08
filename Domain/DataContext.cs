using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.GEN;
using Domain.SEG;
using Domain.MED;
//using Domain.CPO;
//using Domain.POS;
//using Domain.TRK;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new UsersMap());
        }
       

        public DbSet<AuthorPlanOption> AuthorPlanOptions { get; set; }

        public DbSet<UserEmailSetting> UserEmailSettings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<OptionRol> OptionRols { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<ParentOption> ParentOptions { get; set; }

        public DbSet<UserRol> UserRols { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<MaritalSituation> MaritalSituations { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Periodicity> Periodicities { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Ocupation> Ocupations { get; set; }

        public DbSet<Religion> Religions { get; set; }

        public DbSet<BloodType> BloodTypes { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorPlan> AuthorPlans { get; set; }

        public DbSet<AuthorType> AuthorTypes { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<AccountingClassification> AccountingClassifications { get; set; }

        public DbSet<AccountingSubClassification> AccountingSubClassifications { get; set; }

        public DbSet<AccountingAccount> AccountingAccounts { get; set; }

        public DbSet<AccountingAuxiliary> AccountingAuxiliaries { get; set; }

        public DbSet<AccountingSubAuxiliary> AccountingSubAuxiliaries { get; set; }

        

        public DbSet<BusinessType> BusinessTypes { get; set; }

        

        public DbSet<SchoolLevel> SchoolLevels { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Patient> Patients { get; set; }

       

        public DbSet<Report> Reports { get; set; }

        

         //public DbSet<LaboratoryTest> LaboratoryTests { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        

        public DbSet<General> Generals { get; set; }

        public DbSet<GeneralAfection> GeneralAfections { get; set; }

        public DbSet<GeneralVisit> GeneralVisits { get; set; }

        

        public DbSet<Measure> Measures { get; set; }

      

        public DbSet<MeasureEquivalence> MeasureEquivalences { get; set; }

       

        public DbSet<PaymentType> PaymentTypes { get; set; }

       

    }
}
