using SchoolDBwpf.Data;
using SchoolDBwpf.SqlData;
using System.Collections.ObjectModel;

namespace SchoolDBwpf.ViewModel
{
    public class APViewModel : InformationViewModel
    {
        private ЖурналУспеваемости _apLog;
        private StudentPerformance _student;
        private StudentPerformance _selectedStudent;
        private Предмет _subject;
        private Класс _selectedClass;

        public StudentPerformance SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        public Предмет SelectedSubject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        public Класс SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                UpdateLists();
                OnPropertyChanged(nameof(SelectedClass));
            }

        }
        public ObservableCollection<StudentPerformance> StudentPerformances { get; set; }
        public APViewModel()
        {
            StudentPerformances = new ObservableCollection<StudentPerformance>();
            if (CurrentSubject != null)
                SelectedSubject = CurrentSubject;
            if (CurrentClass != null)
                SelectedClass = CurrentClass;
            GetCollection();
        }

        private void GetCollection()
        {
            if(CurrentStudents != null)
            {
                StudentPerformances.Clear();
                foreach(var user in CurrentStudents)
                {
                    _student = new StudentPerformance();
                    _student.Student = user;
                    StudentPerformances.Add(_student);
                }
            }
        }

        public void Evaluate()
        {
            if (StudentPerformances != null)
            {
                foreach (var user in StudentPerformances)
                {
                    _apLog = new ЖурналУспеваемости();
                    _apLog.КодПредмета = SelectedSubject.КодПредмета;
                    _apLog.КодПреподавателя = CurrentUser.CurrentTeacher.КодПреподавателя;
                    _apLog.КодУченика = user.Student.КодУченика;
                    _apLog.Оценка = user.Apprasial;
                    DB.ЖурналУспеваемости.Add(_apLog);
                }
                DB.SaveChanges();
            }
        }

        private void UpdateLists()
        {
            StudentPerformances.Clear();
            if (SelectedClass != null)
            {
                foreach (var user in Students)
                {
                    if (user.Класс == SelectedClass)
                    {
                        _student = new StudentPerformance();
                        _student.Student = user;
                        StudentPerformances.Add(_student);
                    }
                }
            }
        }

    }
}
