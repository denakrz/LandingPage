using System;
using System.Collections.Generic;
using System.IO;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Http;

namespace LUG3WebApi.Added {

    public class AddedFunctions {
        
        public Dictionary<string, string> extension = new Dictionary<string, string>
        {
            {"txt", "text/plain"},
            {"pdf", "application/pdf"},
            {"doc", "application/vnd.ms-word"},
            {"docx", "application/vnd.ms-word"},
            {"xls", "application/vnd.ms-excel"},
            {"xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
            {"png", "image/png"},
            {"jpg", "image/jpeg"},
            {"jpeg", "image/jpeg"},
            {"gif", "image/gif"},
            {"csv", "text/csv"}
        };

        //Get Types
        public string getMimeTypes(string extensionfile)
        {
            return (extension[extensionfile]);
        }

        //CREATE
        public Postulant createPostulant(Form form)
        {
            Postulant postulant = new Postulant
            {
                Name = form.Name,
                Lastname = form.Lastname,
                Dni = form.Dni,
                Birthday = form.Birth,
                Email = form.Email,
                PhoneHome = form.PhoneHome,
                PhoneMobile = form.PhoneMobile,
                GitHub = form.GitHub,
                LinkedIn = form.LinkedIn,
                IdState = 1,
                Iteration = 1,
                Country = 1
            };
            return postulant;
        }
        public Studies createStudies(Form form, int IdPostulantDb, int IdStudyform, int IdStudiesStateform)
        {
            Studies studies = new Studies 
            {
                IdStudy = IdStudyform,
                Institution = form.Institution,
                Career = form.Career,
                IdPostulant = IdPostulantDb,
                IdStudiesState = IdStudiesStateform
            };
            return studies;
        }
        
        public Studies createStudiesget(Studiesget studyget, int IdStudyform, int IdStudiesStateform)
        {
            Studies studies = new Studies 
            {
                IdStudy = IdStudyform,
                Institution = studyget.Institution,
                Career = studyget.Career,
                IdPostulant = studyget.IdPostulant,
                Year = studyget.Year,
                IdStudiesState = IdStudiesStateform
            };
            return studies;
        }
        public Address createAddress(Addressget addressget, int? IdLocation)
        {
            Address address = new Address 
            {
                Id = addressget.Id,
                Home = addressget.Home,
                Number = addressget.Number, 
                PostalCode = addressget.PostalCode,
                IdLocation = IdLocation
            };
            return address;
        }

        public Meeting createMeeting(Meetingget met){
            
            Meeting meeting = new Meeting {
                Id = met.Id,
                IdInstance = met.IdInstance,
                IdPostulant = met.IdPostulant,   
                DateTime = Convert.ToDateTime(met.DateTime)
            };
            return meeting;
        }
        
        public Result createResult(Resultget resultget, byte[] barray, string Name)
        {  
            Result result = new Result
            {
                Form =  barray,
                Name = Name,
                IdMeeting = resultget.IdMeeting,
                Observation = resultget.Observation,
                OK = resultget.OK
            };
            return result;
        }

        //VALIDATION
        //Validation IdStudyGet
        public int validateIdStudyget(Studiesget studyget)
        {
            int IdStudyform = 0;
            if (studyget.Study == "secondary"){
                IdStudyform= 1;
            } else if (studyget.Study == "tertiary"){
                IdStudyform = 2;
            } else if (studyget.Study == "universitary") {                    
                IdStudyform  = 3;
            }
            return IdStudyform;
        }
        public int validateIdStudyStateget(Studiesget studyget)
        {
            int IdStudiesStateform = 0;
            if (studyget.Study1 == "ongoing"){
                IdStudiesStateform= 1;                
            } else if (studyget.Study1 == "finished") {
                IdStudiesStateform = 2;
            } else if (studyget.Study1 == "abandoned") {
                IdStudiesStateform  = 3;
            }
            return IdStudiesStateform;
        }


        //Validation IdStudy
        public int validateIdStudy(Form form)
        {
            int IdStudyform = 0;
            if (form.Study == "secondary"){
                IdStudyform= 1;
            } else if (form.Study == "tertiary") {
                IdStudyform = 2;
            } else if (form.Study == "universitary") {
                IdStudyform  = 3;
            }
            return IdStudyform;
        }
        public int validateIdStudyState(Form form)
        {
            int IdStudiesStateform = 0;
            if (form.Study1 == "ongoing"){
                IdStudiesStateform= 1;
            } else if (form.Study1 == "finished") {
                IdStudiesStateform = 2;
            } else if (form.Study1 == "abandoned") {
                IdStudiesStateform  = 3;
            }
            return IdStudiesStateform;

        }

        //STATE
        public List<BasicPostulant> addState(IEnumerable<PostulantBasic> postulants)
        {
            List<BasicPostulant> postulantstoReturn = new List <BasicPostulant>();
            foreach (var postu in postulants)
            {
                BasicPostulant aux = new BasicPostulant{
                    Id = postu.Id,
                    Name = postu.Name,
                    Lastname = postu.Lastname,
                    Iteration = postu.Iteration
                };
                switch(postu.IdState)
                {
                    case 1: 
                    {
                        aux.State = "Pending contact";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                    case 2: 
                    {
                        aux.State = "Scheduled Assessment";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                    case 3: 
                    {
                        aux.State = "FinishedAssessment";
                        postulantstoReturn.Add(aux);
                        
                        break;
                    }
                    case 4:
                    {
                        aux.State = "Pending Interview";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                    case 5: 
                    {
                        aux.State = "Finished Interview";
                        postulantstoReturn.Add(aux);  
                        break;
                    }
                    case 6: 
                    {
                        aux.State = "Approved";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                    case 7: {
                        aux.State = "Rejected";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                    case 8: {
                        aux.State = "Canceled";
                        postulantstoReturn.Add(aux);
                        break;
                    }
                }
            }
            return postulantstoReturn;
        }
    }
}