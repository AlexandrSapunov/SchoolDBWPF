using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SchoolDBwpf.ViewModel
{
    public class MainViewModel:InformationViewModel
    {
        private DispatcherTimer _timer;
        private string _currentTime;

        public string CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        public MainViewModel()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1)
            };
            _timer.Tick += UpdateTime;
            _timer.Start();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
