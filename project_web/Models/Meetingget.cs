using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Meetingget
    { 
        public int? Id {get;set;}
        [Required]
        public int IdInstance {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        [Required]
        public string DateTime {get;set;}
    }
}