using RegistroPersona.BLL;
using RegistroPersona.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPersona.UI.Registro {
    /// <summary>
    /// Interaction logic for RegistroDePersonas.xaml
    /// </summary>
    public partial class RegistroDePersonas : Window, INotifyPropertyChanged {
		public Persona _persona { get; set; }

		public Persona persona { get { return _persona; } set { _persona = value; MyPropertyChanged("persona"); } }

		public RegistroDePersonas() {
			InitializeComponent();

			persona = new Persona();
			_persona = new Persona();
			MainGrid.DataContext = this;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void MyPropertyChanged(string propiedad) {
			PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propiedad));
		}

		private void NuevoButton_Click(object sender , RoutedEventArgs e) {
			Limpiar();
		}

		private void GuardarButton_Click(object sender , RoutedEventArgs e) {

			if (!Validar()) {
				return;
			}

			bool guardado = false;

			if (persona.PersonaId == 0 || string.IsNullOrWhiteSpace(PersonaIdTextBox.Text)) {
				guardado = PersonasBLL.Guardar(persona);
			} else {
				if (ExisteEnBaseDatos()) {
					guardado = PersonasBLL.Modificar(persona);

				} else {
					MessageBox.Show("Este persona no existe; No se puede modificar");
				}
			}

			if (guardado) {
				MessageBox.Show("Guardado.");
				Limpiar();
			} else {
				MessageBox.Show("Error el guardar.");
			}

		}

		private void EliminarButton_Click(object sender , RoutedEventArgs e) {

			if (!Validar()) {
				return;
			}

			bool eliminado = PersonasBLL.Eliminar(persona.PersonaId);

			if (eliminado) {
				Limpiar();
				MessageBox.Show("Eliminado.");
			} else {
				MessageBox.Show("Este persona no existe.");
			}

		}

		private void BuscarButton_Click(object sender , RoutedEventArgs e) {

			if (ExisteEnBaseDatos()) {
				persona = PersonasBLL.Buscar(persona.PersonaId);
			} else {
				Limpiar();
				MessageBox.Show("Este persona no existe.");
			}

		}

		private void Limpiar() {
			persona.PersonaId = 0;
			persona.Nombre = " ";
			MyPropertyChanged("persona");
		}

		private bool Validar() {
			bool validados = true;

			if (string.IsNullOrWhiteSpace(NombreTextBox.Text)) {
				validados = false;
				NombreTextBox.Focus();
				MessageBox.Show("Ingrese un nombre");
			}

			return validados;
		}

		private bool ExisteEnBaseDatos() {
			Persona persona = PersonasBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));
			return (persona != null);
		}
	}
}
