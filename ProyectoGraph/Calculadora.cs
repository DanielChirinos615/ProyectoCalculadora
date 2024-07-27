using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;
using Microsoft.VisualBasic;
using ExcelLicenseContext = OfficeOpenXml.LicenseContext;
using Proyecto;
using static Proyecto.CompressionControl;
using static Proyecto.TensionControl;


namespace ProyectoGraph
{
    public partial class Calculadora : Form
    {
        private CompressionControlState compressionControlState;
        private TensionControlState tensionControlState;
        private Dictionary<string, SeccionData> seccionesData = new Dictionary<string, SeccionData>();
        private string seccionSeleccionada; // Almacena la sección seleccionada

        public Calculadora()
        {
            InitializeComponent();
            this.Load += Calculadora_Load;
            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
        }

        public Dictionary<string, SeccionData> GetSeccionesData()
        {
            return seccionesData;
        }

        public ComboBox SeccionesComboBox
        {
            get { return comboBox1; }
        }

        public string SeccionSeleccionada
        {
            get { return seccionSeleccionada; }
            set
            {
                seccionSeleccionada = value;
                ActualizarSeccionSeleccionada(seccionSeleccionada);
            }
        }

        private void MostrarControlInicial()
        {
            CompressionControl controlInicial = new CompressionControl(this);
            TensionControl controlInicialT = new TensionControl(this);

            controlInicial.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(controlInicial);

            controlInicial.CargarDatos();
        }

        public void CargarDatosEnComboBox()
        {
            string fileName = "secciones.xlsx";
            string archivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(archivo))
            {
                ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(new FileInfo(archivo)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    seccionesData.Clear(); // Limpiar los datos antiguos
                    SeccionesComboBox.Items.Clear(); // Limpiar el ComboBox

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string seccion = worksheet.Cells[row, 1].Text;
                        string areaText = worksheet.Cells[row, 2].Text;
                        string radioxText = worksheet.Cells[row, 3].Text;
                        string radiozText = worksheet.Cells[row, 4].Text;
                        string wtText = worksheet.Cells[row, 5].Text;
                        string espesorText = worksheet.Cells[row, 6].Text;

                        if (string.IsNullOrWhiteSpace(seccion) &&
                            string.IsNullOrWhiteSpace(areaText) &&
                            string.IsNullOrWhiteSpace(radioxText) &&
                            string.IsNullOrWhiteSpace(radiozText) &&
                            string.IsNullOrWhiteSpace(wtText) &&
                            string.IsNullOrWhiteSpace(espesorText))
                        {
                            // Fila vacía, continuar con la siguiente fila
                            continue;
                        }

                        if (double.TryParse(areaText, out double area) &&
                            double.TryParse(radioxText, out double radiox) &&
                            double.TryParse(radiozText, out double radioz) &&
                            double.TryParse(wtText, out double wt) &&
                            double.TryParse(espesorText, out double espesor))
                        {
                            seccionesData[seccion] = new SeccionData
                            {
                                Area = area,
                                RadioX = radiox,
                                RadioZ = radioz,
                                WT = wt,
                                Espesor = espesor
                            };

                            SeccionesComboBox.Items.Add(seccion);
                        }
                        else
                        {
                            MessageBox.Show($"Error al convertir los datos de la fila {row}. Verifica el formato del archivo Excel.\n" +
                                            $"Sección: {seccion}, Área: {areaText}, RadioX: {radioxText}, RadioZ: {radiozText}, W/T: {wtText}, Espesor: {espesorText}");
                        }
                    }
                    if (SeccionesComboBox.Items.Count > 0)
                    {
                        SeccionesComboBox.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo Excel no se encontró.");
            }
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            MostrarControlInicial();
            CargarDatosEnComboBox();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://ssg-s.pe",
                UseShellExecute = true
            });
        }

        private void tensionButton_Click(object sender, EventArgs e)
        {
            Escenas_Tension();
        }

        private void Escenas_Tension()
        {
            if (panel1.Controls.Count > 0 && panel1.Controls[0] is CompressionControl compressionControl)
            {
                compressionControlState = compressionControl.GetState();
            }
            else if (panel1.Controls.Count > 0 && panel1.Controls[0] is TensionControl tensionControl)
            {
                tensionControlState = tensionControl.GetState();
            }

            TensionControl newTensionControl = new TensionControl(this);
            panel1.Controls.Clear();
            newTensionControl.Dock = DockStyle.Fill;

            if (tensionControlState != null)
            {
                newTensionControl.SetState(tensionControlState);
            }

            panel1.Controls.Add(newTensionControl);
        }

        private void compressionButton_Click(object sender, EventArgs e)
        {
            Escenas_Compression();
        }

        private void Escenas_Compression()
        {
            if (panel1.Controls.Count > 0 && panel1.Controls[0] is CompressionControl compressionControl)
            {
                compressionControlState = compressionControl.GetState();
            }
            else if (panel1.Controls.Count > 0 && panel1.Controls[0] is TensionControl tensionControl)
            {
                tensionControlState = tensionControl.GetState();
            }

            CompressionControl newCompressionControl = new CompressionControl(this); // Pasar la referencia de la calculadora
            panel1.Controls.Clear();
            newCompressionControl.Dock = DockStyle.Fill;

            if (compressionControlState != null)
            {
                newCompressionControl.SetState(compressionControlState);
            }

            panel1.Controls.Add(newCompressionControl);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionSeleccionada = SeccionesComboBox.SelectedItem?.ToString();
        }

        private void ActualizarSeccionSeleccionada(string seccionSeleccionada)
        {
            if (panel1.Controls.Count > 0)
            {
                if (panel1.Controls[0] is CompressionControl compressionControl)
                {
                    compressionControl.ActualizarSeccionSeleccionada(seccionSeleccionada);
                }
                else if (panel1.Controls[0] is TensionControl tensionControl)
                {
                    tensionControl.ActualizarSeccionSeleccionada(seccionSeleccionada);
                }
            }
        }
    }
}
