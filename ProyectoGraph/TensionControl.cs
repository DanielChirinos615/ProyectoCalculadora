using OfficeOpenXml;
using ProyectoGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto.CompressionControl;
using ExcelLicenseContext = OfficeOpenXml.LicenseContext;

namespace Proyecto
{
    public partial class TensionControl : UserControl
    {
        private Calculadora calculadora;
        Dictionary<string, double> fluenciaAcero = new Dictionary<string, double>();
        private Dictionary<string, SeccionDataT> seccionesDataT = new Dictionary<string, SeccionDataT>();
        public TensionControl(Calculadora calculadora)
        {
            InitializeComponent();
            this.calculadora = calculadora;

            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
            calculadora.SeccionesComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            LlenarComboBoxSecciones(calculadora.GetSeccionesDataT());
            CargarDatosEnComboBox();
        }

        private void TensionControl_Load(object sender, EventArgs e)
        {

        }
        public void LlenarComboBoxSecciones(Dictionary<string, SeccionDataT> secciones)
        {
            seccionesDataT = secciones;
            calculadora.SeccionesComboBox.Items.Clear();
            foreach (var seccion in secciones.Keys)
            {
                calculadora.SeccionesComboBox.Items.Add(seccion);
            }
            if (calculadora.SeccionesComboBox.Items.Count > 0)
            {
                calculadora.SeccionesComboBox.SelectedIndex = 0;
            }
        }
        public void ActualizarSeccionSeleccionada(string seccionSeleccionada)
        {
            if (seccionesDataT.ContainsKey(seccionSeleccionada))
            {
                SeccionDataT data = seccionesDataT[seccionSeleccionada];
                Area.Text = data.Area.ToString();
                Espesor.Text = data.Espesor.ToString();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seccionSeleccionada = calculadora.SeccionesComboBox.SelectedItem.ToString();
            ActualizarSeccionSeleccionada(seccionSeleccionada);
        }
        public class SeccionDataT
        {
            public double Area { get; set; }
            public double Espesor { get; set; }
        }
        private void CargarDatosEnComboBox()
        {
            string fileName = "secciones.xlsx";
            string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(archivo))
            {
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(new FileInfo(archivo)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string seccion = worksheet.Cells[row, 1].Text;
                        string areaText = worksheet.Cells[row, 2].Text;
                        string espesorText = worksheet.Cells[row, 6].Text;

                        if (string.IsNullOrWhiteSpace(seccion) &&
                            string.IsNullOrWhiteSpace(areaText) &&
                            string.IsNullOrWhiteSpace(espesorText))
                        {
                            // Fila vacía, continuar con la siguiente fila
                            continue;
                        }

                        if (double.TryParse(areaText, out double area) &&
                            double.TryParse(espesorText, out double espesor))
                        {
                            seccionesDataT[seccion] = new SeccionDataT
                            {
                                Area = area,
                                Espesor = espesor
                            };

                            // Debugging messages
                            Console.WriteLine($"Sección: {seccion}, Área: {area}, Espesor: {espesor}");

                            calculadora.SeccionesComboBox.Items.Add(seccion);
                        }
                        else
                        {
                            MessageBox.Show($"Error al convertir los datos de la fila {row}. Verifica el formato del archivo Excel.\n" +
                                            $"Sección: {seccion}, Área: {areaText}, Espesor: {espesorText}");
                        }
                    }
                    if (calculadora.SeccionesComboBox.Items.Count > 0)
                    {
                        calculadora.SeccionesComboBox.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}
