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

namespace SchoolDBwpf.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ButtonJobLog_Click(object sender, RoutedEventArgs e)
        {
            PositionView view = new PositionView();
            view.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonBegins_Click(object sender, RoutedEventArgs e)
        {
            AttendanceView view = new AttendanceView();
            view.Show();
        }

        private void ButtonGiveMarks_Click(object sender, RoutedEventArgs e)
        {
            AcademicPerformanceView view = new AcademicPerformanceView();
            view.Show();
        }

        private void ButtonMagazines_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow win = new NavigationWindow();
            win.Content = new SchoolMagazinesPage();
            win.Show();
        }
    }
}
