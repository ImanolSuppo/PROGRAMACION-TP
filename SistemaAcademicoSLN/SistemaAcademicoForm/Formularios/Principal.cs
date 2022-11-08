using SistemaAcademico.datos;
using SistemaAcademicoForm.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAcademicoForm
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarAlumno modificar = new ModificarAlumno();
            modificar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarUsuarios consultar = new ConsultarUsuarios();
            consultar.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
        pConsultar.Visible= false;
        pInscripcion.Visible= false;
        pSoporte.Visible= false;
        pAyuda.Visible= false;
        pArchivo.Visible= false;
            IniciarSesion ssion = new IniciarSesion();
            ssion.ShowDialog();
        }

        private void ocultarSubMenu()
        {
            if(pConsultar.Visible== true) 
                pConsultar.Visible = false;
            if(pInscripcion.Visible== true)
                pInscripcion.Visible = false;
            if(pSoporte.Visible== true) 
                pSoporte.Visible = false;   
            if(pAyuda.Visible== true)
                pAyuda.Visible = false;
            if (pArchivo.Visible == true)
                pArchivo.Visible = false; 
        }

        private void MostrarSubMenu (Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else 
                subMenu.Visible = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pConsultar);
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pInscripcion);
        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pSoporte);
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pArchivo);
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pAyuda);
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            AltaUsuarios altaAlumno = new AltaUsuarios();
            altaAlumno.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnInscribirse_Click_1(object sender, EventArgs e)
        {
            AltaInscripciones altaInscripciones = new AltaInscripciones();
            altaInscripciones.ShowDialog();
        }

        private void btnAnularInscripcion_Click(object sender, EventArgs e)
        {
            BajaInscripcion bajaInscripcion = new BajaInscripcion();
            bajaInscripcion.ShowDialog();
        }

        private void btnCarreras_Click_1(object sender, EventArgs e)
        {

        }
    }
}
