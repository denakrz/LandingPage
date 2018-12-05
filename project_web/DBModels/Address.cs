using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Address
    {
        //Esta clase guarda exactamente como esta en la db 
        public int? Id {get;set;}
        public string Home{get;set;}
        public string Number{get;set;}
        public string PostalCode{get;set;}
        public int? IdLocation {get;set;}
    }
}