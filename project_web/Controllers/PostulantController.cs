using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUG3WebApi.Added;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LUG3WebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class PostulantController
    {
        private readonly IDBManager dbm;

        public PostulantController(IDBManager dbm_)
        {
            this.dbm = dbm_;
        }

        [HttpGet]
        [Route ("/api/Postulant/{id}")]
        public PostulantInfo Get (int Id){
            if (Id != 0){
                PostulantInfo info = dbm.GetPostulantInfo(Id);
                return info;
            } else {
                PostulantInfo info = null;
                return (info);
            }
        }
    }
}