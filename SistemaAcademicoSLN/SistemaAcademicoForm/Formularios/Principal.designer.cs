namespace SistemaAcademicoForm
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pAyuda = new System.Windows.Forms.Panel();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.pArchivo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.pSoporte = new System.Windows.Forms.Panel();
            this.btnAnularInscripcion = new System.Windows.Forms.Button();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.btnSoporte = new System.Windows.Forms.Button();
            this.pInscripcion = new System.Windows.Forms.Panel();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnInscripcion = new System.Windows.Forms.Button();
            this.pConsultar = new System.Windows.Forms.Panel();
            this.btnInscripciones = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pAyuda.SuspendLayout();
            this.pArchivo.SuspendLayout();
            this.pSoporte.SuspendLayout();
            this.pInscripcion.SuspendLayout();
            this.pConsultar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.panel1.Controls.Add(this.pAyuda);
            this.panel1.Controls.Add(this.btnAyuda);
            this.panel1.Controls.Add(this.pArchivo);
            this.panel1.Controls.Add(this.btnArchivo);
            this.panel1.Controls.Add(this.pSoporte);
            this.panel1.Controls.Add(this.btnSoporte);
            this.panel1.Controls.Add(this.pInscripcion);
            this.panel1.Controls.Add(this.btnInscripcion);
            this.panel1.Controls.Add(this.pConsultar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 507);
            this.panel1.TabIndex = 1;
            // 
            // pAyuda
            // 
            this.pAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.pAyuda.Controls.Add(this.btnAcercaDe);
            this.pAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pAyuda.Location = new System.Drawing.Point(0, 425);
            this.pAyuda.Name = "pAyuda";
            this.pAyuda.Size = new System.Drawing.Size(200, 25);
            this.pAyuda.TabIndex = 10;
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnAcercaDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcercaDe.FlatAppearance.BorderSize = 0;
            this.btnAcercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcercaDe.Location = new System.Drawing.Point(0, 0);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAcercaDe.Size = new System.Drawing.Size(200, 23);
            this.btnAcercaDe.TabIndex = 0;
            this.btnAcercaDe.Text = "Acerca de ";
            this.btnAcercaDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcercaDe.UseVisualStyleBackColor = false;
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(165)))));
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.Location = new System.Drawing.Point(0, 388);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAyuda.Size = new System.Drawing.Size(200, 37);
            this.btnAyuda.TabIndex = 9;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // pArchivo
            // 
            this.pArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.pArchivo.Controls.Add(this.btnSalir);
            this.pArchivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pArchivo.Location = new System.Drawing.Point(0, 364);
            this.pArchivo.Name = "pArchivo";
            this.pArchivo.Size = new System.Drawing.Size(200, 24);
            this.pArchivo.TabIndex = 8;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(0, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(200, 23);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnArchivo
            // 
            this.btnArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(165)))));
            this.btnArchivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArchivo.FlatAppearance.BorderSize = 0;
            this.btnArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchivo.Location = new System.Drawing.Point(0, 327);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnArchivo.Size = new System.Drawing.Size(200, 37);
            this.btnArchivo.TabIndex = 7;
            this.btnArchivo.Text = "ARCHIVO";
            this.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchivo.UseVisualStyleBackColor = false;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // pSoporte
            // 
            this.pSoporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.pSoporte.Controls.Add(this.btnAnularInscripcion);
            this.pSoporte.Controls.Add(this.btnNuevoUsuario);
            this.pSoporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSoporte.Location = new System.Drawing.Point(0, 280);
            this.pSoporte.Name = "pSoporte";
            this.pSoporte.Size = new System.Drawing.Size(200, 47);
            this.pSoporte.TabIndex = 6;
            // 
            // btnAnularInscripcion
            // 
            this.btnAnularInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnAnularInscripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnularInscripcion.FlatAppearance.BorderSize = 0;
            this.btnAnularInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularInscripcion.Location = new System.Drawing.Point(0, 23);
            this.btnAnularInscripcion.Name = "btnAnularInscripcion";
            this.btnAnularInscripcion.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAnularInscripcion.Size = new System.Drawing.Size(200, 23);
            this.btnAnularInscripcion.TabIndex = 1;
            this.btnAnularInscripcion.Text = "Anular Inscripcion";
            this.btnAnularInscripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularInscripcion.UseVisualStyleBackColor = false;
            this.btnAnularInscripcion.Click += new System.EventHandler(this.btnAnularInscripcion_Click);
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnNuevoUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoUsuario.FlatAppearance.BorderSize = 0;
            this.btnNuevoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNuevoUsuario.Size = new System.Drawing.Size(200, 23);
            this.btnNuevoUsuario.TabIndex = 0;
            this.btnNuevoUsuario.Text = "Nuevo usuario";
            this.btnNuevoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoUsuario.UseVisualStyleBackColor = false;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnNuevoUsuario_Click);
            // 
            // btnSoporte
            // 
            this.btnSoporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(165)))));
            this.btnSoporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoporte.FlatAppearance.BorderSize = 0;
            this.btnSoporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoporte.Location = new System.Drawing.Point(0, 243);
            this.btnSoporte.Name = "btnSoporte";
            this.btnSoporte.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSoporte.Size = new System.Drawing.Size(200, 37);
            this.btnSoporte.TabIndex = 5;
            this.btnSoporte.Text = "SOPORTE";
            this.btnSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoporte.UseVisualStyleBackColor = false;
            this.btnSoporte.Click += new System.EventHandler(this.btnSoporte_Click);
            // 
            // pInscripcion
            // 
            this.pInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.pInscripcion.Controls.Add(this.btnInscribirse);
            this.pInscripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pInscripcion.Location = new System.Drawing.Point(0, 219);
            this.pInscripcion.Name = "pInscripcion";
            this.pInscripcion.Size = new System.Drawing.Size(200, 24);
            this.pInscripcion.TabIndex = 4;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnInscribirse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInscribirse.FlatAppearance.BorderSize = 0;
            this.btnInscribirse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscribirse.Location = new System.Drawing.Point(0, 0);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnInscribirse.Size = new System.Drawing.Size(200, 23);
            this.btnInscribirse.TabIndex = 0;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscribirse.UseVisualStyleBackColor = false;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click_1);
            // 
            // btnInscripcion
            // 
            this.btnInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(165)))));
            this.btnInscripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInscripcion.FlatAppearance.BorderSize = 0;
            this.btnInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripcion.Location = new System.Drawing.Point(0, 182);
            this.btnInscripcion.Name = "btnInscripcion";
            this.btnInscripcion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInscripcion.Size = new System.Drawing.Size(200, 37);
            this.btnInscripcion.TabIndex = 3;
            this.btnInscripcion.Text = "TRANSACCION";
            this.btnInscripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripcion.UseVisualStyleBackColor = false;
            this.btnInscripcion.Click += new System.EventHandler(this.btnInscripcion_Click);
            // 
            // pConsultar
            // 
            this.pConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(100)))), ((int)(((byte)(83)))));
            this.pConsultar.Controls.Add(this.btnInscripciones);
            this.pConsultar.Controls.Add(this.btnUsuarios);
            this.pConsultar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pConsultar.Location = new System.Drawing.Point(0, 137);
            this.pConsultar.Name = "pConsultar";
            this.pConsultar.Size = new System.Drawing.Size(200, 45);
            this.pConsultar.TabIndex = 2;
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnInscripciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInscripciones.FlatAppearance.BorderSize = 0;
            this.btnInscripciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscripciones.Location = new System.Drawing.Point(0, 23);
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnInscripciones.Size = new System.Drawing.Size(200, 23);
            this.btnInscripciones.TabIndex = 1;
            this.btnInscripciones.Text = "Inscripciones";
            this.btnInscripciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripciones.UseVisualStyleBackColor = false;
            this.btnInscripciones.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(215)))), ((int)(((byte)(184)))));
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(200, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(165)))));
            this.btnConsultar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(0, 100);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConsultar.Size = new System.Drawing.Size(200, 37);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "REPORTES";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::SistemaAcademicoForm.Properties.Resources.LOGO2;
            this.pictureBox2.Location = new System.Drawing.Point(413, 156);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(192, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(216)))), ((int)(((byte)(178)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(810, 507);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Principal";
            this.Text = "Sistema Academico";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.pAyuda.ResumeLayout(false);
            this.pArchivo.ResumeLayout(false);
            this.pSoporte.ResumeLayout(false);
            this.pInscripcion.ResumeLayout(false);
            this.pConsultar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Button btnConsultar;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel pConsultar;
        private Button btnInscripciones;
        private Button btnUsuarios;
        private Panel pAyuda;
        private Button btnAcercaDe;
        private Button btnAyuda;
        private Panel pArchivo;
        private Button btnSalir;
        private Button btnArchivo;
        private Panel pSoporte;
        private Button btnAnularInscripcion;
        private Button btnNuevoUsuario;
        private Button btnSoporte;
        private Panel pInscripcion;
        private Button btnInscribirse;
        private Button btnInscripcion;
        private PictureBox pictureBox2;
    }
}

