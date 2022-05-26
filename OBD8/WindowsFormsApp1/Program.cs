using System;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsFormsApp1
{

    class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

    }
    class SoccerContext : DbContext
    {
        public SoccerContext()
        { }

        public DbSet<Player> Players { get; set; }
       // public DbSet<Team> Teams { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}
