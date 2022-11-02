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
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.dgvLegajo = new System.Windows.Forms.DataGridView();
            this.ColLegajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdbAlumno = new System.Windows.Forms.RadioButton();
            this.rdbProfesor = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(69, 28);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(100, 23);
            this.txtLegajo.TabIndex = 0;
            // 
            // dgvLegajo
            // 
            this.dgvLegajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLegajo,
            this.ColNombreCompleto,
            this.ColDireccion,
            this.ColCelular});
            this.dgvLegajo.Location = new System.Drawing.Point(12, 94);
            this.dgvLegajo.Name = "dgvLegajo";
            this.dgvLegajo.RowTemplate.Height = 25;
            this.dgvLegajo.Size = new System.Drawing.Size(481, 68);
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
            // rdbAlumno
            // 
            this.rdbAlumno.AutoSize = true;
            this.rdbAlumno.Location = new System.Drawing.Point(18, 60);
            this.rdbAlumno.Name = "rdbAlumno";
            this.rdbAlumno.Size = new System.Drawing.Size(68, 19);
            this.rdbAlumno.TabIndex = 2;
            this.rdbAlumno.TabStop = true;
            this.rdbAlumno.Text = "Alumno";
            this.rdbAlumno.UseVisualStyleBackColor = true;
            // 
            // rdbProfesor
            // 
            this.rdbProfesor.AutoSize = true;
            this.rdbProfesor.Location = new System.Drawing.Point(92, 60);
            this.rdbProfesor.Name = "rdbProfesor";
            this.rdbProfesor.Size = new System.Drawing.Size(69, 19);
            this.rdbProfesor.TabIndex = 3;
            this.rdbProfesor.TabStop = true;
            this.rdbProfesor.Text = "Profesor";
            this.rdbProfesor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Legajo:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(418, 58);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(18, 168);
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
            this.ClientSize = new System.Drawing.Size(516, 203);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbProfesor);
            this.Controls.Add(this.rdbAlumno);
            this.Controls.Add(this.dgvLegajo);
            this.Controls.Add(this.txtLegajo);
            this.Name = "ConsultarUsuarios";
            this.Text = "ConsultarUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtLegajo;
        private DataGridView dgvLegajo;
        private RadioButton rdbAlumno;
        private RadioButton rdbProfesor;
        private Label label1;
        private Button btnConsultar;
        private DataGridViewTextBoxColumn ColLegajo;
        private DataGridViewTextBoxColumn ColNombreCompleto;
        private DataGridViewTextBoxColumn ColDireccion;
        private DataGridViewTextBoxColumn ColCelular;
        private Button btnSalir;
    }
}