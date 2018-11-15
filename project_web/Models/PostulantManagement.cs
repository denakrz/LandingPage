using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class PostulantManagement
    {
        //Esto guarda lo que envia la pagina de gestion de postulantes
        public bool PendingContact{get;set;}
        public bool ScheduledAssessment{get;set;}
        public bool FinishedAssessment{get;set;}
        public bool PendingInterview{get;set;}
        public bool Approved{get;set;}
        public bool Rejected{get;set;}
        public bool Canceled{get;set;}
    }
}