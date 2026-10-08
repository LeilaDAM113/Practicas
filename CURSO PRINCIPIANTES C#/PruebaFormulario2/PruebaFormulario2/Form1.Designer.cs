namespace PruebaFormulario2
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
			this.customUserControl1 = new PruebaFormulario2.CustomUserControl();
			this.buttonExtend1 = new PruebaFormulario2.ButtonExtend();
			this.SuspendLayout();
			// 
			// customUserControl1
			// 
			this.customUserControl1.labelTitle = "Introducir ubicacion fichero";
			this.customUserControl1.Location = new System.Drawing.Point(27, 33);
			this.customUserControl1.Name = "customUserControl1";
			this.customUserControl1.Size = new System.Drawing.Size(370, 102);
			this.customUserControl1.TabIndex = 0;
			// 
			// buttonExtend1
			// 
			this.buttonExtend1.Location = new System.Drawing.Point(27, 182);
			this.buttonExtend1.Name = "buttonExtend1";
			this.buttonExtend1.Size = new System.Drawing.Size(177, 115);
			this.buttonExtend1.TabIndex = 2;
			this.buttonExtend1.Text = "buttonExtend1";
			this.buttonExtend1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonExtend1);
			this.Controls.Add(this.customUserControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);

        }

        #endregion

        private CustomUserControl customUserControl1;
        private ButtonExtend buttonExtend1;
    }
}

