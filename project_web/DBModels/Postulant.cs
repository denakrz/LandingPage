using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Postulant
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public string Lastname{get;set;}
        
        public string Dni {get;set;}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Birthday{get;set;}
        public int IdAddress{get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        public string PhoneHome {get;set;}
        [Required]
        public string PhoneMobile {get;set;}
        public string GitHub{get;set;}
        public string LinkedIn{get;set;}
        public int IdState {get;set;}
        public int Iteration {get;set;}
        public int Country {get;set;}
    }
}