using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class BasicPostulant
    { 
        public int Id {get;set;}
        public string Name{get;set;}
        public string Lastname{get;set;}
        public string State {get;set;}
        
        public int Iteration {get; set;}
    }
}