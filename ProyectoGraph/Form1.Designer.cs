namespace ProyectoGraph
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Calculo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZBox = new System.Windows.Forms.TextBox();
            this.XBox = new System.Windows.Forms.TextBox();
            this.labelr = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Wt = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.Area = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelAcero = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelCc = new System.Windows.Forms.Label();
            this.labelFa = new System.Windows.Forms.Label();
            this.labelwt = new System.Windows.Forms.Label();
            this.labelfy = new System.Windows.Forms.Label();
            this.labelCa = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SECCIONES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Calculo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ZBox);
            this.groupBox1.Controls.Add(this.XBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compression";
            // 
            // Calculo
            // 
            this.Calculo.Location = new System.Drawing.Point(138, 83);
            this.Calculo.Name = "Calculo";
            this.Calculo.Size = new System.Drawing.Size(75, 23);
            this.Calculo.TabIndex = 4;
            this.Calculo.Text = "Calcular";
            this.Calculo.UseVisualStyleBackColor = true;
            this.Calculo.Click += new System.EventHandler(this.Calculo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Longitud arriostrada en Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Longitud arriostrada en X";
            // 
            // ZBox
            // 
            this.ZBox.Location = new System.Drawing.Point(138, 57);
            this.ZBox.Name = "ZBox";
            this.ZBox.Size = new System.Drawing.Size(217, 20);
            this.ZBox.TabIndex = 1;
            // 
            // XBox
            // 
            this.XBox.Location = new System.Drawing.Point(138, 31);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(217, 20);
            this.XBox.TabIndex = 0;
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(6, 16);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(31, 13);
            this.labelr.TabIndex = 2;
            this.labelr.Text = "KL/r:";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(200, 16);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(36, 13);
            this.labelZ.TabIndex = 1;
            this.labelZ.Text = "KL/rz:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(6, 16);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(36, 13);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "KL/rx:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Wt);
            this.groupBox3.Controls.Add(this.Z);
            this.groupBox3.Controls.Add(this.X);
            this.groupBox3.Controls.Add(this.Area);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(15, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 130);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de la Sección";
            // 
            // Wt
            // 
            this.Wt.AutoSize = true;
            this.Wt.Location = new System.Drawing.Point(120, 102);
            this.Wt.Name = "Wt";
            this.Wt.Size = new System.Drawing.Size(41, 13);
            this.Wt.TabIndex = 7;
            this.Wt.Text = "label11";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Location = new System.Drawing.Point(120, 75);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(41, 13);
            this.Z.TabIndex = 6;
            this.Z.Text = "label10";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(120, 48);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(35, 13);
            this.X.TabIndex = 5;
            this.X.Text = "label9";
            // 
            // Area
            // 
            this.Area.AutoSize = true;
            this.Area.Location = new System.Drawing.Point(120, 20);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(35, 13);
            this.Area.TabIndex = 4;
            this.Area.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "W / T =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Radio de giro en Z =";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Radio de giro en X =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Area de Perfil angular =";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelAcero);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Location = new System.Drawing.Point(218, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 130);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo de Acero";
            // 
            // labelAcero
            // 
            this.labelAcero.AutoSize = true;
            this.labelAcero.Location = new System.Drawing.Point(28, 87);
            this.labelAcero.Name = "labelAcero";
            this.labelAcero.Size = new System.Drawing.Size(81, 13);
            this.labelAcero.TabIndex = 2;
            this.labelAcero.Text = "Valor del acero:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Elija el tipo de acero";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(28, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 521);
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
            this.linkLabel1.Location = new System.Drawing.Point(191, 532);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(154, 16);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "SSG CAPACITACIONES";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelCc
            // 
            this.labelCc.AutoSize = true;
            this.labelCc.Location = new System.Drawing.Point(6, 41);
            this.labelCc.Name = "labelCc";
            this.labelCc.Size = new System.Drawing.Size(23, 13);
            this.labelCc.TabIndex = 3;
            this.labelCc.Text = "Cc:";
            // 
            // labelFa
            // 
            this.labelFa.AutoSize = true;
            this.labelFa.Location = new System.Drawing.Point(5, 65);
            this.labelFa.Name = "labelFa";
            this.labelFa.Size = new System.Drawing.Size(22, 13);
            this.labelFa.TabIndex = 4;
            this.labelFa.Text = "Fa:";
            // 
            // labelwt
            // 
            this.labelwt.AutoSize = true;
            this.labelwt.Location = new System.Drawing.Point(5, 89);
            this.labelwt.Name = "labelwt";
            this.labelwt.Size = new System.Drawing.Size(39, 13);
            this.labelwt.TabIndex = 5;
            this.labelwt.Text = "W / T:";
            // 
            // labelfy
            // 
            this.labelfy.AutoSize = true;
            this.labelfy.Location = new System.Drawing.Point(7, 113);
            this.labelfy.Name = "labelfy";
            this.labelfy.Size = new System.Drawing.Size(24, 13);
            this.labelfy.TabIndex = 6;
            this.labelfy.Text = "Fy: ";
            // 
            // labelCa
            // 
            this.labelCa.AutoSize = true;
            this.labelCa.Location = new System.Drawing.Point(7, 16);
            this.labelCa.Name = "labelCa";
            this.labelCa.Size = new System.Drawing.Size(26, 13);
            this.labelCa.TabIndex = 7;
            this.labelCa.Text = "Ca: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelX);
            this.groupBox2.Controls.Add(this.labelZ);
            this.groupBox2.Location = new System.Drawing.Point(15, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 34);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelr);
            this.groupBox5.Controls.Add(this.labelCc);
            this.groupBox5.Controls.Add(this.labelFa);
            this.groupBox5.Controls.Add(this.labelwt);
            this.groupBox5.Controls.Add(this.labelfy);
            this.groupBox5.Location = new System.Drawing.Point(15, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(382, 132);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resultados";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelCa);
            this.groupBox6.Location = new System.Drawing.Point(15, 474);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(382, 37);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fuerza Admisible";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 573);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ZBox;
        private System.Windows.Forms.TextBox XBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Wt;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label Area;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelAcero;
        private System.Windows.Forms.Button Calculo;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelFa;
        private System.Windows.Forms.Label labelCc;
        private System.Windows.Forms.Label labelwt;
        private System.Windows.Forms.Label labelfy;
        private System.Windows.Forms.Label labelCa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

