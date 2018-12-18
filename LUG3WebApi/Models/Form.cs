using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Form
    {
        [Required]
        public string Name{get;set;}
        [Required]
        public string Lastname {get;set;}
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Birth{get;set;}
        [Required]
        public string Dni {get;set;}
        [Required]
        public string Email {get;set;}
        public string PhoneHome{get;set;}
        [Required]
        public string PhoneMobile {get;set;}
        public string GitHub{get;set;}
        public string LinkedIn{get;set;}
        [Required]
        public string Study{get;set;}
        [Required]
        public string Institution{get;set;}
        [Required]
        public string Career{get;set;}
        [Required]
        public string Study1 {get;set;} //State Abandonado, en curso o finalizado
        [Required]
        public string English {get;set;}
        public string SpeakEnglish{get;set;}
        public string WrittenEnglish{get;set;}
        public string ListenEnglish{get;set;}
        //no me acepta el required
        public string Technologies{get;set;}
        [Required]
        public string InfoProg{get;set;}
        public string Other {get;set;}
        [Required]
        public string intProg {get;set;}
        [Required]
        public string ConverTheme {get;set;}
        [Required]
        public string Cod {get;set;}
        public string Tools {get;set;}
        [Required]
        public string Pc {get;set;}
        [Required]
        public string Experience {get;set;}
    }
}
