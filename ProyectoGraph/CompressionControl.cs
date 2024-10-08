﻿using ExcelLicenseContext = OfficeOpenXml.LicenseContext;
using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ProyectoGraph;

namespace Proyecto
{
    public partial class CompressionControl : UserControl
    {
        static double E = 200000;
        static double FyA36 = 250;
        static double FyA572 = 350;
        double KLr = 0, Fy;
        private Calculadora calculadora;
        Dictionary<string, double> tiposDeAcero = new Dictionary<string, double>();
        private Dictionary<string, SeccionData> seccionesData = new Dictionary<string, SeccionData>();

        public CompressionControl()
        {
            InitializeComponent();
        }

        public CompressionControl(Calculadora calculadora) : this()
        {
            this.calculadora = calculadora;

            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
            calculadora.SeccionesComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            LlenarComboBoxSecciones(calculadora.GetSeccionesData());
        }

        public void CargarDatos()
        {
            calculadora.CargarDatosEnComboBox();
        }

        public void ActualizarSeccionSeleccionada(string seccionSeleccionada)
        {
            if (seccionesData.ContainsKey(seccionSeleccionada))
            {
                SeccionData data = seccionesData[seccionSeleccionada];
                Area.Text = data.Area.ToString();
                X.Text = data.RadioX.ToString();
                Z.Text = data.RadioZ.ToString();
                Wt.Text = data.WT.ToString();
            }
        }
        public void LlenarComboBoxSecciones(Dictionary<string, SeccionData> secciones)
        {
            seccionesData = secciones;
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

        private void Control_Load(object sender, EventArgs e)
        {
            tiposDeAcero.Add("FyA36", FyA36);
            tiposDeAcero.Add("FyA572", FyA572);

            foreach (var tipoDeAcero in tiposDeAcero.Keys)
            {
                comboBox2.Items.Add(tipoDeAcero);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seccionSeleccionada = calculadora.SeccionesComboBox.SelectedItem.ToString();
            ActualizarSeccionSeleccionada(seccionSeleccionada);
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


        private void Calculo_Click_1(object sender, EventArgs e)
        {
            if (Fy == 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de acero.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double LX, LZ;
            if (!double.TryParse(XBox.Text, out LX) || !double.TryParse(ZBox.Text, out LZ))
            {
                MessageBox.Show("Por favor, ingrese valores válidos para las longitudes.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string seccionSeleccionada = calculadora.SeccionesComboBox.SelectedItem.ToString();
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
            using (Opciones opcionesForm = new Opciones(resultado, tipoMenu, direccion))
            {
                if (opcionesForm.ShowDialog() == DialogResult.OK)
                {
                    string opcionSeleccionada = opcionesForm.OpcionSeleccionada;
                    double resultadoCalculado = opcionesForm.ResultadoCalculado;
                    return resultadoCalculado;
                }
            }
            return double.NaN;
        }
        public CompressionControlState GetState()
        {
            return new CompressionControlState
            {
                SelectedSection = calculadora.SeccionesComboBox.SelectedItem?.ToString(),
                SelectedSteel = comboBox2.SelectedItem?.ToString(),
                Lx = double.TryParse(XBox.Text, out double lx) ? lx : 0,
                Lz = double.TryParse(ZBox.Text, out double lz) ? lz : 0,
                LabelArea = Area.Text,
                Fy = this.Fy,
                SeccionesData = this.seccionesData,
                LabelX = labelX.Text,
                LabelZ = labelZ.Text,
                LabelWt = Wt.Text,
                LabelKLr = labelr.Text,
                LabelCc = labelCc.Text,
                LabelFa = labelFa.Text,
                LabelCa = labelCa.Text,
                Acero = labelAcero.Text
            };
        }

        public void SetState(CompressionControlState state)
        {
            if (state.SelectedSection != null)
            {
                calculadora.SeccionesComboBox.SelectedItem = state.SelectedSection;
            }

            if (state.SelectedSteel != null)
            {
                comboBox2.SelectedItem = state.SelectedSteel;
            }
            this.Fy = state.Fy;
            this.seccionesData = state.SeccionesData;
            XBox.Text = state.Lx.ToString();
            ZBox.Text = state.Lz.ToString();
            Area.Text = state.LabelArea;
            labelX.Text = state.LabelX;
            labelZ.Text = state.LabelZ;
            Wt.Text = state.LabelWt;
            labelr.Text = state.LabelKLr;
            labelCc.Text = state.LabelCc;
            labelFa.Text = state.LabelFa;
            labelCa.Text = state.LabelCa;
            labelAcero.Text = state.Acero;
        }
    }
}

