using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using курсовой.ViewModel;

namespace курсовой.View
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class ExpensePage : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public ExpensePage()
        {
            InitializeComponent();
            DataContext = new ExpenseViewModel (bd, this);
        }
    }
}
