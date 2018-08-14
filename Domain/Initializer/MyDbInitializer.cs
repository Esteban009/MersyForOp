namespace Domain.Initializer
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Domain.GEN;

    public class MyDbInitializer : CreateDatabaseIfNotExists<DataContext> //DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Initializing the Gender list
            IList<Gender> defaultGenderList = new List<Gender>
            {
                new Gender() { Name = "M" },
                new Gender() { Name = "F" },
                new Gender() { Name = "I" }
            };
            foreach (var dtl in defaultGenderList)
                context.Genders.Add(dtl);

            //Initializing the Gender list
            IList<Currency> defaultCurrencyList = new List<Currency>
            {
                new Currency() { Code = "USD", Name = "Dollar" },
                new Currency() { Code = "DOP", Name = "Pesos Dominicanos" },
                new Currency() { Code = "EUR", Name = "Euro" }
            };
            foreach (var dtl in defaultCurrencyList)
                context.Currencies.Add(dtl);
            
            base.Seed(context);
        }

    }
}
