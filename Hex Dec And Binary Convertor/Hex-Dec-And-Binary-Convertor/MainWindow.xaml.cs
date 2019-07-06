using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Convertor_berekenen.Lib.Calculations;
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

            CultureInfo clone = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            clone.NumberFormat.NumberDecimalSeparator = ",";
            clone.NumberFormat.NumberDecimalSeparator = ".";

            if (nummer == 0)
            {
            binary(clone);
            }
            else if (nummer == 1)
            {
             
            }

            else if (nummer == 2)
            {
                hexadecimaal(clone);
            }
            else if (nummer == 3)
            {
             octaal(clone);
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

        private void hexadecimaal(CultureInfo clone)
        {
            if (txtInput.Text != "")
            {
                
                decimal ingave = decimal.Parse(txtInput.Text, clone);

                if (cmbSelection.SelectedValue.ToString() == "Decimaal")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblHexadecimaal.Content = newDecimal.hexNummer(ingave);
                }

                if (cmbSelection.SelectedValue.ToString() == "Binair" && Regex.IsMatch(ingave.ToString(), @"[0-1]") && !Regex.IsMatch(ingave.ToString(),@"[2-9]"))
                {
                  convertFromBinary newBinary = new convertFromBinary();
                  lblHexadecimaal.Content = newBinary.hexadecimal(ingave.ToString());
                }
            }  
        }

        private void octaal(CultureInfo clone)
        {

            if (txtInput.Text != "")
            {
                decimal ingave = decimal.Parse(txtInput.Text, clone);
                if (cmbSelection.SelectedValue.ToString() == "Decimaal")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblOctaal.Content = newDecimal.octaalNummer(ingave);
                }
            }
        }

        private void binary(CultureInfo clone)
        {
            if (txtInput.Text != "")
            {
                decimal ingave = decimal.Parse(txtInput.Text, clone);
                if (cmbSelection.SelectedValue.ToString() =="Decimaal")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblBinair.Content = newDecimal.binairNummer(ingave);
                }
            }
        }
        
    }
}
