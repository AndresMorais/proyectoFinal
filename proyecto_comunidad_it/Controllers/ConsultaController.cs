using Microsoft.AspNetCore.Mvc;

namespace proyecto_comunidad_it.Controllers
{
  public class ConsultaController : Controller
  {

      public ConsultaController()
      {        
      }

      public IActionResult Index()
      {
          return View();
      }
  }

}

