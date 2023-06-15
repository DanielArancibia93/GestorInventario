using GestorInventario.Productos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorInventario
{
    public partial class Reporte : Form
    {
        
        public Reporte()
        {
            InitializeComponent();
        }
        public void cargarDatosReporte(List<Producto> lista) 
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lista));
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            

            this.reportViewer1.RefreshReport();
        }
    }
}
