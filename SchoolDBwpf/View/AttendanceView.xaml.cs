using SchoolDBwpf.ViewModel;
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
using System.Windows.Shapes;

namespace SchoolDBwpf.View
{
    /// <summary>
    /// Логика взаимодействия для AttendanceView.xaml
    /// </summary>
    public partial class AttendanceView : Window
    {
        public AttendanceView()
        {
            InitializeComponent();
        }

        private void ButtonMarkStudents_Click(object sender, RoutedEventArgs e)
        {
            ((AttendanceViewModel)DataContext).Mark();
            AcademicPerformanceView view = new AcademicPerformanceView();
            view.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
