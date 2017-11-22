using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Collections;
using System.Linq;

namespace ConsoleApp_TestDB_Dapper
{
    class Repository
    {
        string currentdirectory;
        string connectionString;
 
        public Repository()
        {
            currentdirectory = Environment.CurrentDirectory;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + currentdirectory + @"\BotDatabase.mdf;Integrated Security=True;Connect Timeout=30";//@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BotDatabase.mdf;Integrated Security=True";
        }

        public List<UserData> GetAllUsers()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<UserData>("SELECT * FROM UserData").ToList();
            }
        }

        public UserData GetUserById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<UserData>("SELECT * FROM UserData WHERE Id = @id", new { id }).First();
            }
        }

        public void AddUser(UserData user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO UserData (Id, Login, Password, Name, Surname, Birth) VALUES(@Id, @Login, @Password, @Name, @Surname, @Birth)";
                db.Execute(sqlQuery, user);
            }
        }

        public void UpdateUser(UserData user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE UserData SET Login = @Login, Password = @Password, Name = @Name, Surname = @Surname,  Birth = @Birth WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void DeleteUser(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM UserData WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<Bound> GetAllBounds()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Bound>("SELECT * FROM Bound").ToList();
            }
        }

        public List<Bound> GetAllBoundsOfUser(int user_id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Bound>("SELECT * FROM Bound WHERE User_Id = @user_id", new { user_id}).ToList();
            }
        }

        public Bound GetBoundById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Bound>("SELECT * FROM Bound WHERE Id = @id", new { id }).First();
            }
        }

        public void AddBound(Bound bound)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Bound (Id, User_Id, Instagram, Telegram) VALUES(@Id, @User_Id, @Instagram, @Telegram)";
                db.Execute(sqlQuery, bound);
            }
        }

        public void UpdateBound(Bound bound)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Bound SET User_Id = @User_Id, Instagram = @Instagram, Telegram = @Telegram WHERE Id = @Id";
                db.Execute(sqlQuery, bound);
            }
        }

        public void DeleteBound(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Bound WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<BoundFilter> GetAllFilters()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BoundFilter>("SELECT * FROM Filter").ToList();
            }
        }

        public List<BoundFilter> GetAllFiltersOfBound(int bound_id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BoundFilter>("SELECT * FROM Filter WHERE Bound_Id = @bound_id", new { bound_id }).ToList();
            }
        }

        public void AddFilter(BoundFilter filter)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Filter (Id, Bound_Id, Filter) VALUES(@Id, @Bound_Id, @Filter)";
                db.Execute(sqlQuery, filter);
            }
        }


        public void DeleteFilter(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Filter WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
