using Newtonsoft.Json;
using SistemaAcademico.datos;
using SistemaAcademico.dominio;
using SistemaAcademicoForm.Http;
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

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> parametros = new List<Parametro>();
            if(!string.IsNullOrEmpty(txtApellido.Text))
            {
                Parametro parametroApellido = new Parametro("@apellido", txtApellido.Text);
                parametros.Add(parametroApellido);
            }
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                Parametro parametroNombre = new Parametro("@nombre", txtNombre.Text);
                parametros.Add(parametroNombre);
            }
            string bodyContent = JsonConvert.SerializeObject(parametros);
            string url = "http://localhost:5205/ObtenerAlumnos";
            var result = await ClientSingleton.GetInstance().PostAsync(url, bodyContent);
            List<Alumno>? lst = JsonConvert.DeserializeObject<List<Alumno>>(result);
            dgvLegajo.Rows.Clear();
            foreach (Alumno item in lst)
            {
                dgvLegajo.Rows.Add(item.legajo, item.persona.nombre, item.persona.calle, item.persona.telefono);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
