namespace Ejercicio_25 {
    partial class CBinDec {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtDecimalABinario = new System.Windows.Forms.TextBox();
            this.btnDecimalABinario = new System.Windows.Forms.Button();
            this.txtResDecimalABinario = new System.Windows.Forms.TextBox();
            this.txtResBinarioADecimal = new System.Windows.Forms.TextBox();
            this.btnBinarioADecimal = new System.Windows.Forms.Button();
            this.txtBinarioADecimal = new System.Windows.Forms.TextBox();
            this.lblBinarioADecimal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decimal a Binario";
            // 
            // txtDecimalABinario
            // 
            this.txtDecimalABinario.Location = new System.Drawing.Point(134, 20);
            this.txtDecimalABinario.Name = "txtDecimalABinario";
            this.txtDecimalABinario.Size = new System.Drawing.Size(100, 20);
            this.txtDecimalABinario.TabIndex = 1;
            // 
            // btnDecimalABinario
            // 
            this.btnDecimalABinario.Location = new System.Drawing.Point(253, 19);
            this.btnDecimalABinario.Name = "btnDecimalABinario";
            this.btnDecimalABinario.Size = new System.Drawing.Size(100, 22);
            this.btnDecimalABinario.TabIndex = 2;
            this.btnDecimalABinario.Text = "->";
            this.btnDecimalABinario.UseVisualStyleBackColor = true;
            this.btnDecimalABinario.Click += new System.EventHandler(this.BtnDecimalABinario_Click);
            // 
            // txtResDecimalABinario
            // 
            this.txtResDecimalABinario.Enabled = false;
            this.txtResDecimalABinario.Location = new System.Drawing.Point(372, 20);
            this.txtResDecimalABinario.Name = "txtResDecimalABinario";
            this.txtResDecimalABinario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtResDecimalABinario.Size = new System.Drawing.Size(211, 20);
            this.txtResDecimalABinario.TabIndex = 3;
            // 
            // txtResBinarioADecimal
            // 
            this.txtResBinarioADecimal.Enabled = false;
            this.txtResBinarioADecimal.Location = new System.Drawing.Point(372, 58);
            this.txtResBinarioADecimal.Name = "txtResBinarioADecimal";
            this.txtResBinarioADecimal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtResBinarioADecimal.Size = new System.Drawing.Size(211, 20);
            this.txtResBinarioADecimal.TabIndex = 6;
            // 
            // btnBinarioADecimal
            // 
            this.btnBinarioADecimal.Location = new System.Drawing.Point(253, 57);
            this.btnBinarioADecimal.Name = "btnBinarioADecimal";
            this.btnBinarioADecimal.Size = new System.Drawing.Size(100, 22);
            this.btnBinarioADecimal.TabIndex = 5;
            this.btnBinarioADecimal.Text = "->";
            this.btnBinarioADecimal.UseVisualStyleBackColor = true;
            this.btnBinarioADecimal.Click += new System.EventHandler(this.BtnBinarioADecimal_Click);
            // 
            // txtBinarioADecimal
            // 
            this.txtBinarioADecimal.Location = new System.Drawing.Point(134, 58);
            this.txtBinarioADecimal.Name = "txtBinarioADecimal";
            this.txtBinarioADecimal.Size = new System.Drawing.Size(100, 20);
            this.txtBinarioADecimal.TabIndex = 4;
            // 
            // lblBinarioADecimal
            // 
            this.lblBinarioADecimal.AutoSize = true;
            this.lblBinarioADecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblBinarioADecimal.Location = new System.Drawing.Point(12, 59);
            this.lblBinarioADecimal.Name = "lblBinarioADecimal";
            this.lblBinarioADecimal.Size = new System.Drawing.Size(114, 16);
            this.lblBinarioADecimal.TabIndex = 4;
            this.lblBinarioADecimal.Text = "Binario a Decimal";
            // 
            // CBinDec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(596, 95);
            this.Controls.Add(this.txtResBinarioADecimal);
            this.Controls.Add(this.btnBinarioADecimal);
            this.Controls.Add(this.txtBinarioADecimal);
            this.Controls.Add(this.lblBinarioADecimal);
            this.Controls.Add(this.txtResDecimalABinario);
            this.Controls.Add(this.btnDecimalABinario);
            this.Controls.Add(this.txtDecimalABinario);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CBinDec";
            this.Text = "Conversor binario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDecimalABinario;
        private System.Windows.Forms.Button btnDecimalABinario;
        private System.Windows.Forms.TextBox txtResDecimalABinario;
        private System.Windows.Forms.TextBox txtResBinarioADecimal;
        private System.Windows.Forms.Button btnBinarioADecimal;
        private System.Windows.Forms.TextBox txtBinarioADecimal;
        private System.Windows.Forms.Label lblBinarioADecimal;
    }
}

