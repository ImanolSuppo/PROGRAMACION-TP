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

        public bool Valida()
        {
            //validar los campos...
        }

        public void Clear()
        {
            inscripcion = new Inscripcion(); //Cada vez que se limpie se crea una nueva inscripcion
            //limpiar los campos...
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Valida())
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
