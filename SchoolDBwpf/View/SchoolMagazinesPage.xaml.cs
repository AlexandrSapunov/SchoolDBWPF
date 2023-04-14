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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolDBwpf.View
{
    /// <summary>
    /// Логика взаимодействия для SchoolMagazinesPage.xaml
    /// </summary>
    public partial class SchoolMagazinesPage : Page
    {
        public SchoolMagazinesPage()
        {
            InitializeComponent();
        }

        private void ButtonRemoveAttLog_Click(object sender, RoutedEventArgs e)
        {
            ((MagazinesViewModel)DataContext).RemoveAttLog();
        }

        private void ButtonRemoveAPRemove_Click(object sender, RoutedEventArgs e)
        {
            ((MagazinesViewModel)DataContext).RemoveAPLog();
        }
    }
}
