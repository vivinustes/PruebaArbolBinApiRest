using PruebaArbolBinApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaArbolBinApiRest.Controllers
{
    public class Almacenamiento 
    {
        //Guarda árbol binario en la sesión del usuario
        public static string GuardarArbol(ArbolBinario arbolBinario)
        {

            // Se almacena en la SESSION simulando el guardado en una base de datos
            // se recomienta no utilizar la session en los servicios REST en modo "stateless" por 
            // efectos de rendimiento, para este caso se hace la excepcion ya que es un ejemplo, evitando asi la 
            // generación y almacenamiento de una base de datos local o remota
            string id = Guid.NewGuid().ToString();
            HttpContext.Current.Session[id] = arbolBinario;

            // retorna identificador del arbol creado
            return id;
        }

        //Obtiene el árbol binario almacenado en la sesión del usuario
        public static ArbolBinario ObtenerArbol(string id)
        {
            // Se obtiene de la base de datos (simulada) por la session
            Models.ArbolBinario arbolBinario = HttpContext.Current.Session[id] as ArbolBinario;

            // retorna arbol almacenado
            return arbolBinario;
        }
    }
}
