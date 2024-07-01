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
using ExcelLicenseContext = OfficeOpenXml.LicenseContext;


namespace ProyectoGraph
{
    public partial class Form1 : Form
    {
        static double pi = 3.1416;
        static double E = 200000;
        static double FyA36 = 250;
        static double FyA572 = 350;
        double KLr = 0, KLx = 0, KLz = 0, Fy;
        Dictionary<string, double> tiposDeAcero = new Dictionary<string, double>();
        private Dictionary<string, SeccionData> seccionesData = new Dictionary<string, SeccionData>();
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
            CargarDatosEnComboBox();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosEnComboBox()
        {
            string archivo = "C:\\Users\\danie\\source\\repos\\ProyectoGraph\\ProyectoGraph\\Assets\\secciones.xlsx"; 

            if (File.Exists(archivo))
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(archivo)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) 
                    {
                        string seccion = worksheet.Cells[row, 1].Text;
                        string areaText = worksheet.Cells[row, 2].Text;
                        string radioxText = worksheet.Cells[row, 3].Text;
                        string radiozText = worksheet.Cells[row, 4].Text;
                        string wtText = worksheet.Cells[row, 5].Text;

                        if (string.IsNullOrWhiteSpace(seccion) &&
                            string.IsNullOrWhiteSpace(areaText) &&
                            string.IsNullOrWhiteSpace(radioxText) &&
                            string.IsNullOrWhiteSpace(radiozText) &&
                            string.IsNullOrWhiteSpace(wtText))
                        {
                            // Fila vacía, continuar con la siguiente fila
                            continue;
                        }

                        if (double.TryParse(areaText, out double area) &&
                            double.TryParse(radioxText, out double radiox) &&
                            double.TryParse(radiozText, out double radioz) &&
                            double.TryParse(wtText, out double wt))
                        {
                            seccionesData[seccion] = new SeccionData
                            {
                                Area = area,
                                RadioX = radiox,
                                RadioZ = radioz,
                                WT = wt
                            };

                            comboBox1.Items.Add(seccion);
                        }
                        else
                        {
                            MessageBox.Show($"Error al convertir los datos de la fila {row}. Verifica el formato del archivo Excel.\n" +
                                            $"Sección: {seccion}, Área: {areaText}, RadioX: {radioxText}, RadioZ: {radiozText}, W/T: {wtText}");
                        }
                    }
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo Excel no se encontró.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seccionSeleccionada = comboBox1.SelectedItem.ToString();
            if (seccionesData.ContainsKey(seccionSeleccionada))
            {
                SeccionData data = seccionesData[seccionSeleccionada];
                Area.Text = data.Area.ToString();
                X.Text = data.RadioX.ToString();
                Z.Text = data.RadioZ.ToString();
                Wt.Text = data.WT.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tiposDeAcero.Add("FyA36", FyA36);
            tiposDeAcero.Add("FyA572", FyA572);

            foreach (var tipoDeAcero in tiposDeAcero.Keys)
            {
                comboBox2.Items.Add(tipoDeAcero);
            }
        }
        public class SeccionData
        {
            public double Area { get; set; }
            public double RadioX { get; set; }
            public double RadioZ { get; set; }
            public double WT { get; set; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = comboBox2.SelectedItem.ToString();

            if (tiposDeAcero.TryGetValue(tipoSeleccionado, out double valorAcero))
            {
                Fy = valorAcero;
                labelAcero.Text = $"Valor del acero: {valorAcero}";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://ssg-s.pe",
                UseShellExecute = true
            });
        }

        private void Calculo_Click(object sender, EventArgs e)
        {
            double LX, LZ;
            if (!double.TryParse(XBox.Text, out LX) || !double.TryParse(ZBox.Text, out LZ))
            {
                MessageBox.Show("Por favor, ingrese valores válidos para las longitudes.");
                return;
            }

            string seccionSeleccionada = comboBox1.SelectedItem.ToString();
            if (!seccionesData.TryGetValue(seccionSeleccionada, out SeccionData seccionData))
            {
                MessageBox.Show("Seleccione una sección válida.");
                return;
            }

            double area = seccionData.Area;
            double radioX = seccionData.RadioX;
            double radioZ = seccionData.RadioZ;
            double wt = seccionData.WT;

            // Cálculo para X
            double ResultadoX = (LX * 100) / radioX;
            double resultadoXValor = CalcularResultado(ResultadoX, "X");

            // Cálculo para Z
            double ResultadoZ = (LZ * 100) / radioZ;
            double resultadoZValor = CalcularResultado(ResultadoZ, "Z");

            // Mostrar resultados
            if (double.IsNaN(resultadoXValor))
            {
                labelX.Text = "Sobrepasa el limite de esbeltez en X";
            }
            else
            {
                labelX.Text = $"KL/rx: {resultadoXValor}";
            }

            if (double.IsNaN(resultadoZValor))
            {
                labelZ.Text = "Sobrepasa el limite de esbeltez en Z";
            }
            else
            {
                labelZ.Text = $"KL/rz: {resultadoZValor}";
            }

            // Calcular KLr
            if (!double.IsNaN(resultadoXValor) && !double.IsNaN(resultadoZValor))
            {
                KLr = resultadoXValor > resultadoZValor ? resultadoXValor : resultadoZValor;
            }
            else if (!double.IsNaN(resultadoXValor))
            {
                KLr = resultadoXValor;
            }
            else if (!double.IsNaN(resultadoZValor))
            {
                KLr = resultadoZValor;
            }
            else
            {
                KLr = double.NaN;
                MessageBox.Show("Ambas direcciones sobrepasan el límite de esbeltez.");
            }

            if (!double.IsNaN(KLr))
            {
                labelr.Text = $"KLr: {KLr}";
            }
            //Calcular los resultados faltantes
            double Cc = (Math.PI * Math.Sqrt(2 * E / Fy));
            double Fa = 0;
            double Fcr1 = ((1.677 * 0.677) * (wt / (80 / Math.Sqrt(Fy / 6.9444)))) * Fy;
            double Fcr2 = (0.0332 * Math.Pow(Math.PI, 2) * E) / Math.Pow(wt, 2);

            if (KLr > Cc)
            {
                Fa = (Math.Pow(Math.PI, 2) * E) / (Math.Pow(KLr, 2));
            }
            else if (KLr < Cc && wt < (80 / Math.Sqrt(Fy / 6.9444)))
            {
                Fa = (1 - 0.5 * (Math.Pow((KLr / Cc), 2))) * Fy;
            }
            else if (KLr < Cc && wt > (80 / Math.Sqrt(Fy / 6.9444)) && wt <= 144 / Math.Sqrt(Fy / 6.9444))
            {
                Fa = (1 - 0.5 * (Math.Pow((KLr / Cc), 2))) * Fcr1;
            }
            else if (KLr < Cc && wt > 144 / Math.Sqrt(Fy / 6.9444))
            {
                Fa = (1 - 0.5 * (Math.Pow((KLr / Cc), 2))) * Fcr2;
            }

            double Ca = (area * Fa) * 100;

            labelr.Text = $"KL/r: {KLr}";
            labelCc.Text = $"Cc: {Cc}";
            labelFa.Text = $"Fa: {Fa}";
            labelwt.Text = $"W / T: {wt}";
            labelfy.Text = $"Fy: {Fy}";
            labelCa.Text = $"Ca: {Ca}";

        }
        private double CalcularResultado(double resultado, string direccion)
        {
            if (resultado >= 0 && resultado <= 120)
            {
                return MostrarMenuOpciones(resultado, 1, direccion);
            }
            else if (resultado > 120 && resultado <= 250)
            {
                return MostrarMenuOpciones(resultado, 2, direccion);
            }
            else
            {
                return double.NaN;
            }
        }
        private double MostrarMenuOpciones(double resultado, int tipoMenu, string direccion)
        {
            using (Form opcionesForm = new Form())
            {
                opcionesForm.Text = $"Seleccionar Opción para {direccion}";
                opcionesForm.Width = 300;
                opcionesForm.Height = 200;


                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                opcionesForm.Controls.Add(label);

                ComboBox comboBoxOpciones = new ComboBox() { Left = 50, Top = 50, Width = 200 };

                if (tipoMenu == 1)
                {
                    comboBoxOpciones.Items.Add("No excéntrico");
                    comboBoxOpciones.Items.Add("Excéntrico en un extremo");
                    comboBoxOpciones.Items.Add("Excéntrico en ambos extremos");
                }
                else if (tipoMenu == 2)
                {
                    comboBoxOpciones.Items.Add("Sin restricción a la rotación");
                    comboBoxOpciones.Items.Add("Restricción rotacional en un extremo");
                    comboBoxOpciones.Items.Add("Restricción rotacional en ambos extremos");
                }

                comboBoxOpciones.SelectedIndex = 0;

                Button buttonAceptar = new Button() { Text = "Aceptar", Left = 100, Width = 100, Top = 100 };
                buttonAceptar.DialogResult = DialogResult.OK;

                opcionesForm.Controls.Add(comboBoxOpciones);
                opcionesForm.Controls.Add(buttonAceptar);
                opcionesForm.AcceptButton = buttonAceptar;

                if (opcionesForm.ShowDialog() == DialogResult.OK)
                {
                    string opcionSeleccionada = comboBoxOpciones.SelectedItem.ToString();
                    double resultadoCalculado = resultado;

                    switch (opcionSeleccionada)
                    {
                        case "No excéntrico":
                            resultadoCalculado = resultado;
                            break;
                        case "Excéntrico en un extremo":
                            resultadoCalculado = 30 + 0.75 * resultado;
                            break;
                        case "Excéntrico en ambos extremos":
                            resultadoCalculado = 60 + 0.5 * resultado;
                            break;
                        case "Sin restricción a la rotación":
                            resultadoCalculado = resultado;
                            break;
                        case "Restricción rotacional en un extremo":
                            resultadoCalculado = 28.6 + 0.762 * resultado;
                            break;
                        case "Restricción rotacional en ambos extremos":
                            resultadoCalculado = 46.2 + 0.615 * resultado;
                            break;
                        default:
                            MessageBox.Show("Opción no válida");
                            return double.NaN;
                    }

                    string resultadoTexto = $"KL/r{direccion.ToLower()} = {resultadoCalculado}";
                    MessageBox.Show(resultadoTexto);
                    return resultadoCalculado;
                }
            }

            return double.NaN;
        }

    }
}
