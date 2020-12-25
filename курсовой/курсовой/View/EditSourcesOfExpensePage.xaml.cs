using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using курсовой.ViewModel;
using System.Windows;

namespace курсовой.View
{
    public partial class EditSourcesOfExpensePage : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public EditSourcesOfExpensePage()
        {
            InitializeComponent();
            DataContext = new EditSourcesOfExpenseViewModel(bd, this);
        }
    }
}
