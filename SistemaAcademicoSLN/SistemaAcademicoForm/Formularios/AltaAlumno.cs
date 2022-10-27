//using SistemaAcademico.datos.Interfaz;
using SistemaAcademico.datos;
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
    public partial class AltaAlumno : Form
    {
        private IDao dao;
        public AltaAlumno()
        {
            InitializeComponent();
        }

    }
}
