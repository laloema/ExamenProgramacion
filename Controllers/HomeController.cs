using ExamenProgramacion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenProgramacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Agrupar y contar numeros
        public IActionResult Prueba1()
        {
            //Con este array de numeros 
            //Agrupar y ordenar descendentemente por numero de repeticiones 
            //Ejemplo de respueta [{"valor":#numero,"contador":#Repeticiones},{"valor":#numero,"contador":#Repeticiones}]
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            var n = arr1.GroupBy(x=>x).Select(x=>new { Valor = x.Key, Contador = x.Count() }).OrderByDescending(x=>x.Contador).ToList();
            
            return Ok(n);
        }

        //
    }
}