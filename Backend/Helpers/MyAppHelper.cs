using System;
using System.Linq;
using Backend.Models;
using Domain;

namespace Backend.Helpers
{
    public class MyAppHelper
    {
        private static readonly ApplicationDbContext UserContext = new ApplicationDbContext();
        private static readonly DataContext Db = new DataContext();
        public static int GenerateRecord(int authorId, int other = 0)
        {
            try
            {
                int maxAge ;
                switch (other)
                {
                    case 1:
                        maxAge = Db.Analyticals.Where(u => u.Patient.Person.AuthorId == authorId).Max(p => p.RefNumber);
                        break;
                    case 2:
                        maxAge = Db.Customers.Where(u => u.Person.AuthorId == authorId).Max(p => p.Code);
                        break;
                    default:
                        maxAge = Db.Patients.Where(u => u.Person.AuthorId == authorId).Max(p => p.Record);
                        break;
                }

                return maxAge + 1;
            }
            catch (Exception)
            {
                return 1;
            }

        }
    }
}