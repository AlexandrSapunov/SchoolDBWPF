using SchoolDBwpf.Data;
using SchoolDBwpf.SqlData;
using System.Collections.ObjectModel;

namespace SchoolDBwpf.ViewModel
{
    public class AttendanceViewModel : InformationViewModel
    {
        private Класс _selectedClass;
        private Предмет _selectedSubject;
        private MarkStudent _markStudent;
        private MarkStudent _selectedItem;
        private ЖурналПосещаемости _attLog;

        public ObservableCollection<MarkStudent> CurrentStudentClass { get; set; }

        public Класс SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                UpdateStudentsList();
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        public Предмет SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        public MarkStudent SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public AttendanceViewModel()
        {
            CurrentStudentClass = new ObservableCollection<MarkStudent>();
            GetCollection();
        }

        public void Mark()
        {
            CurrentStudents = new ObservableCollection<Ученик>();
            CurrentSubject = new Предмет();
            CurrentSubject = SelectedSubject;
            CurrentClass = SelectedClass;
            foreach (var item in CurrentStudentClass)
            {
                _attLog = new ЖурналПосещаемости();
                _attLog.КодПредмета = SelectedSubject.КодПредмета;
                _attLog.КодПреподавателя = CurrentUser.CurrentTeacher.КодПреподавателя;
                _attLog.КодУченика = item.Student.КодУченика;
                if (item.IsAttended == true)
                {
                    _attLog.КодОтметки = 1;
                    CurrentStudents.Add(item.Student);
                }
                else
                    _attLog.КодОтметки = 2;
                DB.ЖурналПосещаемости.Add(_attLog);
            }
            DB.SaveChanges();
        }

        private void GetCollection() //получим список markstudents
        {
            foreach (var user in Students)
            {
                _markStudent = new MarkStudent();
                _markStudent.Student = user;
                CurrentStudentClass.Add(_markStudent);
            }
        }

        private void UpdateStudentsList()
        {
            CurrentStudentClass.Clear();
            if (SelectedClass != null)
            {
                foreach (var user in Students)
                {
                    if (user.Класс == SelectedClass)
                    {
                        _markStudent = new MarkStudent();
                        _markStudent.Student = user;
                        CurrentStudentClass.Add(_markStudent);
                    }
                }
            }
        }

    }
}
