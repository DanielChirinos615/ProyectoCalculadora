namespace ProyectoGraph
{
    partial class Calculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelModo = new System.Windows.Forms.Label();
            this.compressionButton = new System.Windows.Forms.Button();
            this.tensionButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 554);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(191, 565);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(154, 16);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "SSG CAPACITACIONES";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelModo
            // 
            this.labelModo.AutoSize = true;
            this.labelModo.Location = new System.Drawing.Point(21, 18);
            this.labelModo.Name = "labelModo";
            this.labelModo.Size = new System.Drawing.Size(47, 13);
            this.labelModo.TabIndex = 11;
            this.labelModo.Text = "MODOS";
            // 
            // compressionButton
            // 
            this.compressionButton.Location = new System.Drawing.Point(127, 11);
            this.compressionButton.Name = "compressionButton";
            this.compressionButton.Size = new System.Drawing.Size(75, 23);
            this.compressionButton.TabIndex = 12;
            this.compressionButton.Text = "Compression";
            this.compressionButton.UseVisualStyleBackColor = true;
            this.compressionButton.Click += new System.EventHandler(this.compressionButton_Click);
            // 
            // tensionButton
            // 
            this.tensionButton.Location = new System.Drawing.Point(237, 11);
            this.tensionButton.Name = "tensionButton";
            this.tensionButton.Size = new System.Drawing.Size(75, 23);
            this.tensionButton.TabIndex = 13;
            this.tensionButton.Text = "Tension";
            this.tensionButton.UseVisualStyleBackColor = true;
            this.tensionButton.Click += new System.EventHandler(this.tensionButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 514);
            this.panel1.TabIndex = 14;
            // 
            // Compression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tensionButton);
            this.Controls.Add(this.compressionButton);
            this.Controls.Add(this.labelModo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Compression";
            this.Text = "Calculadora";
            this.Load += new System.EventHandler(this.Compression_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelModo;
        private System.Windows.Forms.Button compressionButton;
        private System.Windows.Forms.Button tensionButton;
        private System.Windows.Forms.Panel panel1;
    }
}

