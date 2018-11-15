using System.Collections.Generic;
using LUG3WebApi.DBModels;

namespace LUG3WebApi.DBManagerAll
{
    public interface IDBManager
    {
        int Insert(Postulant postulant); //listo
        void InsertStudies(Studies studies); //listo
        void InsertAttached(Attached attached, int IdPostulant); //listo
        Postulant GetPostulant(int Postulant);
        IEnumerable<PostulantBasic> GetPostulantAll();
        void Delete (int id);
        Postulant Update (Postulant postulant);
        PostulantInfo GetPostulantInfo(int id); 
    }
}