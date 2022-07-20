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

namespace WinApp
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            TB0.Text = "0";
        }

        //==========================
        public string NumberStr = "";
        public double ans = 0;
        public double FirstNum = 0;
        public double SecondNum = 0;
        public string Sign = "";

        private void Calculate()
        {
            switch (Sign)
            {
                case "+":
                    FirstNum += SecondNum;
                        break;

                case "-":
                    FirstNum -= SecondNum;
                    break;

                case "X":
                    FirstNum *= SecondNum;
                    break;

                case "/":
                    if(SecondNum != 0)
                        FirstNum /= SecondNum;
                    else
                    {
                        FirstNum = 0;
                        SecondNum = 0;
                        ans = 0;
                    }
                    break;

                default:
                    break;
            }
            SecondNum = 0;
            Sign = "";
            NumberStr = "0";
        }
        //==========================

        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void BN_Click(object sender, RoutedEventArgs e)
        {
            NumberStr += (e.Source as Button).Content.ToString();
            TB0.Text = NumberStr;
            if (NumberStr == ","|| NumberStr == "-,")
            {
                NumberStr = "0" + NumberStr;
                TB0.Text = NumberStr;
            }
        }

        private void BActSign_Click(object sender, RoutedEventArgs e)
        {
            if(Sign == ""&&FirstNum==0)
            {
                Sign = (e.Source as Button).Content.ToString();

                try
                {
                    FirstNum = Convert.ToDouble(NumberStr);
                }
                catch
                {
                    FirstNum = 0;
                    NumberStr = "0";
                }
                
                TB1.Text = NumberStr + Sign;
                NumberStr = "";
            }
            else if(NumberStr != "")
            {
                try
                {
                    SecondNum = Convert.ToDouble(NumberStr);
                }
                catch
                {
                    SecondNum = 0;
                }
                Calculate();
                TB1.Text = FirstNum.ToString() + " "+ (e.Source as Button).Content.ToString();
                Sign = (e.Source as Button).Content.ToString();
                TB0.Text = FirstNum.ToString();
            }
            else
            {
                Sign = (e.Source as Button).Content.ToString();
                TB1.Text = FirstNum.ToString() +  Sign;
            }
        }

        private void BEquals_Click(object sender, RoutedEventArgs e)
        {
            if (Sign != "" && NumberStr != "")
            {
                try
                {
                    SecondNum = Convert.ToDouble(NumberStr);
                }
                catch
                {
                    SecondNum = 0;
                }
                TB1.Text += NumberStr + "=";
                Calculate();
                NumberStr = "";
                Sign = "";
                TB0.Text = FirstNum.ToString();
            }
            else if (Sign != "" && NumberStr == "")
            {
                Sign = "";
                TB1.Text = FirstNum.ToString() + "=";
                TB0.Text = FirstNum.ToString();
            }
            else
            {
                try
                {
                    FirstNum = Convert.ToDouble(NumberStr);
                }
                catch
                {

                }
                NumberStr = "";
                Sign = "";
                TB1.Text = FirstNum.ToString() + "=";
                TB0.Text = FirstNum.ToString();
            }            
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            NumberStr = "";
            FirstNum = 0;
            SecondNum = 0;
            Sign = "";
            TB0.Text = "0";
            TB1.Text = "";
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (NumberStr.Length > 1)
            {
                NumberStr = NumberStr.Remove(NumberStr.Length - 1);
                TB0.Text = NumberStr;
            }
            else
            {
                NumberStr = "";
                TB0.Text = "0";
            }
        }

        private void BSign_Click(object sender, RoutedEventArgs e)
        {

            if (NumberStr != "" && NumberStr.Contains("-"))
            {
                NumberStr = NumberStr.Remove(0,1);
                TB0.Text = NumberStr;
            }
            else
            {
                NumberStr = "-" + NumberStr;
                TB0.Text = NumberStr;
            }

        }
    }
}
