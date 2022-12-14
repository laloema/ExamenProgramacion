﻿using ExamenProgramacion.Models;
using ExamenProgramacion.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenProgramacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataGeneratorService _dataGeneratorService;

        public HomeController(IDataGeneratorService dataGeneratorService)
        {
            _dataGeneratorService = dataGeneratorService;
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

            return Ok();
        }

        //Buscar por Rango de Edad >25 & <65 y las personas que inicien con la letra enviada  
        public IActionResult Prueba2(string letra)
        {
            //500 personas
            List<Persona> listaPersonas = _dataGeneratorService.GenerarPersonas();

            return Ok();
        }

        //Separar lista de numeros en pares o impares
        public IActionResult Prueba3()
        {
            //Resultado esperado {"pares":[300,34],"impares":[81,3]}
            List<int> numeros = _dataGeneratorService.GenerarNumeros();

            return Ok();
        }

        //Agrupar palabras por mayor numero de vocales
        public IActionResult Prueba4()
        {
            //resultado Esperado {"a":["palabra1","Palabra2"],"e":["pelebre1"],"i":["pilibri1"]}
            List<PalabraDTO> palabras = _dataGeneratorService.GenerarPalabras();

            return Ok();
        }

        //Recibir datos Json y combinar los recibidos con los entregados 
        public IActionResult Prueba5()
        {
            return Ok();
        }
    }
}