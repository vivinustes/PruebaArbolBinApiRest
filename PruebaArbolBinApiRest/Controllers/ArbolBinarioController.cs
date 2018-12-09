using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaArbolBinApiRest.Models;

namespace PruebaArbolBinApiRest.Controllers
{
    public class ArbolBinarioController : ApiController
    {
        // POST: ArbolBinario/Crear
        // API: Metodo para crear el árbol binario
        [HttpPost]
        [Route("API/ArbolBinario/Crear")]
        [ResponseType(typeof(string))]
        public IHttpActionResult Crear([FromBody] string[] nodosArbol)
        {
            // Instancia clase de arbol binario
            ArbolBinario arbolBinario = new ArbolBinario();

            // Itera e inserta cada nodo de arbol
            for (int i = 0; i < nodosArbol.Length; i++)
            {
                arbolBinario.InsertarNodo(int.Parse(nodosArbol[i]));
            }

            // Almacena arbol en base de datos (simulación), retorna identificador 
            // único para posterior consulta
            string id = Almacenamiento.GuardarArbol(arbolBinario);

            // Retorna ID de arbol creado
            return Ok(id);
        }

        // POST: ArbolBinario/AncestroComunMasCercano
        // API: Metodo para obtener el ancestro común más cercano
        [HttpPost]
        [Route("API/ArbolBinario/AncestroComunMasCercano")]
        [ResponseType(typeof(int))]
        public IHttpActionResult ObtenerAncestroComun([FromBody] AncestroComun ac)
        {
            // Obtiene arbol basado en ID generado previamente por el servicio "<domain>/API/ArbolBinario/Crear"
            ArbolBinario arbolBinario = Almacenamiento.ObtenerArbol(ac.ArbolID);

            try
            {
                // Calcula el ancestro mas cercano basado en el "ID" del arbol creado 
                // previamente con el servicio "<domain>/API/ArbolBinario/Crear"
                int commonAncestor = AncestroArbol.CalcAncestroComun(arbolBinario, ac.ValorNodo1, ac.ValorNodo2);

                // Retorna ID de arbol creado
                return Ok(commonAncestor);
            }
            catch (Exception e)
            {
                return BadRequest("No fue posible cacular el ancestro común mas cercano");
            }
        }

    }
}
