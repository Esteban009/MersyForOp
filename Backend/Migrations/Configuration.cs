namespace Backend.Migrations
{
    using Domain;
    using Domain.GEN;
    using Domain.MED;
    using Domain.SEG;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
        }

    }
}

