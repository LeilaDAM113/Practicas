namespace PruebaFormulario
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
			this.btnOpenWebinars = new System.Windows.Forms.Button();
			this.lblOpenWebinars = new System.Windows.Forms.Label();
			this.txtOpenWebinars = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.pbOpenWebinars = new System.Windows.Forms.PictureBox();
			this.btnNextLesson = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbOpenWebinars)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOpenWebinars
			// 
			this.btnOpenWebinars.Location = new System.Drawing.Point(59, 94);
			this.btnOpenWebinars.Name = "btnOpenWebinars";
			this.btnOpenWebinars.Size = new System.Drawing.Size(140, 58);
			this.btnOpenWebinars.TabIndex = 0;
			this.btnOpenWebinars.Text = "OpenWebinars";
			this.btnOpenWebinars.UseVisualStyleBackColor = true;
			this.btnOpenWebinars.Click += new System.EventHandler(this.btnOpenWebinars_Click);
			this.btnOpenWebinars.MouseEnter += new System.EventHandler(this.btnOpenWebinars_MouseEnter);
			// 
			// lblOpenWebinars
			// 
			this.lblOpenWebinars.AutoSize = true;
			this.lblOpenWebinars.Location = new System.Drawing.Point(240, 115);
			this.lblOpenWebinars.Name = "lblOpenWebinars";
			this.lblOpenWebinars.Size = new System.Drawing.Size(44, 16);
			this.lblOpenWebinars.TabIndex = 1;
			this.lblOpenWebinars.Text = "label1";
			// 
			// txtOpenWebinars
			// 
			this.txtOpenWebinars.Location = new System.Drawing.Point(59, 220);
			this.txtOpenWebinars.Name = "txtOpenWebinars";
			this.txtOpenWebinars.Size = new System.Drawing.Size(225, 22);
			this.txtOpenWebinars.TabIndex = 2;
			this.txtOpenWebinars.TextChanged += new System.EventHandler(this.txtOpenWebinars_TextChanged);
			this.txtOpenWebinars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpenWebinars_KeyDown);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(59, 274);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(95, 20);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// pbOpenWebinars
			// 
			this.pbOpenWebinars.Location = new System.Drawing.Point(408, 94);
			this.pbOpenWebinars.Name = "pbOpenWebinars";
			this.pbOpenWebinars.Size = new System.Drawing.Size(188, 114);
			this.pbOpenWebinars.TabIndex = 5;
			this.pbOpenWebinars.TabStop = false;
			this.pbOpenWebinars.Click += new System.EventHandler(this.pbOpenWebinars_Click);
			// 
			// btnNextLesson
			// 
			this.btnNextLesson.Location = new System.Drawing.Point(643, 389);
			this.btnNextLesson.Name = "btnNextLesson";
			this.btnNextLesson.Size = new System.Drawing.Size(103, 31);
			this.btnNextLesson.TabIndex = 6;
			this.btnNextLesson.Text = "Next lesson";
			this.btnNextLesson.UseVisualStyleBackColor = true;
			this.btnNextLesson.Click += new System.EventHandler(this.btnNextLesson_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnNextLesson);
			this.Controls.Add(this.pbOpenWebinars);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.txtOpenWebinars);
			this.Controls.Add(this.lblOpenWebinars);
			this.Controls.Add(this.btnOpenWebinars);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pbOpenWebinars)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenWebinars;
        private System.Windows.Forms.Label lblOpenWebinars;
        private System.Windows.Forms.TextBox txtOpenWebinars;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pbOpenWebinars;
        private System.Windows.Forms.Button btnNextLesson;
    }
}

