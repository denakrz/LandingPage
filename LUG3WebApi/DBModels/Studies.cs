using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Studies
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int IdStudy{get;set;}
        [Required]
        public string Institution{get;set;}
        [Required]
        public string Career {get;set;}
        [Required]
        public int IdPostulant {get;set;}
        public int Year {get;set;}
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int IdStudiesState{get;set;}
    }
}