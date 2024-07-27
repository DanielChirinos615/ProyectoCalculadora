namespace Proyecto
{
    partial class Opciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opciones));
            this.AcceptButton = new System.Windows.Forms.Button();
            this.comboBoxOpciones = new System.Windows.Forms.ComboBox();
            this.LabelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(126, 98);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 1;
            this.AcceptButton.Text = "Aceptar";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // comboBoxOpciones
            // 
            this.comboBoxOpciones.FormattingEnabled = true;
            this.comboBoxOpciones.Location = new System.Drawing.Point(63, 51);
            this.comboBoxOpciones.Name = "comboBoxOpciones";
            this.comboBoxOpciones.Size = new System.Drawing.Size(200, 21);
            this.comboBoxOpciones.TabIndex = 0;
            this.comboBoxOpciones.SelectedIndexChanged += new System.EventHandler(this.comboBoxOpciones_SelectedIndexChanged);
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelText.Location = new System.Drawing.Point(68, 19);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(169, 20);
            this.LabelText.TabIndex = 1;
            this.LabelText.Text = "Seleccione una opción";
            // 
            // Opciones
            // 
            this.ClientSize = new System.Drawing.Size(326, 498);
            this.ControlBox = false;
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.comboBoxOpciones);
            this.Controls.Add(this.AcceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Opciones";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Opciones_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ComboBox comboBoxOpciones;
        private System.Windows.Forms.Label LabelText;
    }
}