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
    public partial class ConsultaEstudiante : Form
    {
        public ConsultaEstudiante()
        {
            InitializeComponent();
        }



        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Estudiante>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = EstudianteBLL.GetList(P => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = EstudianteBLL.GetList(p => p.Estudianteid == id);
                        break;
                    case 2:
                        listado = EstudianteBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = EstudianteBLL.GetList(p => p.Matricula.Contains(CriterioTextBox.Text));
                        break;
                    case 4:
                        listado = EstudianteBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;
                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = EstudianteBLL.GetList(p => true);
            }

            ConsultaGridView.DataSource = null;
            ConsultaGridView.DataSource = listado;
        }
    }
}
