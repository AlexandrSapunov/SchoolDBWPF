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
    public class StudentPerformance : INotifyPropertyChanged
    {
        private Ученик _student;
        private int _appraisal;
        private int _age;

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
        public int Apprasial
        {
            get
            {
                return _appraisal;
            }
            set
            {
                _appraisal = value;
                OnPropertyChanged(nameof(Apprasial));
            }
        }
        public int Age
        {
            get
            {
                return _age = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(Student.ДатаРождения.Value.ToString("yyyy")));
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
