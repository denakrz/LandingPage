using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.Models
{
    public class Login
    { 
        public string User {get;set;}
        public string Password{get;set;}
    }
}