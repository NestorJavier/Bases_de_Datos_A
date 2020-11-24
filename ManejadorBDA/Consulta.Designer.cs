namespace ManejadorBDA
{
    partial class Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dgConsultas = new System.Windows.Forms.DataGridView();
            this.btEjecutar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 27);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // dgConsultas
            // 
            this.dgConsultas.AllowUserToAddRows = false;
            this.dgConsultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgConsultas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsultas.Location = new System.Drawing.Point(21, 83);
            this.dgConsultas.Name = "dgConsultas";
            this.dgConsultas.Size = new System.Drawing.Size(574, 287);
            this.dgConsultas.TabIndex = 2;
            // 
            // btEjecutar
            // 
            this.btEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btEjecutar.Image")));
            this.btEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEjecutar.Location = new System.Drawing.Point(555, 22);
            this.btEjecutar.Name = "btEjecutar";
            this.btEjecutar.Size = new System.Drawing.Size(40, 46);
            this.btEjecutar.TabIndex = 3;
            this.btEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEjecutar.UseVisualStyleBackColor = true;
            this.btEjecutar.Click += new System.EventHandler(this.btEjecutar_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 393);
            this.Controls.Add(this.btEjecutar);
            this.Controls.Add(this.dgConsultas);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Consulta";
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.dgConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dgConsultas;
        private System.Windows.Forms.Button btEjecutar;
    }
}