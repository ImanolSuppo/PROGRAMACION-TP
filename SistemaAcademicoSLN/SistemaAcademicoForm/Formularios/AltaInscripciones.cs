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
            dtpFecha.Enabled = false;
        }

        private async Task CargarComboAsyncCarrera(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Carrera>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
            cbn.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task CargarComboAsyncMateria(string urlCombo, string display, string value, ComboBox cbn)
        {
            string url = urlCombo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Materia>>(result);
            cbn.DataSource = lst;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
            cbn.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ProximoID()
        {
        }

        public bool Validar()
        {
            //dtpFecha.Value == DateTime.Now no se si poner esto pq por ahi se inscribe en el dia

            if (cboCarreraa.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Ingresar una carrera", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCarreraa.Focus();
                return false;
            }
            if (cboMateria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Ingresar una materia", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMateria.Focus();
                return false;
            }

            return true;
        }
        public void Clear()
        {
            inscripcion = new Inscripcion(); //Cada vez que se limpie se crea una nueva inscripcion
            dupCurso.SelectedItem = 1;
            txtLegajo.Text = string.Empty;
            cboCarreraa.SelectedIndex = -1;
            cboMateria.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dgvDetalle.Rows.Clear();
            cboCarreraa.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!Validar())
            {
                return;
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

            if (cboCarreraa.SelectedIndex==0)
            {
                if(cboMateria.Text=="FISICA" || cboMateria.Text== "ELECTROTECNIA")
                {
                    MessageBox.Show("Esa materia no corresponde a la carrera", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(cboCarreraa.SelectedIndex==1)
            {
                if(cboMateria.Text=="PROGRAMACION I" || cboMateria.Text == "PROGRAMACION II" || cboMateria.Text == "SISTEMA DE PROCESAMIENTO DE DATOS" || cboMateria.Text == "ASO" || cboMateria.Text == "LCI" || cboMateria.Text == "LCII")
                {
                    MessageBox.Show("Esa materia no corresponde a la carrera", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cboCarreraa.Enabled)
            {
                if (MessageBox.Show("Confirma su elección de carrera?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    cboCarreraa.Enabled = false;
                else
                    return;
            }
            Materia materia = (Materia)cboMateria.SelectedItem;
            Carrera carrera = (Carrera)cboCarreraa.SelectedItem;
            DetalleInscripcion detalle = new DetalleInscripcion(carrera, materia, "false",0);

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
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe tener al menos un detalle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLegajo.Text))
            {
                MessageBox.Show("Debe Ingresar un legajo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLegajo.Focus();
                return;
            }
            if (!int.TryParse(dupCurso.Text, out _))
            {
                MessageBox.Show("Debe Ingresar un curso", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dupCurso.Focus();
                return;
            }
            if (!int.TryParse(txtLegajo.Text,out _))
            {
                MessageBox.Show("El legajo debe ser un numero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inscripcion.alumno.legajo = Convert.ToInt32(txtLegajo.Text); //validar que el legajo sea un numero
            inscripcion.fecha = dtpFecha.Value;
            inscripcion.curso = Convert.ToInt32(dupCurso.SelectedItem); //validar         
            
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
    }
}