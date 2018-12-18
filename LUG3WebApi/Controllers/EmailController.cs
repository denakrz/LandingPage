using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using LUG3WebApi.Added;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Text;

namespace LUG3WebApi.Controllers {
[Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase{
        private readonly IDBManager dbm;
        public EmailController(IDBManager dbm_)
        {
            this.dbm = dbm_;
        }
        
        [HttpPost]
        [Route ("/api/Email/{postulantName}/{postulantLastName}/{postulantEmail}/{newState}")]
            public ActionResult Post(string postulantName, string postulantLastName, string postulantEmail, string newState)
            {
                if (newState == "7")
                {
                    //Message segui participando
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Human Resources - Lagash", "hrtestlagash@gmail.com"));
                    message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                    message.Subject = "Decidimos no continuar con tu perfil";
                    message.Body = new TextPart("html"){
                        Text = "Hola " + postulantName + " te enviamos este email para notificarte que decidimos no continuar con tu perfil"
                    };
                    using(var client = new SmtpClient()){
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                return Ok();

                }
                else if(newState == "2")
           {
               //Mensaje que le manda el usuario y la contraseña
                var message = new MimeMessage();
                var password = createPassword(10);
                message.From.Add(new MailboxAddress("Pablo" + "Lagash", "hrtestlagash@gmail.com"));
                message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                message.Subject = "Seguis en carrera!";
                message.Body = new TextPart("html")
                {
                    Text = "Hola " + postulantName + " te enviamos este email para notificarte que seguis en carrera y te contactamos para la siguiente etapa, a partir de aca podras ingresar a la pagina donde te informaremos el dia de la reunion, para ello te adjuntamos:"+ "<br>"
                    + "Tu usuario es: <b>" + postulantEmail + "</b> y tu contraseña es: <b>" + password + "</b> <br> Por cuestiones de seguridad, te sugerimos cambiar la contraseña. <br> Para iniciar sesion ingresa a " + "<a href='http://localhost:49495/index.html'>"+ "Inicia sesion aqui" + "</a>"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return Ok();

           }
                else if (newState == "3")
                {
                    
                        //Message has sido seleccionado para pasar al estado 3
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Human Resources - Lagash", "hrtestlagash@gmail.com"));
                    message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                    message.Subject = "Seguis en carrera!";
                    message.Body = new TextPart("html"){
                        Text = "Hola " + postulantName + " te enviamos este email para notificarte que seguis en carrera y te contactamos para la siguiente etapa 3<br>"
                        };
                    using(var client = new SmtpClient()){
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                        return Ok();

                    
                    
                }else if (newState == "4")
                {
                    
                        //Message has sido seleccionado para pasar al estado 4
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Human Resources - Lagash", "hrtestlagash@gmail.com"));
                    message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                    message.Subject = "Seguis en carrera!";
                    message.Body = new TextPart("html"){
                        Text = "Hola " + postulantName + " te enviamos este email para notificarte que seguis en carrera y te contactamos para la etapa 4<br>"
                    };
                    using(var client = new SmtpClient()){
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                        return Ok();

                    
                    
                }else if (newState == "5")
                {
                    
                        //Message has sido seleccionado para pasar al estado 5
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Human Resources - Lagash", "hrtestlagash@gmail.com"));
                    message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                    message.Subject = "Seguis en carrera!";
                    message.Body = new TextPart("html"){
                        Text = "Hola " + postulantName + " te enviamos este email para notificarte que seguis en carrera y te contactamos para la etapa 5<br>"
                    };
                    using(var client = new SmtpClient()){
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                        return Ok();

                    
                    
                }

                else 
                {
                    if (newState == "6")
                    {
                        //Message has sido seleccionado para pasar al estado 6
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Human Resources - Lagash", "hrtestlagash@gmail.com"));
                    message.To.Add(new MailboxAddress(postulantName + postulantLastName, postulantEmail));
                    message.Subject = "Seguis en carrera!";
                    message.Body = new TextPart("html"){
                        Text = "Hola " + postulantName + " te enviamos este email para notificarte que seguis en carrera y te contactamos para la etapa 6"
                    };
                    using(var client = new SmtpClient()){
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("hrtestlagash@gmail.com", "hrPassword");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                        return Ok();

                    }
                return BadRequest();
                    
                }
            }
              public string createPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!.¿?¡";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

                
        // [HttpPost]
        // [Route("/api/Email/{postulantName}/{postulantLastName}/{postulantEmail}/{newState}")]
    //    public ActionResult Post(string postulantName, string postulantLastName, string postulantEmail, string newState)
    //    {
           
    //        else
    //        {
    //            return new StatusCodeResult(404);
    //        }
    //    }        
        
    }
}