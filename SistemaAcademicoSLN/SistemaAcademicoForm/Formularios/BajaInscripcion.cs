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
    public partial class BajaInscripcion : Form
    {
        IDao dao;
        public BajaInscripcion()
        {
            InitializeComponent();
            dao = new Dao();
        }

        private void BajaInscripcion_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(7);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 3)
            {
                if (MessageBox.Show() == DialogResult.Yes)
                {
                   
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable table = ObtenerTabla();
            List<Inscripcion> lst = ObtenerLista(table);
            dgvDetalle.Rows.Clear();
            int band = 0;
            foreach (Inscripcion inscripcion in lst)
            {
                dgvDetalle.Rows.Add(new object[] {
                    inscripcion.alumno.legajo,
                    inscripcion.detalleInscripcions[band].carrera.nombre,
                    inscripcion.detalleInscripcions[band].materia.nombre,
                    });
            }
        }

        private List<Inscripcion> ObtenerLista(DataTable table)
        {
            List<Inscripcion> lst = new List<Inscripcion>();
            foreach (DataRow dr in table.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                Inscripcion aux = new Inscripcion();
                DetalleInscripcion detalleInscripcions = new DetalleInscripcion();
                detalleInscripcions.carrera.nombre = dr["carrera"].ToString();
                detalleInscripcions.materia.nombre = dr["materia"].ToString();
                aux.alumno.legajo = int.Parse(dr["legajo"].ToString());
                aux.AgregarDetalle(detalleInscripcions);
                lst.Add(aux);
            }
            return lst;
        }

        private DataTable ObtenerTabla()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroDesde = new Parametro("@fecha_desde ", dtpDesde.Value);
            Parametro parametroHasta = new Parametro("@fecha_hasta ", dtpHasta.Value);
            if (!String.IsNullOrEmpty(txtLegajo.Text))
            {
                Parametro parametroLegajo = new Parametro("@legajo", Convert.ToInt32(txtLegajo.Text));
                parametros.Add(parametroLegajo);
            }
            parametros.Add(parametroDesde);
            parametros.Add(parametroHasta);
            
            return dao.ObtenerCombo("SP_obtener_detalles", parametros);
        }
    }
}
