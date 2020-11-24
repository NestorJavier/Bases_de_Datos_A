namespace ManejadorBDA
{
    partial class Nuevo_Nombre
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
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.labNuevoNom = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(34, 66);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNombre.TabIndex = 0;
            // 
            // labNuevoNom
            // 
            this.labNuevoNom.AutoSize = true;
            this.labNuevoNom.Location = new System.Drawing.Point(34, 34);
            this.labNuevoNom.Name = "labNuevoNom";
            this.labNuevoNom.Size = new System.Drawing.Size(126, 13);
            this.labNuevoNom.TabIndex = 1;
            this.labNuevoNom.Text = "Ingrese el nuevo Nombre";
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(37, 92);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // Nuevo_Nombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 124);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.labNuevoNom);
            this.Controls.Add(this.txtBoxNombre);
            this.Name = "Nuevo_Nombre";
            this.Text = "Nuevo_Nombre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labNuevoNom;
        public System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Button btAceptar;
    }
}