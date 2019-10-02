namespace CentralitaWindowsForms
{
    partial class FormProvincial
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
            this.lblFranja = new System.Windows.Forms.Label();
            this.cmbFranja = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblFranja
            // 
            this.lblFranja.AutoSize = true;
            this.lblFranja.Location = new System.Drawing.Point(12, 169);
            this.lblFranja.Name = "lblFranja";
            this.lblFranja.Size = new System.Drawing.Size(76, 13);
            this.lblFranja.TabIndex = 8;
            this.lblFranja.Text = "Franja Horaria:";
            // 
            // cmbFranja
            // 
            this.cmbFranja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFranja.FormattingEnabled = true;
            this.cmbFranja.Location = new System.Drawing.Point(15, 185);
            this.cmbFranja.Name = "cmbFranja";
            this.cmbFranja.Size = new System.Drawing.Size(188, 21);
            this.cmbFranja.TabIndex = 9;
            // 
            // FormProvincial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 262);
            this.Controls.Add(this.cmbFranja);
            this.Controls.Add(this.lblFranja);
            this.Name = "FormProvincial";
            this.Text = "FormProvincial";
            this.Controls.SetChildIndex(this.lblFranja, 0);
            this.Controls.SetChildIndex(this.cmbFranja, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFranja;
        private System.Windows.Forms.ComboBox cmbFranja;
    }
}