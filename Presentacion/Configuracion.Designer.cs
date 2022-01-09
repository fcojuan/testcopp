namespace Rinku.Presentacion
{
    partial class Configuracion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nComiEnt = new System.Windows.Forms.NumericUpDown();
            this.checkComEntrega = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nBonoHrs = new System.Windows.Forms.NumericUpDown();
            this.checkBonoHrs = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nComiCarga = new System.Windows.Forms.NumericUpDown();
            this.checkComiCarga = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nSueldoSobrepasa = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nISRSobrapasa = new System.Windows.Forms.NumericUpDown();
            this.nISR = new System.Windows.Forms.NumericUpDown();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nComiEnt)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBonoHrs)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nComiCarga)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoSobrepasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nISRSobrapasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nISR)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nComiEnt);
            this.groupBox1.Controls.Add(this.checkComEntrega);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagar Comision Por Entrega";
            // 
            // nComiEnt
            // 
            this.nComiEnt.DecimalPlaces = 2;
            this.nComiEnt.Location = new System.Drawing.Point(57, 79);
            this.nComiEnt.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nComiEnt.Name = "nComiEnt";
            this.nComiEnt.Size = new System.Drawing.Size(120, 26);
            this.nComiEnt.TabIndex = 3;
            this.nComiEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nComiEnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nComiEnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nComiEnt_KeyPress);
            // 
            // checkComEntrega
            // 
            this.checkComEntrega.AutoSize = true;
            this.checkComEntrega.Location = new System.Drawing.Point(18, 49);
            this.checkComEntrega.Name = "checkComEntrega";
            this.checkComEntrega.Size = new System.Drawing.Size(172, 24);
            this.checkComEntrega.TabIndex = 2;
            this.checkComEntrega.Text = "Generar Comision";
            this.checkComEntrega.UseVisualStyleBackColor = true;
            this.checkComEntrega.CheckedChanged += new System.EventHandler(this.checkComEntrega_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "En Su Jornada Laboral";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nBonoHrs);
            this.groupBox2.Controls.Add(this.checkBonoHrs);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(350, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pagar Bono Por Hora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choferes";
            // 
            // nBonoHrs
            // 
            this.nBonoHrs.DecimalPlaces = 2;
            this.nBonoHrs.Location = new System.Drawing.Point(57, 79);
            this.nBonoHrs.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nBonoHrs.Name = "nBonoHrs";
            this.nBonoHrs.Size = new System.Drawing.Size(120, 26);
            this.nBonoHrs.TabIndex = 3;
            this.nBonoHrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nBonoHrs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nBonoHrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nBonoHrs_KeyPress);
            // 
            // checkBonoHrs
            // 
            this.checkBonoHrs.AutoSize = true;
            this.checkBonoHrs.Location = new System.Drawing.Point(18, 49);
            this.checkBonoHrs.Name = "checkBonoHrs";
            this.checkBonoHrs.Size = new System.Drawing.Size(172, 24);
            this.checkBonoHrs.TabIndex = 2;
            this.checkBonoHrs.Text = "Generar Comision";
            this.checkBonoHrs.UseVisualStyleBackColor = true;
            this.checkBonoHrs.CheckedChanged += new System.EventHandler(this.checkBonoHrs_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nComiCarga);
            this.groupBox3.Controls.Add(this.checkComiCarga);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(26, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 128);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pagar Bono Por Hora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cargadores";
            // 
            // nComiCarga
            // 
            this.nComiCarga.DecimalPlaces = 2;
            this.nComiCarga.Location = new System.Drawing.Point(57, 79);
            this.nComiCarga.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nComiCarga.Name = "nComiCarga";
            this.nComiCarga.Size = new System.Drawing.Size(120, 26);
            this.nComiCarga.TabIndex = 3;
            this.nComiCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nComiCarga.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nComiCarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nComiCarga_KeyPress);
            // 
            // checkComiCarga
            // 
            this.checkComiCarga.AutoSize = true;
            this.checkComiCarga.Location = new System.Drawing.Point(18, 49);
            this.checkComiCarga.Name = "checkComiCarga";
            this.checkComiCarga.Size = new System.Drawing.Size(172, 24);
            this.checkComiCarga.TabIndex = 2;
            this.checkComiCarga.Text = "Generar Comision";
            this.checkComiCarga.UseVisualStyleBackColor = true;
            this.checkComiCarga.CheckedChanged += new System.EventHandler(this.checkComiCarga_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(194, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.nSueldoSobrepasa);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.nISRSobrapasa);
            this.groupBox4.Controls.Add(this.nISR);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(350, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 157);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuración General";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "ISR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Descontar ISR ";
            // 
            // nSueldoSobrepasa
            // 
            this.nSueldoSobrepasa.DecimalPlaces = 2;
            this.nSueldoSobrepasa.Location = new System.Drawing.Point(64, 125);
            this.nSueldoSobrepasa.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nSueldoSobrepasa.Name = "nSueldoSobrepasa";
            this.nSueldoSobrepasa.Size = new System.Drawing.Size(129, 26);
            this.nSueldoSobrepasa.TabIndex = 8;
            this.nSueldoSobrepasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSueldoSobrepasa.ThousandsSeparator = true;
            this.nSueldoSobrepasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nSueldoSobrepasa_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Si Sueldo Mensual Sobrepasa";
            // 
            // nISRSobrapasa
            // 
            this.nISRSobrapasa.DecimalPlaces = 2;
            this.nISRSobrapasa.Location = new System.Drawing.Point(138, 75);
            this.nISRSobrapasa.Name = "nISRSobrapasa";
            this.nISRSobrapasa.Size = new System.Drawing.Size(65, 26);
            this.nISRSobrapasa.TabIndex = 4;
            this.nISRSobrapasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nISRSobrapasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nISRSobrapasa_KeyPress);
            // 
            // nISR
            // 
            this.nISR.DecimalPlaces = 2;
            this.nISR.Location = new System.Drawing.Point(64, 25);
            this.nISR.Name = "nISR";
            this.nISR.Size = new System.Drawing.Size(73, 26);
            this.nISR.TabIndex = 3;
            this.nISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nISR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nISR_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(338, 344);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 30);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(655, 386);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nComiEnt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nBonoHrs)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nComiCarga)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoSobrepasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nISRSobrapasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nISR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nComiEnt;
        private System.Windows.Forms.CheckBox checkComEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nBonoHrs;
        private System.Windows.Forms.CheckBox checkBonoHrs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nComiCarga;
        private System.Windows.Forms.CheckBox checkComiCarga;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nSueldoSobrepasa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nISRSobrapasa;
        private System.Windows.Forms.NumericUpDown nISR;
        private System.Windows.Forms.Button btnSalir;
    }
}