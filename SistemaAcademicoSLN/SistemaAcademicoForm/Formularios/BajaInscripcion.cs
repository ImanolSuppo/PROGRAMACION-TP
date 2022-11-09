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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            dtpDesde.Value = DateTime.Now.AddMonths(-2);
            dtpHasta.Value = DateTime.Now;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                if (MessageBox.Show("Esta seguro que desea darlo de baja?","CONFIRMACION",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(dgvDetalle.CurrentRow.Cells["colId"].Value.ToString());
                    string url = "http://localhost:5205/BajaInscripcion" + id;
                    var result = await ClientSingleton.GetInstance().DeleteAsync(url);
                    if (result.Equals("1"))
                        MessageBox.Show("Se Actualizó el detalle", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo actualizar el detalle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            ConsultarPorDao();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtLegajo.Text, out _))
            {
                if (!string.IsNullOrEmpty(txtLegajo.Text))
                {
                    MessageBox.Show("El legajo debe ser un numero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtLegajo.Text))
            {
                if (!await ExisteLegajo(Convert.ToInt32(txtLegajo.Text)))
                {
                    MessageBox.Show("El legajo no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ObtenerDetalle obtenerDetalle = new ObtenerDetalle();
            if (!String.IsNullOrEmpty(txtLegajo.Text))
                obtenerDetalle.legajo = Convert.ToInt32(txtLegajo.Text);
            obtenerDetalle.fecha_desde = dtpDesde.Value;
            obtenerDetalle.fecha_hasta = dtpHasta.Value;
            string bodyContent = JsonConvert.SerializeObject(obtenerDetalle);
            string url = "http://localhost:5205/ObtenerDetalle";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
            List<Inscripcion>? lst = JsonConvert.DeserializeObject<List<Inscripcion>>(result);
            dgvDetalle.Rows.Clear();
            foreach (Inscripcion inscripcion in lst)
            {
                foreach (DetalleInscripcion item in inscripcion.detalleInscripcions)
                {
                    dgvDetalle.Rows.Add(new object[] {item.id_detalle,
                    inscripcion.alumno.legajo,
                    item.carrera.nombre,
                    item.materia.nombre,
                    });
                }
            }
        }

        private async Task<bool> ExisteLegajo(int legajo)
        {
            string url = "http://localhost:5205/ConsultarLegajo?legajo="+legajo;
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            if (result.Equals("true"))
                return true;
            return false;
        }

        public void ConsultarPorDao()
        {
            DataTable table = ObtenerTabla();
            List<Inscripcion> lst = ObtenerLista(table);
            dgvDetalle.Rows.Clear();
            foreach (Inscripcion inscripcion in lst)
            {
                foreach (DetalleInscripcion item in inscripcion.detalleInscripcions)
                {
                    dgvDetalle.Rows.Add(new object[] {item.id_detalle,
                    inscripcion.alumno.legajo,
                    item.carrera.nombre,
                    item.materia.nombre,
                    });
                }
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
                detalleInscripcions.id_detalle = int.Parse(dr["id_detalle"].ToString());
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
    }
}
