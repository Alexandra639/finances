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
   public partial class PlanDayPage : Window
    {
        DBDataOperation bd = new DBDataOperation();

        public PlanDayPage()
        {
            InitializeComponent();
            DataContext = new PlanForDaysViewModel(bd, this);

        }
    }
}
