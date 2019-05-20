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

        string[] Selection = new string[] {"Binair", "Decimaal", "Hexadecimaal", "Octaal"};

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
            string method;
            for (int i = 0; i < Selection.Length; i++)
            {
                method = Selection[i];
                if (method == cmbSelection.SelectedItem.ToString())
                {
                    labelVullen_nietVanToepassing(i);
                }
                else
                {
                    labelVullen_berekenen(i);
                }
                whiteSpace(txtInput.Text);
            }
            
        }

        private void labelVullen_nietVanToepassing(int nummer)
        {
            string nvt = "";
            if (nummer == 0)
            {
                lblBinair.Content = nvt;
            }
            else if (nummer == 1)
            {
                lblDecimaal.Content = nvt;
            }

            else
            {
                lblHexadecimaal.Content = nvt;
            }    
        }

        private void labelVullen_berekenen(int nummer)
        {
            string test = "Test";
            if (nummer == 0)
            {
                lblBinair.Content = test;
            }
            else if (nummer == 1)
            {
                lblDecimaal.Content = test;
            }

            else if (nummer == 2)
            {
                lblHexadecimaal.Content = test;
            }
            else if (nummer == 3)
            {
                lblOctaal.Content = test;
            }
        }

        private void whiteSpace(string whiteSpace)
        {
            if (whiteSpace == "")
            {
                lblBinair.Content = "";
                lblDecimaal.Content = "";
                lblHexadecimaal.Content = "";
            }
        }
    }
}
