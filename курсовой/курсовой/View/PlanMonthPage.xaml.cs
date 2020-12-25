using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BLL;
using курсовой.ViewModel;

namespace курсовой.View
{
    public partial class PlanMonthPage:Window
    {
        DBDataOperation bd = new DBDataOperation();
        int i = 0;
        public PlanMonthPage()
        {
            InitializeComponent();
            DataContext = new PlanForMonthsViewModel(bd, this);

        }

        private void _calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {

            C.DisplayMode = CalendarMode.Year;
          
        }
        private void _calendar_OnLoaded(object sender, RoutedEventArgs e)
        {
            C.DisplayMode = CalendarMode.Year;
        }

    }
}
