using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Resultget
    { 
        public int? Id {get;set;}
        [Required]
        public int IdInstance{get;set;}
        [Required]
        public int IdMeeting {get;set;}
        [Required]
        public string Observation{get;set;}
        [Required]
        public int OK{get;set;}
    }
}