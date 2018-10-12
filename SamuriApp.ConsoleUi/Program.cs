using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuriApp.Data;
using SamuriApp.Domain;

namespace SamuriApp.ConsoleUi
{
    public class Program
    {
        public static void Main()
        {
            InsertSamuris();
            //InsertMultipleSamuris();
            //QuerySamuris();
            //RetrieveAndUpdateSamuri();
            //RetrieveAndUpdateMultipleSamuri();
            //QueryUsingRawSql();
            //UpdateUsingSqlCommand();
            
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void InsertSamuris()
        {
            Samuri samuri = new Samuri {Name = "Frank"};

            using (SamuriDbContext context = new SamuriDbContext())
            {
                context.Samuris.Add(samuri);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamuris()
        {
            Samuri samuri1 = new Samuri { Name = "Peter" };
            Samuri samuri2 = new Samuri { Name = "Paul" };
            List<Samuri> samuriList = new List<Samuri> {samuri1, samuri2};

            using (SamuriDbContext context = new SamuriDbContext())
            {
                context.Samuris.AddRange(samuriList);
                context.SaveChanges();
            }
        }

        private static void QuerySamuris()
        {
            using (SamuriDbContext context = new SamuriDbContext())
            {
                List<Samuri> samuris = context.Samuris.Where(s => s.Name.StartsWith("P")).ToList();

                foreach (var samuri in samuris)
                {
                    Console.WriteLine(samuri.Name);
                }
            }
        }

        private static void RetrieveAndUpdateSamuri()
        {
            using (SamuriDbContext context = new SamuriDbContext())
            {
                Samuri samuri = context.Samuris.FirstOrDefault();

                if (samuri == null)
                {
                    return;
                }

                samuri.Name += "San";
                context.SaveChanges();
            }
        }

        private static void RetrieveAndUpdateMultipleSamuri()
        {
            using (SamuriDbContext context = new SamuriDbContext())
            {
                List<Samuri> samuris = context.Samuris.ToList();

                if (samuris.Count > 0)
                {
                    samuris.ForEach(s => s.Name += "San");
                    context.SaveChanges();
                }
            }
        }

        private static void QueryUsingRawSql()
        {
            using (SamuriDbContext context = new SamuriDbContext())
            {
                List<Samuri> samuris = context.Samuris.FromSql("Select * from Samuris").ToList();

                if (samuris.Count <= 0)
                {
                    return;
                }

                foreach (var samuri in samuris)
                {
                    Console.WriteLine(samuri.Name);
                }
            }
        }

        private static void UpdateUsingSqlCommand()
        {
            using (SamuriDbContext context = new SamuriDbContext())
            {
                int count = context.Database.ExecuteSqlCommand("Update Samuris set Name=REPLACE(Name, 'San', 'Nan')");
                Console.WriteLine($"count = {count}");
            }
        }
    }
}
