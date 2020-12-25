using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using курсовой.ViewModel;

namespace курсовой.View
{
    public partial class EditIncomePage
    {
        public EditIncomePage(IncomeViewModel ivm)
        {
            InitializeComponent();
            DataContext = ivm;
        }
    }
}
