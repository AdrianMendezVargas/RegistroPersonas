using RegistroPersona.UI;
using RegistroPersona.UI.Consulta;
using RegistroPersona.UI.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPersona {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ConsultaPersonaMenuItem_Click(object sender , RoutedEventArgs e) {
            ConsultaDePersonas consultaDePersonas = new ConsultaDePersonas();
            consultaDePersonas.Owner = this;
            consultaDePersonas.ShowDialog();
        }

        private void RegitroPersonaMenuItem_Click(object sender , RoutedEventArgs e) {
            RegistroDePersonas registroDePersonas = new RegistroDePersonas();
            registroDePersonas.Owner = this;
            registroDePersonas.ShowDialog();
        }
    }
}
