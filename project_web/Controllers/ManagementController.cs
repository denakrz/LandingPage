using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using LUG3WebApi.Added;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LUG3WebApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase 
    {
        private readonly IDBManager dbm;
        private AddedFunctions fnc;
        public ManagementController(IDBManager dbm_)
        {
            this.dbm = dbm_;
            fnc = new AddedFunctions();
        }

        //GESTION DE POSTULANTES 
        [HttpGet]
        [Route("Postulant")]
        // GET api/Management/Postulant
        public IEnumerable<BasicPostulant> GetPostulantAll()
        {
            IEnumerable<PostulantBasic> postulants = dbm.GetPostulantAll();
            return (fnc.addState(postulants));
        }

        [HttpGet]
        [Route("Postulant/{PostulantId}")]
        //GET api/Management/Postulant/{PostulantId}
        public Postulant GetPostulantbyId(int PostulantId)
        {
            return dbm.GetPostulant(PostulantId);
        }

        [HttpGet]
        [Route("Postulant/Filter/{Id}")]
        //GET api/Management/Postulant/Filter/{Id}
        //Esto va a buscar postulantes segun el filtro (es el Id del state)
        public IEnumerable<BasicPostulant> GetPostulantSelection(int Id)
        {
            IEnumerable <PostulantBasic> postulants = dbm.GetPostulantFilter(Id);
            return (fnc.addState(postulants));
        } 

        [HttpDelete]
        [Route("Postulant/Delete/{PostulantId}")]
        //DELETE api/Management/Postulant/Delete/{PostulantId}
        public void DeletePostulant(int PostulantId)
        {
            dbm.DeletePostulant(PostulantId);
        }

        [HttpPut]
        [Route("Postulant/Modif")]
        //PUT api/Management/Postulant/Modif
        public Postulant Update([FromBody] Postulant postulant)
        {
            if (postulant.Id != 0) 
            {
                return dbm.UpdatePostulant(postulant);
            } else
            {
                return postulant;
            }
            
        }

        //GESTION DE ESTUDIOS
        [HttpPost]
        [Route ("Study")]
        //POST api/Management/Study
        public ActionResult InsertStudies([FromBody] Studies studies)
        {
            if (this.ModelState.IsValid) 
            {
                dbm.InsertStudies(studies);
                return Ok();
            }
            else 
            { 
                return BadRequest();
            }
        }

        [HttpGet]
        [Route ("Study/{IdPostulant}")]
        //GET api/Management/Study/{IdPostulant}
        public IEnumerable<Studies> GetStudies (int IdPostulant)
        {
            return dbm.GetStudies(IdPostulant);
        }

        [HttpPut]
        [Route ("Study/Modif")]
        //PUT api/Management/Study/Modif
        public IEnumerable<Studies> UpdateStudies ([FromBody] Studies studies)
        {
            if (studies.Id != 0)
            {
                return dbm.UpdateStudies(studies);
            } else 
            {
                IEnumerable<Studies> study = null;
                study.Append(studies);
                return study;
            }
            
        }

        //DEVUELVE EL FORM
        [HttpGet]
        [Route ("Form/{IdPostulant}")]
        //GET api/Management/Form/{idPostulant}
        public Form getFormulario(int IdPostulant)
        {
            byte [] barray = dbm.GetForm(IdPostulant);
            string form = Encoding.UTF8.GetString(barray); //No devuelve el form 
            Form formObject = JsonConvert.DeserializeObject<Form>(form);
            return formObject;
        }

        //DEVUELVE EL ID DEL ESTADO        
        [HttpGet]
        [Route ("State/{IdPostulant}")]
        //GET api/Management/State/{IdPostulant}
        public int getState (int IdPostulant)
        {
            return (dbm.GetState(IdPostulant));
        }


        //GESTION DE LA DIRECCION DEL POSTULANTE
        [HttpPost]
        [Route ("Address")]
        //POST api/Management/Address
        public ActionResult InsertAddress([FromBody] Addressget addressget)
        {
            Postulant post = dbm.GetPostulant(addressget.IdPostulant);
            if (this.ModelState.IsValid && post.IdAddress == 0) 
            {
                dbm.InsertAddress(addressget);
                return Ok();
            }
            else 
            { 
                return BadRequest();
            }
        }
        [HttpGet]
        [Route ("Address/{IdPostulant}")]
        //GET api/Management/Address/{IdPostulant}
        public Addressget GetAddress (int IdPostulant)
        {
            return dbm.getAddress(IdPostulant);
        }

        [HttpPut]
        [Route ("Address/Modif/{IdPostulant}")]
        //PUT api/Management/Address/Modif/{IdPostulant}
        public Addressget UpdateAddress ([FromBody] Addressget address, int IdPostulant)
        {
            return dbm.UpdateAddress(address, IdPostulant);
        }

        //GESTION ADJUNTOS
        [HttpPost]
        [Route ("Attached/{IdPostulant}/{IdTypeAttached}")]
        //POST api/Management/Attached/{IdPostulant}/{IdTypeAttached}
        public async Task<IActionResult> InsertAttached([FromForm]IFormFile file, int IdPostulant, int IdTypeAttached)
        {
            var a = HttpContext.Request.Form.Files.FirstOrDefault();
            
            if (a == null)
            {
                return Content("file not selected");
            }
            byte[] barray;
            using (var stream = new MemoryStream())
            {
                await a.CopyToAsync(stream);
                barray = stream.ToArray();
            };

            Attached attached = new Attached{
                Name = a.FileName,
                Link = barray,
                IdTypeAttached = IdTypeAttached
            };
            dbm.InsertAttached(attached, IdPostulant);
            return Ok();
        }
        
        [HttpGet]
        [Route ("Attached/{IdPostulant}")]
        //GET api/Management/Attached/{IdPostulant}
        public IEnumerable<Attachedget> GetAttached (int IdPostulant){
            
            IEnumerable<Attachedget> attached = dbm.GetAttached(IdPostulant);
            return attached;
        }

        [HttpGet] 
        [Route ("Attached/{IdPostulant}/{Name}")]
        //GET api/Management/Attached/{IdPostulant}/{Name}
        public async Task<IActionResult> GetFile(int IdPostulant, string Name)
        {
            if (Name==null)
            {
                return Content("Filename not present");
            }
            
            Fileget file = dbm.GetFile(IdPostulant, Name);
            var memory = new MemoryStream();
            Stream stream;
            using (stream = new MemoryStream(file.Link))
            {
                await stream.CopyToAsync(memory);
            }
            string fileextension = file.Name.Split(".")[file.Name.Split(".").Length-1];
            
            memory.Position = 0; 
            return File(memory, fnc.getMimeTypes(fileextension)); 
        }

        [HttpPut]
        [Route ("Attached/Modif/{IdAttached}/{IdPostulant}/{IdTypeAttached}")]
        //PUT api/Management/Attached/Modif/{IdAttached}/{IdPostulant}/{IdTypeAttached}
        public async Task<IActionResult> UpdateAttached([FromForm]IFormFile file, int IdAttached, int IdPostulant, int IdTypeAttached)
        {   
            var a = HttpContext.Request.Form.Files.FirstOrDefault();

            if (a == null || IdAttached == 0 || IdPostulant == 0)
            {
                return Content("Error en datos");
            }
            byte[] barray;
            using (var stream = new MemoryStream())
            {
                await a.CopyToAsync(stream);
                barray = stream.ToArray();
            };

            Attached attached = new Attached{
                Id = IdAttached,
                Name = a.FileName,
                Link = barray,
                IdTypeAttached = IdTypeAttached
            };
            return Ok(dbm.UpdateAttached(attached, IdPostulant));
        }

        //  ------------------- LOGICA -------------------
        //Si estado = 1 --> Se envia login. Meeting - assessment (2)
        //Si estado = 2 --> Hay una meeting, result de meeting insance 1 (3)
        //Si estado = 3 --> Hay meeting y result. Meeting - tech y P&c (4)
        //Si estado = 4 --> Hay meeting tech y p&c - result de meeting instance 2 o 3 
        //Si estado = 5 --> Hay meetings y result. Meeting - Health Exam
        //Si estado = 6 --> Aprobado. Se puede agregaar resultado de health exam
        //Si estado = 7. --> No se agrega nada, esta rechazado. 
        //Si estado = 8 --> El cancelo, no se agrega nada.

        //GESTION DE REUNIONES  
        [HttpPost]
        [Route ("Meeting")]
        //POST api/Management/Meeting
        public ActionResult insertMeeting([FromBody] Meetingget meetingget)
        {
            if (this.ModelState.IsValid)
            {
                Meeting meeting = fnc.createMeeting(meetingget);
                int IdState = dbm.GetState(meeting.IdPostulant);

                switch (meeting.IdInstance)
                {
                    case 1:
                    {
                        if (IdState == 1)
                        {
                            dbm.InsertMeeting(meeting);
                            dbm.UpdateState(meeting.IdPostulant, 2);
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    case 2:
                    case 3:
                    {
                        if (IdState == 3 || IdState == 4)
                        {
                            dbm.InsertMeeting(meeting);
                            dbm.UpdateState(meeting.IdPostulant, 4);
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    case 4: 
                    {
                        if (IdState == 5 || IdState == 6)
                        {
                            dbm.InsertMeeting(meeting);
                            dbm.UpdateState(meeting.IdPostulant, 6);
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    default:{
                        return BadRequest("Unknown");
                    }
                }
                return Ok();
            } else {
                return BadRequest("Faltan valores");
            }
        }
        
        [HttpGet]
        [Route ("Meeting/{IdPostulant}")]
        //GET api/Management/Meeting/{IdPostulant}
        public IEnumerable<Meetingget> GetMeeting (int IdPostulant)
        {
            return dbm.GetMeeting(IdPostulant);
        }

        [HttpPut]
        [Route ("Meeting/Modif")]
        //PUT  api/Management/Meeting/Modif
        public IEnumerable<Meetingget> UpdateMeeting([FromBody] Meetingget meetingget)
        {
            Meeting meeting = fnc.createMeeting(meetingget);
            return dbm.UpdateMeeting(meeting);
        }

        //GESTION DE RESULTADOS 
        [HttpPost]
        [Route ("Result/{IdPostulant}")]  
        //POST api/Management/Result/{IdPostulant}
        public async Task<IActionResult> insertResult([FromForm] Resultget resultget, [FromForm] IFormFile file, int IdPostulant)
        {
            var a = HttpContext.Request.Form.Files.FirstOrDefault();
            if (a == null || a.Length == 0)
            {
                 return Content("File not selected");
            }
            if (this.ModelState.IsValid && IdPostulant != 0)
            {
                int IdState = dbm.GetState(IdPostulant);
                byte [] barray;
                using (var stream = new MemoryStream())
                {
                    await a.CopyToAsync(stream);
                    barray = stream.ToArray();
                };

                Result result = fnc.createResult(resultget, barray, a.FileName);
                switch (resultget.IdInstance)
                {
                    case 1:
                    {
                        if (IdState == 2)
                        {                          
                            dbm.InsertResult(result);
                            dbm.UpdateState(IdPostulant, 3);
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    case 2:
                    case 3:
                    {
                        if (IdState == 4 || IdState == 5)
                        {
                            dbm.InsertResult(result);
                            dbm.UpdateState(IdPostulant, 5);
                            
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    case 4: 
                    {
                        if (IdState == 6)
                        {
                            dbm.InsertResult(result);
                
                        } else {
                            return BadRequest("El estado no corresponde");
                        }
                        break;
                    }
                    default:{
                        return BadRequest("Unknown");
                    }
                }
                return Ok();
            } else {
                return BadRequest("Faltan valores");
            }
        }

        [HttpGet]
        [Route ("Result/{IdPostulant}")]
        //GET api/Management/Result/{IdPostulant}
        public IEnumerable<Resultget> GetResult (int IdPostulant)
        {
            return dbm.GetResult(IdPostulant);
        }

        [HttpGet]
        [Route ("Result/File/{IdResult}")]
        //GET api/Management/Result/File/{IdResult}
        public async Task<IActionResult> GetFileResult(int IdResult)
        {
            if (IdResult == 0)
            {
                return Content("filename not present");
            }
            FilegetResult file = dbm.GetFileResult(IdResult);
            var memory = new MemoryStream();
            Stream stream;
            using (stream = new MemoryStream(file.Form))
            {
                await stream.CopyToAsync(memory);
            }
            string fileextension = file.Name.Split(".")[file.Name.Split(".").Length-1];
            memory.Position = 0;
            return File(memory, fnc.getMimeTypes(fileextension)); 
        }

        [HttpPut]
        [Route ("Result/Modif/{IdPostulant}")]
        //PUT api/Management/Result/Modif/{IdPostulant}
        public IEnumerable<Resultget> UpdateResult([FromBody] Resultget result, int IdPostulant)
        {
            return dbm.UpdateResult(result, IdPostulant); 
        }

        [HttpPut]
        [Route ("Result/ModifFile/{IdResult}")]
        //PUT api/Management/Result/ModifFile/{IdResult}
        public async Task<IActionResult> UpdateFileResult([FromForm]IFormFile file, int IdResult)
        {
            var a = HttpContext.Request.Form.Files.FirstOrDefault();
            if (a == null || a.Length == 0 || IdResult == 0)
            {
                return Content("file not selected");
            }
            byte[] barray;

            using (var stream = new MemoryStream())
            {
                await a.CopyToAsync(stream);
                barray = stream.ToArray();
            };

            Fileget fileset = new Fileget 
            {
                Name = a.FileName,
                Link = barray
            };
            dbm.UpdateFileResult(fileset, IdResult);
            return Ok();
        }
    }
}