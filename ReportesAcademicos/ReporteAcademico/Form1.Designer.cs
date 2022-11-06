namespace ReporteAcademico
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource17 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsAlumno = new ReporteAcademico.Reporte.DsAlumno();
            this.dTAlumnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTAlumnoTableAdapter = new ReporteAcademico.Reporte.DsAlumnoTableAdapters.DTAlumnoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTAlumnoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource17.Name = "Ds1";
            reportDataSource17.Value = this.dTAlumnoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource17);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReporteAcademico.Reporte.ListadoAlumnos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsAlumno
            // 
            this.dsAlumno.DataSetName = "DsAlumno";
            this.dsAlumno.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dTAlumnoBindingSource
            // 
            this.dTAlumnoBindingSource.DataMember = "DTAlumno";
            this.dTAlumnoBindingSource.DataSource = this.dsAlumno;
            // 
            // dTAlumnoTableAdapter
            // 
            this.dTAlumnoTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTAlumnoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reporte.DsAlumno dsAlumno;
        private System.Windows.Forms.BindingSource dTAlumnoBindingSource;
        private Reporte.DsAlumnoTableAdapters.DTAlumnoTableAdapter dTAlumnoTableAdapter;
    }
}

