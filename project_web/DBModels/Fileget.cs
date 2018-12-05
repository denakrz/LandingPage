using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class Fileget
    {
        public string Name { get; set; }
        public byte [] Link { get; set; }
    }
}