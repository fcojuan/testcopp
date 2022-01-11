namespace Rinku
{
    partial class cEmpleado
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSueldo = new System.Windows.Forms.NumericUpDown();
            this.lblHrs = new System.Windows.Forms.Label();
            this.cBoxJornada = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblrol = new System.Windows.Forms.Label();
            this.cBoxRol = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblnom = new System.Windows.Forms.Label();
            this.lblcod = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSourceEmp = new System.Windows.Forms.BindingSource(this.components);
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSueldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 252);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(758, 211);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.numSueldo);
            this.groupBox1.Controls.Add(this.lblHrs);
            this.groupBox1.Controls.Add(this.cBoxJornada);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBoxTipo);
            this.groupBox1.Controls.Add(this.lblrol);
            this.groupBox1.Controls.Add(this.cBoxRol);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblnom);
            this.groupBox1.Controls.Add(this.lblcod);
            this.groupBox1.Controls.Add(this.txtCod);
            this.groupBox1.Location = new System.Drawing.Point(1, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // numSueldo
            // 
            this.numSueldo.DecimalPlaces = 2;
            this.numSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSueldo.Location = new System.Drawing.Point(179, 137);
            this.numSueldo.Name = "numSueldo";
            this.numSueldo.Size = new System.Drawing.Size(89, 26);
            this.numSueldo.TabIndex = 9;
            this.numSueldo.Tag = "4";
            this.numSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSueldo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSueldo_KeyDown);
            this.numSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numSueldo_KeyPress);
            // 
            // lblHrs
            // 
            this.lblHrs.AutoSize = true;
            this.lblHrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHrs.Location = new System.Drawing.Point(584, 147);
            this.lblHrs.Name = "lblHrs";
            this.lblHrs.Size = new System.Drawing.Size(49, 16);
            this.lblHrs.TabIndex = 13;
            this.lblHrs.Text = "Horas";
            // 
            // cBoxJornada
            // 
            this.cBoxJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxJornada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxJornada.FormattingEnabled = true;
            this.cBoxJornada.Location = new System.Drawing.Point(503, 135);
            this.cBoxJornada.Name = "cBoxJornada";
            this.cBoxJornada.Size = new System.Drawing.Size(75, 28);
            this.cBoxJornada.TabIndex = 10;
            this.cBoxJornada.Tag = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jornada Laboral";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sueldo Por Hora";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(216, 29);
            this.txtID.MaxLength = 5;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 26);
            this.txtID.TabIndex = 8;
            this.txtID.Tag = "0";
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo";
            // 
            // cBoxTipo
            // 
            this.cBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxTipo.FormattingEnabled = true;
            this.cBoxTipo.Location = new System.Drawing.Point(457, 93);
            this.cBoxTipo.Name = "cBoxTipo";
            this.cBoxTipo.Size = new System.Drawing.Size(234, 28);
            this.cBoxTipo.TabIndex = 8;
            this.cBoxTipo.Tag = "3";
            // 
            // lblrol
            // 
            this.lblrol.AutoSize = true;
            this.lblrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrol.Location = new System.Drawing.Point(43, 105);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(31, 16);
            this.lblrol.TabIndex = 5;
            this.lblrol.Text = "Rol";
            // 
            // cBoxRol
            // 
            this.cBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxRol.FormattingEnabled = true;
            this.cBoxRol.Location = new System.Drawing.Point(110, 93);
            this.cBoxRol.Name = "cBoxRol";
            this.cBoxRol.Size = new System.Drawing.Size(234, 28);
            this.cBoxRol.TabIndex = 7;
            this.cBoxRol.Tag = "2";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(110, 61);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(581, 26);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Tag = "1";
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // lblnom
            // 
            this.lblnom.AutoSize = true;
            this.lblnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnom.Location = new System.Drawing.Point(43, 71);
            this.lblnom.Name = "lblnom";
            this.lblnom.Size = new System.Drawing.Size(62, 16);
            this.lblnom.TabIndex = 2;
            this.lblnom.Text = "Nombre";
            // 
            // lblcod
            // 
            this.lblcod.AutoSize = true;
            this.lblcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcod.Location = new System.Drawing.Point(43, 39);
            this.lblcod.Name = "lblcod";
            this.lblcod.Size = new System.Drawing.Size(57, 16);
            this.lblcod.TabIndex = 1;
            this.lblcod.Text = "Codigo";
            // 
            // txtCod
            // 
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(110, 29);
            this.txtCod.MaxLength = 5;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 26);
            this.txtCod.TabIndex = 5;
            this.txtCod.Tag = "0";
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(18, 22);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(95, 30);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "&Nuevo";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(345, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 30);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(128, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(458, 26);
            this.txtsearch.MaxLength = 5;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(290, 26);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.Tag = "0";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(455, 9);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(77, 16);
            this.lblsearch.TabIndex = 6;
            this.lblsearch.Text = "Busqueda";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(523, 466);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(143, 16);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Empleados Totales";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Modificar o Eliminar Empleado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Buscar Empleado Por Codigo o Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Seleccionar Registro En La Tabla";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Brown;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(235, 22);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(95, 30);
            this.btnBorrar.TabIndex = 3;
            this.btnBorrar.Text = "&Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // cEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 526);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Name = "cEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo de empleados";
            this.Load += new System.EventHandler(this.cEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSueldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lblcod;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblnom;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxTipo;
        private System.Windows.Forms.Label lblrol;
        private System.Windows.Forms.ComboBox cBoxRol;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSourceEmp;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cBoxJornada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHrs;
        private System.Windows.Forms.NumericUpDown numSueldo;
    }
}

