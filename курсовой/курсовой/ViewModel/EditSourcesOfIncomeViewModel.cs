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
    class EditSourcesOfIncomeViewModel : VM
    {
        DBDataOperation bd;
        public System.Windows.Window w;

		private List<IncomeGuideModel> _SourceOfIncomeDataGrid;
		public List<IncomeGuideModel> SourceOfIncomeDataGrid
		{
			get
			{
				return _SourceOfIncomeDataGrid;
			}
			set
			{
				_SourceOfIncomeDataGrid = value;
				OnProperty("SourceOfIncomeDataGrid");
			}
		}
		private string _icomeType;
		public string icomeType
		{
			get
			{
				return _icomeType;
			}
			set
			{
				_icomeType = value;
				OnProperty("icomeType");
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

	
		public RelayCommand AddSourceOfIncome
		{
		
			get
			{
				return new RelayCommand(o =>
				{
					if (icomeType == null || icomeType == "")
					{
						MessageBox.Show("Введите источник доходов");
						return;
					}
					try
					{
						IncomeGuideModel inc = new IncomeGuideModel();
						inc.userFk = App.id;
						inc.income_type = icomeType;
						inc.show = true;

						bd.CreateINCOME_GUIDE(inc);
						MessageBox.Show("Источник дохода успешно добавлен");

						icomeType = null;
						SourceOfIncomeDataGrid = bd.GetALLINCOME_GUIDES(App.id);
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
	   "Вы точно хотите удалить источник дохода?",
	   "Удаление записи",
	   MessageBoxButton.YesNo
	  );
					if (result == MessageBoxResult.Yes)
					{
						int id = SourceOfIncomeDataGrid[selectedItem].income_guide_code_ID;
						bd.DeleteINCOME_GUIDE(id, App.id);
						MessageBox.Show("Источник дохода удален");
						SourceOfIncomeDataGrid = bd.GetALLINCOME_GUIDES(App.id);
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
					IncomePage f = new IncomePage();
					f.Show();
					w.Close();
				});


			}

		}
		public EditSourcesOfIncomeViewModel(DBDataOperation myBd, System.Windows.Window w2)
		{
			bd = myBd;
			SourceOfIncomeDataGrid = bd.GetALLINCOME_GUIDES(App.id);
			w = w2;
		}
	}
}
