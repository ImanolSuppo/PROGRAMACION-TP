//using SistemaAcademico.datos.Interfaz;
using SistemaAcademico.datos;
using SistemaAcademico.dominio;
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
    public partial class AltaUsuarios : Form
    {
        private IDao dao;
        public AltaUsuarios()
        {
            InitializeComponent();
            dao = new Dao();
        }

        private void AltaAlumno_Load(object sender, EventArgs e)
        {
            CargarCombo("SP","displey","value",cbnBarrio);
            CargarCombo("SP", "displey", "value",cbnTipoDoc);
        }

        private void CargarCombo(string SP, string display, string value, ComboBox cbn)
        {
            DataTable table = dao.ObtenerCombo(SP);
            cbn.DataSource = table;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
            cbn.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ProximoID()  //Esto está hecho para que el usuario pueda ver la cantidad de alumnos que hay en el sistema 
        {
            int next = dao.ObtenerProximoNro("");
            lblAlumno.Text = "Usted será el alumno n°: " + next.ToString();
        }//es necesario(?
        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cbnTipoDoc.SelectedIndex = -1;
            txtDoc.Clear();
            cbnBarrio.SelectedIndex = -1;
            txtCalle.Clear();
            txtAltura.Clear();
        }


        private void cbNoTel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoTel.Enabled)
            {
                txtTelefono.Clear();
                txtTelefono.Enabled = false;
            }
            else
                txtTelefono.Enabled = true;
        }
        public bool Validar() //Mejorar la validacion(que muestre un mensaje por cada problema)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe Ingresar un nombre");
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar un Apellido");
                return false;
            }

            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar un Telefono");
                return false;
            }

            if (int.TryParse(txtDoc.Text, out _))
            {
                MessageBox.Show("El documento debe ser numerico");
                return false;
            }

            if (int.TryParse(txtAltura.Text, out _))
            {
                MessageBox.Show("la altura debe ser numerica");
                return false;
            }

            if (int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El telefono debe ser numerico");
                return false;
            }


            return true;
            public bool ExisteLegajo(int legajo)
        {
            DataTable table = dao.ConsultarLegajo("", legajo);//Asignar SP
            if (table.Rows.Count > 0)
                return true;
            return false;
        }

        private void cbNoLocalidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoLocalidad.Enabled)
            {
                cbnBarrio.SelectedIndex = -1;
                txtCalle.Clear();
                txtAltura.Clear();
                cbnBarrio.Enabled = false;
                txtCalle.Enabled = false;
                txtAltura.Enabled = false;
            }
            else
            {
                cbnBarrio.Enabled = true;
                txtCalle.Enabled = true;
                txtAltura.Enabled = true;
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Validar los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefeno = Convert.ToInt32(txtTelefono.Text); //puede saltar error por superar la capacidad max
                int tipoDoc = Convert.ToInt32(cbnTipoDoc.SelectedValue);
                int documento = Convert.ToInt32(txtDoc.Text);
                int barrio = Convert.ToInt32(cbnBarrio.SelectedValue);
                string calle = txtCalle.Text;
                int altura = Convert.ToInt32(txtAltura.Text);
                    Persona persona = new Persona(nombre, apellido, barrio, calle, altura, telefeno, tipoDoc, documento);
                int legajo = dao.AltaLegajo(persona);
                if(legajo == 0)
                {
                    MessageBox.Show("No se pudo crear el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se creó el Usuario, Tu legajo es: " + legajo, "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

            }
        }
    }
}
