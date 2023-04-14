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
    /// Логика взаимодействия для PositionView.xaml
    /// </summary>
    public partial class PositionView : Window
    {
        public PositionView()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить данные и зарыть окно? \nПосле нажатия 'NO' данные будут сохранены!","Подтверждение",MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ((PositionViewModel)DataContext).SaveDB();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    ((PositionViewModel)DataContext).SaveDB();
                    break;
            }
        }
    }
}
