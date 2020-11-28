using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_comunidad_it.Models;
using System.Net;

namespace proyecto_comunidad_it.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly legislacionContext db;

        public HomeController(ILogger<HomeController> logger,
            legislacionContext contexto)
        {
            this.logger = logger;
            this.db = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// /// EL CONTROLADOR DE ABAJO RETORNA LA VISTA DE LA PAGINA CONSULTA
        public IActionResult Consulta()
        {
            return View();
        }

        /// EL CONTROLADOR DE ABAJO RETORNA LA LISTA DE CONSULTAS
        public JsonResult ConsultarLegislacion()
        {
            return Json(db.legislacion.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
             return View();
        }

        public IActionResult respuestaContacto()
        {
            return View();
        }
        

        public string myMail = "aplicacioncomunidadit@gmail.com";
        public string myPassword = "Aplicacion_2020";
        // private readonly ILogger<HomeController> _logger;

        public string NombreContacto(string nombre)
        {
            return $"Gracias por el mensaje {nombre}";
        }

        [HttpPost]
        public IActionResult EnviarContacto (string nombre,  string apellido, string mail, string consulta )
         {
            ViewBag.nombre = nombre;
            ViewBag.mail = mail;
            ViewBag.mensaje = consulta;

            var smtpClient = new SmtpClient("smtp.gmail.com"){
                Port = 587,
                Credentials = new NetworkCredential(myMail,myPassword),
                EnableSsl = true,
            };

            string mensajeMail = $"{nombre}, tu mensaje fue recibido. Nos pondremos en contacto con usted.\n Su mensaje fue: {consulta}";

            // smtpClient.Send(myMail, mail, $"{nombre}, gracias por tu mensaje", mensajeMail);
            // smtpClient.Send(myMail, myMail, $"Llego un mail de {mail}", $"{consulta}");
            
            return View("RespuestaContacto");
        }
            
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
