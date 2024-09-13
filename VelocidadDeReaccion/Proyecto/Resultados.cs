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
    public partial class Resultados : Form
    {
        private double[] total;
        private double promedio;
        public Resultados(double[] tot, double prom)
        {
            InitializeComponent();
            this.BackColor = Color.PaleTurquoise;
            //Se ingresan los tiempos individuales a la listbox
            for (int i = 0; i < tot.Length; i++)
            {
                string mensaje = $"{i + 1}) {tot[i]:0.###} segundos!";
                lisbTiemposIndividuales.Items.Add(mensaje);
            }

            lblPromedio.Text = $"¡{prom:#.###} segundos!";

            total = tot;
            promedio = prom;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DatosGuardados datosGuardados = new DatosGuardados();
            datosGuardados.GuardarDatos(total, promedio);
            btnGuardar.Enabled = false;
        }
    }
}
