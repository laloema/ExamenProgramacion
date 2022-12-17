﻿using ExamenProgramacion.Models;
using ExamenProgramacion.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            List<int> arr1List = arr1.ToList();
            List<Numeros> list = new();
            for (int i = 0; i <= arr1List.Count-1; i++) {
                if (!list.Any(n => n.Valor == arr1List[i]))
                {
                    Numeros numeros = new()
                    {
                        Valor = arr1List[i],
                        Contador = arr1List.FindAll(n => n == arr1List[i]).Count
                    };
                    list.Add(numeros);
                }
            }
            list = list.OrderByDescending(n => n.Contador).ToList();
            return Json(list);
        }

        //Buscar por Rango de Edad >25 & <65 y las personas que inicien con la letra enviada  
        public IActionResult Prueba2(string letra)
        {
            //500 personas
            List<Persona> listaPersonas = _dataGeneratorService.GenerarPersonas();
            List<Persona> EnRango = listaPersonas.FindAll(p => p.Edad > 25 && p.Edad < 65 && p.Nombre[0].ToString().ToLower() == letra.ToLower());
            return Json(EnRango);
        }

        //Separar lista de numeros en pares o impares
        public IActionResult Prueba3()
        {
            //Resultado esperado {"pares":[300,34],"impares":[81,3]}
            List<int> numeros = _dataGeneratorService.GenerarNumeros();
            NumerosParesImpares numerosSeparados = new() { 
                Pares = numeros.FindAll(n => n%2 == 0),
                Impares = numeros.FindAll(n => n%2 != 0)
            };
            return Json(numerosSeparados);
        }

        //Agrupar palabras por mayor numero de vocales
        public IActionResult Prueba4()
        {
            //resultado Esperado {"a":["palabra1","Palabra2"],"e":["pelebre1"],"i":["pilibri1"]}
            List<PalabraDTO> palabras = _dataGeneratorService.GenerarPalabras();

            return Ok();
        }

        //Recibir datos Json y combinar los recibidos con los entregados 
        [HttpPost]
        public IActionResult Prueba5()
        {
            /*
             * Ejemplo de Respuesta:
             * [{
                    "id": 1,
                    "nombre": "Lolita",
                    "apellido": "Kreiger",
                    "pedidos": [
                        {
                            "ordenId": 4568,
                            "producto": "kiwi",
                            "cantidad": 2
                        }
                    ],
                    "usuario": "Clementina81",
                    "email": "Sherman.Jacobi@hotmail.com",
                    "idUnique": "7a04e5d6-594a-44a6-87ee-3f7f6cf72ffb"
                }]
             */

            
            List<DatosUsuario> res = _dataGeneratorService.GenerarUsuariosDatos();
            List<DatosPedidos> respedidos = _dataGeneratorService.GenerarPedidos();

            
            return Ok();
        }
    }
}