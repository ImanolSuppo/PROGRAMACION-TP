using SistemaAcademico.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAcademicoForm.Formularios
{
    public partial class ConsultarUsuarios : Form
    {
        private IDao dao;
        public ConsultarUsuarios()
        {
            InitializeComponent();
            dao = new Dao();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLegajo.Text))
            {
                MessageBox.Show("Legajo vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtLegajo.Text, out _))
            {
                MessageBox.Show("Solo insertar caracteres numericos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rdbAlumno.Checked && !rdbProfesor.Checked)
            {
                MessageBox.Show("Debe especificar si es Alumno o Profesor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int legajo = Convert.ToInt32(txtLegajo.Text);
            DataTable table = dao.ConsultarLegajo("SP_CONSULTAR_LEGAJO", legajo); //INSERTAR SP
            dgvLegajo.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                string? NombreComp = item["Nombre_Completo"].ToString();
                string? Direccion = item["Direccion"].ToString();
                string? celular = item["Celular"].ToString();
                dgvLegajo.Rows.Add(legajo,NombreComp,Direccion,celular);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
