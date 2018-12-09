using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LUG3WebApi.Added;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Http;

namespace LUG3WebApi.DBManagerAll 
{
    public class DBManager : IDBManager 
    {
        private AddedFunctions fnc = new AddedFunctions();
        private string connStr = "Server=(localdb)\\MSSQLLocalDB; Database=LU-G3; Integrated Security = true;";

        //POSTULANT
        public int InsertPostulant(Postulant postulant)
        {
            var sql = "INSERT INTO Postulant (Name, Lastname, Dni, Email, Birthday, PhoneHome, PhoneMobile, Github, Linkedin, IdState, Iteration, Country) VALUES (@Name, @Lastname, @Dni, @Email, @Birthday, @PhoneHome, @PhoneMobile, @Github, @Linkedin, @IdState, @Iteration, @Country)";
            var sql2 = "SELECT * FROM Postulant WHERE Dni = @Dni";
            int Id = 0;
            
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql,  postulant);
                
                string dni = postulant.Dni;
                Id = (int) conn.Query<Postulant>(sql2, param: (object) new { @Dni = dni }).FirstOrDefault().Id;
                conn.Close();
            }
            return Id;
        }
        public Postulant GetPostulant(int IdPostulant)
        {
            var sql = "SELECT * from Postulant WHERE Id = @Id AND Country = 1";

            Postulant postulant;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                postulant = conn.Query<Postulant>(sql, new{ @Id = IdPostulant }).FirstOrDefault();
                conn.Close();
            }
            return postulant;
        }
        public IEnumerable<PostulantBasic> GetPostulantFilter(int IdState)
        {
            var sql = "SELECT Id, Name, LastName, IdState, Iteration FROM dbo.Postulant WHERE IdState = @IdState";

            IEnumerable<PostulantBasic> postulants;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                postulants = conn.Query<PostulantBasic>(sql, new {@IdState = IdState});
                conn.Close();
            }
            return postulants;
        }
        public IEnumerable<PostulantBasic> GetPostulantAll()
        {
            var sql = "SELECT Id, Name, LastName, IdState, Iteration FROM dbo.Postulant WHERE Country = 1";
            IEnumerable<PostulantBasic> postulants;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                postulants = conn.Query<PostulantBasic>(sql);
                conn.Close();
            }
            return postulants;
        }
        public Postulant UpdatePostulant(Postulant postulant)
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
        public void DeletePostulant(int IdPostulant)
        {
            var sql = "UPDATE Postulant SET IdState = 8 WHERE Id = @Id";

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, new { @Id = IdPostulant});
                conn.Close();
            }
        }
        // method GET vista Postulant
        public PostulantInfo GetPostulantInfo(int IdPostulant)
        {
            PostulantInfo postinf;

            var sql = "SELECT Id, Name, LastName, IdState from Postulant WHERE Id = @Id";
            var sql2 = "SELECT TOP 1 * FROM Meeting WHERE IdPostulant = @Id ORDER BY IdInstance DESC";

            // try
            // {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                postinf = conn.Query<PostulantInfo>(sql, new { @Id = IdPostulant }).FirstOrDefault();

                if (postinf.IdState == 2 || postinf.IdState == 4 || postinf.IdState == 6)
                {
                    postinf.Meeting = true;
                    postinf.DateTime = conn.Query<Meeting>(sql2, new { @Id = IdPostulant }).FirstOrDefault().DateTime;

                }
                else
                {
                    postinf.Meeting = false;
                    postinf.DateTime = null;
                }
                conn.Close();
            }
            // }
            // catch (Exception)
            // {
            //     postinf = null;
            // }
            return postinf;
        }
        //ADDRESS
        public void InsertAddress(Addressget addressget)
        {
            var sql = "SELECT * FROM Location WHERE Location = @Location";
            var sql2 = "INSERT INTO Location (Location) VALUES (@NameLocation)";
            var sql3 = "INSERT INTO Address (Home, Number, PostalCode, IdLocation) VALUES (@Home, @Number, @PostalCode, @IdLocation)";
            var sql4 = "SELECT TOP 1 * FROM Address ORDER BY Id DESC";
            var sql5 = "UPDATE Postulant SET IdAddress = @IdAddress WHERE Id = @Id";

            int? IdLocation = 0;
            int? IdAddress = 0;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                IdLocation = ThereisLocation(addressget.Location);

                if (IdLocation != null && IdLocation != 0) 
                {
                    Address address = fnc.createAddress(addressget, IdLocation);
                    conn.Execute(sql3, address);
                    IdAddress = (int) conn.Query(sql4).FirstOrDefault().Id;
                    conn.Execute(sql5, new {@IdAddress = IdAddress, @Id = addressget.IdPostulant});
                } else 
                {
                    conn.Execute (sql2, new {@NameLocation = addressget.Location});
                    IdLocation = (int) conn.Query(sql, new {@Location = addressget.Location}).FirstOrDefault().Id;
                    Address address =fnc.createAddress(addressget, IdLocation);
                    conn.Execute(sql3, address);
                    IdAddress = (int) conn.Query(sql4).FirstOrDefault().Id;
                    conn.Execute(sql5, new {@IdAddress = IdAddress, @Id = addressget.IdPostulant});
                }
                conn.Close();
            }
        }

        public Addressget getAddress(int IdPostulant)
        {
            var sql = "SELECT a.Id, a.Home, a.Number, a.Postalcode, l.Location FROM Postulant p INNER JOIN Address a ON (p.IdAddress = a.Id) INNER JOIN Location l ON (a.IdLocation = l.Id) WHERE p.Id = @IdPostulant";
            Addressget address;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                address = conn.Query<Addressget> (sql, new {@IdPostulant = IdPostulant}).FirstOrDefault();
                conn.Close();
            }
            address.IdPostulant = IdPostulant;
            return address;
        }

        public Addressget UpdateAddress (Addressget addressget, int IdPostulant){
            
            var sql = "SELECT * FROM Location Where Location = @Location";
            var sql2 = "INSERT INTO Location (Location) VALUES (@NameLocation)";
            var sql3 = "UPDATE Address SET Home = @Home, Number = @Number, PostalCode = @PostalCode, IdLocation = @IdLocation WHERE Id = @Id";
            var sql4 = "SELECT * FROM Postulant WHERE Id = @Id";
            
            int? IdLocation = 0;
            int? IdAddress = 0;

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                IdLocation = ThereisLocation(addressget.Location);

                if (IdLocation != null && IdLocation != 0) 
                {
                    if (addressget.Id != null && addressget.Id != 0){
                        Address address = fnc.createAddress(addressget, IdLocation);
                        conn.Execute(sql3, address);
                    } else {
                        IdAddress = (int) conn.Query(sql4, new {@Id = IdPostulant}).FirstOrDefault().IdAddress;
                        Address address = fnc.createAddress(addressget, IdLocation);
                        address.Id = IdAddress;
                        conn.Execute(sql3, address);
                    }
                    
                } else {
                    conn.Execute (sql2, new { @NameLocation = addressget.Location});
                    IdLocation = (int) conn.Query(sql).FirstOrDefault().Id;
                    if (addressget.Id != null && addressget.Id != 0){
                        Address address =  fnc.createAddress(addressget, IdLocation);
                        conn.Execute(sql3, address);
                    } else {
                        IdAddress = (int) conn.Query(sql4, new {@Id = IdPostulant}).FirstOrDefault().IdAddress;
                        Address address =  fnc.createAddress(addressget, IdLocation);
                        address.Id = IdAddress;
                        conn.Execute(sql3, address);
                    }
                }
                conn.Close();
            }
            return getAddress(IdPostulant);
        }  

        private int ThereisLocation(string Location){
            var sql = "SELECT * FROM Location";

            IEnumerable <Locationn> locations;
            int IdLocation = 0;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                locations = conn.Query<Locationn>(sql);
                conn.Close();
            }
            foreach (Locationn loc in locations){
                if (loc.Location == Location) {
                    IdLocation = loc.Id;
                }
            }
            return IdLocation;
        }
        //STUDIES
        public void InsertStudies(Studies studies)
        {
            var sql = "INSERT INTO Studies (IdStudy, Institution, Career, IdPostulant, Year, IdStudiesState) VALUES (@IdStudy, @Institution, @Career, @IdPostulant, @Year, @IdStudiesState)";
            
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql,  studies);
                conn.Close();
            }
        }
        public IEnumerable<Studies> GetStudies(int IdPostulant)
        {
            var sql = "SELECT * from Studies WHERE IdPostulant = @IdPostulant";

            IEnumerable <Studies> studies;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                studies = conn.Query<Studies>(sql, new{ @IdPostulant = IdPostulant });
                conn.Close();
            }
            return studies;
        }
        public IEnumerable<Studies> UpdateStudies(Studies studies)
        {
            var sql = "UPDATE Studies SET IdStudy = @IdStudy, Institution = @Institution, Career = @Career, IdStudiesState = @IdStudiesState Where Id = @Id";
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, studies);
                conn.Close();
            }

            return this.GetStudies(studies.IdPostulant);
        }

        //ATTACHED
        public void InsertAttached(Attached attached, int IdPostulant_)
        {
            var sql = "INSERT INTO Attached (Name, Link, IdTypeAttached) VALUES (@Name, @Link, @IdTypeAttached)";
            var sql2 = "SELECT TOP 1 * FROM Attached ORDER BY Id DESC";
            var sql3 = "INSERT INTO PostulantAttached (IdPostulant, IdAttached) VALUES (@IdPostulant, @IdAttached)";
            int IdAttached_ = 0;
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql,  attached);
                IdAttached_ = (int) conn.Query(sql2).FirstOrDefault().Id;
                conn.Execute(sql3, new {IdPostulant = IdPostulant_, IdAttached = IdAttached_} );
                conn.Close();
            }
        }

        public IEnumerable<Attachedget> GetAttached(int IdPostulant)
        {
            var sql = "SELECT Id, Name, IdTypeAttached FROM Attached a INNER JOIN PostulantAttached pa ON (pa.IdAttached = a.Id) WHERE pa.IdPostulant = @IdPostulant";

            IEnumerable <Attachedget> attachedget;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                attachedget = conn.Query<Attachedget>(sql, new{ @IdPostulant = IdPostulant});
                conn.Close();
            }
            foreach (Attachedget aux in attachedget){
                aux.IdPostulant = IdPostulant;
            }
            return attachedget;
        }
        
        public Fileget GetFile (int IdPostulant, string Name){
            var sql = "SELECT Name, Link FROM Attached a INNER JOIN PostulantAttached pa ON (pa.IdAttached = a.Id) WHERE pa.IdPostulant = @IdPostulant AND a.Name = @Name ";

            Fileget file;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                file = conn.Query<Fileget>(sql, new{ @IdPostulant = IdPostulant, @Name = Name}).FirstOrDefault();
                conn.Close();
            }
            return file;
        }

        public IEnumerable<Attachedget> UpdateAttached(Attached attached, int IdPostulant_)
        {
            var sql = "UPDATE Attached SET Name = @Name, Link = @Link, IdTypeAttached = @IdTypeAttached WHERE  Id = @Id";
        
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql,  attached);
                conn.Close();
            }
            return this.GetAttached(IdPostulant_);
        }

        //MEETING
        public void InsertMeeting(Meeting meeting)
        {
            var sql = "INSERT INTO Meeting (IdInstance, IdPostulant, DateTime) VALUES (@Idinstance, @IdPostulant, @DatenTime)";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql,  meeting);
                conn.Close();
            }
        }
        public IEnumerable<Meetingget> GetMeeting(int IdPostulant)
        {
            var sql = "SELECT * from Meeting WHERE IdPostulant = @IdPostulant";

            IEnumerable <Meetingget> meetingget;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                meetingget= conn.Query<Meetingget>(sql, new{ @IdPostulant = IdPostulant });
                conn.Close();
            }
            return meetingget;
        }
        public IEnumerable<Meetingget> UpdateMeeting(Meeting meeting)
        {
            var sql = "UPDATE Meeting SET DateTime = @DateTime WHERE Id = @Id AND IdPostulant = @IdPostulant";
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, meeting);
                conn.Close();
            }

            return this.GetMeeting(meeting.IdPostulant);
        }
        //STATE
        public int GetState(int IdPostulant)
        {
            var sql = "SELECT * FROM Postulant WHERE Id = @Id";
            int IdState = 0;
            
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                IdState = (int) conn.Query<Postulant>(sql, param: (object) new { @Id = IdPostulant}).FirstOrDefault().IdState;
                conn.Close();
            }
            return IdState;
        }   

        
        public IEnumerable <StateC> GetStateById(int IdPostulant)
        {
            var sql = "SELECT st.Id, st.State FROM State st inner join Postulant P on St.Id = P.IdState  where P.Id = @Id";
            IEnumerable <StateC> state;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                state = conn.Query<StateC>(sql, new{ @Id = IdPostulant });
                conn.Close();
            }
            return state;
            
        }
        public void UpdateState(int IdPostulant, int IdState)
        {
            var sql = "UPDATE Postulant SET IdState = @IdState WHERE Id = @Id";

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, new { @IdState = IdState, @Id = IdPostulant});
                conn.Close();
            }
        }
        //GET FORM
        public byte[] GetForm(int IdPostulant)
        {
            var sql = "SELECT a.Link FROM Attached a INNER JOIN PostulantAttached pa ON a.Id = pa.IdAttached WHERE pa.IdPostulant = @IdPostulant";
            byte [] Link;
            
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();

                Link = conn.Query<Attached> (sql, new {@IdPostulant = IdPostulant}).FirstOrDefault().Link;
                conn.Close();
            }
            return Link;
        }
        //Result
        public void InsertResult(Result result)
        {
            var sql = "INSERT INTO Result (Name, Form, IdMeeting, Observation, OK) VALUES (@Name, @Form, @IdMeeting, @Observation, @OK)";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, result);
                conn.Close();
            }
        }
        public IEnumerable<Resultget> GetResult(int IdPostulant)
        {
            var sql = "SELECT r.Id, m.IdInstance, r.IdMeeting, r.Observation, r.OK FROM Result r INNER JOIN Meeting m ON (m.Id = r.IdMeeting) WHERE m.IdPostulant = @IdPostulant";

            IEnumerable <Resultget> result;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                result = conn.Query<Resultget>(sql, new{ @IdPostulant = IdPostulant });
                conn.Close();
            }
            return result;
        }

        public FilegetResult GetFileResult(int IdResult)
        {
            var sql = "SELECT Name, Form FROM Result WHERE Id = @Id";

            FilegetResult file;
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                file = conn.Query<FilegetResult>(sql, new{ @Id = IdResult}).FirstOrDefault();
                conn.Close();
            }
            return file;
        }

        public IEnumerable<Resultget> UpdateResult(Resultget result, int IdPostulant)
        {
            var sql = "UPDATE Result SET Observation = @Observation, OK = @OK WHERE Id = @Id";
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, result);
                conn.Close();
            }
            return this.GetResult(IdPostulant);
        }

        public void UpdateFileResult(Fileget file, int IdResult)
        {
            var sql = "UPDATE Result SET Name = @Name, Form = @Form WHERE Id = @Id";
            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, new {@Name = file.Name, @Form = file.Link, @Id = IdResult});
                conn.Close();
            }
        }
    }
}