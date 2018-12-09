using System;
namespace LUG3WebApi.DBModels
{
    public class UserInfo
    {
        public string Token{get;set;}
        public int LoginType {get;set;}
        public int? IdPostulant {get;set;}
        
    }
}