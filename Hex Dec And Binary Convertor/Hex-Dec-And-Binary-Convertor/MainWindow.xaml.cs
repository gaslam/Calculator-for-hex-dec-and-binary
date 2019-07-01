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
using Convertor_berekenen.Lib;
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
        
        Berekenen berekenen = new Berekenen();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Selection.Length; i++)
            {
                cmbSelection.Items.Add(Selection[i]);
            }

            cmbSelection.SelectedIndex = 1;
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
                    whiteSpace(txtInput.Text);
                    labelVullen_berekenen(i);
                }
                
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

            else if (nummer == 2)
            {
                lblHexadecimaal.Content = nvt;
            }

            else if (nummer == 3)
            {
                lblOctaal.Content = nvt;
            }
        }

        private void labelVullen_berekenen(int nummer)
        {
            string test = "Test";
            if (nummer == 0)
            {
      
            }
            else if (nummer == 1)
            {
             
            }

            else if (nummer == 2)
            {
                hexadecimaal();
            }
            else if (nummer == 3)
            {
            
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

        private void hexadecimaal()
        {
            if (txtInput.Text != "")
            {
                lblHexadecimaal.Content = berekenen.Nummer(decimal.Parse(txtInput.Text));
            }
            
        }
        
    }
}
