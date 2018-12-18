using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUG3WebApi.Added;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LUG3WebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IDBManager dbm;
        AddedFunctions fnc;

        public RegisterController(IDBManager dbm_)
        {
            this.dbm = dbm_;
            fnc = new AddedFunctions();
        }


        //GUARDA EL FORMULARIO
        [HttpPost]
        [AllowAnonymous]
        [Route ("/api/Register/")]
        public ActionResult Post([FromBody] Form form)
        {
            if (this.ModelState.IsValid)
            {
                Postulant postulant = fnc.createPostulant(form);
                //Aca valida datos y guarda en db
                int IdPostulantDb = dbm.InsertPostulant(postulant);
                int IdStudyform = fnc.validateIdStudy(form);
                int IdStudiesStateform = fnc.validateIdStudyState(form);           
                Studies studies = fnc.createStudies(form, IdPostulantDb, IdStudyform, IdStudiesStateform);
                dbm.InsertStudies(studies);

                var formString = JsonConvert.SerializeObject(form);
                var barray = Encoding.UTF8.GetBytes(formString);

                Attached attached = new Attached {
                    Name = "InitForm.txt",
                    Link = barray,
                    IdTypeAttached = 1
                };

                dbm.InsertAttached(attached, IdPostulantDb);
                return Ok();
            } else {
                return BadRequest();
            }

        }
        
        // GUARDA UN ESTUDIO
        [HttpPost]
        [Route ("/api/Register/Study")]
        public ActionResult PostStudy([FromBody] Studiesget studyget)
        {
            if (this.ModelState.IsValid)
            {   
                int IdStudyform = fnc.validateIdStudyget(studyget);
                int IdStudiesStateform = fnc.validateIdStudyStateget(studyget);

                Studies studies = fnc.createStudiesget(studyget, IdStudyform, IdStudiesStateform);
                dbm.InsertStudies(studies);
                return Ok();
            } else {
                return BadRequest();
            }
            
        }
    }
}