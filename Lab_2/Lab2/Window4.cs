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
    class Window4
    {
        public Window4()
        {
            InitControlls();
        }

        public Window wn = new Window();
    
        public void InitControlls()
        {
            wn.Title = "Про розробника";
            wn.Width = 640.521;
            wn.Height = 210.459;
            wn.ResizeMode = ResizeMode.NoResize;
            wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Grid MyGrid = new Grid();
            MyGrid.ShowGridLines = false;
            List<double> RHeight = new List<double>() {10,40,20,20,20,20,20,20,30,10 };
            List<double> CWidth = new List<double>() { 10, 420, 200, 10 };
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

            TextBlock[] TB = new TextBlock[6];
            List<string> TB_Contents = new List<string>()
            {
                "ПІБ: Приймак Юрій Дмитрович."
                , "Група: КП-12."
                , "Факультет: ФПМ"
                , "Національний університет України\"Київський політехнічний інститут імені Ігоря Сікорського\""
                , "Cтворено: 24.05.2022."
            };

            TB[0] = new TextBlock();
            TB[0].Text = "Про розробника";
            TB[0].Foreground = Brushes.LightPink;
            TB[0].FontSize = 18;
            i = 1;
            foreach(string str in TB_Contents)
            {
                TB[i] = new TextBlock();
                TB[i].Text = str;
                TB[i].Foreground = Brushes.Gray;
                TB[i].FontSize = 14;
                i++;
            }
            Button ToMW = new Button();
            ToMW.Content = "До головного вікна";
            ToMW.Click += ToMW_Click;

            for(i = 0; i<6; i++)
            {
                Grid.SetRow(TB[i], 1+i);
                Grid.SetColumn(TB[i], 1);
                Grid.SetColumnSpan(TB[i], 2);
                MyGrid.Children.Add(TB[i]);
            }
            Grid.SetRow(ToMW, 8);
            Grid.SetColumn(ToMW, 2);
            MyGrid.Children.Add(ToMW);


            wn.Content = MyGrid;
            wn.Show();
        }

        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            wn.Close();
        }
    }
}
