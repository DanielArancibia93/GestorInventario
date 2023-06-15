using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventario.Productos
{
    public class Producto
    {
        private string codigo;
        private string nombre;
        private string descripcion;
        private int cantidad;
        private int precio;

        public Producto(string cod, string nom, string desc, int can, int pre) 
        {
            codigo = cod;
            nombre = nom;
            descripcion = desc;
            cantidad = can;
            precio = pre;
        
        }

        public Producto(string cod, int can)
        {
            codigo = cod;
            cantidad = can;

        }
        public Producto(string cod, string nom, string desc)
        {
            codigo= cod;
            nombre = nom; 
            descripcion = desc;
        }
        public Producto()
        {
            
        }




        public string Codigo { get {  return codigo; } set { codigo = value; } }
        public string Nombre { get {  return nombre; } set { nombre = value; } }
        public string Descripcion { get {  return descripcion; } set { descripcion = value; } }
        public int Cantidad { get {  return cantidad; } set { cantidad = value; } }
        public int Precio { get { return precio; } set { precio = value; } }


        
        
    }
}
