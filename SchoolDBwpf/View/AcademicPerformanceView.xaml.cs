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
    /// Логика взаимодействия для AcademicPerformanceView.xaml
    /// </summary>
    public partial class AcademicPerformanceView : Window
    {
        public AcademicPerformanceView()
        {
            InitializeComponent();
        }

        private void ButtonRate_Click(object sender, RoutedEventArgs e)
        {
            ((APViewModel)DataContext).Evaluate();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
