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

        string[] Selection = new string[] { "Binair", "Decimaal", "Hexadecimaal", "Octaal" };





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
            decimal ingave;
            string stringingave = "";

            if (decimal.TryParse(txtInput.Text, out ingave))
            {
                ingave = decimal.Parse(txtInput.Text, clone);
            }
            else
            {
                stringingave = txtInput.Text;
            }


            if (nummer == 0)
            {
                binary(clone, ingave, stringingave);
            }
            else if (nummer == 1)
            {
                decimaal(clone, ingave);
            }

            else if (nummer == 2)
            {
                hexadecimaal(clone, ingave);
            }
            else if (nummer == 3)
            {
                octaal(clone, ingave);
            }
        }

        private void whiteSpace(string whiteSpace)
        {
            if (whiteSpace == "")
            {
                lblBinair.Content = "";
                lblDecimaal.Content = "";
                lblHexadecimaal.Content = "";
                lblOctaal.Content = "";
            }
        }

        private void hexadecimaal(CultureInfo clone, decimal ingave)
        {
            if (txtInput.Text != "")
            {
                if (cmbSelection.SelectedValue.ToString() == "Decimaal")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblHexadecimaal.Content = newDecimal.hexNummer(ingave);
                }

                if (cmbSelection.SelectedValue.ToString() == "Binair" && Regex.IsMatch(ingave.ToString(), @"[0-1]") && !Regex.IsMatch(ingave.ToString(), @"[2-9]"))
                {
                    convertFromBinary newBinary = new convertFromBinary();
                    lblHexadecimaal.Content = newBinary.hexadecimal(ingave);
                }
            }
        }

        private void octaal(CultureInfo clone, decimal ingave)
        {

            if (txtInput.Text != "")
            {
                if (cmbSelection.SelectedValue.ToString() == "Decimaal")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblOctaal.Content = newDecimal.octaalNummer(ingave);
                }

                if (cmbSelection.SelectedValue.ToString() == "Binair" && Regex.IsMatch(ingave.ToString(), @"[0-1]") && !Regex.IsMatch(ingave.ToString(), @"[2-9]"))
                {
                    convertFromBinary newBinary = new convertFromBinary();
                    lblOctaal.Content = newBinary.octal(ingave);
                }
            }
        }

        private void binary(CultureInfo clone, decimal ingave, string stringingave)
        {
            if (txtInput.Text != "")
            {
                if (cmbSelection.SelectedValue.ToString() == "Decimaal" && stringingave == "")
                {
                    convertFromDecimal newDecimal = new convertFromDecimal();
                    lblBinair.Content = newDecimal.binairNummer(ingave);
                }

                if (cmbSelection.SelectedValue.ToString() == "Hexadecimaal")
                {
                    ConvertFromHexadecimal newDecimal = new ConvertFromHexadecimal();
                    lblBinair.Content = newDecimal.binary(stringingave);
                }
            }
        }

        private void decimaal(CultureInfo clone, decimal ingave)
        {
            if (txtInput.Text != "")
            {
                if (cmbSelection.SelectedValue.ToString() == "Binair" && Regex.IsMatch(ingave.ToString(), @"[0-1]") && !Regex.IsMatch(ingave.ToString(), @"[2-9]"))
                {
                    convertFromBinary newBinary = new convertFromBinary();
                    lblDecimaal.Content = newBinary.Decimaal(ingave);
                }
            }
        }

    }
}
