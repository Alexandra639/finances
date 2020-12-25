using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using курсовой.ViewModel;
using BLL;

namespace курсовой.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class EditMyProfilePage : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public EditMyProfilePage(int past)
        {
            InitializeComponent();
            DataContext = new EditMyProfileViewModel (bd, this, past);
        }
    }
}
