using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class PostulantBasic
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        public string Name{get;set;}
        public string Lastname{get;set;}
        public int IdState {get;set;}
        
        public int Iteration {get;set;}
    }
}