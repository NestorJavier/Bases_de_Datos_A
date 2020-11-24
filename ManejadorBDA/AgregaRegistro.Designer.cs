namespace ManejadorBDA
{
    partial class Modifica_Atributo
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
            this.Aceptar = new System.Windows.Forms.Button();
            this.tBoxReg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.Location = new System.Drawing.Point(12, 121);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 47;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Visible = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // tBoxReg
            // 
            this.tBoxReg.Location = new System.Drawing.Point(88, 49);
            this.tBoxReg.Name = "tBoxReg";
            this.tBoxReg.Size = new System.Drawing.Size(100, 20);
            this.tBoxReg.TabIndex = 48;
            this.tBoxReg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxReg_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(85, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 50;
            this.label.Text = "label1";
            // 
            // Modifica_Atributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tBoxReg);
            this.Controls.Add(this.Aceptar);
            this.Name = "Modifica_Atributo";
            this.Text = "Ingresa Información";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.TextBox tBoxReg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label;
    }
}