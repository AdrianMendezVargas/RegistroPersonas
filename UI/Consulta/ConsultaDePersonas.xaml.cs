using RegistroPersona.BLL;
using RegistroPersona.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroPersona.UI.Consulta {
    /// <summary>
    /// Interaction logic for ConsultaDePersonas.xaml
    /// </summary>
    public partial class ConsultaDePersonas : Window {
        public ConsultaDePersonas() {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {
            CargarResultados();
        }

        private void CargarResultados() {

            List<Persona> personasList = new List<Persona>();

            if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text)) {

                switch (FiltroComboBox.SelectedIndex) {

                    case 0: //id
                        int.TryParse(CriterioTextBox.Text , out int personaId);
                        personasList = PersonasBLL.GetList(p => p.PersonaId == personaId);
                        break;

                    case 1:  //Nombre
                        
                        personasList = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                }

            } else {

                personasList = PersonasBLL.GetList(p => true);
            }

            ResultadosDataGrid.ItemsSource = personasList;



        }
    }
}
