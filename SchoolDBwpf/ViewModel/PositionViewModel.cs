using SchoolDBwpf.SqlData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBwpf.ViewModel
{
    public class PositionViewModel:InformationViewModel
    {
        private ЖурналДолжностей _selectedJournal;

        public ЖурналДолжностей SelectedJournal
        {
            get
            {
                return _selectedJournal;
            }
            set
            {
                _selectedJournal = value;
                OnPropertyChanged(nameof(SelectedJournal));
            }
        }

        public ObservableCollection<ДолжностьШколы> Positons { get; set; }
        public ObservableCollection<ЖурналДолжностей> JobLogs { get; set; }

        public PositionViewModel()
        {
            GetCollection();
        }

        private void GetCollection()
        {
            JobLogs = new ObservableCollection<ЖурналДолжностей>();
            foreach(var journal in DB.ЖурналДолжностей)
            {
                JobLogs.Add(journal);
            }
            Positons = new ObservableCollection<ДолжностьШколы>();
            foreach(var position in DB.ДолжностьШколы)
            {
                Positons.Add(position);
            }
        }

        public void SaveDB()
        {
            DB.SaveChanges();
        }
    }
}
