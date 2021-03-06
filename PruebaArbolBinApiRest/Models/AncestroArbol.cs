﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaArbolBinApiRest.Models
{
    public class AncestroArbol
    {
        //Calcula el ancestro común más cercano entre los valores ingresados
        public static int CalcAncestroComun(ArbolBinario arbolBinario, int ValorNodo1, int ValorNodo2)
        {
            int AncestroComun = 0;

            Resultado result = ObtenerAncestroComunMasCercano(arbolBinario.ObtenerNodoRaiz(), ValorNodo1, ValorNodo2);

            //Valida si los valores ingresados existen en el árbol creado previamente
            if (result != null && result.NodoArbol != null)
            {
                //Valida si los dos valores ingresados son nodos que tienen el mismo padre
                if (result.ExisteNodo1 && result.ExisteNodo2)
                {
                    AncestroComun = result.NodoArbol.ObtenerValor();
                }
                else
                {
                    //Valida si los dos valores ingresados son nodos con padres distintos
                    if (CompararValor(result.NodoArbol, ValorNodo1) || CompararValor(result.NodoArbol, ValorNodo2))
                    {
                        AncestroComun = result.NodoArbol.ObtenerValor();
                    }
                    else
                    {
                        //Valida si los valor ingresados existen en algún nodo del arbol
                        if (CompararValor(result.NodoArbol, ValorNodo1))
                        {                            
                            throw new Exception("El valor " + ValorNodo2 + " , NO esta presente en el árbol");
                        }
                        else
                        {                            
                            throw new Exception("El valor " + ValorNodo1 + " , NO esta presente en el árbol");
                        }
                    }
                }
            }

            return AncestroComun;
        }

        private static Resultado ObtenerAncestroComunMasCercano (NodoArbolBinario NodoArbol, int valor1, int valor2, NodoArbolBinario nodoPadre = null)
        {

            if (NodoArbol == null) return new Resultado();

            Resultado result = new Resultado();

            if (NodoArbol.ObtenerValor() == valor1)
            {
                result.ExisteNodo1 = true;

                if (NodoArbol.ObeterNodoDerecha() != null && NodoArbol.ObeterNodoDerecha().ObtenerValor() == valor2)
                {
                    result.NodoArbol = nodoPadre;
                }
                else if (NodoArbol.ObeterNodoIzquierda() != null && NodoArbol.ObeterNodoIzquierda().ObtenerValor() == valor2)
                {
                    result.NodoArbol = nodoPadre;
                }
                else
                {
                    result.NodoArbol = NodoArbol;
                }
                return result;
            }

            if (NodoArbol.ObtenerValor() == valor2)
            {
                result.ExisteNodo2 = true;
                if (NodoArbol.ObeterNodoDerecha() != null && NodoArbol.ObeterNodoDerecha().ObtenerValor() == valor1)
                {
                    result.NodoArbol = nodoPadre;
                }
                else if (NodoArbol.ObeterNodoIzquierda() != null && NodoArbol.ObeterNodoIzquierda().ObtenerValor() == valor1)
                {
                    result.NodoArbol = nodoPadre;
                }
                else
                {
                    result.NodoArbol = NodoArbol;
                }
                return result;
            }
            
            Resultado resultadoIzquierda = ObtenerAncestroComunMasCercano(NodoArbol.ObeterNodoIzquierda(), valor1, valor2, NodoArbol);
            Resultado resultadoDerecha = ObtenerAncestroComunMasCercano(NodoArbol.ObeterNodoDerecha(), valor1, valor2, NodoArbol);

            if (resultadoIzquierda.NodoArbol != null && resultadoDerecha.NodoArbol != null)
            {
                result.ExisteNodo2 = true;
                result.ExisteNodo1 = true;
                result.NodoArbol = NodoArbol;
                return result;
            }


            if (resultadoIzquierda.NodoArbol != null)
            {
                result.ExisteNodo1 = true;
                result.NodoArbol = resultadoIzquierda.NodoArbol;
                return result;
            }

            result.ExisteNodo2 = true;
            result.NodoArbol = resultadoDerecha.NodoArbol;
            return result;

        }

        public static bool CompararValor(NodoArbolBinario nodoArbolBinario, int valor)
        {
            if (nodoArbolBinario == null) return false;

            if (nodoArbolBinario.ObtenerValor() == valor || CompararValor(nodoArbolBinario.ObeterNodoIzquierda(), valor)
                || CompararValor(nodoArbolBinario.ObeterNodoDerecha(), valor))
            {
                return true;
            }

            return false;
        }
    }
}