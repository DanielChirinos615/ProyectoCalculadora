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
        private Dictionary<string, SeccionDataT> seccionesDataT = new Dictionary<string, SeccionDataT>();
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
        public Dictionary<string, SeccionDataT> GetSeccionesDataT()
        {
            return seccionesDataT;
        }

        public ComboBox SeccionesComboBox
        {
            get { return comboBox1; }
        }

        private void MostrarControlInicial()
        {
            CompressionControl controlInicial = new CompressionControl(this); 
            TensionControl controlInicialT = new TensionControl(this);

            controlInicial.Dock = DockStyle.Fill;
            controlInicialT.Dock = DockStyle.Fill;

            panel1.Controls.Add(controlInicial);
            panel1.Controls.Add(controlInicialT);
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            MostrarControlInicial();
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
            //else if (panel1.Controls.Count > 0 && panel1.Controls[0] is TensionControl tensionControl)
            //{
            //    tensionControlState = tensionControl.GetState();
            //}

            TensionControl newTensionControl = new TensionControl(this);
            panel1.Controls.Clear();
            newTensionControl.Dock = DockStyle.Fill;

            //if (tensionControlState != null)
            //{
            //    newTensionControl.SetState(tensionControlState);
            //}

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
            //else if (panel1.Controls.Count > 0 && panel1.Controls[0] is TensionControl tensionControl)
            //{
            //    tensionControlState = tensionControl.GetState();
            //}

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
            if (panel1.Controls.Count > 0 && panel1.Controls[0] is CompressionControl compressionControl)
            {
                compressionControl.ActualizarSeccionSeleccionada(comboBox1.SelectedItem.ToString());
            }
            if (panel1.Controls.Count > 0 && panel1.Controls[0] is TensionControl tensionControl)
            {
                tensionControl.ActualizarSeccionSeleccionada(comboBox1.SelectedItem.ToString());
            }
        }
    }
}
