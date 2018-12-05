using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Attachedget
    { 
        public int? Id {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        public string Name {get;set;}
        public int IdTypeAttached {get;set; }

    }
}