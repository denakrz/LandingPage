using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Studies
    {
        //Esta clase guarda exactamente como esta en la db 
        public int IdStudy{get;set;}
        public string Institution{get;set;}
        public string Career {get;set;}
        public int IdPostulant {get;set;}
        public int Year {get;set;}
        public int IdStudiesState{get;set;}
    }
}