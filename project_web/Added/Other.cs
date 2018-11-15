using System;
using System.Collections.Generic;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;

namespace LUG3WebApi.Added {

    public class AddedFunctions {
        public Studies createStudiesget(StudiesGet studyget, int IdStudyform, int IdStudiesStateform)
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
        public int validateIdStudyget(StudiesGet studyget)
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
        public int validateIdStudyStateget(StudiesGet studyget)
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
                IdState = 1
            };
            return postulant;
        }
        public List<BasicPostulant> addState(IEnumerable<PostulantBasic> postulants)
        {
            List<BasicPostulant> postulantstoReturn = new List <BasicPostulant>();
            foreach (var postu in postulants)
            {
                BasicPostulant aux = new BasicPostulant{
                    Id = postu.Id,
                    Name = postu.Name,
                    Lastname = postu.Lastname,
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