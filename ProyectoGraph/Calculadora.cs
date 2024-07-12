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


namespace ProyectoGraph
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        private void Compression_Load(object sender, EventArgs e)
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
            TensionControl tensionControl = new TensionControl();
            panel1.Controls.Clear();

            tensionControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(tensionControl);
        }

        private void compressionButton_Click(object sender, EventArgs e)
        {
            Escenas_Compression();
        }

        private void Escenas_Compression()
        {
            CompressionControl compressionControl = new CompressionControl();

            panel1.Controls.Clear();

            compressionControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(compressionControl);
        }

        private void MostrarControlInicial()
        {
            CompressionControl controlInicial = new CompressionControl();

            controlInicial.Dock = DockStyle.Fill;

            panel1.Controls.Add(controlInicial);
        }

    }
}
