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
    public partial class Opciones : Form
    {
        public string OpcionSeleccionada { get; private set; }
        public double ResultadoCalculado { get; private set; }

        public Opciones(double resultado, int tipoMenu, string direccion)
        {
            InitializeComponent();
            base.Text = $"Seleccionar Opción para {direccion}";
            Width = 300;
            Height = 200;

            // Ajusta las opciones del ComboBox según el tipo de menú
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

            AcceptButton.Click += (sender, e) =>
            {
                OpcionSeleccionada = comboBoxOpciones.SelectedItem?.ToString();
                if (OpcionSeleccionada != null)
                {
                    ResultadoCalculado = CalcularResultado(OpcionSeleccionada, resultado);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Seleccione una opción válida.");
                }
            };
        }

        private double CalcularResultado(string opcionSeleccionada, double resultado)
        {
            switch (opcionSeleccionada)
            {
                case "No excéntrico":
                    return resultado;
                case "Excéntrico en un extremo":
                    return 30 + 0.75 * resultado;
                case "Excéntrico en ambos extremos":
                    return 60 + 0.5 * resultado;
                case "Sin restricción a la rotación":
                    return resultado;
                case "Restricción rotacional en un extremo":
                    return 28.6 + 0.762 * resultado;
                case "Restricción rotacional en ambos extremos":
                    return 46.2 + 0.615 * resultado;
                default:
                    throw new ArgumentOutOfRangeException("Opción no válida");
            }
        }

        private void Opciones_Load(object sender, EventArgs e) { }

        private void acceptButtom_Click(object sender, EventArgs e)
        {
        }
    }
}
