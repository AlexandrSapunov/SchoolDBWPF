using SchoolDBwpf.SqlData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBwpf.Data
{
    public class MarkStudent:INotifyPropertyChanged
    {
        private Ученик _student;
        private bool _isAttended;

        public Ученик Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public bool IsAttended
        {
            get
            {
                return _isAttended;
            }
            set
            {
                _isAttended = value;
                OnPropertyChanged(nameof(IsAttended));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
