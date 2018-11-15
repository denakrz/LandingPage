using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using LUG3WebApi.Added;

namespace LUG3WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase {
        
        private readonly IDBManager dbm;
        private AddedFunctions fnc;

        public ManagementController(IDBManager dbm_){
            this.dbm = dbm_;
            fnc = new AddedFunctions();
        }

        [HttpGet]
        [Route("/api/Management/")]
        //Esto devuelve todos los postulantes
        public IEnumerable<BasicPostulant> GetPostulantAll()
        {
            IEnumerable<PostulantBasic> postulants = dbm.GetPostulantAll();
            return (fnc.addState(postulants));
        }

        [HttpGet]
        [Route("/api/Management/{PostulantId}")]
        public Postulant GetPostulantbyId(int PostulantId){
            return dbm.GetPostulant(PostulantId);
        }

        /* [HttpGet]
        [Route("/api/Management/")]
        //Esto va a buscar postulantes segun el filtro
        public void GetPostulantSelection(PostulantManagement postmanag)
        {
        } */

        [HttpDelete]
        [Route("/api/Management/{PostulantId}")]
        public void DeletePostulant(int PostulantId)
        {
            dbm.Delete(PostulantId);
        }

        [HttpPut]
        [Route("/api/Management/")]
        public Postulant Update(Postulant postulant)
        {
            return dbm.Update(postulant);
        }
    
    }
}