using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Meeting
    { 
        //esta clase guarda exactamente como esta en la db
        public int? Id {get;set;}
        [Required]
        public int IdInstance {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        [Required]
        public DateTime DateTime {get;set;}
    }
}