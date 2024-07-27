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

namespace Proyecto
{
    public partial class Opciones : Form
    {
        PictureBox pictureBox;
        public string OpcionSeleccionada { get; private set; }
        public double ResultadoCalculado { get; private set; }

        public Opciones(double resultado, int tipoMenu, string direccion)
        {
            InitializeComponent();

            if (pictureBox == null)
            {
                pictureBox = new PictureBox();
                pictureBox.Location = new System.Drawing.Point(13, 143); 
                pictureBox.Size = new System.Drawing.Size(297, 320);
                this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; 
                this.Controls.Add(pictureBox);
            }
            LabelText.Text = $"Seleccionar Opción para {direccion}";

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
            comboBoxOpciones.SelectedIndexChanged += comboBoxOpciones_SelectedIndexChanged;
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

        private void comboBoxOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = comboBoxOpciones.SelectedItem?.ToString();
            if (opcion != null)
            {
                try
                {
                    switch (opcion)
                    {
                        case "No excéntrico":
                            pictureBox.Image = Image.FromFile("Assets//excentricidad.png");
                            break;
                        case "Excéntrico en un extremo":
                            pictureBox.Image = Image.FromFile("Assets//excentricidad.png");
                            break;
                        case "Excéntrico en ambos extremos":
                            pictureBox.Image = Image.FromFile("Assets//excentricidad.png");
                            break;
                        case "Sin restricción a la rotación":
                            pictureBox.Image = Image.FromFile("Assets//restriccion.png");
                            break;
                        case "Restricción rotacional en un extremo":
                            pictureBox.Image = Image.FromFile("Assets//restriccion.png");
                            break;
                        case "Restricción rotacional en ambos extremos":
                            pictureBox.Image = Image.FromFile("Assets//restriccion.png");
                            break;
                        default:
                            pictureBox.Image = null;
                            break;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"Archivo no encontrado: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                }
            }
        }

        private void Opciones_Load_1(object sender, EventArgs e)
        {

        }
    }
}
