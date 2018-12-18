using System;
using System.ComponentModel.DataAnnotations;

namespace LUG3WebApi.DBModels
{
    public class FilegetResult
    {
        public string Name { get; set; }
        public byte [] Form { get; set; }
    }
}