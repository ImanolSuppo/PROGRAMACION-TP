using SistemaAcademico.datos;
using Newtonsoft.Json;
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

        private async void AltaAlumno_Load(object sender, EventArgs e)
        {
            await CargarComboAsyncBarrio("http://localhost:5205/Barrios", "barrio","id",cbnBarrio);
            await CargarComboAsyncTipoDoc("http://localhost:5205/TipoDocumentos", "tipo_doc", "id", cbnTipoDoc);
            await ProximoIDAsync();
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
        private async Task CargarComboAsyncTipoDoc(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoDocumento>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
        }
        public async Task ProximoIDAsync()  //Esto está hecho para que el usuario pueda ver la cantidad de alumnos que hay en el sistema 
        {
            string url = "http://localhost:5205/Proximo";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var proxLegajo = JsonConvert.DeserializeObject<int>(result);
                   
            lblAlumno.Text = "Su legajo sería n°: " + proxLegajo.ToString();
        }
        public async void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cbnTipoDoc.SelectedIndex = -1;
            txtDoc.Clear();
            cbnBarrio.SelectedIndex = -1;
            txtCalle.Clear();
            txtAltura.Clear();
            await ProximoIDAsync();
        }


        public bool Validar() //Mejorar la validacion(que muestre un mensaje por cada problema)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCalle.Text) || string.IsNullOrEmpty(txtDoc.Text) || string.IsNullOrEmpty(txtAltura.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(cbnBarrio.Text) || string.IsNullOrEmpty(cbnTipoDoc.Text))
            {
                MessageBox.Show("Todos los campos deben tener un valor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtDoc.Text, out _) || !int.TryParse(txtAltura.Text, out _) || !int.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("Documento, altura y telefono deben ser números", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool ExisteLegajo(int legajo)
        {
            DataTable table = dao.ConsultarLegajo("", legajo);//Asignar SP
            if (table.Rows.Count > 0)
                return true;
            return false;
        }


        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            else
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefeno = Convert.ToInt32(txtTelefono.Text); //puede saltar error por superar la capacidad max
                TipoDocumento id_tipo_doc = (TipoDocumento)cbnTipoDoc.SelectedItem;
                string nombre_tipo_doc = cbnTipoDoc.Text;
                int documento = Convert.ToInt32(txtDoc.Text);
                Barrios id_barrio = (Barrios)cbnBarrio.SelectedItem;
                string nombre_barrio = cbnBarrio.Text;
                string calle = txtCalle.Text;
                int altura = Convert.ToInt32(txtAltura.Text);                               
                    Persona persona = new Persona(nombre, apellido, id_barrio, calle, altura, telefeno, id_tipo_doc, documento);
                string bodyContent = JsonConvert.SerializeObject(persona);
                string url = "http://localhost:5205/Alumno";
                var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
                if (result.Equals("0"))
                {
                    MessageBox.Show("No se pudo crear el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se creó el Usuario, Tu legajo es: " + result, "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
    }
}
