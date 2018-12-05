using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Addressget
    { 
        public int? Id {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        [Required]
        public string Home{get;set;}
        [Required]
        public string Number{get;set;}
        public string PostalCode {get;set;}
        [Required]
        public string Location {get;set;}

    }
}