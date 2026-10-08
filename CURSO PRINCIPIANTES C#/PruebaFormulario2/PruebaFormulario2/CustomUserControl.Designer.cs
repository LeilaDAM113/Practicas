namespace PruebaFormulario2
{
    partial class CustomUserControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.lblLabel = new System.Windows.Forms.Label();
			this.txtBox = new System.Windows.Forms.TextBox();
			this.btnBoton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// lblLabel
			// 
			this.lblLabel.AutoSize = true;
			this.lblLabel.Location = new System.Drawing.Point(23, 29);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(44, 16);
			this.lblLabel.TabIndex = 0;
			this.lblLabel.Text = "label1";
			// 
			// txtBox
			// 
			this.txtBox.Location = new System.Drawing.Point(26, 48);
			this.txtBox.Name = "txtBox";
			this.txtBox.Size = new System.Drawing.Size(236, 22);
			this.txtBox.TabIndex = 1;
			// 
			// btnBoton
			// 
			this.btnBoton.Location = new System.Drawing.Point(281, 46);
			this.btnBoton.Name = "btnBoton";
			this.btnBoton.Size = new System.Drawing.Size(78, 27);
			this.btnBoton.TabIndex = 2;
			this.btnBoton.Text = "button1";
			this.btnBoton.UseVisualStyleBackColor = true;
			this.btnBoton.Click += new System.EventHandler(this.btnBoton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// CustomUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnBoton);
			this.Controls.Add(this.txtBox);
			this.Controls.Add(this.lblLabel);
			this.Name = "CustomUserControl";
			this.Size = new System.Drawing.Size(370, 102);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Button btnBoton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
