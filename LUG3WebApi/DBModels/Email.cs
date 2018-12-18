using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Email
    { 
        public int id{get;set;}
        public string mail {get;set;}
        public string name{get;set;}
        public string lastname {get;set;}
        
        public int idType{get;set;}
        // Si es de rrhh --> 1
        // Si es postulante --> 2
        public string descripcion {get;set;}

        
    }
}