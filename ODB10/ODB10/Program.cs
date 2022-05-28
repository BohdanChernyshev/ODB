using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;

namespace Unit10App
{

    class Program
    {
        private static void GetFiles()
        {
            List<Image> images = new List<Image>();
            string SQL = "SELECT * FROM Files";

            using (var connection = new SQLiteConnection("Data Source=filesdata.db"))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(SQL, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            int id = reader.GetInt32(0);
                            string filename = reader.GetString(1);
                            string title = reader.GetString(2);
                            byte[] data = (byte[])reader.GetValue(3);

                            Image image = new Image(id, filename, title, data);
                            images.Add(image);
                        }
                    }
                    Console.WriteLine($"Считано объектов: {images.Count}");
                }

                // для примера сохраним первый файл из списка в папку приложения
                if (images.Count > 0)
                {
                    using (FileStream fs = new FileStream(images[0].FileName, FileMode.OpenOrCreate))
                    {
                        fs.Write(images[0].Data, 0, images[0].Data.Length);
                        Console.WriteLine($"Файл {images[0].Title} сохранен");
                    }
                }
            }
        }
        public class Image
        {

            public Image(int id, string filename, string title, byte[] data)
            {
                Id = id;
                FileName = filename;
                Title = title;
                Data = data;
            }
            public int Id { get; private set; }
            public string FileName { get; private set; }
            public string Title { get; private set; }
            public byte[] Data { get; private set; }
        }
        private static void SaveFile(string filename, string title)
        {
            // сначала считываем файл из файловой системы
            // получаем короткое имя файла для сохранения в бд
            string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // forest.jpg

            // массив для хранения бинарных данных файла
            byte[] imageData;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            using (var connection = new SQLiteConnection("Data Source=filesdata.db"))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Files (Title, FileName, ImageData)
                                        VALUES (@FileName, @Title, @ImageData)";
                command.Parameters.Add(new SQLiteParameter("@FileName", shortFileName));
                command.Parameters.Add(new SQLiteParameter("@Title", title));
                command.Parameters.Add(new SQLiteParameter("@ImageData", imageData));
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
        }
        static void Main(string[] args)
        {
            //create table
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand();
            //    command.Connection = connection;
            //    command.CommandText = "CREATE TABLE Users(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Age INTEGER NOT NULL)";
            //    command.ExecuteNonQuery();

            //    Console.WriteLine("Таблица Users создана");
            //}
            //Console.Read();

            //Insert
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand();
            //    command.Connection = connection;
            //    command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
            //    int number = command.ExecuteNonQuery();

            //    Console.WriteLine($"В таблицу Users добавлено объектов: {number}");
            //}
            //Console.Read();
            //string SQLExpression = "INSERT INTO Users (Name, Age) VALUES ('Alice', 32), ('Bob', 28)";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);

            //    int number = command.ExecuteNonQuery();

            //    Console.WriteLine($"В таблицу Users добавлено объектов: {number}");
            //}
            //Console.Read();

            //update
            //string SQLExpression = "UPDATE Users SET Age=20 WHERE Name='Tom'";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);

            //    int number = command.ExecuteNonQuery();

            //    Console.WriteLine($"Обновлено объектов: {number}");
            //}
            //Console.Read();

            //delete
            // string SQLExpression = "DELETE FROM Users WHERE Name='Tom'";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);

            //    int number = command.ExecuteNonQuery();

            //    Console.WriteLine($"Удалено объектов: {number}");
            //}
            //Console.Read();


            //Console.WriteLine("Введите имя:");
            //string name = Console.ReadLine();

            //Console.WriteLine("Введите возраст:");
            //int age = Int32.Parse(Console.ReadLine());

            //string SQLExpression = $"INSERT INTO Users (Name, Age) VALUES ('{name}', {age})";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    // добавление
            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine($"Добавлено объектов: {number}");

            //    // обновление ранее добавленного объекта
            //    Console.WriteLine("Введите новое имя:");
            //    name = Console.ReadLine();
            //    SQLExpression = $"UPDATE Users SET Name='{name}' WHERE Age={age}";
            //    command.CommandText = SQLExpression;
            //    number = command.ExecuteNonQuery();
            //    Console.WriteLine($"Обновлено объектов: {number}");
            //    connection.Close();
            //}
            //Console.Read();

            //select
            //string SQLExpression = "SELECT * FROM Users";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    using (SQLiteDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows) // если есть данные
            //        {
            //            while (reader.Read())   // построчно считываем данные
            //            {
            //                var id = reader.GetValue(0);
            //                var name = reader.GetValue(1);
            //                var age = reader.GetValue(2);

            //                Console.WriteLine($"{id} \t {name} \t {age}");
            //            }
            //        }
            //    }
            //}
            //Console.Read();

            //typization
            //    string SQLExpression = "SELECT * FROM Users";
            //    using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //    {
            //        connection.Open();
            //        SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    using (SQLiteDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows) // если есть данные
            //        {
            //            while (reader.Read())   // построчно считываем данные
            //            {
            //                int id = reader.GetInt32(0);
            //                String name = reader.GetString(1);
            //                int age = reader.GetInt32(2);

            //                Console.WriteLine($"{id} \t {name} \t {age}");
            //            }
            //        }
            //    }
            //}
            //Console.Read();

            //parametrization
            //int userage = 28;
            //string username = "Dan";
            //// выражение SQL для добавления данных
            //string SQLExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();
            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    // создаем параметр для имени
            //    SQLiteParameter nameParam = new SQLiteParameter("@name", username);
            //    // добавляем параметр к команде
            //    command.Parameters.Add(nameParam);
            //    // создаем параметр для возраста
            //    SQLiteParameter ageParam = new SQLiteParameter("@age", userage);
            //    // добавляем параметр к команде
            //    command.Parameters.Add(ageParam);
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine($"Добавлено объектов: {number}");
            //    // вывод данных
            //    command.CommandText = "SELECT * FROM Users";
            //    using (SQLiteDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows) // если есть данные
            //        {
            //            while (reader.Read())   // построчно считываем данные
            //            {
            //                int id = reader.GetInt32(0);
            //                string name = reader.GetString(1);
            //                int age = reader.GetInt32(2);
            //                Console.WriteLine($"{id} \t {name} \t {age}");
            //            }
            //        }
            //    }
            //}
            //Console.Read();

            //scalar
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand();
            //    command.Connection = connection;
            //    command.CommandText = @"INSERT INTO Users (Name, Age) 
            //                            VALUES ('Sam', 45);
            //                            SELECT last_insert_rowid();";
            //    object id = command.ExecuteScalar();

            //    Console.WriteLine($"Идентификатор добавленного объекта {id}");
            //}
            //Console.Read();

            //scalar2
            //using (var connection = new SQLiteConnection("Data Source=SQLitedata.db"))
            //{
            //    connection.Open();

            //    string SQLExpression = "SELECT COUNT(*) FROM Users";
            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    object count = command.ExecuteScalar();

            //    command.CommandText = "SELECT MIN(Age) FROM Users";
            //    object minAge = command.ExecuteScalar();

            //    command.CommandText = "SELECT AVG(Age) FROM Users";
            //    object avgAge = command.ExecuteScalar();

            //    Console.WriteLine($"В таблице {count} объектa(ов)");
            //    Console.WriteLine($"Минимальный возраст: {minAge}");
            //    Console.WriteLine($"Средний возраст: {avgAge}");
            //}
            //Console.Read();

            //
            //string SQLExpression = @"CREATE TABLE Files 
            //                    (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //                     Title TEXT NOT NULL, 
            //                     FileName TEXT NOT NULL,
            //                     ImageData BLOB)";
            //using (var connection = new SQLiteConnection("Data Source=filesdata.db"))
            //{
            //    connection.Open();

            //    SQLiteCommand command = new SQLiteCommand(SQLExpression, connection);
            //    command.ExecuteNonQuery();
            //    Console.WriteLine("Таблица Files  создана");
            //}
            //Console.Read();

            //// метод в качестве параметров получает полный путь к файлу и его название
            //SaveFile("D:\\forest.jpg", "Лес");
            //Console.Read();

            GetFiles();
            Console.Read();
        }
    }
}