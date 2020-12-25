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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class IncomePage : Window
    {
      
        DBDataOperation bd = new DBDataOperation();

        public IncomePage()
        {
            InitializeComponent();
            DataContext = new IncomeViewModel(bd,this);

        }

   
    }
}
