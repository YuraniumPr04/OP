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

namespace WinApp 
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1A : Window
    {
        public Window1A()
        {
            InitializeComponent();
        }
        public string[] hints = new string[] { "номер залікової книжки", "прізвище", "ім'я", "по-батькові" };
        public List<uint> LogID = new List<uint>();//Існуючі номери
        public string previous = "";//Всі існуючі записи
        private void Window1A_Loaded(object sender,EventArgs e)
        {
            (previous, LogID) = ReadAndRemember();
            SetHints();
            CMB0.ItemsSource = LogID;
        }
        
        


        
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

        private void WtiteToFile(string previous)
        {
            StreamWriter AccountW;
            AccountW = new StreamWriter("Students.txt");
            AccountW.Write(previous + Convert.ToString(CMB0.Text) + "|" + TB1.Text + "|" + TB2.Text + "|" + TB3.Text);
            AccountW.Close();
        }

        private bool InputCheck(List<uint> LogID)
        {
            StreamReader RChar = new StreamReader("Chars.txt");
            string AllowedChars = RChar.ReadToEnd();
            int i = 1;
            bool x = true;
            List<TextBox> TBList = new List<TextBox>() {TB1,TB2,TB3};
            foreach(TextBox tb in TBList)
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
                    foreach(char ch in CharText)
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
                if (LogID.Contains(Convert.ToUInt32(CMB0.Text)))
                {
                    x = false;
                    CMB0.Foreground = Brushes.Red;

                }
            }
            catch
            {
                x = false;
                CMB0.Foreground = Brushes.Red;

            }
            return x;
        }
        

        //===============\/=|Обробники Кнопок|=\/=================== 

        private void ReadButton_Click(object sender, RoutedEventArgs e) 
        {
            
            if (InputCheck(LogID))
            {
                WtiteToFile(previous);
                previous += Convert.ToString(CMB0.Text) + "|" + TB1.Text + "|" + TB2.Text + "|" + TB3.Text + "\n";
                LogID.Add(Convert.ToUInt32(CMB0.Text));
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
                    if (Convert.ToUInt32(CMB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
                    {
                        ToWrite += Convert.ToString(CMB0.Text) + "|" + TB1.Text + "|" + TB2.Text + "|" + TB3.Text + "\n";
                    }
                    else
                    {
                        ToWrite += log+"\n";
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
                    if (Convert.ToUInt32(CMB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
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
            AccountR.Close();
            previous = ToWrite;
            StreamWriter AccountW = new StreamWriter("Students.txt");
            AccountW.Write(ToWrite);
            AccountW.Close();
            LogID.Remove(Convert.ToUInt32(CMB0.SelectedItem));
            SetHints();
        }

        private void ToMW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        //===============\/=|Обробники TextBox + ComboBox|=\/=================== 
        private void SetHints()
        {
            int i = 1; 
            List<TextBox> TBList = new List<TextBox>() {TB1, TB2, TB3 };
            foreach(TextBox tb in TBList)
            {                
                tb.Text = hints[i];
                tb.Foreground = Brushes.Gray;
                i++;
            }
            CMB0.Text = hints[0];
            CMB0.Foreground = Brushes.Gray;
        }


        private void CMB0_MouseEnter(object sender, MouseEventArgs e)
        {
            CMB0.FontStyle = FontStyles.Italic;
        }
        private void TB1_MouseEnter(object sender, MouseEventArgs e)
        {
            TB1.FontStyle = FontStyles.Italic;
        }
        private void TB2_MouseEnter(object sender, MouseEventArgs e)
        {
            TB2.FontStyle = FontStyles.Italic;
        }
        private void TB3_MouseEnter(object sender, MouseEventArgs e)
        {
            TB3.FontStyle = FontStyles.Italic;
        }

        private void CMB0_MouseLeave(object sender, MouseEventArgs e)
        {
            CMB0.FontStyle = FontStyles.Normal;
        }
        private void TB1_MouseLeave(object sender, MouseEventArgs e)
        {
            TB1.FontStyle = FontStyles.Normal;
        }
        private void TB2_MouseLeave(object sender, MouseEventArgs e)
        {
            TB2.FontStyle = FontStyles.Normal;
        }
        private void TB3_MouseLeave(object sender, MouseEventArgs e)
        {
            TB3.FontStyle = FontStyles.Normal;
        }

        private void CMB0_SelectionChanged(object sender, SelectionChangedEventArgs e)//=======<вибір між (новим елементом) та (редагувати)
        {
            if (CMB0.Text != hints[0])
                CMB0.Foreground = Brushes.Black;
            try
            {
                if (LogID.Contains(Convert.ToUInt32(CMB0.SelectedValue)))
                {
                    DeleteButton.IsEnabled = true;
                    EditButton.IsEnabled = true;
                    ReadButton.IsEnabled = false;
                    StreamReader AccountR = new StreamReader("Students.txt");
                    while (!AccountR.EndOfStream)
                    {
                        try
                        {
                            string log = AccountR.ReadLine();
                            string[] LastLog = log.Split('|');
                            if(Convert.ToUInt32(CMB0.SelectedValue) == Convert.ToUInt32(LastLog[0]))
                            {
                                TB1.Text = LastLog[1];
                                TB2.Text = LastLog[2];
                                TB3.Text = LastLog[3];
                                TB1.Foreground = Brushes.Black;
                                TB2.Foreground = Brushes.Black;
                                TB3.Foreground = Brushes.Black;
                            }
                            
                        }
                        catch
                        {
                            DeleteButton.IsEnabled = false;
                            EditButton.IsEnabled = false;
                            ReadButton.IsEnabled = true;
                        }
                    }
                    AccountR.Close();
                }
                else
                {
                    DeleteButton.IsEnabled = false;
                    EditButton.IsEnabled = false;
                    ReadButton.IsEnabled = true;
                }
            }
            catch
            {

            }
        }
        private void TB1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB1.Text != hints[1])
                TB1.Foreground = Brushes.Black;
        }
        private void TB2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB2.Text != hints[2])
                TB2.Foreground = Brushes.Black;
        }
        private void TB3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TB3.Text != hints[3])
                TB3.Foreground = Brushes.Black;
        }

        private void CMB0_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CMB0.Text == hints[0])
            {
                CMB0.Text = null;
                CMB0.Foreground = Brushes.Black;
            }
            CMB0.FontStyle = FontStyles.Italic;
        }
        private void TB1_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB1.Text == hints[1])
            {
                TB1.Text = null;
                TB1.Foreground = Brushes.Black;
            }
            TB1.FontStyle = FontStyles.Italic;
        }
        private void TB2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB2.Text == hints[2])
            {
                TB2.Text = null;
                TB2.Foreground = Brushes.Black;
            }
            TB2.FontStyle = FontStyles.Italic;
        }
        private void TB3_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB3.Text == hints[3])
            {
                TB3.Text = null;
                TB3.Foreground = Brushes.Black;
            }
            TB3.FontStyle = FontStyles.Italic;
        }

        private void CMB0_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (CMB0.Text == "")
            {
                CMB0.Text = hints[0];
                CMB0.Foreground = Brushes.Gray;
            }
            CMB0.FontStyle = FontStyles.Normal;
        }
        private void TB1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB1.Text == "")
            {
                TB1.Text = hints[1];
                TB1.Foreground = Brushes.Gray;
            }
            TB1.FontStyle = FontStyles.Normal;
        }
        private void TB2_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB2.Text == "")
            {
                TB2.Text = hints[2];
                TB2.Foreground = Brushes.Gray;
            }
            TB2.FontStyle = FontStyles.Normal;
        }
        private void TB3_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TB3.Text == "")
            {
                TB3.Text = hints[3];
                TB3.Foreground = Brushes.Gray;
            }
            TB3.FontStyle = FontStyles.Normal;
        }

      
    }
}
