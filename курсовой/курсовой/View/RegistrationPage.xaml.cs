using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using курсовой.ViewModel;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class RegistranionPage : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public RegistranionPage()
        {
            InitializeComponent();
            DataContext =new RegistrationViewModel(bd,this);
            
        }

      
    }
}
