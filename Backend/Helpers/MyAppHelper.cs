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
                        maxAge = 0;
                        break;
                    case 2:
                        maxAge = 0;
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