using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Proyecto
{
    public partial class App : Form
    {
        //Variables y Arrays para el proceso
        private double[] milisegundosAntes = new double[5];
        private double[] milisegundosDespues = new double[5];
        private string almacenarMili;
        private int t, i = 0;
        public App()
        {
            //Iniciar el Form y esperar a que el usuario haga click para comenzar
            InitializeComponent();
            lblAhora.Visible = false;
            lblEspere.Visible = false;
            this.MouseClick += new MouseEventHandler(Inicio);
        }

        //Primer click, funciona para iniciar el "juego"
        private void Inicio(object sender, MouseEventArgs e)
        {
            lblComenzar.Visible = false;
            this.BackColor = Color.PaleVioletRed;
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            this.MouseClick -= new MouseEventHandler(Inicio);
            Espera();
        }

        //Método que se usará para cada tiempo de espera
        private async void Espera()
        {
            //Controlar posible excepción fuera de rango
            if (i < 5)
            {
                //Se crea y espera un tiempo aleatorio, se cambian aspectos de la GUI
                //se guarda la hora en segundos y milisegundos y se espera un click
                Random rnd = new Random();
                t = rnd.Next(1, 6);
                await Task.Delay(t * 1000);
                this.Cursor = Cursors.Default;
                this.Enabled = true;
                this.BackColor = Color.PaleGreen;
                lblEspere.Visible = false;
                lblAhora.Visible = true;
                almacenarMili = DateTime.Now.ToString("ss.fff");
                milisegundosAntes[i] = Double.Parse(almacenarMili);
                this.MouseClick += new MouseEventHandler(this.DoClick);
            }
            //sale del bucle
            else
            {
                //Se reactiva el formulario y se llama al último método
                this.Cursor = Cursors.Default;
                this.Enabled = true;
                Fin(milisegundosAntes, milisegundosDespues);
            }
        }

        private void DoClick(object sender, MouseEventArgs e)
        {
            //Se modifica nuevamente la GUI y cuando el usuario hace clic se guarda una nueva hora en segundos y milisegundos
            almacenarMili = DateTime.Now.ToString("ss.fff");
            milisegundosDespues[i] = Double.Parse(almacenarMili);
            i++;
            lblAhora.Visible = false;
            lblEspere.Visible = true;
            this.BackColor = Color.PaleVioletRed;
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            //Se desactiva la detección de clicks y se vuelve a iniciar el bucle
            this.MouseClick -= new MouseEventHandler(this.DoClick);
            Espera();
        }

        /// <summary>
        /// Recibe toda la información de la interacción y la procesa en tiempos de reacción individuales y promedio
        /// </summary>
        /// <param name="inicio">Array con la información en s y ms cuando la pantalla se ponía en verde</param>
        /// <param name="fin">Array con la información en s y ms cuando se hacía click en la pantalla</param>
        private void Fin(double[] inicio, double[] fin)
        {
            double promedio = 0;
            double[] total = new double[5];
            //se determina los tiempos de reacción individuales y el promedio
            for (int i = 0; i < inicio.Length; i++)
            {
                total[i] = fin[i] - inicio[i];
                promedio = promedio + total[i];
            }
            promedio = promedio / 5;
            //Se abre el siguiente formulario y se cierra este
            Resultados res = new Resultados(total, promedio);
            res.Show();
            this.Dispose();
        }
    }
}