using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class MostrarDatos : Form
    {
        public List<Proyecto.DatosGuardados.Datos> listaD;
        public MostrarDatos()
        {
            InitializeComponent();
        }

        public void MostrarLista(List<Proyecto.DatosGuardados.Datos> ls)
        {
            this.Show();
            listaD = ls;
            int i = 1;
            lisvMostrar.View = View.Details;
            lisvMostrar.Columns.Add("Vez #");
            lisvMostrar.Columns.Add("Fecha");
            lisvMostrar.Columns.Add("Tiempo Promedio");
            foreach (var dato in ls)
            {
                ListViewItem item = new ListViewItem($"{i.ToString()})");
                item.SubItems.Add(dato.FechaString);
                item.SubItems.Add($"{dato.Promedio:0.###} segundos.");
                lisvMostrar.Items.Add(item);
                i++;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int i = 1;
            lisvMostrar.Items.Clear();
            foreach (var dato in listaD)
            {
                if (dato.Fecha.ToString("dd/MM/yyyy") != dtpBuscador.Value.ToString("dd/MM/yyyy"))
                {
                }
                else
                {
                    ListViewItem item = new ListViewItem($"{i.ToString()})");
                    item.SubItems.Add(dato.FechaString);
                    item.SubItems.Add($"{dato.Promedio:0.###} segundos.");
                    lisvMostrar.Items.Add(item);
                    i++;
                }
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            int i = 1;

            lisvMostrar.Items.Clear();

            foreach (var dato in listaD)
            {
                ListViewItem item = new ListViewItem($"{i.ToString()})");
                item.SubItems.Add(dato.FechaString);
                item.SubItems.Add($"{dato.Promedio:0.###} segundos.");
                lisvMostrar.Items.Add(item);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IndicacionesBuscador indicaciones = new IndicacionesBuscador();
            indicaciones.Show();
        }
    }
    public class Datos
    {
        public DateTime dt { get; set; }
        public double[] tiempos { get; set; }
        public double prom { get; set; }
    }
}
