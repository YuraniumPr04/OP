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
using System.IO;
namespace Lab2
{
    class Window3
    {
        public Window3()
        {
            InitControlls();
        }

        public Window wn = new Window();
        public TextBlock TB1 = new TextBlock();
        public TextBlock TB0 = new TextBlock();

        public void InitControlls()
        {
            wn.Title = "Калькулятор";
            wn.Width =  230.521;
            wn.Height = 300.459;
            wn.ResizeMode = ResizeMode.NoResize;
            wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Grid MyGrid = new Grid();
            MyGrid.ShowGridLines = false;
            List<double> RHeight = new List<double>()  { 5, 15, 35, 5, 30, 5, 30, 5, 30, 5, 30, 5, 30, 5, 30, 5};
            List<double> CWidth = new List<double>() { 5, 50, 5, 50, 5, 50, 5, 50, 5 };
            RowDefinition[] rows = new RowDefinition[RHeight.Count];
            ColumnDefinition[] cols = new ColumnDefinition[CWidth.Count];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            int i = 0;
            foreach (double h in RHeight)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(h + "* ");
                MyGrid.RowDefinitions.Add(rows[i]);
                i++;
            }
            i = 0;
            foreach (double w in CWidth)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(w + "* ");                                                                                                                 
                MyGrid.ColumnDefinitions.Add(cols[i]);
                i++;
            }

            TB0.Text = "0";
            TB0.Background = Brushes.LemonChiffon;
            TB0.Foreground = Brushes.LightPink;
            TB0.FontSize = 21;
            TB1.Background = Brushes.LemonChiffon;
            TB1.Foreground = Brushes.LightPink;
            TB1.FontSize = 11;
            Button[] BN = new Button[11];
            for(i = 0; i < 10; i++)
            {
                BN[i] = new Button();
                BN[i].Content = (i).ToString();
                BN[i].Click += BN_Click;
            }
            BN[10] = new Button();
            BN[10].Content = ",";
            BN[10].Click += BN_Click;
            Button[] BN_Op = new Button[4];
            List<string> bn_act_content = new List<string>() { "+", "-", "*", "/" };
            i = 0;
            foreach(string a in bn_act_content)
            {
                BN_Op[i] = new Button();
                BN_Op[i].Content = a;
                BN_Op[i].Click += BN_Op_Click;
                i++;
            }
            Button BN_Equals = new Button();
            BN_Equals.Content = "=";
            BN_Equals.Click += BN_Equals_Click;
            Button BN_Clear = new Button();
            BN_Clear.Content = "C";
            BN_Clear.Click += BN_Clear_Click;
            Button BN_Delete = new Button();
            BN_Delete.Content = "del";
            BN_Delete.Click += BN_Delete_Click;
            Button BN_ChangeSign = new Button();
            BN_ChangeSign.Content = "+/-";
            BN_ChangeSign.Click += BN_ChangeSign_Click;
            Button BN_ToMW = new Button();
            BN_ToMW.Content = "До головного вікна";
            BN_ToMW.Click += BN_ToMW_Click;

            Grid.SetRow(TB1, 1);
            Grid.SetColumn(TB1, 1);
            Grid.SetColumnSpan(TB1, 7);
            MyGrid.Children.Add(TB1);
            Grid.SetRow(TB0, 2);
            Grid.SetColumn(TB0, 1);
            Grid.SetColumnSpan(TB0, 7);
            MyGrid.Children.Add(TB0);
            int n = 0;
            for (i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    n += 1;
                    Grid.SetRow(BN[n], 6 + 2 * (j));
                    Grid.SetColumn(BN[n], 1 + 2 * (i));
                    MyGrid.Children.Add(BN[n]);
                }
            }
            n = 0;
            for (i = 0; i < 4; i++)
            {
               
                Grid.SetRow(BN_Op[n], 6 + 2 * (i));
                Grid.SetColumn(BN_Op[n], 7);
                MyGrid.Children.Add(BN_Op[n]);
                n += 1;
            }
            Grid.SetRow(BN_Equals, 4);
            Grid.SetColumn(BN_Equals, 3);
            MyGrid.Children.Add(BN_Equals);
            Grid.SetRow(BN_Clear, 4);
            Grid.SetColumn(BN_Clear, 5);
            MyGrid.Children.Add(BN_Clear);
            Grid.SetRow(BN_Delete, 4);
            Grid.SetColumn(BN_Delete, 7);
            MyGrid.Children.Add(BN_Delete);
            Grid.SetRow(BN_ChangeSign, 12);
            Grid.SetColumn(BN_ChangeSign, 1);
            MyGrid.Children.Add(BN_ChangeSign);
            Grid.SetRow(BN[0], 12);
            Grid.SetColumn(BN[0], 3);
            MyGrid.Children.Add(BN[0]);
            Grid.SetRow(BN[10], 12);
            Grid.SetColumn(BN[10], 5);
            MyGrid.Children.Add(BN[10]);
            Grid.SetRow(BN_ToMW, 14);
            Grid.SetColumn(BN_ToMW, 1);
            Grid.SetColumnSpan(BN_ToMW, 7);
            MyGrid.Children.Add(BN_ToMW);

            wn.Content = MyGrid;
            wn.Show();
        }

        //================|LOGIC|===============
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
                    if (SecondNum != 0)
                        FirstNum /= SecondNum;
                    else
                    {
                        FirstNum = 0;
                        SecondNum = 0;
                        ans = 0;
                        TB1.Text = "0";
                        TB0.Text = "";
                    }
                    break;

                default:
                    break;
            }
            SecondNum = 0;
            Sign = "";
            NumberStr = "";
        }

        //==
        private void BN_Click(object sender, RoutedEventArgs e)
        {
            NumberStr += (e.Source as Button).Content.ToString();
            TB0.Text = NumberStr;
            if (NumberStr == "," || NumberStr == "-,")
            {
                NumberStr = "0" + NumberStr;
                TB0.Text = NumberStr;
            }
        }
        private void BN_Op_Click(object sender, RoutedEventArgs e)
        {
            if (Sign == "" && FirstNum == 0)
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
            else if (NumberStr != "")
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
                TB1.Text = FirstNum.ToString() + " " + (e.Source as Button).Content.ToString();
                Sign = (e.Source as Button).Content.ToString();
                TB0.Text = FirstNum.ToString();
            }
            else
            {
                Sign = (e.Source as Button).Content.ToString();
                TB1.Text = FirstNum.ToString() + Sign;
            }

        }
        private void BN_Equals_Click(object sender, RoutedEventArgs e)
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
        private void BN_Clear_Click(object sender, RoutedEventArgs e)
        {
            NumberStr = "";
            FirstNum = 0;
            SecondNum = 0;
            Sign = "";
            TB0.Text = "0";
            TB1.Text = "";
        }
        private void BN_Delete_Click(object sender, RoutedEventArgs e)
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
        private void BN_ChangeSign_Click(object sender, RoutedEventArgs e)
        {

            if (NumberStr != "" && NumberStr.Contains("-"))
            {
                NumberStr = NumberStr.Remove(0, 1);
                TB0.Text = NumberStr;
            }
            else
            {
                NumberStr = "-" + NumberStr;
                TB0.Text = NumberStr;
            }

        }
        private void BN_ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            wn.Close();
        }
    }
}
    
