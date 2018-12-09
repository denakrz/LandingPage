using System.Collections.Generic;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;

namespace LUG3WebApi.DBManagerAll
{
    public interface IDBManager
    {
        //Gestion postulant
        int InsertPostulant(Postulant postulant); 
        Postulant GetPostulant(int Postulant);
        IEnumerable<PostulantBasic> GetPostulantFilter(int IdState);
        IEnumerable<PostulantBasic> GetPostulantAll();
        Postulant UpdatePostulant (Postulant postulant);
        void DeletePostulant(int IdPostulant);

        //Para vista de postulantes
        PostulantInfo GetPostulantInfo(int id); 

        //Gestion Address
        void InsertAddress(Addressget addressget);
        Addressget getAddress(int IdPostulant);
        Addressget UpdateAddress (Addressget addressget, int IdPostulant);

        //Gestion Studies
        void InsertStudies(Studies studies); 
        IEnumerable<Studies> GetStudies(int IdPostulant);
        IEnumerable<Studies> UpdateStudies(Studies studies);
        
        //Gestion Adjuntos
        void InsertAttached(Attached attached, int IdPostulant); 
        IEnumerable<Attachedget> GetAttached(int IdPostulant);
        Fileget GetFile (int IdPostulant, string Name);
        IEnumerable<Attachedget> UpdateAttached(Attached attached, int IdPostulant_);

        //Gestion Meetings 
        void InsertMeeting(Meeting meeting);
        IEnumerable<Meetingget> GetMeeting(int IdPostulant);
        IEnumerable<Meetingget> UpdateMeeting(Meeting meeting);

        //Gestion State
        int GetState(int IdPostulant);
        IEnumerable<StateC> GetStateById(int IdPostulant);
        void UpdateState(int IdPostulant, int IdState);
        
        //Devuelve formulario
        byte[] GetForm(int IdPostulant);

        //Gestion Result
        void InsertResult(Result result);
        IEnumerable<Resultget> GetResult(int IdPostulant);
        FilegetResult GetFileResult(int IdResult);
        IEnumerable<Resultget> UpdateResult(Resultget result, int IdPostulant);
        void UpdateFileResult(Fileget file, int IdResult);

        //Login
    }
}