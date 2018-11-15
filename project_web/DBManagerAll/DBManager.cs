using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;

namespace LUG3WebApi.DBManagerAll 
{
    public class DBManager : IDBManager 
    {
        private string connStr = "Server=(localdb)\\MSSQLLocalDB; Database=LU-G3; Integrated Security = true;";
        public void Delete(int IdPostulant)
        {
            var sql = "UPDATE Postulant SET IdState = 8 WHERE Id = @Id";

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, new { @Id = IdPostulant});
                conn.Close();
            }
        }

        public Postulant GetPostulant(int IdPostulant)
        {
            var sql = "SELECT * from Postulant WHERE Id = @Id";

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                Postulant postulant = conn.Query<Postulant>(sql, new{ @Id = IdPostulant }).FirstOrDefault();
                conn.Close();
                return postulant;
            }
        }

        public IEnumerable<PostulantBasic> GetPostulantAll()
        {
            var sql = "SELECT Id, Name, LastName, IdState FROM dbo.Postulant";

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                IEnumerable<PostulantBasic> postulants = conn.Query<PostulantBasic>(sql);
                conn.Close();

                return postulants;
            }
        }

        public void InsertStudies(Studies studies)
        {
            var sql = "INSERT INTO Studies (IdStudy, Institution, Career, IdPostulant, Year, IdStudiesState) VALUES (@IdStudy, @Institution, @Career, @IdPostulant, @Year, @IdStudiesState)";

            using (var conn = new SqlConnection(connStr)){
                conn.Open();
                conn.Execute(sql,  studies);
                conn.Close();
            }
        }

        public void InsertAttached(Attached attached, int IdPostulant_)
        {
            var sql = "INSERT INTO Attached (Link, IdTypeAttached) VALUES (@Link, @IdTypeAttached)";
            var sql2 = "SELECT TOP 1 * FROM Attached ORDER BY Id DESC";
            var sql3 = "INSERT INTO PostulantAttached (IdPostulant, IdAttached) VALUES (@IdPostulant, @IdAttached)";
            int IdAttached_ = 0;
            using (var conn = new SqlConnection(connStr)){
                conn.Open();
                conn.Execute(sql,  attached);
                IdAttached_ = (int) conn.Query(sql2).FirstOrDefault().Id;
                conn.Execute(sql3, new {IdPostulant = IdPostulant_, IdAttached = IdAttached_} );
                conn.Close();
            }
        }
        public int Insert(Postulant postulant)
        {
            var sql = "INSERT INTO Postulant (Name, Lastname, Dni, Email, Birthday, PhoneHome, PhoneMobile, Github, Linkedin, IdState) VALUES (@Name, @Lastname, @Dni, @Email, @Birthday, @PhoneHome, @PhoneMobile, @Github, @Linkedin, @IdState)";
            var sql2 = "SELECT * FROM Postulant WHERE Dni = @Dni";
            int Id = 0;
            
            using (var conn = new SqlConnection(connStr)){
                conn.Open();
                conn.Execute(sql,  postulant);
                
                string dni = postulant.Dni;

                Id = (int) conn.Query<Postulant>(sql2, param: (object) new { @Dni = dni }).FirstOrDefault().Id;
                conn.Close();
            }

            return Id;
        }
        public Postulant Update(Postulant postulant)
        {
            var sql = "UPDATE Postulant SET Name = @Name, Lastname = @Lastname, Dni = @Dni, Email = @Email, Birthday = @Birthday, PhoneHome = @PhoneHome, PhoneMobile = @PhoneMobile, GitHub = @GitHub, LinkedIn = @LinkedIn WHERE Id = @Id";
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, postulant);
                conn.Close();
            }

            return this.GetPostulant(postulant.Id);
        }

        public PostulantInfo GetPostulantInfo(int IdPostulant){
            PostulantInfo postinf;

            var sql = "SELECT Id, Name, LastName, IdState from Postulant WHERE Id = @Id";
            var sql2 = "SELECT TOP 1 Date, Time FROM Meeting WHERE IdPostulant = 22 ORDER BY IdInstance DESC";
            
            try {
                using(var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    postinf = conn.Query<PostulantInfo>(sql, new{ @Id = IdPostulant }).FirstOrDefault();

                    if (postinf.IdState == 2 || postinf.IdState == 4 || postinf.IdState == 6 ){
                        postinf.Meeting = true;
                        DateNTime datetime = conn.Query<DateNTime>(sql2, new{ @Id = IdPostulant }).FirstOrDefault();
                        postinf.DateTime = Convert.ToDateTime(datetime.Date + datetime.Time);
                    } else {
                        postinf.Meeting = false;
                        postinf.DateTime = null;
                    }               
                    conn.Close();
                }
            } catch (Exception){
                postinf = null;
            }
            return postinf;
        }
    }
}