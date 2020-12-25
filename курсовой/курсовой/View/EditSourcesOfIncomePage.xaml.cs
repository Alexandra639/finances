using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
using курсовой.ViewModel;

namespace курсовой.View
{
    public partial class EditSourcesOfIncomePage : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public EditSourcesOfIncomePage()
        {
            InitializeComponent();
            DataContext = new EditSourcesOfIncomeViewModel(bd, this);
        }
    }
}
