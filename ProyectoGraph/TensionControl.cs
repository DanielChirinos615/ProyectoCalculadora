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
        static double SyA36 = 250;
        static double SyA572 = 350;
        double Sy;
        private Calculadora calculadora;
        Dictionary<string, double> fluenciaAcero = new Dictionary<string, double>();
        private Dictionary<string, SeccionData> seccionesData = new Dictionary<string, SeccionData>();

        public TensionControl()
        {
            InitializeComponent();
        }

        public TensionControl(Calculadora calculadora) : this()
        {
            this.calculadora = calculadora;

            ExcelPackage.LicenseContext = ExcelLicenseContext.NonCommercial;
            calculadora.SeccionesComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            LlenarComboBoxSecciones(calculadora.GetSeccionesData());
            LlenarCtBox();
        }

        private void TensionControl_Load(object sender, EventArgs e)
        {
            fluenciaAcero.Add("SyA36", SyA36);
            fluenciaAcero.Add("SyA572", SyA572);

            foreach (var fluenciaAcero in fluenciaAcero.Keys)
            {
                comboBox2.Items.Add(fluenciaAcero);
            }
        }

        private void LlenarCtBox()
        {
            CtBox.Items.Clear();
            CtBox.Items.Add("Un ala empernada");
            CtBox.Items.Add("Dos alas empernadas");
            CtBox.SelectedIndex = 0;
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
                Espesor.Text = data.Espesor.ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seccionSeleccionada = calculadora.SeccionesComboBox.SelectedItem.ToString();
            ActualizarSeccionSeleccionada(seccionSeleccionada);
        }

        public TensionControlState GetState()
        {
            return new TensionControlState
            {
                SelectedSection = calculadora.SeccionesComboBox.SelectedItem?.ToString(),
                LabelArea = Area.Text,
                LabelEspesor = Espesor.Text,
                SeccionesData = this.seccionesData,
                LabelAn = labelAn.Text,
                LabelD = labelD.Text,
                LabelFt = labelFt.Text,
                LabelH = labelH.Text,
                DBox = DBox.Text,
                DaBox = DaBox.Text,
                HBox = HBox.Text,
                CtBox = CtBox.Text,
                Sy = comboBox2.Text,
                AceroF = labelAcero.Text
            };
        }

        public void SetState(TensionControlState state)
        {
            if (state.SelectedSection != null)
            {
                calculadora.SeccionesComboBox.SelectedItem = state.SelectedSection;
            }

            this.seccionesData = state.SeccionesData;
            Area.Text = state.LabelArea;
            Espesor.Text = state.LabelEspesor;
            labelAn.Text = state.LabelAn;
            labelD.Text = state.LabelD;
            labelFt.Text = state.LabelFt;
            labelH.Text = state.LabelH;
            DBox.Text = state.DBox;
            DaBox.Text = state.DaBox;
            HBox.Text = state.HBox;
            CtBox.Text = state.CtBox;
            comboBox2.Text = state.Sy;
            labelAcero.Text = state.AceroF;
        }

        private void Calculo_Click(object sender, EventArgs e)
        {
            double D, Da, H, Ft = 0;

            if (Sy == 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de acero.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(DBox.Text, out D) || !double.TryParse(DaBox.Text, out Da) || !double.TryParse(HBox.Text, out H))
            {
                MessageBox.Show("Por favor, ingrese valores válidos.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string seccionSeleccionada = calculadora.SeccionesComboBox.SelectedItem.ToString();
            if (!seccionesData.TryGetValue(seccionSeleccionada, out SeccionData seccionData))
            {
                MessageBox.Show("Seleccione una sección válida.");
                return;
            }

            double area = seccionData.Area;
            double espesor = seccionData.Espesor;

            // Área neta
            double An = area - ((espesor * Da) / 10.0) * H;

            // Capacidad de tracción

            int tipo = CtBox.SelectedIndex + 1;

            if (tipo == 1)
            {
                Ft = (Sy * An * 0.9) * 100;
            }
            else if (tipo == 2)
            {
                Ft = (Sy * An) * 100;
            }

            An = Math.Round(An, 4);
            Ft = Math.Round(Ft, 4);

            // Mostrar resultados
            labelD.Text = $"Tamaño de Perno: {D}";
            labelH.Text = $"Número de Agujeros: {H}";
            labelAn.Text = $"Área neta: {An}";
            labelFt.Text = $"Capacidad de tracción: {Ft}";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = comboBox2.SelectedItem.ToString();
            if (fluenciaAcero.TryGetValue(tipoSeleccionado, out double valorAcero))
            {
                Sy = valorAcero;
                labelAcero.Text = $"Valor del acero: {valorAcero}";
            }
        }
    }
}
