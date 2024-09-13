using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Proyecto
{
    public class DatosGuardados
    {
        private string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//Registro.xml";

        public void GuardarDatos(double[] total, double promedio)
        {
            if (File.Exists(ruta))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ruta);

                XmlNode root = doc.DocumentElement;

                XmlNode interaccion = doc.CreateElement("Interaccion");

                XmlElement fecha = doc.CreateElement("Fecha");
                fecha.InnerText = DateTime.Now.ToString();
                interaccion.AppendChild(fecha);

                for (int i = 0; i < total.Length; i++)
                {
                    XmlElement tiempo = doc.CreateElement($"Tiempo{i + 1}");
                    tiempo.InnerText = total[i].ToString();
                    interaccion.AppendChild(tiempo);
                }

                XmlElement prom = doc.CreateElement("Promedio");
                prom.InnerText = promedio.ToString();
                interaccion.AppendChild(prom);

                root.AppendChild(interaccion);
                doc.Save(ruta);
            }
            else
            {
                XmlDocument doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement rootElement = doc.CreateElement(string.Empty, "Items", string.Empty);
                doc.AppendChild(rootElement);

                XmlElement interaccion = doc.CreateElement("Interaccion");

                XmlElement fecha = doc.CreateElement("Fecha");
                fecha.InnerText = DateTime.Now.ToString();
                interaccion.AppendChild(fecha);

                for (int i = 0; i < total.Length; i++)
                {
                    XmlElement tiempo = doc.CreateElement($"Tiempo{i + 1}");
                    tiempo.InnerText = total[i].ToString();
                    interaccion.AppendChild(tiempo);
                }

                XmlElement prom = doc.CreateElement("Promedio");
                prom.InnerText = promedio.ToString();
                interaccion.AppendChild(prom);

                rootElement.AppendChild(interaccion);
                doc.Save(ruta);
            }

            MessageBox.Show("¡Guardado Exitoso!", "Exito");
        }


        public void CargarDatos()
        {
            if (File.Exists(ruta))
            {
                XDocument doc = XDocument.Load(ruta);

                List<Datos> data = Deserializar(ruta);

                MostrarDatos mostrar = new MostrarDatos();
                mostrar.MostrarLista(data);
            }
            else
            {
                MessageBox.Show("No se ha encontrado el archivo deseado...", "Error");
            }
        }
        public static List<Datos> Deserializar(string ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Open))
            {
                XmlSerializer deserial = new XmlSerializer(typeof(ListaDatos));
                ListaDatos listDatos = (ListaDatos)deserial.Deserialize(fs);
                return listDatos.Interaccion;
            }
        }

        [Serializable]
        public class Datos
        {
            [XmlIgnore]
            public DateTime Fecha { get; set; }

            [XmlElement("Fecha")]
            public string FechaString
            {
                get { return Fecha.ToString("dd/MM/yyyy HH:mm:ss"); }
                set { Fecha = DateTime.ParseExact(value, "d/M/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public double Tiempo1 { get; set; }
            public double Tiempo2 { get; set; }
            public double Tiempo3 { get; set; }
            public double Tiempo4 { get; set; }
            public double Tiempo5 { get; set; }
            public double Promedio { get; set; }
        }

        [Serializable]
        [XmlRoot("Items")]
        public class ListaDatos
        {
            [XmlElement]
            public List<Datos> Interaccion { get; set; }
        }
    }
}
