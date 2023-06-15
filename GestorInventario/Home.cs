using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorInventario.Productos;

namespace GestorInventario
{
    public partial class Home : Form
    {

        
        public Home()
        {
            InitializeComponent();
        }

        public List<Producto> Productos = new List<Producto>();

        public void ingresoProducto()
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string cantidad = txtCantidad.Text;
            string precio = txtPrecio.Text;
            try
            {
                if (codigo.Length > 0 && nombre.Length > 0 && descripcion.Length > 0 && cantidad.Length > 0 && precio.Length > 0)
                {
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtCantidad.Text = "";
                    txtPrecio.Text = "";

                    Producto producto1 = new Producto(codigo, nombre, descripcion, int.Parse(cantidad), int.Parse(precio));

                    Producto productoExistente = Productos.Find(p => p.Codigo == codigo);
                    if (productoExistente != null)
                    {
                        productoExistente.Cantidad = productoExistente.Cantidad + int.Parse(cantidad);

                    }
                    else
                    {
                        Productos.Add(producto1);
                        MessageBox.Show("Se ha agregado el siguiente producto: \n Codigo: "+codigo+"\n Nombre: "+nombre+"\n Descripcion: "+descripcion+"\n Cantidad: "+cantidad+"\n Precio: "+precio);
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Productos;
                }
                else
                {
                    MessageBox.Show("Se deben llenar todos los campos");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("La cantidad y/o el precio, deben ser digitos");

                return;
            }
            

            
        }

        public void salidaProducto() 
        {
            string codigo = txtCodigo.Text;
            
            string cantidad = txtCantidad.Text;
            try
            {

                if (codigo.Length > 0 && cantidad.Length > 0)
                {
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtCantidad.Text = "";
                    txtPrecio.Text = "";
                    Producto producto1 = new Producto(codigo, int.Parse(cantidad));

                    Producto productoExistente = Productos.Find(p => p.Codigo == codigo);

                    if (productoExistente == null)
                    {
                        MessageBox.Show("El producto no existe");
                        return;

                    }

                    if (productoExistente.Cantidad <= 0)
                    {
                        productoExistente.Cantidad = 0;
                        MessageBox.Show("El stock debe ser mayor a 0");


                    }
                    else
                    {
                        productoExistente.Cantidad = productoExistente.Cantidad - int.Parse(cantidad);
                        MessageBox.Show("Se han retirado " + cantidad + " elementos del elemento con codigo " + productoExistente.Codigo);
                    }





                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Productos;
                }
                else
                {
                    MessageBox.Show("Se deben llenar todos los campos");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("La cantidad debe ser digito");

                return;

            }
  

        }

        public void generarReporte() 
        {
            Reporte rep = new Reporte();
            rep.cargarDatosReporte(Productos);
            rep.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        { 
            ingresoProducto();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            salidaProducto();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            generarReporte();
        }
    }
}
