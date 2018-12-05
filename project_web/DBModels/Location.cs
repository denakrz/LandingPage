using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Locationn
    {
        //Esta clase guarda exactamente como esta en la db 
        public int Id {get;set;}
        public string Location {get;set;}
    }
}