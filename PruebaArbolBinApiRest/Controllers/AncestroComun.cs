namespace PruebaArbolBinApiRest.Controllers
{
    //Modelo de datos de entrada para ontener el ancestro común más cercano
    public class AncestroComun
    {
        public string ArbolID { get; set; }
        public int ValorNodo1 { get; set; }
        public int ValorNodo2 { get; set; }
    }
}