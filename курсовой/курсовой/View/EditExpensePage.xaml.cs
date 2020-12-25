using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using курсовой.ViewModel;

namespace курсовой.View
{
    public partial class EditExpensePage
    {
        public EditExpensePage(ExpenseViewModel ivm)
        {
            InitializeComponent();
            DataContext = ivm;
        }
    }
}
