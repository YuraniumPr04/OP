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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            FillDictSetCMItemsValue();
            setCells();
        }

        //=============================
        public Dictionary<string, (int, int)> CBNum = new Dictionary<string, (int, int)>();
        private void FillDictSetCMItemsValue()
        {


            for (int n = 0; n < 25; n++)
            {
                CBNum.Add("CB" + n.ToString(), (n / 5, n - (n / 5) * 5));
            }
        }
        bool game = true;
        int player = 1;
        int[,] cell = new int[5, 5];
        private void setCells()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j =0; j < 5; j++)
                {
                    cell[i, j] = -1;
                }
            }
               
        }
        private void WinCheck(int i,int j)
        {
            if(  LineCheck(i, j, -1, 0) + LineCheck(i, j, +1, 0) +1 >= 4)
            {
                Win();
            }
            if (LineCheck(i, j, 0, -1) + LineCheck(i, j, 0, +1) +1 >= 4)
            {
                Win();
            }
            if (LineCheck(i, j, -1, -1) + LineCheck(i, j, +1, +1) +1 >=4)
            {
                Win();
            }
            if (LineCheck(i, j, -1, +1) + LineCheck(i, j, +1, -1) +1 >= 4)
            {
                Win();
            }
        }
        private int LineCheck(int i, int j, int a, int b)
        {
            int n = a;
            int m = b;
            int streak = 0;
            bool line = true;
            while (line && i + n >= 0 && i + n <= 4 && j + m >= 0 && j + m <= 4) 
            {
                if (cell[i, j] == cell[i + n, j + m])
                {
                    streak++;
                    n += a;
                    m += b;
                }
                else
                    line = false;
            }
            return streak;
        }
        private void Win()
        {
            var message = MessageBox.Show("Player " + player.ToString() + "win");
            for (int n = 0; n < 25; n++)
            {
                object item = Field.FindName("CB" + n.ToString());
                ComboBox cb = (ComboBox)item;
                cb.IsEnabled = false;
                
            }
            switch (player)
            {
                case 0:

                    TB0.Text = (Convert.ToInt32(TB0.Text) + 1).ToString();
                    
                    break;
                case 1:
                    TB1.Text = (Convert.ToInt32(TB1.Text) + 1).ToString();
                    break;
                default:
                    break;
            }
            game = false;
        }
        //=============================

        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }


        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (game)
            {
                int i, j;
                (i, j) = CBNum[(e.Source as ComboBox).Name];
                cell[i, j] = player;
                WinCheck(i, j);
                (e.Source as ComboBox).IsEnabled = false;
                switch (player)
                {
                    case 0:
                        player = 1;
                        TB1.FontWeight = FontWeights.Bold;
                        TB3.FontWeight = FontWeights.Bold;
                        TB0.FontWeight = FontWeights.Light;
                        TB4.FontWeight = FontWeights.Light;
                        break;
                    case 1:
                        player = 0;
                        TB1.FontWeight = FontWeights.Light;
                        TB3.FontWeight = FontWeights.Light;
                        TB0.FontWeight = FontWeights.Bold;
                        TB4.FontWeight = FontWeights.Bold;
                        break;
                    default:
                        break;
                }
            }
        }

        private void CB_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            List<string> item1 = new List<string> { "x" };
            List<string> item0 = new List<string> { "o" };
            switch (player)
            {
                case 0:
                    (e.Source as ComboBox).ItemsSource = item0;
                    break;
                case 1:
                    (e.Source as ComboBox).ItemsSource = item1;
                    break;
                default:
                    break;
            }
        }

        private void PAgain_Click(object sender, RoutedEventArgs e)
        {
            setCells();
            for (int n = 0; n < 25; n++)
            {
                player = 1;
                object item = Field.FindName("CB" + n.ToString());
                ComboBox cb = (ComboBox)item;
                cb.IsEnabled = true;
                cb.SelectedIndex = -1;
            }
            game = true;
            TB1.FontWeight = FontWeights.Bold;
            TB3.FontWeight = FontWeights.Bold;
            TB0.FontWeight = FontWeights.Light;
            TB4.FontWeight = FontWeights.Light;
        }
    }
}
