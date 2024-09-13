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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            App app = new App();
            app.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            FormIndicaciones formIndicaciones = new FormIndicaciones();
            formIndicaciones.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DatosGuardados datos = new DatosGuardados();
            datos.CargarDatos();
        }
    }
}
