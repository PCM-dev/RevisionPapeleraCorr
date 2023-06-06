namespace RevisionPapeleraCorr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvFABP = new System.Windows.Forms.DataGridView();
            this.dgvCSV = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFABP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSV)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(308, 20);
            this.txtInfo.TabIndex = 6;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(821, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(242, 20);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvFABP
            // 
            this.dgvFABP.AllowUserToAddRows = false;
            this.dgvFABP.AllowUserToDeleteRows = false;
            this.dgvFABP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFABP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFABP.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFABP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFABP.Location = new System.Drawing.Point(12, 38);
            this.dgvFABP.Name = "dgvFABP";
            this.dgvFABP.ReadOnly = true;
            this.dgvFABP.RowHeadersVisible = false;
            this.dgvFABP.Size = new System.Drawing.Size(555, 400);
            this.dgvFABP.TabIndex = 4;
            // 
            // dgvCSV
            // 
            this.dgvCSV.AllowUserToAddRows = false;
            this.dgvCSV.AllowUserToDeleteRows = false;
            this.dgvCSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCSV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCSV.Location = new System.Drawing.Point(574, 39);
            this.dgvCSV.Name = "dgvCSV";
            this.dgvCSV.ReadOnly = true;
            this.dgvCSV.RowHeadersVisible = false;
            this.dgvCSV.Size = new System.Drawing.Size(489, 399);
            this.dgvCSV.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(574, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(241, 20);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvCSV);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvFABP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FABP Pendientes de Enviar a Corr";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFABP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvFABP;
        private System.Windows.Forms.DataGridView dgvCSV;
        private System.Windows.Forms.Button btnBuscar;
    }
}

