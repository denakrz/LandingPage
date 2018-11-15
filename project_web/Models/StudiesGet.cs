using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class StudiesGet
    {
        
        [Required]
        public string Study{get;set;}
        [Required]
        public string Institution{get;set;}
        [Required]
        public string Career {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        public int Year {get;set;}
        [Required]
        public string Study1{get;set;}
    }
}