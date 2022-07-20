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

namespace Lab2
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Window1 Win1 = new Window1();
            Hide();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Window2 Win2 = new Window2();
            Hide();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Window3 Win3 = new Window3();
            Hide();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Window4 Win4 = new Window4();
            Hide();
        }
    }
}
