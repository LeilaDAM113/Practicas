namespace PruebaFormulario
{
    partial class FormAdvancedControls
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
			this.lbCoches = new System.Windows.Forms.ListBox();
			this.cmbCombo = new System.Windows.Forms.ComboBox();
			this.dtpOpenWebinars = new System.Windows.Forms.DateTimePicker();
			this.pgPrueba = new System.Windows.Forms.ProgressBar();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// lbCoches
			// 
			this.lbCoches.FormattingEnabled = true;
			this.lbCoches.ItemHeight = 16;
			this.lbCoches.Items.AddRange(new object[] {
            "Ford",
            "Jaguar",
            "Chevrolet"});
			this.lbCoches.Location = new System.Drawing.Point(21, 32);
			this.lbCoches.Name = "lbCoches";
			this.lbCoches.Size = new System.Drawing.Size(170, 308);
			this.lbCoches.TabIndex = 0;
			// 
			// cmbCombo
			// 
			this.cmbCombo.FormattingEnabled = true;
			this.cmbCombo.Location = new System.Drawing.Point(220, 32);
			this.cmbCombo.Name = "cmbCombo";
			this.cmbCombo.Size = new System.Drawing.Size(247, 24);
			this.cmbCombo.TabIndex = 1;
			// 
			// dtpOpenWebinars
			// 
			this.dtpOpenWebinars.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpOpenWebinars.Location = new System.Drawing.Point(220, 100);
			this.dtpOpenWebinars.Name = "dtpOpenWebinars";
			this.dtpOpenWebinars.Size = new System.Drawing.Size(247, 22);
			this.dtpOpenWebinars.TabIndex = 2;
			// 
			// pgPrueba
			// 
			this.pgPrueba.Location = new System.Drawing.Point(220, 176);
			this.pgPrueba.Name = "pgPrueba";
			this.pgPrueba.Size = new System.Drawing.Size(453, 23);
			this.pgPrueba.TabIndex = 3;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(220, 224);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(381, 200);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// FormAdvancedControls
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.pgPrueba);
			this.Controls.Add(this.dtpOpenWebinars);
			this.Controls.Add(this.cmbCombo);
			this.Controls.Add(this.lbCoches);
			this.Name = "FormAdvancedControls";
			this.Text = "FormAdvancedControls";
			this.Load += new System.EventHandler(this.FormAdvancedControls_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCoches;
        private System.Windows.Forms.ComboBox cmbCombo;
        private System.Windows.Forms.DateTimePicker dtpOpenWebinars;
        private System.Windows.Forms.ProgressBar pgPrueba;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}