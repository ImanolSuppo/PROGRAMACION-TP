namespace SistemaAcademicoForm.Formularios
{
    partial class ConsultarUsuarios
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
            this.dgvLegajo = new System.Windows.Forms.DataGridView();
            this.ColLegajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLegajo
            // 
            this.dgvLegajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLegajo,
            this.ColNombreCompleto,
            this.ColDireccion,
            this.ColCelular});
            this.dgvLegajo.Location = new System.Drawing.Point(12, 12);
            this.dgvLegajo.Name = "dgvLegajo";
            this.dgvLegajo.RowTemplate.Height = 25;
            this.dgvLegajo.Size = new System.Drawing.Size(481, 229);
            this.dgvLegajo.TabIndex = 1;
            // 
            // ColLegajo
            // 
            this.ColLegajo.HeaderText = "Legajo";
            this.ColLegajo.Name = "ColLegajo";
            this.ColLegajo.ReadOnly = true;
            // 
            // ColNombreCompleto
            // 
            this.ColNombreCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColNombreCompleto.HeaderText = "Nombre Completo";
            this.ColNombreCompleto.MinimumWidth = 100;
            this.ColNombreCompleto.Name = "ColNombreCompleto";
            this.ColNombreCompleto.ReadOnly = true;
            // 
            // ColDireccion
            // 
            this.ColDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColDireccion.HeaderText = "Direccion";
            this.ColDireccion.MinimumWidth = 100;
            this.ColDireccion.Name = "ColDireccion";
            this.ColDireccion.ReadOnly = true;
            // 
            // ColCelular
            // 
            this.ColCelular.HeaderText = "Celular";
            this.ColCelular.Name = "ColCelular";
            this.ColCelular.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 247);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ConsultarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 282);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvLegajo);
            this.MaximumSize = new System.Drawing.Size(533, 321);
            this.Name = "ConsultarUsuarios";
            this.Text = "ConsultarUsuarios";
            this.Load += new System.EventHandler(this.ConsultarUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgvLegajo;
        private DataGridViewTextBoxColumn ColLegajo;
        private DataGridViewTextBoxColumn ColNombreCompleto;
        private DataGridViewTextBoxColumn ColDireccion;
        private DataGridViewTextBoxColumn ColCelular;
        private Button btnSalir;
    }
}