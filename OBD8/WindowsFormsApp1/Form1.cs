using System;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsFormsApp1
{
            public partial class Form1 : Form
        {
            SoccerContext db;
            public Form1()
            {
                InitializeComponent();

                db = new SoccerContext();
                db.Players.Load();

                dataGridView1.DataSource = db.Players.Local.ToBindingList();
            }
            // добавление
        private void AddB_Click(object sender, EventArgs e)
        {
          
                PlayerForm plForm = new PlayerForm();
                DialogResult result = plForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                Player player = new Player();
                player.Age = (int)plForm.Pl_Age.Value;
                player.Name = plForm.Pl_Name.Text;
                player.Position = plForm.Pl_Position.SelectedItem.ToString();

                db.Players.Add(player);
                db.SaveChanges();

                MessageBox.Show("Новый объект добавлен");
            
        }
        // редактирование

        private void UpdateB_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Player player = db.Players.Find(id);

                PlayerForm plForm = new PlayerForm();

                plForm.Pl_Age.Value = player.Age;
                plForm.Pl_Position.SelectedItem = player.Position;
                plForm.Pl_Name.Text = player.Name;

                DialogResult result = plForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                player.Age = (int)plForm.Pl_Age.Value;
                player.Name = plForm.Pl_Name.Text;
                player.Position = plForm.Pl_Position.SelectedItem.ToString();

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");

            }
        }

        // удаление
            private void DeleteB_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Player player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }

        }
    }
    }

