namespace WindowsForms
{
    partial class FrmCatedra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbOrdenar = new System.Windows.Forms.ComboBox();
            this.lstAlumnos = new System.Windows.Forms.ListBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstAlumnosCalificados = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbOrdenar);
            this.groupBox1.Controls.Add(this.lstAlumnos);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnCalificar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alumnos";
            // 
            // cmbOrdenar
            // 
            this.cmbOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdenar.FormattingEnabled = true;
            this.cmbOrdenar.Location = new System.Drawing.Point(6, 220);
            this.cmbOrdenar.Name = "cmbOrdenar";
            this.cmbOrdenar.Size = new System.Drawing.Size(407, 21);
            this.cmbOrdenar.TabIndex = 1;
            this.cmbOrdenar.SelectedIndexChanged += new System.EventHandler(this.CmbOrdenar_SelectedIndexChanged);
            // 
            // lstAlumnos
            // 
            this.lstAlumnos.FormattingEnabled = true;
            this.lstAlumnos.Location = new System.Drawing.Point(6, 59);
            this.lstAlumnos.Name = "lstAlumnos";
            this.lstAlumnos.Size = new System.Drawing.Size(407, 147);
            this.lstAlumnos.TabIndex = 3;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(338, 23);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(171, 23);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 1;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.BtnCalificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(6, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstAlumnosCalificados);
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 236);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alumnos Calificados";
            // 
            // lstAlumnosCalificados
            // 
            this.lstAlumnosCalificados.FormattingEnabled = true;
            this.lstAlumnosCalificados.Location = new System.Drawing.Point(6, 29);
            this.lstAlumnosCalificados.Name = "lstAlumnosCalificados";
            this.lstAlumnosCalificados.Size = new System.Drawing.Size(407, 199);
            this.lstAlumnosCalificados.TabIndex = 0;
            // 
            // FrmCatedra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCatedra";
            this.Text = "FrmCatedra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOrdenar;
        private System.Windows.Forms.ListBox lstAlumnos;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstAlumnosCalificados;
    }
}