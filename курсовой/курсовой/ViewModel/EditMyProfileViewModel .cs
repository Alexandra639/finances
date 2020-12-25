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
  public  class EditMyProfileViewModel : VM
    {
        UserModel user;
        DBDataOperation bd;
        public Window thisW;
        int pastPage;
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnProperty("Name");
            }
        }
        private string _Surname;
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                _Surname = value;
                OnProperty("Surname");
            }
        }
        private string _Login;
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



        public RelayCommand UpdateUSER
        {
            get
            {
                return new RelayCommand(o =>
                {
                       if (Name == "" || Surname == "" || Password == "")
                    {
                        MessageBox.Show("Не все поля заполнены");
                        return;
                    }
                    try
                    {
                        UserModel user2 = new UserModel();
                        user2.user_code_ID = App.id;
                        user2.name = Name;
                        user2.surname = Surname;
                        user2.password = Password;
                        user2.login = Login;
                        bd.UpdateUSER(user2);
                        MessageBox.Show("Изменения сохранены");
                    }
                    catch
                    {
                        MessageBox.Show("Поля заполнены некорректно");
                        return;
                    }
                   
                });
            }
        }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(o =>
                {
                    switch (pastPage)
                    {
                        case 1: 
                            IncomePage i = new IncomePage();
                            i.Show();
                            break;
                        case 2:
                            ExpensePage e = new ExpensePage();
                            e.Show();
                            break;
                        case 3:
                            PlanDayPage pd = new PlanDayPage();
                            pd.Show();
                            break;
                        case 4:
                            PlanMonthPage pm = new PlanMonthPage();
                            pm.Show();
                            break;
                        case 5:
                            PlanYearPage py = new PlanYearPage();
                            py.Show();
                            break;
                    }
                    thisW.Close();
                });
            }
        }
        public EditMyProfileViewModel (DBDataOperation myBd, Window w2, int past)
        {
            bd = myBd;
            pastPage = past;
            user = bd.GetUSER(App.id);
            Name =user.name;
            Surname = user.surname;
            Login = user.login;
            Password = user.password;
            thisW = w2;
        }
    }
}

