using System;
using System.Linq;
using System.Data.Entity;
namespace OBD8
{
   
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
    public class PhoneContext : DbContext
    {
        

        public PhoneContext() : base("DefaultConnect")
        { }

        public DbSet<Phone> Phones { get; set; }
    }
    class Program
    {
        static public void PrintBase()
        {
            using (PhoneContext db = new PhoneContext())
            {


                var phones = db.Phones.ToList();
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1} - {2}", p.Id, p.Name, p.Price);
            }
            Console.Write("\n");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                Phone p3 = new Phone { Name = "Samsung Galaxy S7", Price = 20000 };
                Phone p2 = new Phone { Name = "iPhone 7", Price = 28000 };

                // добавление
                db.Phones.Add(p3);
                db.Phones.Add(p2);
                db.SaveChanges();   // сохранение изменений

                var phones = db.Phones.ToList();
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1} - {2}", p.Id, p.Name, p.Price);
            }
            Console.Write("\n");
            Console.ReadKey();

            using (PhoneContext db = new PhoneContext())
            {
                // получаем первый объект
                Phone p1 = db.Phones.FirstOrDefault();

                p1.Price = 30000;
                db.SaveChanges();   // сохраняем изменения

                var phones = db.Phones.ToList();
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1} - {2}", p.Id, p.Name, p.Price);
            }
            Console.Write("\n");
            Console.ReadKey();

            Phone p4;
            using (PhoneContext db = new PhoneContext())
            {
                p4 = db.Phones.FirstOrDefault();
            }
            using (PhoneContext db = new PhoneContext())
            {
                if (p4 != null)
                {
                    p4.Price = 60000;
                    db.Entry(p4).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            PrintBase();


            using (PhoneContext db = new PhoneContext())
            {
                Phone p1 = db.Phones.FirstOrDefault();
                if (p1 != null)
                {
                    db.Phones.Remove(p1);
                    db.SaveChanges();
                }
                //if (p1 != null)
                //{
                //    db.Entry(p1).State = EntityState.Deleted;
                //    db.SaveChanges();
                //}
            }
            PrintBase();

            Phone p5;
            using (PhoneContext db = new PhoneContext())
            {
                p5 = db.Phones.FirstOrDefault();
            }
            // редактирование
            using (PhoneContext db = new PhoneContext())
            {
                if (p5 != null)
                {
                    db.Phones.Attach(p5);
                    p5.Price = 999;
                    db.SaveChanges();
                }
            }
            PrintBase();
            // удаление
            using (PhoneContext db = new PhoneContext())
            {
                if (p5 != null)
                {
                    db.Phones.Attach(p5);
                    db.Phones.Remove(p5);
                    db.SaveChanges();
                }
            }
            PrintBase();
            using (PhoneContext db=new PhoneContext())
            {
                db.Database.Delete();
            }
        }

    }
}
