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
    public partial class ConsultarCarreras : Form
    {
        /* La idea que se me ocurrió acá es hacer simplemente un diseño. Sin tener que usar mucha logica
         * Pondriamos en el nombre de la carrera como Subtitulo, luego una breve descripcion, los titulos y
         * la duracion de la carrera (todo lo sacamos de la pag de utn)
         * Le podriamos agregar un Metodo que nos permita saber la cantidad de alumnos inscriptos en cada Carrera*/

        public ConsultarCarreras()
        {
            InitializeComponent();
        }
    }
}
