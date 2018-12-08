using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaArbolBinApiRest.Models
{
    public class ArbolBinario
    {
        NodoArbolBinario nodoRaiz;

        public ArbolBinario() { }

        public void CrearNodoRaiz(NodoArbolBinario nodoArbolBinario)
        {
            nodoRaiz = nodoArbolBinario;
        }

        public NodoArbolBinario ObtenerNodoRaiz()
        {
            return nodoRaiz;
        }

        public void InsertarNodo (int Nodo)
        {
            nodoRaiz = InsertarNodo(nodoRaiz, Nodo);
        }

        private NodoArbolBinario InsertarNodo(NodoArbolBinario nodoArbolBinario, int Nodo)
        {
            if (nodoArbolBinario == null)
            {
                nodoArbolBinario = new NodoArbolBinario(Nodo);
                return nodoArbolBinario;
            }

            if (nodoArbolBinario.ObtenerValor() < Nodo)
            {
                nodoArbolBinario.AsignarNodoDerecha(InsertarNodo(nodoArbolBinario.ObeterNodoDerecha(), Nodo));
            }

            else
            {
                nodoArbolBinario.AsignarNodoIzquierda(InsertarNodo(nodoArbolBinario.ObeterNodoIzquierda(), Nodo));
            }

            return nodoArbolBinario;
        }
    }
}