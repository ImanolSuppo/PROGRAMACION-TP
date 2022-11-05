﻿//using SistemaAcademico.datos.Interfaz;
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
            CargarComboAsyncBarrio("http://localhost:5205/Barrios", "barrio","id_barrio",cbnBarrio);
            CargarComboAsyncTipoDoc("http://localhost:5205/TipoDocumentos", "tipo_doc", "id_tipo_doc", cbnTipoDoc);
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
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNombre.Text))
                return false;
            if (int.TryParse(txtDoc.Text, out _) || int.TryParse(txtAltura.Text, out _) || int.TryParse(txtTelefono.Text, out _))
                return false;
            return true;
        }
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
                int id_tipo_doc = Convert.ToInt32(cbnTipoDoc.SelectedValue);
                string nombre_tipo_doc = cbnTipoDoc.Text;
                int documento = Convert.ToInt32(txtDoc.Text);
                int id_barrio = Convert.ToInt32(cbnBarrio.SelectedValue);
                string nombre_barrio = cbnBarrio.Text;
                string calle = txtCalle.Text;
                int altura = Convert.ToInt32(txtAltura.Text);
                Barrios barrio = new Barrios(id_barrio, nombre_barrio);
                TipoDocumento tipoDoc = new TipoDocumento(id_tipo_doc, nombre_tipo_doc);
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
