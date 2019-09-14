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

namespace RegistroEstudiante.UI.Registros
{
    public partial class rInscripciones : Form
    {
        public rInscripciones()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IDEstudianteNumericUpDown.Value = 0;
            IDInscripcionNumericUpDown.Value = 0;
            BalanceTextBox.Text = string.Empty;
            DepositoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            FechaDateTimePicker.Value = DateTime.Now;
            ComentariosRichTextBox.Text = string.Empty;
        }
        private Inscripcion LlenarClase()
        {
            Inscripcion inscripcion = new Inscripcion();

            inscripcion.Estudianteid = Convert.ToInt32(IDEstudianteNumericUpDown.Value);
            inscripcion.Inscripcionid = Convert.ToInt32(IDInscripcionNumericUpDown.Value);
            inscripcion.Monto = Convert.ToDecimal(MontoTextBox.Text);
            inscripcion.Deposito = Convert.ToDecimal(DepositoTextBox.Text);
            inscripcion.Comentarios = ComentariosRichTextBox.Text;
            inscripcion.Fecha = FechaDateTimePicker.Value;

            decimal monto = Convert.ToDecimal(MontoTextBox.Text);
            decimal deposito = Convert.ToDecimal(DepositoTextBox.Text);

            if (Convert.ToDecimal(BalanceTextBox.Text + "0") > 0)
            {
                if (monto == deposito)
                {
                    EstudianteBLL.GuardarBalance((int)IDEstudianteNumericUpDown.Value, 0);
                    inscripcion.Balance = 0;
                }
                else
                {
                    EstudianteBLL.GuardarBalance((int)IDEstudianteNumericUpDown.Value,( -1* deposito));
                    inscripcion.Balance = (Convert.ToDecimal(BalanceTextBox.Text) - deposito);
                }
            }
            else
            {
                EstudianteBLL.GuardarBalance((int)IDEstudianteNumericUpDown.Value, (inscripcion.Monto - inscripcion.Deposito));
                inscripcion.Balance = (inscripcion.Monto - inscripcion.Deposito);
            }
           

            return inscripcion;
        }

        private void LlenarCampo(Inscripcion inscripcion)
        {

            IDEstudianteNumericUpDown.Value = inscripcion.Estudianteid;
            IDInscripcionNumericUpDown.Value = inscripcion.Inscripcionid;
            MontoTextBox.Text = Convert.ToString(inscripcion.Monto);
            DepositoTextBox.Text = Convert.ToString(inscripcion.Deposito);
            BalanceTextBox.Text = Convert.ToString(inscripcion.Balance);
            ComentariosRichTextBox.Text = inscripcion.Comentarios;
            FechaDateTimePicker.Value = inscripcion.Fecha;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripcion inscripcion = InscripcionBLL.Buscar((int)IDInscripcionNumericUpDown.Value);
         //   Estudiante estudiante = EstudianteBLL.Buscar((int)IDEstudianteNumericUpDown.Value);

            return (inscripcion != null /*&& estudiante != null*/);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MyErrorProvider.SetError(MontoTextBox, "El campo Monto no puede estar vacio");
                MontoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = true;
            Inscripcion inscripcion;

            if (!Validar())
                return;

            inscripcion = LlenarClase();

            if (IDInscripcionNumericUpDown.Value == 0)
                paso = InscripcionBLL.guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar, no existe en la base de datos","Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = InscripcionBLL.Modificar(inscripcion);
            }
            if (paso)
            {  
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDInscripcionNumericUpDown.Text, out id);

            Limpiar();

            if (InscripcionBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDInscripcionNumericUpDown, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Inscripcion inscripcion = new Inscripcion();
            int.TryParse(IDInscripcionNumericUpDown.Text, out id);
            
            Limpiar();

            inscripcion = InscripcionBLL.Buscar(id);

            if(inscripcion == null)
            {
                MessageBox.Show("Persona no encontrada");
            }
            else
            {
                LlenarCampo(inscripcion);
            }
        }
    }
}
