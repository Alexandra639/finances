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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Models;
using BLL;
using курсовой.ViewModel;

namespace курсовой
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// /*9.	Учет домашних финансов
   /* Ведение расходов и доходов для членов семьи.Расходы складываются из 
    * покупок товаров и трат на услуги.Учесть различные источники дохода.
    * Приложение должно предоставлять функцию формирования бюджета и  информировать
    * о превышении установленного лимита на бюджет.Предоставить возможность формирования
    * отчета «Итоговое сальдо» за указанный период.
 */
    public partial class MainWindow : Window
    {
        public int id = 0;
        DBDataOperation bd = new DBDataOperation();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowsViewModel (bd, this);
        }

   
    }
}
