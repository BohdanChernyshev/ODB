using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ODB9
{
    public class DiscountPhone
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class PhoneContext : DbContext
    {
        public PhoneContext()
        {
            this.Database.Connection.ConnectionString = "Data Source=(localdb)\\v11.0;Initial Catalog=phonesdb;Integrated Security=True";
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public Company()
        {
            Phones = new List<Phone>();
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
           

            using (PhoneContext db = new PhoneContext())
            {
                Console.WriteLine(db.Database.Connection.ConnectionString);
            }
            Console.ReadKey();
            Console.WriteLine("\nCompanies");
            using (PhoneContext db = new PhoneContext())
            {
                var comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
                foreach (var company in comps)
                    Console.WriteLine(company.Name);
            }
            Console.ReadKey();
            Console.WriteLine("\n");

            using (PhoneContext db = new PhoneContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%Samsung%");
                var phones = db.Database.SqlQuery<Phone>("SELECT * FROM Phones WHERE Name LIKE @name", param);
                foreach (var phone in phones)
                    Console.WriteLine(phone.Name);
            }
            Console.ReadKey();
            //using (PhoneContext db = new PhoneContext())
            //{
            //    //db.Database.Delete();
            //   // вставка
            //    //int numberOfRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO Companies (Name) VALUES ('HTC')");
            //    //// обновление
            //    //int numberOfRowUpdated = db.Database.ExecuteSqlCommand("UPDATE Companies SET Name='Nokia' WHERE Id=3");
            //    //// удаление
            //    //int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM Companies WHERE Id=3");
            //    //var comps = db.Database.SqlQuery<Company>("SELECT * FROM Companies");
            //    //foreach (var company in comps)
            //    //    Console.WriteLine(company.Name);
            //}
            //    Console.ReadKey();

            Console.WriteLine("\n");
            using (PhoneContext db = new PhoneContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@price", 26000);
                var phones = db.Database.SqlQuery<Phone>("SELECT * FROM GetPhonesByPrice (@price)", param);
                foreach (var phone in phones)
                    Console.WriteLine(phone.Name);
            }
            Console.ReadKey();
            Console.WriteLine("\n--> GetPriceWithDiscount");
            using (PhoneContext db = new PhoneContext())
            {
                // скидка - 15%
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@discount", 15);
                var phones = db.Database.SqlQuery<DiscountPhone>("SELECT * FROM GetPriceWithDiscount (@discount)", param);
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1}", p.Name, p.Price);
            }
            Console.ReadKey();
            Console.WriteLine("\n--> SP - Get Phones By Company");
            using (PhoneContext db = new PhoneContext())
            {
                var param = new System.Data.SqlClient.SqlParameter("@name", "Samsung");
                var phones = db.Database.SqlQuery<Phone>("GetPhonesByCompany @name", param);
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1}", p.Name, p.Price);
            }
            Console.ReadKey();

        }
    }
}
