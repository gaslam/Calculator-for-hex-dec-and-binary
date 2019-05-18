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

namespace Hex_Dec_And_Binary_Convertor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] Selection = new string[] {"Binair", "Decimaal", "Hexadecimaal"};

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Selection.Length; i++)
            {
                cmbSelection.Items.Add(Selection[i]);
            }

            cmbSelection.SelectedIndex = 0;
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblBinair.Content = txtInput.Text;
            lblDecimaal.Content = txtInput.Text;
            lblHexadecimaal.Content = txtInput.Text;
        }
    }
}
