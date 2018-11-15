using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class DateNTime
    {
        //Esta clase guarda exactamente como esta en la db 
        public string Date {get;set;}
        public string Time{get;set;}      

    }
}