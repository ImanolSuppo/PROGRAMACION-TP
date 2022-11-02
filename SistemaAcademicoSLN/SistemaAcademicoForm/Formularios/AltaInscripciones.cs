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
            CargarCombo();//asignar el combo a materia
            CargarCombo();//asignar el combo a carrera
        }

        private void CargarCombo(string SP, string display, string value, ComboBox cbn)
        {
            DataTable table = dao.ObtenerCombo(SP);
            cbn.DataSource = table;
            cbn.DisplayMember = display;
            cbn.ValueMember = value;
            cbn.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    if (row.Cells["colMateria"].Value.ToString().Equals(cboMateria.Text))
                    {
                        MessageBox.Show("Materia: " + cboMateria.Text + " ya se encuentra como detalle!", "Control",

                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                int materia = Convert.ToInt32(cboMateria.SelectedValue);
                int carrera = Convert.ToInt32(cboCarreraa.SelectedValue);
                DetalleInscripcion detalle = new DetalleInscripcion();
                detalle.Materia = materia;
                detalle.Carrera = carrera;

                inscripcion.AgregarDetalle(detalle);
                dgvDetalle.Rows.Add(new object[] { carrera, materia });

            }
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            inscripcion.Alumno.Legajo=Convert.ToInt32(txtLegajo.Text); //validar que el legajo sea un numero
            inscripcion.Fecha = dtpFecha.Value;
            inscripcion.Curso = Convert.ToInt32(txtCurso.Text); //validar
            if (dao.AltaInscripcion(inscripcion))
                MessageBox.Show("Inscripcion registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("ERROR. No se pudo registrar la inscripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Clear();

        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 3)
            {
                inscripcion.EliminarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

            }
        }
    } 
}
