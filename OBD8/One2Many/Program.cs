using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace One2Many
{
    class Program
    {
        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public int Age { get; set; }

            public int? TeamId { get; set; }
            public Team Team { get; set; }
        }
        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; } // название команды

            public ICollection<Player> Players { get; set; }
            public Team()
            {
                Players = new List<Player>();
            }
           
        }
        class SoccerContext : DbContext
        {
            public SoccerContext()
            //    : base("DefaultConnection")
            { }

            public DbSet<Player> Players { get; set; }
            public DbSet<Team> Teams { get; set; }
        }
        static void Main(string[] args)
        {
            using (SoccerContext db = new SoccerContext())
            {

                // db.Database.Delete();
                // создание и добавление моделей
                Team t1 = new Team { Name = "Барселона" };
                Team t2 = new Team { Name = "Реал Мадрид" };
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();
                Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий", Team = t2 };
                Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий", Team = t1 };
                Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник", Team = t1 };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();

                // вывод 
                foreach (Player pl in db.Players.Include(p => p.Team))
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }
                    Console.WriteLine();
                }

                Console.Write("\n");
                Console.ReadKey();



                t2.Name = "Реал М."; // изменим название
                db.Entry(t2).State = EntityState.Modified;
                // переведем игрока из одной команды в другую
                pl3.Team = t2;
                db.Entry(pl3).State = EntityState.Modified;
                db.SaveChanges();

                // вывод 
                foreach (Player pl in db.Players.Include(p => p.Team))
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }
                    Console.WriteLine();
                }

                Console.Write("\n");
                Console.ReadKey();

                Player pl_toDelete = db.Players.First(p => p.Name == "Роналду");
                db.Players.Remove(pl_toDelete);
                // удаление команды     
                Team t_toDelete = db.Teams.First();
                db.Teams.Remove(t_toDelete);
                db.SaveChanges();

                // вывод 
                foreach (Player pl in db.Players.Include(p => p.Team))
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }
                    Console.WriteLine();
                }
                db.Database.Delete();
            }
            Console.Write("\n");
            Console.ReadKey();

        }
    }
}
