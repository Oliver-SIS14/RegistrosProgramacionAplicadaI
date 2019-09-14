using RegistroEstudiante.BLL;
using RegistroEstudiante.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiante.UI.Consultas
{
    public partial class ConsultaInscripciones : Form
    {
        public ConsultaInscripciones()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Inscripcion>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionBLL.GetListInscripcion(P => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetListInscripcion(p => p.Inscripcionid == id);
                        break;
                    case 2:
                        int id2 = Convert.ToInt32(CriterioTextBox.Text);
                        listado = InscripcionBLL.GetListInscripcion(p => p.Estudianteid == id2);
                        break;

                }

                listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = InscripcionBLL.GetListInscripcion(p => true);
            }

            ConsultaGridView.DataSource = null;
            ConsultaGridView.DataSource = listado;
        }
    }
}
