namespace ManejadorBDA
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
            this.components = new System.ComponentModel.Container();
            this.AgregaTabla = new System.Windows.Forms.Button();
            this.txtBAgrega = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.abrirBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.modificarBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarBaseDeDatosActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbTablas = new System.Windows.Forms.ComboBox();
            this.labNombreBD = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageAtributos = new System.Windows.Forms.TabPage();
            this.cmbTablasPK = new System.Windows.Forms.ComboBox();
            this.txtBoxLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgAtributos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoIndice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminaAtr = new System.Windows.Forms.Button();
            this.cmbtipoIndice = new System.Windows.Forms.ComboBox();
            this.btnModificaAtr = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAltaAtr = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNomAtribut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabPageRegistros = new System.Windows.Forms.TabPage();
            this.btConsultas = new System.Windows.Forms.Button();
            this.btEliminaRegistro = new System.Windows.Forms.Button();
            this.btModificaRegistro = new System.Windows.Forms.Button();
            this.NewAdd = new System.Windows.Forms.Button();
            this.dgRegistros = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnModificaTabla = new System.Windows.Forms.Button();
            this.btEliminaTabla = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPageAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtributos)).BeginInit();
            this.TabPageRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // AgregaTabla
            // 
            this.AgregaTabla.Enabled = false;
            this.AgregaTabla.Location = new System.Drawing.Point(12, 55);
            this.AgregaTabla.Name = "AgregaTabla";
            this.AgregaTabla.Size = new System.Drawing.Size(80, 23);
            this.AgregaTabla.TabIndex = 0;
            this.AgregaTabla.Text = "Agrega Tabla";
            this.AgregaTabla.UseVisualStyleBackColor = true;
            this.AgregaTabla.Click += new System.EventHandler(this.AgregaTabla_Click);
            // 
            // txtBAgrega
            // 
            this.txtBAgrega.Enabled = false;
            this.txtBAgrega.Location = new System.Drawing.Point(116, 56);
            this.txtBAgrega.Name = "txtBAgrega";
            this.txtBAgrega.Size = new System.Drawing.Size(131, 20);
            this.txtBAgrega.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaBaseDeDatosToolStripMenuItem,
            this.toolStripSeparator1,
            this.abrirBaseDeDatosToolStripMenuItem,
            this.toolStripSeparator2,
            this.modificarBaseDeDatosToolStripMenuItem,
            this.toolStripSeparator3,
            this.eliminarBaseDeDatosActualToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaBaseDeDatosToolStripMenuItem
            // 
            this.nuevaBaseDeDatosToolStripMenuItem.Name = "nuevaBaseDeDatosToolStripMenuItem";
            this.nuevaBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.nuevaBaseDeDatosToolStripMenuItem.Text = "Nueva Base De Datos";
            this.nuevaBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.nuevaBaseDeDatosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // abrirBaseDeDatosToolStripMenuItem
            // 
            this.abrirBaseDeDatosToolStripMenuItem.Name = "abrirBaseDeDatosToolStripMenuItem";
            this.abrirBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.abrirBaseDeDatosToolStripMenuItem.Text = "Abrir Base De Datos";
            this.abrirBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.abrirBaseDeDatosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // modificarBaseDeDatosToolStripMenuItem
            // 
            this.modificarBaseDeDatosToolStripMenuItem.Enabled = false;
            this.modificarBaseDeDatosToolStripMenuItem.Name = "modificarBaseDeDatosToolStripMenuItem";
            this.modificarBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.modificarBaseDeDatosToolStripMenuItem.Text = "Modificar Base De Datos";
            this.modificarBaseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.modificarBaseDeDatosToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(228, 6);
            // 
            // eliminarBaseDeDatosActualToolStripMenuItem
            // 
            this.eliminarBaseDeDatosActualToolStripMenuItem.Enabled = false;
            this.eliminarBaseDeDatosActualToolStripMenuItem.Name = "eliminarBaseDeDatosActualToolStripMenuItem";
            this.eliminarBaseDeDatosActualToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.eliminarBaseDeDatosActualToolStripMenuItem.Text = "Eliminar Base De Datos Actual";
            this.eliminarBaseDeDatosActualToolStripMenuItem.Click += new System.EventHandler(this.eliminarBaseDeDatosActualToolStripMenuItem_Click);
            // 
            // cmbTablas
            // 
            this.cmbTablas.AllowDrop = true;
            this.cmbTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablas.Enabled = false;
            this.cmbTablas.FormattingEnabled = true;
            this.cmbTablas.Location = new System.Drawing.Point(269, 56);
            this.cmbTablas.Name = "cmbTablas";
            this.cmbTablas.Size = new System.Drawing.Size(131, 21);
            this.cmbTablas.TabIndex = 3;
            this.cmbTablas.SelectedIndexChanged += new System.EventHandler(this.cmbTablas_SelectedIndexChanged);
            // 
            // labNombreBD
            // 
            this.labNombreBD.AutoSize = true;
            this.labNombreBD.Location = new System.Drawing.Point(231, 24);
            this.labNombreBD.Name = "labNombreBD";
            this.labNombreBD.Size = new System.Drawing.Size(88, 13);
            this.labNombreBD.TabIndex = 4;
            this.labNombreBD.Text = "Nombre de la BD";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPageAtributos);
            this.TabControl1.Controls.Add(this.TabPageRegistros);
            this.TabControl1.Location = new System.Drawing.Point(12, 84);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(594, 307);
            this.TabControl1.TabIndex = 5;
            this.TabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // TabPageAtributos
            // 
            this.TabPageAtributos.Controls.Add(this.cmbTablasPK);
            this.TabPageAtributos.Controls.Add(this.txtBoxLong);
            this.TabPageAtributos.Controls.Add(this.label5);
            this.TabPageAtributos.Controls.Add(this.dgAtributos);
            this.TabPageAtributos.Controls.Add(this.btnEliminaAtr);
            this.TabPageAtributos.Controls.Add(this.cmbtipoIndice);
            this.TabPageAtributos.Controls.Add(this.btnModificaAtr);
            this.TabPageAtributos.Controls.Add(this.label6);
            this.TabPageAtributos.Controls.Add(this.btnAltaAtr);
            this.TabPageAtributos.Controls.Add(this.cmbTipo);
            this.TabPageAtributos.Controls.Add(this.label4);
            this.TabPageAtributos.Controls.Add(this.txtBoxNomAtribut);
            this.TabPageAtributos.Controls.Add(this.label3);
            this.TabPageAtributos.Location = new System.Drawing.Point(4, 22);
            this.TabPageAtributos.Name = "TabPageAtributos";
            this.TabPageAtributos.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAtributos.Size = new System.Drawing.Size(586, 281);
            this.TabPageAtributos.TabIndex = 1;
            this.TabPageAtributos.Text = "Atributos";
            this.TabPageAtributos.UseVisualStyleBackColor = true;
            // 
            // cmbTablasPK
            // 
            this.cmbTablasPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablasPK.Enabled = false;
            this.cmbTablasPK.FormattingEnabled = true;
            this.cmbTablasPK.Location = new System.Drawing.Point(187, 11);
            this.cmbTablasPK.Name = "cmbTablasPK";
            this.cmbTablasPK.Size = new System.Drawing.Size(121, 21);
            this.cmbTablasPK.TabIndex = 39;
            this.cmbTablasPK.SelectedIndexChanged += new System.EventHandler(this.cmbTablasPK_SelectedIndexChanged);
            // 
            // txtBoxLong
            // 
            this.txtBoxLong.Location = new System.Drawing.Point(466, 50);
            this.txtBoxLong.Name = "txtBoxLong";
            this.txtBoxLong.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLong.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Longitud";
            // 
            // dgAtributos
            // 
            this.dgAtributos.AllowUserToAddRows = false;
            this.dgAtributos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAtributos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Tipo,
            this.TipoIndice,
            this.Longitud});
            this.dgAtributos.Location = new System.Drawing.Point(19, 92);
            this.dgAtributos.Name = "dgAtributos";
            this.dgAtributos.ReadOnly = true;
            this.dgAtributos.Size = new System.Drawing.Size(547, 166);
            this.dgAtributos.TabIndex = 36;
            this.dgAtributos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAtributos_CellClick);
            this.dgAtributos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAtributos_CellDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // TipoIndice
            // 
            this.TipoIndice.HeaderText = "TipoIndice";
            this.TipoIndice.Name = "TipoIndice";
            this.TipoIndice.ReadOnly = true;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "Longitud";
            this.Longitud.Name = "Longitud";
            this.Longitud.ReadOnly = true;
            // 
            // btnEliminaAtr
            // 
            this.btnEliminaAtr.Location = new System.Drawing.Point(491, 9);
            this.btnEliminaAtr.Name = "btnEliminaAtr";
            this.btnEliminaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnEliminaAtr.TabIndex = 34;
            this.btnEliminaAtr.Text = "Elimina";
            this.btnEliminaAtr.UseVisualStyleBackColor = true;
            this.btnEliminaAtr.Click += new System.EventHandler(this.btnEliminaAtr_Click);
            // 
            // cmbtipoIndice
            // 
            this.cmbtipoIndice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoIndice.FormattingEnabled = true;
            this.cmbtipoIndice.Items.AddRange(new object[] {
            "Clave Foranea",
            "Clave Primaria",
            "Sin Llave"});
            this.cmbtipoIndice.Location = new System.Drawing.Point(83, 11);
            this.cmbtipoIndice.Name = "cmbtipoIndice";
            this.cmbtipoIndice.Size = new System.Drawing.Size(83, 21);
            this.cmbtipoIndice.Sorted = true;
            this.cmbtipoIndice.TabIndex = 32;
            this.cmbtipoIndice.SelectedIndexChanged += new System.EventHandler(this.cmbtipoIndice_SelectedIndexChanged);
            // 
            // btnModificaAtr
            // 
            this.btnModificaAtr.Location = new System.Drawing.Point(410, 9);
            this.btnModificaAtr.Name = "btnModificaAtr";
            this.btnModificaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnModificaAtr.TabIndex = 35;
            this.btnModificaAtr.Text = "Modifica";
            this.btnModificaAtr.UseVisualStyleBackColor = true;
            this.btnModificaAtr.Click += new System.EventHandler(this.btnModificaAtr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Tipo Indice";
            // 
            // btnAltaAtr
            // 
            this.btnAltaAtr.Location = new System.Drawing.Point(329, 9);
            this.btnAltaAtr.Name = "btnAltaAtr";
            this.btnAltaAtr.Size = new System.Drawing.Size(75, 23);
            this.btnAltaAtr.TabIndex = 33;
            this.btnAltaAtr.Text = "Alta";
            this.btnAltaAtr.UseVisualStyleBackColor = true;
            this.btnAltaAtr.Click += new System.EventHandler(this.btnAltaAtr_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Entero",
            "Flotante",
            "Cadena"});
            this.cmbTipo.Location = new System.Drawing.Point(218, 49);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 28;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tipo";
            // 
            // txtBoxNomAtribut
            // 
            this.txtBoxNomAtribut.Location = new System.Drawing.Point(66, 50);
            this.txtBoxNomAtribut.MaxLength = 30;
            this.txtBoxNomAtribut.Name = "txtBoxNomAtribut";
            this.txtBoxNomAtribut.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNomAtribut.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nombre";
            // 
            // TabPageRegistros
            // 
            this.TabPageRegistros.Controls.Add(this.btConsultas);
            this.TabPageRegistros.Controls.Add(this.btEliminaRegistro);
            this.TabPageRegistros.Controls.Add(this.btModificaRegistro);
            this.TabPageRegistros.Controls.Add(this.NewAdd);
            this.TabPageRegistros.Controls.Add(this.dgRegistros);
            this.TabPageRegistros.Location = new System.Drawing.Point(4, 22);
            this.TabPageRegistros.Name = "TabPageRegistros";
            this.TabPageRegistros.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRegistros.Size = new System.Drawing.Size(586, 281);
            this.TabPageRegistros.TabIndex = 2;
            this.TabPageRegistros.Text = "Registros";
            this.TabPageRegistros.UseVisualStyleBackColor = true;
            // 
            // btConsultas
            // 
            this.btConsultas.Location = new System.Drawing.Point(309, 15);
            this.btConsultas.Name = "btConsultas";
            this.btConsultas.Size = new System.Drawing.Size(75, 23);
            this.btConsultas.TabIndex = 6;
            this.btConsultas.Text = "Consultas";
            this.btConsultas.UseVisualStyleBackColor = true;
            this.btConsultas.Click += new System.EventHandler(this.btConsultas_Click);
            // 
            // btEliminaRegistro
            // 
            this.btEliminaRegistro.Location = new System.Drawing.Point(493, 15);
            this.btEliminaRegistro.Name = "btEliminaRegistro";
            this.btEliminaRegistro.Size = new System.Drawing.Size(75, 23);
            this.btEliminaRegistro.TabIndex = 5;
            this.btEliminaRegistro.Text = "Elimina";
            this.btEliminaRegistro.UseVisualStyleBackColor = true;
            this.btEliminaRegistro.Click += new System.EventHandler(this.btEliminaRegistro_Click);
            // 
            // btModificaRegistro
            // 
            this.btModificaRegistro.Location = new System.Drawing.Point(405, 15);
            this.btModificaRegistro.Name = "btModificaRegistro";
            this.btModificaRegistro.Size = new System.Drawing.Size(75, 23);
            this.btModificaRegistro.TabIndex = 4;
            this.btModificaRegistro.Text = "Modifica";
            this.btModificaRegistro.UseVisualStyleBackColor = true;
            this.btModificaRegistro.Click += new System.EventHandler(this.btModificaRegistro_Click);
            // 
            // NewAdd
            // 
            this.NewAdd.Location = new System.Drawing.Point(20, 15);
            this.NewAdd.Name = "NewAdd";
            this.NewAdd.Size = new System.Drawing.Size(75, 23);
            this.NewAdd.TabIndex = 3;
            this.NewAdd.Text = "Nuevo";
            this.NewAdd.UseVisualStyleBackColor = true;
            this.NewAdd.Click += new System.EventHandler(this.NewAdd_Click);
            // 
            // dgRegistros
            // 
            this.dgRegistros.AllowUserToAddRows = false;
            this.dgRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRegistros.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegistros.Location = new System.Drawing.Point(6, 54);
            this.dgRegistros.Name = "dgRegistros";
            this.dgRegistros.Size = new System.Drawing.Size(574, 224);
            this.dgRegistros.TabIndex = 1;
            this.dgRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRegistros_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnModificaTabla
            // 
            this.btnModificaTabla.Enabled = false;
            this.btnModificaTabla.Location = new System.Drawing.Point(421, 55);
            this.btnModificaTabla.Name = "btnModificaTabla";
            this.btnModificaTabla.Size = new System.Drawing.Size(85, 23);
            this.btnModificaTabla.TabIndex = 39;
            this.btnModificaTabla.Text = "Modifica Tabla";
            this.btnModificaTabla.UseVisualStyleBackColor = true;
            this.btnModificaTabla.Click += new System.EventHandler(this.button1_Click);
            // 
            // btEliminaTabla
            // 
            this.btEliminaTabla.Location = new System.Drawing.Point(512, 56);
            this.btEliminaTabla.Name = "btEliminaTabla";
            this.btEliminaTabla.Size = new System.Drawing.Size(90, 23);
            this.btEliminaTabla.TabIndex = 40;
            this.btEliminaTabla.Text = "Elimina Tabla";
            this.btEliminaTabla.UseVisualStyleBackColor = true;
            this.btEliminaTabla.Click += new System.EventHandler(this.btEliminaTabla_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 393);
            this.Controls.Add(this.btEliminaTabla);
            this.Controls.Add(this.btnModificaTabla);
            this.Controls.Add(this.cmbTablas);
            this.Controls.Add(this.labNombreBD);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.AgregaTabla);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtBAgrega);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Manejador";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPageAtributos.ResumeLayout(false);
            this.TabPageAtributos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtributos)).EndInit();
            this.TabPageRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AgregaTabla;
        private System.Windows.Forms.TextBox txtBAgrega;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem abrirBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbTablas;
        private System.Windows.Forms.Label labNombreBD;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage TabPageAtributos;
        private System.Windows.Forms.DataGridView dgAtributos;
        private System.Windows.Forms.Button btnEliminaAtr;
        private System.Windows.Forms.ComboBox cmbtipoIndice;
        private System.Windows.Forms.Button btnModificaAtr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAltaAtr;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNomAtribut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem modificarBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBoxLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem eliminarBaseDeDatosActualToolStripMenuItem;
        private System.Windows.Forms.Button btnModificaTabla;
        private System.Windows.Forms.ComboBox cmbTablasPK;
        private System.Windows.Forms.TabPage TabPageRegistros;
        private System.Windows.Forms.DataGridView dgRegistros;
        private System.Windows.Forms.Button NewAdd;
        private System.Windows.Forms.Button btEliminaRegistro;
        private System.Windows.Forms.Button btModificaRegistro;
        private System.Windows.Forms.Button btConsultas;
        private System.Windows.Forms.Button btEliminaTabla;
    }
}

