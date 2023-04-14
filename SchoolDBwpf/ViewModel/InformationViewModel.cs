using SchoolDBwpf.Data;
using SchoolDBwpf.SqlData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBwpf.ViewModel
{
    public class InformationViewModel:DbContext,INotifyPropertyChanged
    {
        private static bool IsOpen = false;
        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public SchoolEntities DB { get; set; }

        public static ObservableCollection<Класс> ClassLists { get; set; } //список классов
        public static ObservableCollection<Ученик> Students { get; set; } //список учеников
        public static ObservableCollection<Предмет> Subjects { get; set; } //список предметов

        public static ObservableCollection<Ученик> CurrentStudents { get; set; } //список учеников присутствующих на паре
        public static Предмет CurrentSubject { get; set; } //предмет на котором отмечали учеников
        public static Класс CurrentClass { get; set; } //класс который отмечали
        public InformationViewModel()
        {
            CurrentUser = new User();
            DB = new SchoolEntities();
            if (IsOpen == false)
            {
                GetCollection();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void GetCollection()
        {
            IsOpen = true;
            ClassLists = new ObservableCollection<Класс>();
            Students = new ObservableCollection<Ученик>();
            Subjects = new ObservableCollection<Предмет>();
            foreach(var classlist in DB.Класс)
            {
                ClassLists.Add(classlist);
            }
            foreach(var user in DB.Ученик)
            {
                Students.Add(user);
            }
            foreach(var subject in DB.Предмет)
            {
                Subjects.Add(subject);
            }
        }
    }
}
