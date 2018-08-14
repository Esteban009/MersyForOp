namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingAccounts",
                c => new
                    {
                        AccountingAccountId = c.Int(nullable: false, identity: true),
                        AccountingSubClassificationId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 6),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AccountingAccountId)
                .ForeignKey("dbo.AccountingSubClassifications", t => t.AccountingSubClassificationId)
                .Index(t => t.AccountingSubClassificationId)
                .Index(t => t.Code, unique: true, name: "AccountingAccount_Code_Index");
            
            CreateTable(
                "dbo.AccountingAuxiliaries",
                c => new
                    {
                        AccountingAuxiliaryId = c.Int(nullable: false, identity: true),
                        AccountingAccountId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AccountingAuxiliaryId)
                .ForeignKey("dbo.AccountingAccounts", t => t.AccountingAccountId)
                .Index(t => t.AccountingAccountId)
                .Index(t => t.Code, unique: true, name: "AccountingAuxiliary_Code_Index")
                .Index(t => t.Name, unique: true, name: "AccountingAuxiliary_Name_Index");
            
            CreateTable(
                "dbo.AccountingSubAuxiliaries",
                c => new
                    {
                        AccountingSubAuxiliaryId = c.Int(nullable: false, identity: true),
                        AccountingAuxiliaryId = c.Int(nullable: false),
                        Code = c.String(maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AccountingSubAuxiliaryId)
                .ForeignKey("dbo.AccountingAuxiliaries", t => t.AccountingAuxiliaryId)
                .Index(t => t.AccountingAuxiliaryId)
                .Index(t => t.Code, unique: true, name: "AccountingSubAuxiliary_Code_Index")
                .Index(t => t.Name, unique: true, name: "AccountingSubAuxiliary_Name_Index");
            
            CreateTable(
                "dbo.AccountingSubClassifications",
                c => new
                    {
                        AccountingSubClassificationId = c.Int(nullable: false, identity: true),
                        AccountingClassificationId = c.Int(nullable: false),
                        Code = c.String(maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AccountingSubClassificationId)
                .ForeignKey("dbo.AccountingClassifications", t => t.AccountingClassificationId)
                .Index(t => t.AccountingClassificationId)
                .Index(t => t.Name, unique: true, name: "AccountingSubClassification_Name_Index");
            
            CreateTable(
                "dbo.AccountingClassifications",
                c => new
                    {
                        AccountingClassificationId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                        Origin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountingClassificationId)
                .Index(t => t.Code, unique: true, name: "AccountingClassification_Code_Index")
                .Index(t => t.Name, unique: true, name: "AccountingClassification_Name_Index");
            
            CreateTable(
                "dbo.AuthorPlanOptions",
                c => new
                    {
                        AuthorPlanOptionId = c.Int(nullable: false, identity: true),
                        AuthorPlanId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorPlanOptionId)
                .ForeignKey("dbo.AuthorPlans", t => t.AuthorPlanId)
                .ForeignKey("dbo.Options", t => t.OptionId)
                .Index(t => t.AuthorPlanId)
                .Index(t => t.OptionId);
            
            CreateTable(
                "dbo.AuthorPlans",
                c => new
                    {
                        AuthorPlanId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        CurrencyId = c.Int(nullable: false),
                        PeriodicityId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.AuthorPlanId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.Periodicities", t => t.PeriodicityId)
                .Index(t => t.Code, unique: true, name: "AuthorPlan_Code_Index")
                .Index(t => t.Name, unique: true, name: "AuthorPlan_Name_Index")
                .Index(t => t.CurrencyId)
                .Index(t => t.PeriodicityId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Imagen = c.String(),
                        Email = c.String(maxLength: 50),
                        Tel = c.String(maxLength: 50),
                        StartDate = c.DateTime(),
                        StatusId = c.Int(nullable: false),
                        AuthorPlanId = c.Int(nullable: false),
                        AuthorTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.AuthorPlans", t => t.AuthorPlanId)
                .ForeignKey("dbo.AuthorTypes", t => t.AuthorTypeId)
                .Index(t => t.Code, unique: true, name: "Author_Code_Index")
                .Index(t => t.Email, unique: true, name: "Author_Email_Index")
                .Index(t => t.Tel, unique: true, name: "Author_Tel_Index")
                .Index(t => t.StatusId)
                .Index(t => t.AuthorPlanId)
                .Index(t => t.AuthorTypeId);
            
            CreateTable(
                "dbo.MeasureEquivalences",
                c => new
                    {
                        MeasureEquivalenceId = c.Int(nullable: false, identity: true),
                        MeasureMasterId = c.Int(nullable: false),
                        MeasureSlaveId = c.Int(nullable: false),
                        Equivalence = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuthorId = c.Int(nullable: false),
                        Measure_MeasureId = c.Int(),
                        Measure_MeasureId1 = c.Int(),
                        MeasureMaster_MeasureId = c.Int(),
                        MeasureSlave_MeasureId = c.Int(),
                    })
                .PrimaryKey(t => t.MeasureEquivalenceId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Measures", t => t.Measure_MeasureId)
                .ForeignKey("dbo.Measures", t => t.Measure_MeasureId1)
                .ForeignKey("dbo.Measures", t => t.MeasureMaster_MeasureId)
                .ForeignKey("dbo.Measures", t => t.MeasureSlave_MeasureId)
                .Index(t => t.AuthorId)
                .Index(t => t.Measure_MeasureId)
                .Index(t => t.Measure_MeasureId1)
                .Index(t => t.MeasureMaster_MeasureId)
                .Index(t => t.MeasureSlave_MeasureId);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        MeasureId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeasureId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .Index(t => t.Code, unique: true, name: "Measure_Code_Index")
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Rnc = c.String(maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BornDate = c.DateTime(),
                        GenderId = c.Int(nullable: false),
                        SchoolLevelId = c.Int(),
                        CountryId = c.Int(nullable: false),
                        Email = c.String(maxLength: 50),
                        Tel = c.String(maxLength: 15),
                        Cel = c.String(maxLength: 15),
                        MaritalSituationId = c.Int(nullable: false),
                        OcupationId = c.Int(nullable: false),
                        ReligionId = c.Int(nullable: false),
                        Address = c.String(maxLength: 200),
                        StatusId = c.Int(nullable: false),
                        Imagen = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.MaritalSituations", t => t.MaritalSituationId)
                .ForeignKey("dbo.Ocupations", t => t.OcupationId)
                .ForeignKey("dbo.Religions", t => t.ReligionId)
                .ForeignKey("dbo.SchoolLevels", t => t.SchoolLevelId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.GenderId)
                .Index(t => t.SchoolLevelId)
                .Index(t => t.CountryId)
                .Index(t => t.MaritalSituationId)
                .Index(t => t.OcupationId)
                .Index(t => t.ReligionId)
                .Index(t => t.StatusId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                        Demonym = c.String(maxLength: 25),
                        Imagen = c.String(),
                        Continent_ContinentId = c.Int(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Continents", t => t.Continent_ContinentId)
                .Index(t => t.Code, unique: true, name: "Country_Code_Index")
                .Index(t => t.Name, unique: true, name: "Country_Name_Index")
                .Index(t => t.Demonym, unique: true, name: "Country_Demonym_Index")
                .Index(t => t.Continent_ContinentId);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        ContinentId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 50),
                        Demonym = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ContinentId)
                .Index(t => t.Code, unique: true, name: "Continent_Code_Index")
                .Index(t => t.Name, unique: true, name: "Continent_Name_Index")
                .Index(t => t.Demonym, unique: true, name: "Continent_Demonym_Index");
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.GenderId)
                .Index(t => t.Name, unique: true, name: "Gender_Name_Index");
            
            CreateTable(
                "dbo.MaritalSituations",
                c => new
                    {
                        MaritalSituationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MaritalSituationId)
                .Index(t => t.Name, unique: true, name: "MaritalSituation_Name_Index");
            
            CreateTable(
                "dbo.Ocupations",
                c => new
                    {
                        OcupationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OcupationId)
                .Index(t => t.Name, unique: true, name: "Ocupation_Name_Index");
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Record = c.Int(nullable: false),
                        Record2 = c.String(),
                        CreationDate = c.DateTime(),
                        InsuranceId = c.Int(nullable: false),
                        InsuranceNumber = c.String(maxLength: 15),
                        BloodTypeId = c.Int(nullable: false),
                        Age = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.BloodTypes", t => t.BloodTypeId)
                .ForeignKey("dbo.Insurances", t => t.InsuranceId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.InsuranceId)
                .Index(t => t.BloodTypeId);
            
            CreateTable(
                "dbo.BloodTypes",
                c => new
                    {
                        BloodTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BloodTypeId)
                .Index(t => t.Code, unique: true, name: "BloodType_Code_Index")
                .Index(t => t.Name, unique: true, name: "BloodType_Name_Index");
            
            CreateTable(
                "dbo.GeneralAfections",
                c => new
                    {
                        GeneralAfectionId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        VisitDate = c.DateTime(),
                        VisitReason = c.String(nullable: false, maxLength: 500),
                        Symptoms = c.String(maxLength: 500),
                        PhysicalExam = c.String(maxLength: 500),
                        Labs = c.String(maxLength: 500),
                        Conclusion = c.String(maxLength: 500),
                        Indications = c.String(maxLength: 500),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.GeneralAfectionId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.GeneralVisits",
                c => new
                    {
                        GeneralVisitId = c.Int(nullable: false, identity: true),
                        GeneralAfectionId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        VisitDate = c.DateTime(),
                        VisitReason = c.String(nullable: false, maxLength: 500),
                        Revision = c.String(maxLength: 500),
                        VitalSign = c.String(maxLength: 500),
                        PresionArterialSist = c.Int(nullable: false),
                        PresionArterialDiast = c.Int(nullable: false),
                        Pulsaciones = c.Int(nullable: false),
                        RitmoResp = c.Int(nullable: false),
                        Temp = c.Int(nullable: false),
                        Altura = c.String(),
                        Peso = c.Int(nullable: false),
                        PresionArterial = c.Int(nullable: false),
                        PhysicalExam = c.String(maxLength: 500),
                        Labs = c.String(maxLength: 500),
                        Diagnostic = c.String(maxLength: 500),
                        Conclusion = c.String(maxLength: 500),
                        Indications = c.String(maxLength: 500),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.GeneralVisitId)
                .ForeignKey("dbo.GeneralAfections", t => t.GeneralAfectionId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.GeneralAfectionId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Generals",
                c => new
                    {
                        GeneralId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        AntFamiliar = c.String(maxLength: 500),
                        AntPersonales = c.String(maxLength: 500),
                        Diabetes = c.Boolean(nullable: false),
                        Drugs = c.Boolean(nullable: false),
                        Tobaco = c.Boolean(nullable: false),
                        Alcohol = c.Boolean(nullable: false),
                        Sports = c.String(maxLength: 500),
                        Pasatiempos = c.String(maxLength: 500),
                        Work = c.String(maxLength: 500),
                        Food = c.String(maxLength: 500),
                        Accidents = c.String(maxLength: 500),
                        Traumatismos = c.String(maxLength: 500),
                        Fracturas = c.String(maxLength: 500),
                        Alergys = c.String(maxLength: 500),
                        Sugeries = c.String(maxLength: 500),
                        Incapacidades = c.String(maxLength: 500),
                        Menstruacion = c.String(maxLength: 500),
                        Respiracion = c.String(maxLength: 500),
                        Piel = c.String(maxLength: 500),
                        Urinarias = c.String(maxLength: 500),
                        Psiquiatria = c.String(maxLength: 500),
                        InfanciaEnferma = c.String(maxLength: 500),
                        NoQuirurgicas = c.String(maxLength: 500),
                        Medicaments = c.String(maxLength: 500),
                        Enfermedades = c.String(maxLength: 500),
                        Observations = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.GeneralId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsuranceId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        AditionalInfo = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.InsuranceId)
                .Index(t => t.Code, unique: true, name: "Insurance_Code_Index")
                .Index(t => t.Name, unique: true, name: "Insurance_Name_Index");
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ReligionId)
                .Index(t => t.Name, unique: true, name: "Religion_Name_Index");
            
            CreateTable(
                "dbo.SchoolLevels",
                c => new
                    {
                        SchoolLevelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.SchoolLevelId)
                .Index(t => t.Name, unique: true, name: "SchoolLevel_Name_Index");
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Table = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.OptionRols",
                c => new
                    {
                        OptionRolId = c.Int(nullable: false, identity: true),
                        OptionId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Undefined = c.Boolean(nullable: false),
                        Index = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                        Create = c.Boolean(nullable: false),
                        Edit = c.Boolean(nullable: false),
                        Details = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionRolId)
                .ForeignKey("dbo.Options", t => t.OptionId)
                .ForeignKey("dbo.Rols", t => t.RolId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.OptionId)
                .Index(t => t.RolId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        ParentOptionId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                        Link = c.String(maxLength: 100),
                        Area = c.String(maxLength: 25),
                        Controller = c.String(maxLength: 25),
                        Action = c.String(maxLength: 25),
                        Order = c.Int(),
                        Class = c.String(maxLength: 100),
                        Icon = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.ParentOptions", t => t.ParentOptionId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ParentOptionId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.ParentOptions",
                c => new
                    {
                        ParentOptionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 100),
                        Link = c.String(maxLength: 100),
                        Order = c.Int(),
                        Class = c.String(maxLength: 100),
                        Icon = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentOptionId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        UserRolId = c.Int(nullable: false, identity: true),
                        RolId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        Undefined = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Option_OptionId = c.Int(),
                    })
                .PrimaryKey(t => t.UserRolId)
                .ForeignKey("dbo.Rols", t => t.RolId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Options", t => t.Option_OptionId)
                .Index(t => t.RolId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId)
                .Index(t => t.Option_OptionId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 100),
                        Level = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.AuthorId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserTypeId = c.Int(nullable: false),
                        Picture = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        StatusId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId)
                .Index(t => t.UserTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Record = c.String(),
                        CreationDate = c.DateTime(),
                        Especialidad = c.String(),
                        Cmd = c.String(),
                        City = c.String(),
                        Prefix = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        MainHeader = c.String(maxLength: 1000),
                        Header1 = c.String(maxLength: 200),
                        Header2 = c.String(maxLength: 200),
                        Header3 = c.String(maxLength: 200),
                        Description = c.String(maxLength: 100),
                        Body = c.String(),
                        MainFooter = c.String(maxLength: 100),
                        Footer1 = c.String(maxLength: 100),
                        Footer2 = c.String(maxLength: 100),
                        Footer3 = c.String(maxLength: 100),
                        Width = c.String(nullable: false, maxLength: 100),
                        Heigh = c.String(nullable: false, maxLength: 100),
                        Imagen = c.String(),
                        AuthorId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.AuthorId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserEmailSettings",
                c => new
                    {
                        UserEmailSettingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        HostNameSmtp = c.String(),
                        Port = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserEmailSettingId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserTypeId)
                .Index(t => t.Name, unique: true, name: "UserType_Name_Index");
            
            CreateTable(
                "dbo.AuthorTypes",
                c => new
                    {
                        AuthorTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AuthorTypeId)
                .Index(t => t.Name, unique: true, name: "AuthorType_Name_Index");
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CurrencyId)
                .Index(t => t.Code, unique: true, name: "Currency_Code_Index")
                .Index(t => t.Name, unique: true, name: "Currency_Name_Index");
            
            CreateTable(
                "dbo.Periodicities",
                c => new
                    {
                        PeriodicityId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PeriodicityId)
                .Index(t => t.Code, unique: true, name: "Periodicity_Code_Index")
                .Index(t => t.Name, unique: true, name: "Periodicity_Name_Index");
            
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        BusinessTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BusinessTypeId)
                .Index(t => t.Name, unique: true, name: "BusinessType_Name_Index");
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PaymentTypeId)
                .Index(t => t.Code, unique: true, name: "PaymentType_Code_Index")
                .Index(t => t.Name, unique: true, name: "PaymentType_Name_Index");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorPlans", "PeriodicityId", "dbo.Periodicities");
            DropForeignKey("dbo.AuthorPlans", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Authors", "AuthorTypeId", "dbo.AuthorTypes");
            DropForeignKey("dbo.Authors", "AuthorPlanId", "dbo.AuthorPlans");
            DropForeignKey("dbo.People", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OptionRols", "StatusId", "dbo.Status");
            DropForeignKey("dbo.UserRols", "Option_OptionId", "dbo.Options");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.UserRols", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEmailSettings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Reports", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Reports", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.UserRols", "StatusId", "dbo.Status");
            DropForeignKey("dbo.UserRols", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Rols", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OptionRols", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Rols", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Options", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Options", "ParentOptionId", "dbo.ParentOptions");
            DropForeignKey("dbo.ParentOptions", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OptionRols", "OptionId", "dbo.Options");
            DropForeignKey("dbo.AuthorPlanOptions", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Authors", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AuthorPlans", "StatusId", "dbo.Status");
            DropForeignKey("dbo.People", "SchoolLevelId", "dbo.SchoolLevels");
            DropForeignKey("dbo.People", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Patients", "PersonId", "dbo.People");
            DropForeignKey("dbo.Patients", "InsuranceId", "dbo.Insurances");
            DropForeignKey("dbo.Generals", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.GeneralAfections", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.GeneralVisits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.GeneralVisits", "GeneralAfectionId", "dbo.GeneralAfections");
            DropForeignKey("dbo.Patients", "BloodTypeId", "dbo.BloodTypes");
            DropForeignKey("dbo.People", "OcupationId", "dbo.Ocupations");
            DropForeignKey("dbo.People", "MaritalSituationId", "dbo.MaritalSituations");
            DropForeignKey("dbo.People", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.People", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Continent_ContinentId", "dbo.Continents");
            DropForeignKey("dbo.People", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.MeasureEquivalences", "MeasureSlave_MeasureId", "dbo.Measures");
            DropForeignKey("dbo.MeasureEquivalences", "MeasureMaster_MeasureId", "dbo.Measures");
            DropForeignKey("dbo.MeasureEquivalences", "Measure_MeasureId1", "dbo.Measures");
            DropForeignKey("dbo.MeasureEquivalences", "Measure_MeasureId", "dbo.Measures");
            DropForeignKey("dbo.Measures", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.MeasureEquivalences", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.AuthorPlanOptions", "AuthorPlanId", "dbo.AuthorPlans");
            DropForeignKey("dbo.AccountingSubClassifications", "AccountingClassificationId", "dbo.AccountingClassifications");
            DropForeignKey("dbo.AccountingAccounts", "AccountingSubClassificationId", "dbo.AccountingSubClassifications");
            DropForeignKey("dbo.AccountingSubAuxiliaries", "AccountingAuxiliaryId", "dbo.AccountingAuxiliaries");
            DropForeignKey("dbo.AccountingAuxiliaries", "AccountingAccountId", "dbo.AccountingAccounts");
            DropIndex("dbo.PaymentTypes", "PaymentType_Name_Index");
            DropIndex("dbo.PaymentTypes", "PaymentType_Code_Index");
            DropIndex("dbo.BusinessTypes", "BusinessType_Name_Index");
            DropIndex("dbo.Periodicities", "Periodicity_Name_Index");
            DropIndex("dbo.Periodicities", "Periodicity_Code_Index");
            DropIndex("dbo.Currencies", "Currency_Name_Index");
            DropIndex("dbo.Currencies", "Currency_Code_Index");
            DropIndex("dbo.AuthorTypes", "AuthorType_Name_Index");
            DropIndex("dbo.UserTypes", "UserType_Name_Index");
            DropIndex("dbo.UserEmailSettings", new[] { "UserId" });
            DropIndex("dbo.Reports", new[] { "User_UserId" });
            DropIndex("dbo.Reports", new[] { "AuthorId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "AuthorId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Rols", new[] { "StatusId" });
            DropIndex("dbo.Rols", new[] { "AuthorId" });
            DropIndex("dbo.UserRols", new[] { "Option_OptionId" });
            DropIndex("dbo.UserRols", new[] { "StatusId" });
            DropIndex("dbo.UserRols", new[] { "UserId" });
            DropIndex("dbo.UserRols", new[] { "RolId" });
            DropIndex("dbo.ParentOptions", new[] { "StatusId" });
            DropIndex("dbo.Options", new[] { "StatusId" });
            DropIndex("dbo.Options", new[] { "ParentOptionId" });
            DropIndex("dbo.OptionRols", new[] { "StatusId" });
            DropIndex("dbo.OptionRols", new[] { "RolId" });
            DropIndex("dbo.OptionRols", new[] { "OptionId" });
            DropIndex("dbo.SchoolLevels", "SchoolLevel_Name_Index");
            DropIndex("dbo.Religions", "Religion_Name_Index");
            DropIndex("dbo.Insurances", "Insurance_Name_Index");
            DropIndex("dbo.Insurances", "Insurance_Code_Index");
            DropIndex("dbo.Generals", new[] { "PatientId" });
            DropIndex("dbo.GeneralVisits", new[] { "PatientId" });
            DropIndex("dbo.GeneralVisits", new[] { "GeneralAfectionId" });
            DropIndex("dbo.GeneralAfections", new[] { "PatientId" });
            DropIndex("dbo.BloodTypes", "BloodType_Name_Index");
            DropIndex("dbo.BloodTypes", "BloodType_Code_Index");
            DropIndex("dbo.Patients", new[] { "BloodTypeId" });
            DropIndex("dbo.Patients", new[] { "InsuranceId" });
            DropIndex("dbo.Patients", new[] { "PersonId" });
            DropIndex("dbo.Ocupations", "Ocupation_Name_Index");
            DropIndex("dbo.MaritalSituations", "MaritalSituation_Name_Index");
            DropIndex("dbo.Genders", "Gender_Name_Index");
            DropIndex("dbo.Continents", "Continent_Demonym_Index");
            DropIndex("dbo.Continents", "Continent_Name_Index");
            DropIndex("dbo.Continents", "Continent_Code_Index");
            DropIndex("dbo.Countries", new[] { "Continent_ContinentId" });
            DropIndex("dbo.Countries", "Country_Demonym_Index");
            DropIndex("dbo.Countries", "Country_Name_Index");
            DropIndex("dbo.Countries", "Country_Code_Index");
            DropIndex("dbo.People", new[] { "AuthorId" });
            DropIndex("dbo.People", new[] { "StatusId" });
            DropIndex("dbo.People", new[] { "ReligionId" });
            DropIndex("dbo.People", new[] { "OcupationId" });
            DropIndex("dbo.People", new[] { "MaritalSituationId" });
            DropIndex("dbo.People", new[] { "CountryId" });
            DropIndex("dbo.People", new[] { "SchoolLevelId" });
            DropIndex("dbo.People", new[] { "GenderId" });
            DropIndex("dbo.Measures", new[] { "AuthorId" });
            DropIndex("dbo.Measures", "Measure_Code_Index");
            DropIndex("dbo.MeasureEquivalences", new[] { "MeasureSlave_MeasureId" });
            DropIndex("dbo.MeasureEquivalences", new[] { "MeasureMaster_MeasureId" });
            DropIndex("dbo.MeasureEquivalences", new[] { "Measure_MeasureId1" });
            DropIndex("dbo.MeasureEquivalences", new[] { "Measure_MeasureId" });
            DropIndex("dbo.MeasureEquivalences", new[] { "AuthorId" });
            DropIndex("dbo.Authors", new[] { "AuthorTypeId" });
            DropIndex("dbo.Authors", new[] { "AuthorPlanId" });
            DropIndex("dbo.Authors", new[] { "StatusId" });
            DropIndex("dbo.Authors", "Author_Tel_Index");
            DropIndex("dbo.Authors", "Author_Email_Index");
            DropIndex("dbo.Authors", "Author_Code_Index");
            DropIndex("dbo.AuthorPlans", new[] { "StatusId" });
            DropIndex("dbo.AuthorPlans", new[] { "PeriodicityId" });
            DropIndex("dbo.AuthorPlans", new[] { "CurrencyId" });
            DropIndex("dbo.AuthorPlans", "AuthorPlan_Name_Index");
            DropIndex("dbo.AuthorPlans", "AuthorPlan_Code_Index");
            DropIndex("dbo.AuthorPlanOptions", new[] { "OptionId" });
            DropIndex("dbo.AuthorPlanOptions", new[] { "AuthorPlanId" });
            DropIndex("dbo.AccountingClassifications", "AccountingClassification_Name_Index");
            DropIndex("dbo.AccountingClassifications", "AccountingClassification_Code_Index");
            DropIndex("dbo.AccountingSubClassifications", "AccountingSubClassification_Name_Index");
            DropIndex("dbo.AccountingSubClassifications", new[] { "AccountingClassificationId" });
            DropIndex("dbo.AccountingSubAuxiliaries", "AccountingSubAuxiliary_Name_Index");
            DropIndex("dbo.AccountingSubAuxiliaries", "AccountingSubAuxiliary_Code_Index");
            DropIndex("dbo.AccountingSubAuxiliaries", new[] { "AccountingAuxiliaryId" });
            DropIndex("dbo.AccountingAuxiliaries", "AccountingAuxiliary_Name_Index");
            DropIndex("dbo.AccountingAuxiliaries", "AccountingAuxiliary_Code_Index");
            DropIndex("dbo.AccountingAuxiliaries", new[] { "AccountingAccountId" });
            DropIndex("dbo.AccountingAccounts", "AccountingAccount_Code_Index");
            DropIndex("dbo.AccountingAccounts", new[] { "AccountingSubClassificationId" });
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.Periodicities");
            DropTable("dbo.Currencies");
            DropTable("dbo.AuthorTypes");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserEmailSettings");
            DropTable("dbo.Reports");
            DropTable("dbo.Doctors");
            DropTable("dbo.Users");
            DropTable("dbo.Rols");
            DropTable("dbo.UserRols");
            DropTable("dbo.ParentOptions");
            DropTable("dbo.Options");
            DropTable("dbo.OptionRols");
            DropTable("dbo.Status");
            DropTable("dbo.SchoolLevels");
            DropTable("dbo.Religions");
            DropTable("dbo.Insurances");
            DropTable("dbo.Generals");
            DropTable("dbo.GeneralVisits");
            DropTable("dbo.GeneralAfections");
            DropTable("dbo.BloodTypes");
            DropTable("dbo.Patients");
            DropTable("dbo.Ocupations");
            DropTable("dbo.MaritalSituations");
            DropTable("dbo.Genders");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.People");
            DropTable("dbo.Measures");
            DropTable("dbo.MeasureEquivalences");
            DropTable("dbo.Authors");
            DropTable("dbo.AuthorPlans");
            DropTable("dbo.AuthorPlanOptions");
            DropTable("dbo.AccountingClassifications");
            DropTable("dbo.AccountingSubClassifications");
            DropTable("dbo.AccountingSubAuxiliaries");
            DropTable("dbo.AccountingAuxiliaries");
            DropTable("dbo.AccountingAccounts");
        }
    }
}
