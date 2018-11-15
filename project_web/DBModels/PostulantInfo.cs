using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class PostulantInfo
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        public string Name{get;set;}
        public string Lastname{get;set;}
        public int IdState {get;set;} //Si es 2, 4 o 6, hay meeting
        //Si es 1, 3, 5 
        public bool Meeting {get;set;}
        public DateTime? DateTime {get;set;}        

    }
}