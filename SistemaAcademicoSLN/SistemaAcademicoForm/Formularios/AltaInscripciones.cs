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
        /*aca tengo muchas dudas:
         * 1. Hay que resolver el tema de que no puedas inscribirte a una materia de otra carrera (tabla car_mat posible solucion)
         * 2. ¿Es necesario poner las notas de parciales y finales?. Porque si recien te estas inscribiendo no tendrias notas
         */

        public AltaInscripciones()
        {
            InitializeComponent();
        }
    }
}
