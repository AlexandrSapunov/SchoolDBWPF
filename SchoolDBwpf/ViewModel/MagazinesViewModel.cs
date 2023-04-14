using SchoolDBwpf.SqlData;
using System;
using System.Collections.ObjectModel;

namespace SchoolDBwpf.ViewModel
{
    public class MagazinesViewModel : InformationViewModel
    {
        private ЖурналПосещаемости _selectedAttendance;
        private ЖурналУспеваемости _selectedAcademicPerformance;
        private DateTime _selectedDate;
        private Предмет _selectedSubject;

        public ЖурналПосещаемости SelectedAttendance
        {
            get
            {
                return _selectedAttendance;
            }
            set
            {
                _selectedAttendance = value;
                OnPropertyChanged(nameof(SelectedAttendance));
            }
        }
        public ЖурналУспеваемости SelectedAcademicPerformance
        {
            get
            {
                return _selectedAcademicPerformance;
            }
            set
            {
                _selectedAcademicPerformance = value;
                OnPropertyChanged(nameof(SelectedAcademicPerformance));
            }
        }
        public DateTime SelectedDateAL
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                UpdateAttendanceList();
                OnPropertyChanged(nameof(SelectedDateAL));
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
                UpdateSubject();
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        public ObservableCollection<ЖурналПосещаемости> AttendanceLog { get; set; }
        public ObservableCollection<ЖурналУспеваемости> APLog { get; set; }  //APLog журнал успеваемости

        public MagazinesViewModel()
        {
            GetCollection();
            SelectedDateAL = DateTime.Now;
        }

        public void RemoveAttLog()//удаляет запись Журнала посещаемости
        {
            if (SelectedAttendance != null)
            {
                DB.ЖурналПосещаемости.Remove(SelectedAttendance);
                DB.SaveChanges();
                AttendanceLog.Remove(SelectedAttendance);
            }
        }
        public void RemoveAPLog()
        {
            if (SelectedAcademicPerformance != null)
            {
                DB.ЖурналУспеваемости.Remove(SelectedAcademicPerformance);
                DB.SaveChanges();
                APLog.Remove(SelectedAcademicPerformance);
            }
        }

        private void UpdateSubject()
        {
            if (SelectedSubject != null)
            {
                APLog.Clear();
                foreach (var item in DB.ЖурналУспеваемости)
                {
                    if (item.Предмет.КодПредмета == SelectedSubject.КодПредмета)
                    {
                        APLog.Add(item);
                    }
                }
            }
        }
        private void GetCollection()
        {
            AttendanceLog = new ObservableCollection<ЖурналПосещаемости>();
            APLog = new ObservableCollection<ЖурналУспеваемости>();
            foreach (var item in DB.ЖурналПосещаемости)
            {
                AttendanceLog.Add(item);
            }
            foreach (var item in DB.ЖурналУспеваемости)
            {
                APLog.Add(item);
            }
        }
        private void UpdateAttendanceList()
        {
            if (SelectedDateAL != null)
            {
                AttendanceLog.Clear();
                foreach (var item in DB.ЖурналПосещаемости)
                {
                    if (item.ДатаОтметки.Value.ToString("dd:MM:yy") == SelectedDateAL.ToString("dd:MM:yy"))
                    {
                        AttendanceLog.Add(item);
                    }
                }
            }
        }
    }
}
