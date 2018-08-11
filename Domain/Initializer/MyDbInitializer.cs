using System.Collections.Generic;
using System.Data.Entity;
using Domain.GEN;

namespace Domain.Initializer
{
    public class MyDbInitializer :CreateDatabaseIfNotExists<DataContext> //DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Initializing the Gender list
            IList<Gender> defaultGenderList = new List<Gender>();

            defaultGenderList.Add(new Gender() { Name = "M" });
            defaultGenderList.Add(new Gender() { Name = "F" });
            defaultGenderList.Add(new Gender() { Name = "I" });
            foreach (var dtl in defaultGenderList)
                context.Genders.Add(dtl);

            //Initializing the Gender list
            IList<Currency> defaultCurrencyList = new List<Currency>();

            defaultCurrencyList.Add(new Currency() { Code="USD", Name = "Dollar" });
            defaultCurrencyList.Add(new Currency() { Code = "DOP", Name = "Pesos Dominicanos" });
            defaultCurrencyList.Add(new Currency() { Code = "EUR", Name = "Euro" });
            foreach (var dtl in defaultCurrencyList)
                context.Currencies.Add(dtl);



            base.Seed(context);
        }

    }
}
