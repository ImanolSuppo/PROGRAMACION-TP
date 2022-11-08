using Newtonsoft.Json;
using SistemaAcademico.datos;
using SistemaAcademico.dominio;
using SistemaAcademicoForm.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAcademicoForm.Formularios
{
    public partial class ModificarAlumno : Form
    {
        private IDao dao;
        public ModificarAlumno()
        {
            dao = new Dao();
            InitializeComponent();
        }
        private async void ModificarAlumno_Load(object sender, EventArgs e)
        {
            await CargarComboAsyncBarrio("http://localhost:5205/Barrios", "barrio", "id", cboBarrio);
            await CargarComboAsyncTipoDoc("http://localhost:5205/TipoDocumentos", "tipo_doc", "id", cboTipoDoc);
            CargarLegajos();
            Limpiar();
        }

        private void CargarLegajos()
        {
            DataTable tabla = new DataTable();
            tabla = dao.ObtenerCombo("SP_combo_legajo", null);
            cboLegajo.DataSource = tabla;
            cboLegajo.ValueMember = "legajo";
            cboLegajo.DisplayMember = "legajo";


        }

        //private async Task CargarComboAsyncLegajos(string urlCombo, string display, string value, ComboBox cbn)
        //{
        //    string url = urlCombo;
        //    var result = await ClientSingleton.GetInstance().GetAsync(url);
        //    var lst = JsonConvert.DeserializeObject<List<Alumnos>>(result);
        //    cbn.DataSource = lst;
        //    cbn.DisplayMember = display;
        //    cbn.ValueMember = value;
        //}
        private async Task CargarComboAsyncTipoDoc(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoDocumento>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
        }
        private async Task CargarComboAsyncBarrio(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Barrios>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
        }
        public bool Validar() //Mejorar la validacion(que muestre un mensaje por cada problema)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtNroDoc.Text) || string.IsNullOrEmpty(txtAltura.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(cboBarrio.Text) || string.IsNullOrEmpty(cboTipoDoc.Text))
            {
                MessageBox.Show("Todos los campos deben tener un valor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtNroDoc.Text, out _) || !int.TryParse(txtAltura.Text, out _) || !int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("Documento, altura y telefono deben ser números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboLegajo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un legajo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cboTipoDoc.SelectedIndex = -1;
            txtNroDoc.Clear();
            cboBarrio.SelectedIndex = -1;
            txtCalle.Clear();
            txtAltura.Clear();
            cboLegajo.SelectedIndex = -1;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            else
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefeno = Convert.ToInt32(txtTelefono.Text);
                TipoDocumento id_tipo_doc = (TipoDocumento)cboTipoDoc.SelectedItem;
                string nombre_tipo_doc = cboTipoDoc.Text;
                int documento = Convert.ToInt32(txtNroDoc.Text);
                Barrios id_barrio = (Barrios)cboBarrio.SelectedItem;
                string nombre_barrio = cboBarrio.Text;
                string calle = txtCalle.Text;
                int altura = Convert.ToInt32(txtAltura.Text);
                int legajo = (int)cboLegajo.SelectedValue;

                Persona persona = new Persona(nombre, apellido, id_barrio, calle, altura, telefeno, id_tipo_doc, documento);
                Alumno oAlumno = new Alumno(legajo, persona);
                string bodyContent = JsonConvert.SerializeObject(oAlumno);
                string url = "http://localhost:5205/ActualizarUsuario";
                var result = await ClientSingleton.GetInstance().PutAsync(url, bodyContent);
                if (result.Equals("true"))
                {
                    MessageBox.Show("El alumno fue editado correctamente", "Confirmación", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("NO SE PUDO EDITAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
    }
}