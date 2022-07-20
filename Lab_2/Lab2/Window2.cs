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
    class Window2
    {
        public Window2()
        {
            InitControlls();
            FillDictSetCMBItemsValue();
            SetCells();
        }
        public Window wn = new Window();
        public ComboBox[,] CB = new ComboBox[5, 5];
        public TextBlock[] P0 = new TextBlock[2];
        public TextBlock[] P1 = new TextBlock[2];

        public void InitControlls()
        {
            wn.Title = "Журнал";
            wn.Width = 500;
            wn.Height = 290;
            wn.ResizeMode = ResizeMode.NoResize;
            wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid MyGrid = new Grid();
            MyGrid.ShowGridLines = false;
            List<double> RHeight = new List<double>() { 10, 50, 5, 50, 5, 50, 5, 50, 5, 50, 10 };
            List<double> CWidth = new List<double>() { 10, 50, 5, 50, 5, 50, 5, 50, 5, 50, 10, 100, 100, 10 };
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

            //field
            for (i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    CB[i, j] = new ComboBox();
                    CB[i, j].GotKeyboardFocus += CB0_GotKeyboardFocus;
                    CB[i, j].SelectionChanged += CB0_SelectionChanged;
                    CB[i, j].Name = "CB" + Convert.ToString(i * 5 + j);
                    CB[i, j].FontSize = 32;
                    
                }
            }
            Button ToMW = new Button(); // Tomw
            ToMW.Content = "До головного вікна";
            ToMW.Click += ToMW_Click;
            Button PlayAgain = new Button(); // Play again
            PlayAgain.Content = "Грати заново";
            PlayAgain.Click += PlayAgain_Click;
            //Player0 info
            for (i = 0; i < 2; i++)
            {
                P0[i] = new TextBlock();
                P0[i].Background = Brushes.LemonChiffon;
                P0[i].Foreground = Brushes.LightPink;
            }
            P0[0].FontSize = 24;
            P0[0].Text = "Player1";
            P0[0].FontWeight = FontWeights.Bold;
            P0[1].FontSize = 36;
            P0[1].Text = "0";
            P0[1].FontWeight = FontWeights.Bold;
            P0[1].TextAlignment = TextAlignment.Center;
            //Player0 info
            for (i = 0; i < 2; i++)
            {
                P1[i] = new TextBlock();
                P1[i].Background = Brushes.LemonChiffon;
                P1[i].Foreground = Brushes.LightPink;
            }
            P1[0].FontSize = 24;
            P1[0].Text = "Player2";
            P1[1].FontSize = 36;
            P1[1].Text = "0";
            P1[1].TextAlignment = TextAlignment.Center;

            for (i = 0; i<5;i++)//field
            {
                for (int j = 0; j < 5; j++)
                {
                    Grid.SetRow(CB[i,j],  1 + 2 * (j ));
                    Grid.SetColumn(CB[i,j], 1 + 2 * (i ));
                    MyGrid.Children.Add(CB[i,j]);
                }
            }
            Grid.SetRow(ToMW, 9);//ToMW
            Grid.SetColumn(ToMW, 11);
            Grid.SetColumnSpan(ToMW, 2);
            MyGrid.Children.Add(ToMW);
            Grid.SetRow(PlayAgain, 7);//Play Again
            Grid.SetColumn(PlayAgain, 11);
            Grid.SetColumnSpan(PlayAgain, 2);
            MyGrid.Children.Add(PlayAgain);
            Grid.SetRow(P0[0], 1);//Player0
            Grid.SetColumn(P0[0], 11);
            MyGrid.Children.Add(P0[0]);
            Grid.SetRow(P0[1], 2);
            Grid.SetColumn(P0[1], 11);
            Grid.SetRowSpan(P0[1], 2);
            MyGrid.Children.Add(P0[1]);
            Grid.SetRow(P1[0], 1);//Player1
            Grid.SetColumn(P1[0], 12);
            MyGrid.Children.Add(P1[0]);
            Grid.SetRow(P1[1], 2);
            Grid.SetColumn(P1[1], 12);
            Grid.SetRowSpan(P1[1], 2);
            MyGrid.Children.Add(P1[1]);

            wn.Content = MyGrid;
            wn.Show();
        }

       

        public Dictionary<string, (int, int)> CBNum = new Dictionary<string, (int, int)>();
        public bool game = true;
        public int player = 1;
        public int[,] cell = new int[5, 5];
        private void FillDictSetCMBItemsValue()
        {


            for (int n = 0; n < 25; n++)
            {
                CBNum.Add("CB" + n.ToString(), (n / 5, n - (n / 5) * 5));
            }
        }
        private void SetCells()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    cell[i, j] = -1;
                }
            }

        }
        private void WinCheck(int i, int j)
        {
            if (LineCheck(i, j, -1, 0) + LineCheck(i, j, +1, 0) + 1 >= 4)
            {
                Win();
            }
            if (LineCheck(i, j, 0, -1) + LineCheck(i, j, 0, +1) + 1 >= 4)
            {
                Win();
            }
            if (LineCheck(i, j, -1, -1) + LineCheck(i, j, +1, +1) + 1 >= 4)
            {
                Win();
            }
            if (LineCheck(i, j, -1, +1) + LineCheck(i, j, +1, -1) + 1 >= 4)
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
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CB[i, j].IsEnabled = false;
                }
            }
            switch (player)
            {
                case 0:

                    P0[1].Text = (Convert.ToInt32(P0[1].Text) + 1).ToString();

                    break;
                case 1:
                    P1[1].Text = (Convert.ToInt32(P1[1].Text) + 1).ToString();
                    break;
                default:
                    break;
            }
            game = false;
        }
        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            wn.Close();
        }

        private void CB0_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
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
        private void CB0_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                        P1[0].FontWeight = FontWeights.Bold;
                        P1[1].FontWeight = FontWeights.Bold;
                        P0[0].FontWeight = FontWeights.Light;
                        P0[1].FontWeight = FontWeights.Light;
                        break;
                    case 1:
                        player = 0;
                        P1[0].FontWeight = FontWeights.Light;
                        P1[1].FontWeight = FontWeights.Light;
                        P0[0].FontWeight = FontWeights.Bold;
                        P0[1].FontWeight = FontWeights.Bold;
                        break;
                    default:
                        break;
                }
            }
        }
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            SetCells();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    player = 1;
                    CB[i, j].IsEnabled = true;
                    CB[i, j].SelectedItem = -1;
                    CB[i, j].Text = "";
                }
            }
            game = true;
            P1[0].FontWeight = FontWeights.Bold;
            P1[1].FontWeight = FontWeights.Bold;
            P0[0].FontWeight = FontWeights.Light;
            P0[1].FontWeight = FontWeights.Light;
        }
    }    
}
