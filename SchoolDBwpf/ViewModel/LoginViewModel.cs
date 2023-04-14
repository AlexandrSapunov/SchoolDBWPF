using SchoolDBwpf.Data;
using System;
using SchoolDBwpf.SqlData;
using System.Windows.Input;
using System.Windows.Threading;

namespace SchoolDBwpf.ViewModel
{
    public class LoginViewModel : InformationViewModel
    {
        private DispatcherTimer _timer;
        private string _stringStatus;

        public string StringStatus
        {
            get
            {
                return _stringStatus;
            }
            set
            {
                _stringStatus = value;
                OnPropertyChanged(nameof(StringStatus));
            }
        }

        public LoginViewModel()
        {
            CurrentUser = new User();
            CurrentUser.CurrentTeacher = new Преподаватель();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(4);
            _timer.Tick += UpdateString;
            _timer.Start();
        }

        private void UpdateString(object sender, EventArgs e)
        {
            StringStatus = "";
        }

        public bool Login()
        {
            if (CurrentUser.CurrentTeacher.Логин.Length > 0)
            {
                if (CurrentUser.CurrentTeacher.Пароль.Length > 5)
                {
                    foreach(var user in DB.Преподаватель)
                    {
                        if(user.Логин == CurrentUser.CurrentTeacher.Логин)
                        {
                            if(user.Пароль == CurrentUser.CurrentTeacher.Пароль)
                            {
                                CurrentUser.CurrentTeacher = user;
                                StringStatus = "Успешный вход в систему!";
                                return true;
                            }
                            else
                            {
                                StringStatus = "Неверный пароль!";
                                return false;
                            }
                        }
                    }
                    StringStatus = "Пользователь не найден!";
                    return false;
                }
                else
                {
                    StringStatus = "Пароль должен быть не короче 6 символов!";
                    return false;
                }
            }
            else
            {
                StringStatus = "Введите логин!";
                return false;
            }
        }

    }
}
