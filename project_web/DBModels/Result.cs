using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Result
    { 
        public int? Id {get;set;}
        public string Name {get; set;}
        public byte[] Form {get;set;}
        public int IdMeeting {get;set;}
        public string Observation{get;set;}
        public int OK{get;set;}
    }
}