using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.GEN;
using Domain.SEG;
using Domain.MED;
using Domain.POS;
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

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<General> Generals { get; set; }

        public DbSet<GeneralAfection> GeneralAfections { get; set; }

        public DbSet<GeneralVisit> GeneralVisits { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<MeasureEquivalence> MeasureEquivalences { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Analytical> Analyticals { get; set; }

        public DbSet<ShopUser> ShopUsers { get; set; }

        public DbSet<Shop> Shops { get; set; }

        //public DbSet<Product> Products { get; set; }

        //public DbSet<Purchase> Purchases { get; set; }

        //public DbSet<Supplier> Suppliers { get; set; }

        //public DbSet<Sale> Sales { get; set; }

        //public DbSet<SalesDetail> SalesDetails { get; set; }

        //public DbSet<Cashier> Cashiers { get; set; }

        //public DbSet<CashierDetail> CashierDetails { get; set; }

        //public DbSet<BankCheck> BankChecks { get; set; }

        //public DbSet<Inventory> Inventories { get; set; }

        //public DbSet<Account> Accounts { get; set; }

        //public DbSet<Operation> Operations { get; set; }

        //public DbSet<Origin> Origins { get; set; }

        //public DbSet<Wallet> Wallets { get; set; }

        //public DbSet<Tag> Tags { get; set; }

        //public DbSet<Budget> Budgets { get; set; }

        //public DbSet<BudgetDetail> BudgetDetails { get; set; }

        // public DbSet<SaleType> SaleTypes { get; set; }

        //public DbSet<AccountType> AccountTypes { get; set; }

        //public DbSet<SaleAsosiation> SaleAsosiations { get; set; }

        //public DbSet<Admision> Admisions { get; set; }

        //public DbSet<Area> Areas { get; set; }

        //public DbSet<Appointment> Appointments { get; set; }

        // public DbSet<Endocrine> Endocrines { get; set; }

        //public DbSet<Gynecology> Gynecologies { get; set; }

        //public DbSet<GynecologyVisit> GynecologyVisits { get; set; }

        //public DbSet<Obstetric> Obstetrics { get; set; }

        //public DbSet<LaboratoryTest> LaboratoryTests { get; set; }

        //public DbSet<LaboratoryResult> LaboratoryResults { get; set; }

        //public DbSet<ObstetricVisit> ObstetricVisits { get; set; }

        //public DbSet<AnalyticalSheet> AnalyticalSheets { get; set; }

        //public DbSet<Recipe> Recipes { get; set; }

        //public DbSet<MedicalCertificate> MedicalCertificates { get; set; }

        // public DbSet<Business> Businesses { get; set; }

        //public DbSet<PediatricGrowth> PediatricGrowths { get; set; }

        //public DbSet<AnalyticalDetail> AnalyticalDetails { get; set; }

        //public DbSet<BusinessSubClassification> BusinessSubClassifications { get; set; }

        //public DbSet<BusinessAccount> BusinessAccounts { get; set; }

        //public DbSet<BusinessAuxiliary> BusinessAuxiliaries { get; set; }

        //public DbSet<BusinessSubAuxiliary> BusinessSubAuxiliaries { get; set; }

        //public DbSet<Cardiology> Cardiologies { get; set; }

        //public DbSet<Pediatric> Pediatrics { get; set; }

        //public DbSet<PediatricVisit> PediatricVisits { get; set; }

        //public DbSet<Vaccine> Vaccines { get; set; }

        //public DbSet<Orthopedic> Orthopedics { get; set; }

        //public DbSet<Inmunization> Inmunizations { get; set; }

        //public DbSet<Bariatric> Bariatrics { get; set; }

        //public DbSet<BariatricVisit> BariatricVisits { get; set; }

        //public DbSet<LaboratoryTest> LaboratoryTests { get; set; }

        //public DbSet<Treatment> Treatments { get; set; }

        //public DbSet<TreatmentVisit> TreatmentVisits { get; set; }

        //public DbSet<LabClasification> LabClasifications { get; set; }

        //public DbSet<Laboratory> Laboratories { get; set; }

        //public DbSet<LaboratoryDetail> LaboratoryDetails { get; set; }

        //public DbSet<Psychiatry> Psychiatrys { get; set; }

        //public DbSet<Urology> Urologys { get; set; }

        //public DbSet<Anesthetic> Anesthetics { get; set; }

        //public DbSet<Surgery> Surgeries { get; set; }

        //public DbSet<Brand> Brands { get; set; }

        //public DbSet<Category> Categories { get; set; }

        //public DbSet<ServiceType> ServiceTypes { get; set; }

        //public DbSet<FinancialYear> FinancialYears { get; set; }

    }
}
