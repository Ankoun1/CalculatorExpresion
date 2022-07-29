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

namespace CalculatorExpresion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal first;       
        decimal second;
        decimal result = 0;
        char operatorCalc;
        bool error = false;
        bool operatorsExist => operatorCalc != '+' && operatorCalc != '-' && operatorCalc != '*' && operatorCalc != '/';

        public MainWindow()
        {
            InitializeComponent();
        }
        public void Diseble()
        {

            Grid.IsEnabled = false;
            Off.IsEnabled = true;
            On.IsEnabled = false;
            TxtResult.Text = String.Empty; 


        }

        public void Eneble()
        {
            
            Grid.IsEnabled = true;
            Off.IsEnabled = false;
            On.IsEnabled = true;
            TxtResult.Text = "0";

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;
            if(TxtResult.Text == "0" || result != 0 || TxtResult.Text == "error!")
            {
                TxtResult.Clear();
                result = 0;
            }
            
            TxtResult.Text += btn.Content.ToString();

            second = decimal.Parse(TxtResult.Text);
        }       

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
           
            //first = decimal.Parse(TxtResult.Text);
            operatorCalc = 'C';
            TxtResult.Text = "0";
        } 
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
            }
            else if (operatorsExist)
            {
                first = decimal.Parse(TxtResult.Text);
                operatorCalc = '/';
                TxtResult.Clear();
            }
        }

        private void MulButton_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
            }
            else if (operatorsExist)
            {
                first = decimal.Parse(TxtResult.Text);
                operatorCalc = '*';
                TxtResult.Clear();
            }
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
            }
            else if (operatorsExist)
            {
                first = decimal.Parse(TxtResult.Text);
                operatorCalc = '-';
                TxtResult.Clear();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
            }
            else if (operatorsExist)
            { 
                first = decimal.Parse(TxtResult.Text);
                operatorCalc = '+';
                TxtResult.Clear();
            }
            

        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            

            if (TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
                error = true;
            }
            else
            {
                second = decimal.Parse(TxtResult.Text);
            }
           
            
            //operatorCalc = '=';
            //TxtResult.Clear();

            switch (operatorCalc)
            {
                case '*':
                    result = first * second;
                    break;
                case '/':
                    if (second != 0)
                    {
                    
                        result = first / second;
                    }
                    else
                    {
                        if (!error)
                        {
                            TxtResult.Text = "error!";
                        }                       
                       
                        
                    }
                  
                    break; 
                case '-':
                    result = first - second;
                    break;
                case '+':
                    result = first + second;

                    break;
               
                default:
                    TxtResult.Text = "0";
                    break;
            }

            operatorCalc = default;

            if(TxtResult.Text == "0")
            {
                TxtResult.Clear();
            }
            if (TxtResult.Text != "error!")
            {
                TxtResult.Text = result.ToString();
                error = false;
            }
            
        }

        private void RealNumButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(TxtResult.Text == "error!")
            {
                TxtResult.Text = "0";
            }
            else if (!TxtResult.Text.Contains(','))
            {
                TxtResult.Text += ",";
                second = decimal.Parse(TxtResult.Text);
            }     
        }


        private void On_Click(object sender, RoutedEventArgs e)
        {
            Diseble();
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            Eneble();
        }
       

        private void Correction_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = TxtResult.Text.Substring(0, TxtResult.Text.Length - 1);
            if (TxtResult.Text == "error!" || TxtResult.Text.Length == 0)
            {
                TxtResult.Text = "0";
            }
            
        }
    }
}
