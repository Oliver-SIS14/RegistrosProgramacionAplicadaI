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

        private void InscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario3 = new rInscripciones();
            formulario3.MdiParent = this;
            formulario3.Show();
        }

        private void EstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new RegistroEstudiantes();
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void InscripcionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form formulario3 = new rInscripciones();
            formulario3.MdiParent = this;
            formulario3.Show();
        }

        private void EstudiantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form formulario2 = new ConsultaEstudiante();
            formulario2.MdiParent = this;
            formulario2.Show();
        }

        private void InscripcionesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form formulario3 = new ConsultaInscripciones();
            formulario3.MdiParent = this;
            formulario3.Show();
        }
    }
}
