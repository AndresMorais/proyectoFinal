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
using System.ComponentModel.DataAnnotations;

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

// INICIO LOGIN
        [HttpPost]
        public ActionResult Index(LoginViewModel loginDataModel)
       
        {
            if (ModelState.IsValid)
            {
             // AQUÍ EL CÓDIGO DE VALIDACIÓN DEL USUARIO
                
                // return RedirectToAction("LoginOk");
                return RedirectToAction("CargarLegislacion");
                 
            }                
            else
            {
                return View(loginDataModel);
            }                
        }

        public ActionResult LoginOK()
        {
            // LA VALIDACIÓN DEL USUARIO HA SIDO CORRECTA
            
            return View();
        }
     // FIN LOGIN

        

        /// RETORNA LA VISTA DE LA PAGINA CONSULTA
        public IActionResult Consulta()
        {
            return View(db.legislacion.ToList());
        }

        ///  RETORNA LA LISTA DE LEGISLACION CARGADAS
        // public JsonResult ConsultarLegislacion()
        // {
        //     return Json(db.legislacion.ToList());
        // }

        


        /// CARGAR UNA NUEVA LEGISLACION
        public IActionResult CrearLegislacion (string Tipo, int Numero, string Origen, string Objeto, string Enlace)
        {
            Legislacion nuevaLegislacion = new Legislacion (){
                Tipo = Tipo,
                Numero = Numero,
                Origen = Origen,
                Objeto = Objeto,
                Enlace = Enlace

            };
            db.legislacion.Add(nuevaLegislacion);
            db.SaveChanges ();
            return RedirectToAction("CargarLegislacion", "Home");
    
            // return Json (nuevaLegislacion);                       
        }
   
        // VISTAS
        public IActionResult CargarLegislacion()
        {
            return View();
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
        
        // MAIL
        public string myMail = "aplicacioncomunidadit@gmail.com";
        public string myPassword = "Aplicacion_2020";
        // private readonly ILogger<HomeController> _logger;

        public string NombreContacto(string nombre)
        {
            return $"Gracias por el mensaje {nombre}";
        }

        [HttpPost]
        public IActionResult EnviarContacto (string nombre, string mail, string mensaje)
         {
            ViewBag.nombre = nombre;
            ViewBag.mail = mail;
            ViewBag.mensaje = mensaje;

            var smtpClient = new SmtpClient("smtp.gmail.com"){
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(myMail, myPassword),
                EnableSsl = true,
            };

            string mensajeMail = $"{nombre}, tu mensaje fue recibido. Nos pondremos en contacto con usted.\n Su mensaje fue: {mensaje}";

            smtpClient.Send(myMail,mail, $"{nombre}, gracias por tu mensaje", mensajeMail);
            smtpClient.Send(myMail,myMail, $"Llego un mail de {nombre}"," Revisa el servidor");
            
            return View("RespuestaContacto");
        }
            
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
