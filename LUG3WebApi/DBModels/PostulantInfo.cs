using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class PostulantInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int IdState { get; set; } // 2, 4 o 6 --> meeting
        // 1, 3, 5 --> no hay meeting 
        public bool Meeting { get; set; }
        public DateTime? DateTime { get; set; }

    }
}