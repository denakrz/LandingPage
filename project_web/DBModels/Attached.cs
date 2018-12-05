using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Attached
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        public string Name {get;set;}
        public byte[] Link {get;set;}
        public int IdTypeAttached {get;set; }
    }  
}