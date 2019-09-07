using RegistroEstudiante.UI.Consultas;
using RegistroEstudiante.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiante
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new RegistroEstudiantes();
            formulario.Show();
        }

        private void ConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario2 = new ConsultaEstudiante();
            formulario2.Show();
        }
    }
}
