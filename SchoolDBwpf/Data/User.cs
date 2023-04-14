using SchoolDBwpf.SqlData;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchoolDBwpf.Data
{
    public class User : INotifyPropertyChanged
    {
        private static Преподаватель _currentTeacher;

        public Преподаватель CurrentTeacher
        {
            get
            {
                return _currentTeacher;
            }
            set
            {
                _currentTeacher = value;
                OnPropertyChanged(nameof(CurrentTeacher));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
