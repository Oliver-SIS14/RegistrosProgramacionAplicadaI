using RegistroEstudiante.BLL;
using RegistroEstudiante.DAL;
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
    public partial class RegistroEstudiantes : Form
    {
        public RegistroEstudiantes()
        {
            InitializeComponent();
        }
       
        private void Limpiar()
        {
            IDNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            MatriculaMaskedTextBox.Text = string.Empty;
            CedulaMasketTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            SexoComboBox.Text = string.Empty;
            BalanceMaskedTextBox.Text = string.Empty;
            NacimientoDateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();

            estudiante.Estudianteid = Convert.ToInt32(IDNumericUpDown.Value);
            estudiante.Nombres = NombresTextBox.Text;
            estudiante.Apellidos = ApellidosTextBox.Text;
            estudiante.Cedula = CedulaMasketTextBox.Text;
            estudiante.Telefono = TelefonoMaskedTextBox.Text;
            estudiante.Matricula = MatriculaMaskedTextBox.Text;
            estudiante.Celular = CelularMaskedTextBox.Text;
         //   estudiante.Balance = Convert.ToDecimal(BalanceMaskedTextBox.Text);
            estudiante.Sexo = SexoComboBox.SelectedIndex;
            estudiante.Email = EmailTextBox.Text;
            estudiante.FechaNacimiento = NacimientoDateTimePicker.Value;
            
            return estudiante;
        }
        private void LlenaCampo(Estudiante estudiante)
        {
            IDNumericUpDown.Value = estudiante.Estudianteid;
            NombresTextBox.Text = estudiante.Nombres ;
            ApellidosTextBox.Text = estudiante.Apellidos ;
            CedulaMasketTextBox.Text = estudiante.Cedula;
            TelefonoMaskedTextBox.Text = estudiante.Telefono ;
            MatriculaMaskedTextBox.Text = estudiante.Matricula ;
            CelularMaskedTextBox.Text = estudiante.Celular;
            BalanceMaskedTextBox.Text = Convert.ToString(estudiante.Balance);
            SexoComboBox.Text = Convert.ToString(estudiante.Sexo);
            EmailTextBox.Text = estudiante.Email;
            NacimientoDateTimePicker.Value = estudiante.FechaNacimiento ;
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, "El Campo Nombres no puede estar vacio.");
                NombresTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ApellidosTextBox.Text))
            {
                MyErrorProvider.SetError(ApellidosTextBox, "El Campo Apellidos no puede estar vacio.");
                ApellidosTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(MatriculaMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(MatriculaMaskedTextBox, "El Campo Matricula no puede estar vacio.");
                MatriculaMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaMasketTextBox.Text))
            {
                MyErrorProvider.SetError(CedulaMasketTextBox, "El Campo Cedula no puede estar vacio.");
                CedulaMasketTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "El Campo telefono no puede estar vacio.");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CelularMaskedTextBox, "El Campo Celular no puede estar vacio.");
                CelularMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NacimientoDateTimePicker.Text))
            {
                MyErrorProvider.SetError(NacimientoDateTimePicker, "El Campo Fecha no puede estar vacio.");
                NacimientoDateTimePicker.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SexoComboBox.Text))
            {
                MyErrorProvider.SetError(SexoComboBox, "El Campo Sexo no puede estar vacio.");
                SexoComboBox.Focus();
                paso = false;
            }


            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiante estudiante = EstudianteBLL.Buscar((int)IDNumericUpDown.Value);

            return (estudiante != null);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Estudiante estudiante;
            if (!Validar())
                return;

            estudiante = LlenaClase();


            bool paso;
            if (IDNumericUpDown.Value == 0)
                paso = EstudianteBLL.Guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar un estudiante que no esta registrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = EstudianteBLL.Modificar(estudiante);

            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("No fue posible guardar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            _ = new Estudiante();
            int.TryParse(IDNumericUpDown.Text, out int id);

            Limpiar();

            Estudiante estudiante = EstudianteBLL.Buscar(id);

            if (estudiante == null)
            {
                MessageBox.Show("Persona No Encontrada.");
            }
            else
            {
                LlenaCampo(estudiante);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int.TryParse(IDNumericUpDown.Text, out int id);

            Limpiar();

            if (EstudianteBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no este registrada.");
        }

    }
}
