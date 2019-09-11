namespace Clase07
{
    partial class frmPaleta
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPaleta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTempera = new System.Windows.Forms.ToolStripMenuItem();
            this.gboxPaleta = new System.Windows.Forms.GroupBox();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.listboxTemperas = new System.Windows.Forms.ListBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gboxPaleta.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdministracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsAdministracion
            // 
            this.tsAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPaleta});
            this.tsAdministracion.Name = "tsAdministracion";
            this.tsAdministracion.Size = new System.Drawing.Size(100, 20);
            this.tsAdministracion.Text = "Administración";
            // 
            // tsPaleta
            // 
            this.tsPaleta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTempera});
            this.tsPaleta.Name = "tsPaleta";
            this.tsPaleta.Size = new System.Drawing.Size(137, 22);
            this.tsPaleta.Text = "Crear Paleta";
            this.tsPaleta.Click += new System.EventHandler(this.crearPaletaToolStripMenuItem_Click);
            // 
            // tsTempera
            // 
            this.tsTempera.Name = "tsTempera";
            this.tsTempera.Size = new System.Drawing.Size(121, 22);
            this.tsTempera.Text = "Témpera";
            this.tsTempera.Click += new System.EventHandler(this.tsTempera_Click);
            // 
            // gboxPaleta
            // 
            this.gboxPaleta.Controls.Add(this.btnModificar);
            this.gboxPaleta.Controls.Add(this.btnMas);
            this.gboxPaleta.Controls.Add(this.btnMenos);
            this.gboxPaleta.Controls.Add(this.listboxTemperas);
            this.gboxPaleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxPaleta.Location = new System.Drawing.Point(0, 24);
            this.gboxPaleta.Name = "gboxPaleta";
            this.gboxPaleta.Size = new System.Drawing.Size(800, 318);
            this.gboxPaleta.TabIndex = 2;
            this.gboxPaleta.TabStop = false;
            this.gboxPaleta.Text = "Paleta";
            this.gboxPaleta.Visible = false;
            // 
            // btnMas
            // 
            this.btnMas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMas.Location = new System.Drawing.Point(3, 255);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(794, 30);
            this.btnMas.TabIndex = 2;
            this.btnMas.Text = "+";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Visible = false;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenos.Location = new System.Drawing.Point(3, 285);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(794, 30);
            this.btnMenos.TabIndex = 1;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Visible = false;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // listboxTemperas
            // 
            this.listboxTemperas.Dock = System.Windows.Forms.DockStyle.Top;
            this.listboxTemperas.FormattingEnabled = true;
            this.listboxTemperas.Location = new System.Drawing.Point(3, 16);
            this.listboxTemperas.Name = "listboxTemperas";
            this.listboxTemperas.Size = new System.Drawing.Size(794, 238);
            this.listboxTemperas.TabIndex = 0;
            this.listboxTemperas.Visible = false;
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = true;
            this.btnModificar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnModificar.Location = new System.Drawing.Point(3, 225);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(794, 30);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // frmPaleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.gboxPaleta);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPaleta";
            this.Text = "Paleta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gboxPaleta.ResumeLayout(false);
            this.gboxPaleta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAdministracion;
        private System.Windows.Forms.ToolStripMenuItem tsPaleta;
        private System.Windows.Forms.ToolStripMenuItem tsTempera;
        private System.Windows.Forms.GroupBox gboxPaleta;
        private System.Windows.Forms.ListBox listboxTemperas;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnModificar;
    }
}

