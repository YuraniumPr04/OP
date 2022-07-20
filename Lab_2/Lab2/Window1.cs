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
    class Window1
    {
        public Window1()
        {
            initControlls();
            (previous, LogID) = ReadAndRemember();
            SetHints();
            CB0.ItemsSource = LogID;
        }

        public Window wn = new Window();
        public ComboBox CB0 = new ComboBox();
        public TextBox[] TB = new TextBox[3];
        public Button[] B = new Button[4];
 

        private void initControlls()
        {
            wn.Title = "Журнал";
            wn.Width = 440;
            wn.Height = 160;
            wn.ResizeMode = ResizeMode.NoResize;
            wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Grid MyGrid = new Grid();
            MyGrid.ShowGridLines = false;
            List<double> RHeight = new List<double>() {10, 35, 5 ,35,5,35,5,35,10};
            List<double> CWidth = new List<double>() { 10, 220, 50, 150, 10 };
            RowDefinition[] rows = new RowDefinition[RHeight.Count];
            ColumnDefinition[] cols = new ColumnDefinition[CWidth.Count];
            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            int i = 0;
            foreach(double h in RHeight)
            {
                rows[i] = new RowDefinition();
                rows[i].Height = (GridLength)gridLengthConverter.ConvertFrom(h + "* ");
                MyGrid.RowDefinitions.Add(rows[i]);
                i++;
            }
            i = 0;
            foreach(double w in CWidth)
            {
                cols[i] = new ColumnDefinition();
                cols[i].Width = (GridLength)gridLengthConverter.ConvertFrom(w + "* ");
                MyGrid.ColumnDefinitions.Add(cols[i]);
                i++;
            }

            //comtrols settings
                CB0.Height = 35;
                CB0.Width = 220;
                CB0.GotKeyboardFocus += CB0_GotKeyboardFocus;
                CB0.LostKeyboardFocus += CB0_LostKeyboardFocus;
                CB0.MouseEnter += CB0_MouseEnter;
                CB0.MouseLeave += CB0_MouseLeave;
                CB0.SelectionChanged += CB0_SelectionChanged;
            for(i = 0; i < 3; i++)
            {
                TB[i] = new TextBox();
                TB[i].Name = "TB" + i.ToString();
                TB[i].Height = 35;
                TB[i].Width = 220;
                TB[i].TextChanged += TB_TextChanged;
                TB[i].GotKeyboardFocus += TB_GotKeyboardFocus;
                TB[i].LostKeyboardFocus += TB_LostKeyboardFocus;
                TB[i].MouseEnter += TB_MouseEnter;
                TB[i].MouseLeave += TB_MouseLeave;
            }
            //==Add
            Button ReadButton = new Button();
            B[0] = ReadButton;
            ReadButton.Content = "Додати";
            ReadButton.Click += ReadButton_Click;
            //==Edit
            Button EditButton = new Button();
            B[1] = EditButton;
            EditButton.Content = "Редагувати";
            EditButton.Click += EditButton_Click;
            EditButton.IsEnabled = false;
            //==Delete
            Button DeleteButton = new Button();
            B[2] = DeleteButton;
            DeleteButton.Content = "Видалити";
            DeleteButton.Click += DeleteButton_Click;
            DeleteButton.IsEnabled = false;
            //==ToMW
            Button ToMW = new Button();
            B[3] = ToMW;
            ToMW.Content = "До головного вікна";
            ToMW.Click += ToMW_Click;

            //GreedContent
            Grid.SetRow(CB0, 1);
            Grid.SetColumn(CB0, 1);
            MyGrid.Children.Add(CB0);
            for (i = 0; i < 3; i++)
            {
                Grid.SetRow(TB[i], 1 + 2 * (i + 1));
                Grid.SetColumn(TB[i], 1);
                MyGrid.Children.Add(TB[i]);
            }
            Grid.SetRow(ReadButton, 1);
            Grid.SetColumn(ReadButton, 3);
            MyGrid.Children.Add(ReadButton);
            Grid.SetRow(EditButton, 3);
            Grid.SetColumn(EditButton, 3);
            MyGrid.Children.Add(EditButton);
            Grid.SetRow(DeleteButton, 5);
            Grid.SetColumn(DeleteButton, 3);
            MyGrid.Children.Add(DeleteButton);
            Grid.SetRow(ToMW, 7);
            Grid.SetColumn(ToMW, 3);
            MyGrid.Children.Add(ToMW);

            wn.Content = MyGrid;
            wn.Show();
        }

        //=======|logic|======
        public string[] hints = new string[] { "номер залікової книжки", "прізвище", "ім'я", "по-батькові" };
        public List<uint> LogID = new List<uint>();//Існуючі номери
        public string previous = "";//Всі існуючі записи

        private (string, List<uint>) ReadAndRemember()
        {
            List<uint> LogID = new List<uint>();
            string previous = "";
            StreamReader AccountR;
            AccountR = new StreamReader("Students.txt");
            string log = "";
            while (!AccountR.EndOfStream)
            {
                try
                {
                    log = AccountR.ReadLine();
                    previous += log + "\n";
                    string[] LastLog = log.Split('|');
                    LogID.Add(Convert.ToUInt32(LastLog[0]));
                }
                catch
                {

                }
            }
            AccountR.Close();
            return (previous, LogID);
        }

        private bool InputCheck(List<uint> LogID)
        {
            StreamReader RChar = new StreamReader("Chars.txt");
            string AllowedChars = RChar.ReadToEnd();
            int i = 1;
            bool x = true;
            foreach (TextBox tb in TB)
            {
                if (tb.Text == "")
                {
                    x = false;
                    tb.Text = hints[i];
                    tb.Foreground = Brushes.Red;
                }
                else if (tb.Text.Contains(hints[0])
                    || tb.Text.Contains(hints[1])
                    || tb.Text.Contains(hints[2])
                    || tb.Text.Contains(hints[3]))
                {
                    x = false;
                    tb.Foreground = Brushes.Red;
                }
                else
                {
                    char[] CharText = tb.Text.ToCharArray();
                    foreach (char ch in CharText)
                    {
                        if (!AllowedChars.Contains(ch.ToString()))
                        {
                            x = false;
                            tb.Foreground = Brushes.Red;
                        }
                    }
                }
                i++;

            }
            try
            {
                if (LogID.Contains(Convert.ToUInt32(CB0.Text)))
                {
                    x = false;
                    CB0.Foreground = Brushes.Red;

                }
            }
            catch
            {
                x = false;
                CB0.Foreground = Brushes.Red;

            }
            return x;
        }

        private void WtiteToFile(string previous)
        {
            StreamWriter AccountW;
            AccountW = new StreamWriter("Students.txt");
            string ToWrite = previous + Convert.ToString(CB0.Text);
            foreach(TextBox tb in TB)
            {
                ToWrite += "|" + tb.Text;
            }
            AccountW.Write(ToWrite);
            AccountW.Close();
        }

        private void SetHints()
        {
            int i = 1;
            foreach (TextBox tb in TB)
            {
                tb.Text = hints[i];
                tb.Foreground = Brushes.Gray;
                i++;
            }
            CB0.Text = hints[0];
            CB0.Foreground = Brushes.Gray;
        }

        //=======|Buttons|=======
        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck(LogID))
            {
                WtiteToFile(previous);
                previous += Convert.ToString(CB0.Text) ;
                foreach(TextBox tb in TB)
                {
                    previous += "|" + tb.Text;
                }
                previous += "\n";
                LogID.Add(Convert.ToUInt32(CB0.Text));
                SetHints();
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string ToWrite = "";
            StreamReader AccountR = new StreamReader("Students.txt");
            while (!AccountR.EndOfStream)
            {
                try
                {
                    string log = AccountR.ReadLine();
                    string[] LastLog = log.Split('|');
                    if (Convert.ToUInt32(CB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
                    {
                        ToWrite += Convert.ToString(CB0.Text);
                        foreach (TextBox tb in TB)
                        {
                            ToWrite += "|" + tb.Text;
                        }
                        ToWrite += "\n";
                    }
                    else
                    {
                        ToWrite += log + "\n";
                    }
                }
                catch
                {

                }
            }
            AccountR.Close();
            previous = ToWrite;
            StreamWriter AccountW = new StreamWriter("Students.txt");
            AccountW.Write(ToWrite);
            AccountW.Close();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string ToWrite = "";
            StreamReader AccountR = new StreamReader("Students.txt");
            while (!AccountR.EndOfStream)
            {
                try
                {
                    string log = AccountR.ReadLine();
                    string[] LastLog = log.Split('|');
                    if (Convert.ToUInt32(CB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
                    {

                    }
                    else
                    {
                        ToWrite += log + "\n";
                    }
                }
                catch
                {

                }
            }
        }
        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            wn.Close();
        }
        //=======================

        private void CB0_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CB0.Text != hints[0])
                CB0.Foreground = Brushes.Black;
            try
            {
                if (LogID.Contains(Convert.ToUInt32(CB0.SelectedValue)))
                {
                    B[2].IsEnabled = true;
                    B[1].IsEnabled = true;
                    B[0].IsEnabled = false;
                    StreamReader AccountR = new StreamReader("Students.txt");
                    while (!AccountR.EndOfStream)
                    {
                        try
                        {
                            string log = AccountR.ReadLine();
                            string[] LastLog = log.Split('|');
                            if (Convert.ToUInt32(CB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    TB[i].Text = LastLog[i + 1];
                                    TB[i].Foreground = Brushes.Black;
                                }
                            }
                        }
                        catch
                        {
                            B[2].IsEnabled = false;
                            B[1].IsEnabled = false;
                            B[0].IsEnabled = true;
                        }
                    }
                    AccountR.Close();
                }
                else
                {
                    B[2].IsEnabled = false;
                    B[1].IsEnabled = false;
                    B[0].IsEnabled = true;
                }
            }
            catch
            {

            }
        }
        private void TB_TextChanged(object sender, RoutedEventArgs e)
        {
            if ((e.Source as TextBox).Text != hints[Convert.ToInt32((e.Source as TextBox).Name[2].ToString()) + 1])
                (e.Source as TextBox).Foreground = Brushes.Black;
        }

        private void TB_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if ((e.Source as TextBox).Text == hints[Convert.ToInt32((e.Source as TextBox).Name[2].ToString()) + 1])
            {
                (e.Source as TextBox).Text = null;
                (e.Source as TextBox).Foreground = Brushes.Black;
            }
            (e.Source as TextBox).FontStyle = FontStyles.Italic;
        }
        private void CB0_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if (CB0.Text == hints[0])
            {
                CB0.Text = null;
                CB0.Foreground = Brushes.Black;
            }
            CB0.FontStyle = FontStyles.Italic;
        }

        private void TB_LostKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if ((e.Source as TextBox).Text == "")
            {
                (e.Source as TextBox).Text = hints[Convert.ToInt32((e.Source as TextBox).Name[2].ToString()) + 1];
                (e.Source as TextBox).Foreground = Brushes.Gray;
            }
            (e.Source as TextBox).FontStyle = FontStyles.Normal;
        }
        private void CB0_LostKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if (CB0.Text == "")
            {
                CB0.Text = hints[0];
                CB0.Foreground = Brushes.Gray;
            }
            CB0.FontStyle = FontStyles.Normal;
        }

        private void TB_MouseEnter(object sender, RoutedEventArgs e)
        {
            (e.Source as TextBox).FontStyle = FontStyles.Italic;
        }
        private void CB0_MouseEnter(object sender, RoutedEventArgs e)
        {
            CB0.FontStyle = FontStyles.Italic;
        }

        private void TB_MouseLeave(object sender, RoutedEventArgs e)
        {
            (e.Source as TextBox).FontStyle = FontStyles.Normal;
        }
        private void CB0_MouseLeave(object sender, RoutedEventArgs e)
        {
            CB0.FontStyle = FontStyles.Normal;
        }
    }
}
