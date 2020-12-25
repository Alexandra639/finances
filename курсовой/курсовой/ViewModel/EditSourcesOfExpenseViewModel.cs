using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using BLL.Models;
using курсовой.View;

namespace курсовой.ViewModel
{
    class EditSourcesOfExpenseViewModel:VM
    {
		DBDataOperation bd;
		public Window w;

		private List<ExpenseGuideModel> _SourceOfExpenseDataGrid;
		public List<ExpenseGuideModel> SourceOfExpenseDataGrid
		{
			get
			{
				return _SourceOfExpenseDataGrid;
			}
			set
			{
				_SourceOfExpenseDataGrid = value;
				OnProperty("SourceOfExpenseDataGrid");
			}
		}
		private string _expenseType;
		public string expenseType
		{
			get
			{
				return _expenseType;
			}
			set
			{
				_expenseType = value;
				OnProperty("expenseType");
			}
		}
		private int _selectedItem;
		public int selectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				OnProperty("selectedItem");
			}
		}


		public RelayCommand AddSourceOfExpense
		{

			get
			{
				return new RelayCommand(o =>
				{
					if (expenseType == null || expenseType == "")
					{
						MessageBox.Show("Введите источник расходов");
						return;
					}
					try
					{
						ExpenseGuideModel exp = new ExpenseGuideModel();
						exp.userFk = App.id;
						exp.expense_type = expenseType;
						exp.show = true;

						bd.CreateEXPENSE_GUIDE(exp);
						MessageBox.Show("Источник расходов успешно добавлен");

						expenseType = null;
						SourceOfExpenseDataGrid = bd.GetALLEXPENSE_GUIDES(App.id);
					}
					catch
                    {
						MessageBox.Show("Поле некорректно заполнено");
						return;
					}

				});
			}

		}
		public RelayCommand DeleteSourceOfIncome
		{

			get
			{
				return new RelayCommand(o =>
				{
					if (selectedItem == -1)
					{
						MessageBox.Show("Выберите запись для удаления");
						return;
					}
					MessageBoxResult result = MessageBox.Show(
	   "Вы точно хотите удалить источник расхода?",
	   "Удаление записи",
	   MessageBoxButton.YesNo
	  );
					if (result == MessageBoxResult.Yes)
					{
						int id = SourceOfExpenseDataGrid[selectedItem].expense_guide_code_ID;
						bd.DeleteEXPENSE_GUIDE(id, App.id);
						MessageBox.Show("Источник расхода удален");
						SourceOfExpenseDataGrid = bd.GetALLEXPENSE_GUIDES(App.id);
					}

				});


			}

		}
		public RelayCommand Back
		{

			get
			{
				return new RelayCommand(o =>
				{
					ExpensePage f = new ExpensePage();
					f.Show();
					w.Close();
				});


			}

		}
		public EditSourcesOfExpenseViewModel(DBDataOperation myBd, System.Windows.Window w2)
		{
			bd = myBd;
			SourceOfExpenseDataGrid = bd.GetALLEXPENSE_GUIDES(App.id);
			w = w2;
		}
	}
}
