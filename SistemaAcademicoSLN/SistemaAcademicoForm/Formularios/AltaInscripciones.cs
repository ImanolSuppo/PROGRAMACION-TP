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
    public partial class AltaInscripciones : Form
    {
        private IDao dao;
        private Inscripcion inscripcion;
        public AltaInscripciones()
        {
            InitializeComponent();
            dao = new Dao();
        }

        private void AltaInscripciones_Load(object sender, EventArgs e)
        {
            CargarComboAsyncMateria("http://localhost:5205/Materias", "nombre","id_materia",cboMateria);
            CargarComboAsyncCarrera("http://localhost:5205/Carreras","nombre","id_carrera",cboCarreraa);
            Clear();
        }

        private async Task CargarComboAsyncCarrera(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Carrera>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
        }
        private async Task CargarComboAsyncMateria(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Materia>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
        }
        public void ProximoID()
        {
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtCurso.Text))
            {
                MessageBox.Show("Debe Ingresar un curso");
                txtCurso.Focus();
                return false;
            }
            //dtpFecha.Value == DateTime.Now no se si poner esto pq por ahi se inscribe en el dia
            if (string.IsNullOrEmpty(txtLegajo.Text))
            {
                MessageBox.Show("Debe Ingresar un legajo");
                txtLegajo.Focus();
                return false;
            }
            if (cboCarreraa.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Ingresar una carrera");
                cboCarreraa.Focus();
                return false;
            }
            if (cboMateria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Ingresar una materia");
                cboMateria.Focus();
                return false;
            }
            try
            {
                int.TryParse(txtLegajo.Text, out _);

            }
            catch (Exception ex)
            {
                MessageBox.Show("El legajo debe ser un numero");
                return false;
            }
            return true;
        }
        public void Clear()
        {
            inscripcion = new Inscripcion(); //Cada vez que se limpie se crea una nueva inscripcion
            txtCurso.Text = string.Empty;
            txtLegajo.Text = string.Empty;
            cboCarreraa.SelectedIndex = -1;
            cboMateria.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dgvDetalle.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                MessageBox.Show("Error, verifique los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.Cells["ColMateria"].Value.ToString().Equals(cboMateria.Text))
                    {
                        MessageBox.Show("Materia: " + cboMateria.Text + " ya se encuentra como detalle!", "Control",

                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            Materia materia = (Materia)cboMateria.SelectedItem;
            Carrera carrera = (Carrera)cboCarreraa.SelectedItem;
            DetalleInscripcion detalle = new DetalleInscripcion(carrera, materia, "");

            inscripcion.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(new object[] { carrera.nombre, materia.nombre });
        }


        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 2)
            {
                inscripcion.EliminarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

            }
        }

        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            inscripcion.alumno.legajo = Convert.ToInt32(txtLegajo.Text); //validar que el legajo sea un numero
            inscripcion.fecha = dtpFecha.Value;
            inscripcion.curso = Convert.ToInt32(txtCurso.Text); //validar         
            
            await GuardarInscripcionAsync(inscripcion);
            Clear();
        }
        public async Task GuardarInscripcionAsync(Inscripcion inscripcion)
        {
            string bodyContent = JsonConvert.SerializeObject(inscripcion);
            string url = "http://localhost:5205/Inscripcion";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
            if (result.Equals("true"))
                MessageBox.Show("Inscripcion registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ERROR. No se pudo registrar la inscripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}