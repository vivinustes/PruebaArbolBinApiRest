using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaArbolBinApiRest.Models
{
    public class NodoArbolBinario
    {
        int valor;
        NodoArbolBinario izquierda;
        NodoArbolBinario derecha;

        public NodoArbolBinario() { }

        public NodoArbolBinario(int valor)
        {
            this.valor = valor;
        }

        public int ObtenerValor()
        {
            return valor;
        }

        public NodoArbolBinario ObeterNodoDerecha()
        {
            return derecha;
        }

        public NodoArbolBinario ObeterNodoIzquierda()
        {
            return izquierda;
        }

        public void AsignarValor(int valor)
        {
            this.valor = valor;
        }

        public void AsignarNodoIzquierda (NodoArbolBinario nodoIzquierdo)
        {
            izquierda = nodoIzquierdo;
        }

        public void AsignarNodoDerecha(NodoArbolBinario nodoDerecho)
        {
            derecha = nodoDerecho;
        }

    }
}