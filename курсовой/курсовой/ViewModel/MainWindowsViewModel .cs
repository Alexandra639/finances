using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using System.Windows;
using курсовой.View;

namespace курсовой.ViewModel
{
   public class MainWindowsViewModel : VM
    {
        DBDataOperation bd;
        private string _Login;
        public Window w;
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                OnProperty("Login");
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnProperty("Password");
            }
        }

        public RelayCommand Authorization
        {
            get
            {
                return new RelayCommand(o =>
                {
                    
                if (Password == null || Login == null)
                {
                    MessageBox.Show("Не все поля заполнены");
                }
                else
                {
                   
                   
                    App.id = bd.GetUSER(Login, Password);
                    if (App.id != 0)
                    {
                        IncomePage f = new IncomePage();
                        f.Show();
                            w.Close();
                      }
                      else
                      {
                          MessageBox.Show("Неверный логин или пароль");
                      }
                  }
                    });
            }
        }

        public RelayCommand Registration
        {
            get
            {
                return new RelayCommand(o =>
                {
                    RegistranionPage ww = new RegistranionPage();
                    ww.Show();
                    w.Close();
                });
            }
        }



        public MainWindowsViewModel (DBDataOperation myBd, Window w2)
        {
            bd = myBd;
            w = w2;
        }
    }
}
