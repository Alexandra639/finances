using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using System.Windows;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using курсовой.View;



namespace курсовой.ViewModel
{
	public class IncomeViewModel:VM
	{
		DBDataOperation bd;
		public Window w;
		public Window wEditInc;
		public List<IncomeGuideModel> IncomeGuide { get; set; }
		private List<IncomeSelect> _IncomeDataGrid;
		public List<IncomeSelect> IncomeDataGrid
		{
			get
			{
				return _IncomeDataGrid;
			}
			set
			{
				_IncomeDataGrid = value;
				OnProperty("IncomeDataGrid");//Когда объект класса изменяет значение свойства, то он через событие PropertyChanged извещает систему об изменении свойства. А система обновляет все привязанные объекты.

			}
		}
		//для получения данных из комбобокса
		private IncomeGuideModel _iNCOME;
		public IncomeGuideModel iNCOME
		{
			get
			{
				return _iNCOME;
			}
			set
			{
				_iNCOME = value;
				OnProperty("iNCOME");
			}
		}

		//для получения данных из датапикчер1
		private DateTime _iNCOMEDate;
		public DateTime iNCOMEDate
		{
			get
			{
				return _iNCOMEDate;
			}
			set
			{
				_iNCOMEDate = value;
				OnProperty("iNCOMEDate");
			}
		}
		private DateTime _iNCOMEDate1;
		public DateTime iNCOMEDate1
		{
			get
			{
				return _iNCOMEDate1;
			}
			set
			{
				_iNCOMEDate1 = value;
				OnProperty("iNCOMEDate1");

			}
		}
		private DateTime _iNCOMEDate2;
		public DateTime iNCOMEDate2
		{
			get
			{
				return _iNCOMEDate2;
			}
			set
			{
				_iNCOMEDate2 = value;
				OnProperty("iNCOMEDate2");
			}
		}
		private string _iNCOMESize;
		public string iNCOMESize
		{
			get
			{
				return _iNCOMESize;
			}
			set
			{
				_iNCOMESize = value;
				OnProperty("iNCOMESize");
			}
		}
		private string _iNCOMESum;
		public string iNCOMESum
		{
			get
			{
				return _iNCOMESum;
			}
			set
			{
				_iNCOMESum = value;
				OnProperty("iNCOMESum");
			}
		}
		private int _selectedItemDataGrid;
		public int selectedItemDataGrid
		{
			get
			{
				return _selectedItemDataGrid;
			}
			set
			{
				_selectedItemDataGrid = value;
				OnProperty("selectedItemDataGrid");
			}
		}
		private DateTime _DateUpdate;
		public DateTime DateUpdate
		{
			get
			{
				return _DateUpdate;
			}
			set
			{
				_DateUpdate = value;
				OnProperty("DateUpdate");
			}
		}
		public List<IncomeGuideModel> SourcesUpdate { get; set; }
		private string _SizeUpdate;
		public string SizeUpdate
		{
			get
			{
				return _SizeUpdate;
			}
			set
			{
				_SizeUpdate = value;
				OnProperty("SizeUpdate");
			}
		}
		private IncomeGuideModel _SelectedSourceUpdate;
		public IncomeGuideModel SelectedSourceUpdate
		{
			get
			{
				return _SelectedSourceUpdate;
			}
			set
			{
				_SelectedSourceUpdate = value;
				OnProperty("SelectedSourceUpdate");
			}
		}
		private int _SelectedSourceIdUpdate;
		public int SelectedSourceIdUpdate
		{
			get
			{
				return _SelectedSourceIdUpdate;
			}
			set
			{
				_SelectedSourceIdUpdate = value;
				OnProperty("SelectedSourceUpdate");
			}
		}
		public RelayCommand AddIncome
		{
			//добавление дохода
			get
			{
				return new RelayCommand(o =>
				{
					
						if (iNCOME == null || iNCOMESize == "0" || iNCOMESize == "" || Convert.ToString(iNCOMEDate) == "")
						{
							MessageBox.Show("Не все поля заполнены");
							return;
						}
					if (Convert.ToDecimal(iNCOMESize) < 0)
					{
						MessageBox.Show("Размер дохода имеет неверный формат");
					}
					try
					{
						IncomeModel income = new IncomeModel();
						income.income_user_FK = App.id;
						income.income_date = iNCOMEDate;
						income.income_size = Convert.ToInt32(iNCOMESize);
						income.income_guide_FK = Convert.ToInt32(iNCOME.income_guide_code_ID);

						bd.CreateINCOME(income);
						MessageBox.Show("Доход успешно добавлен");

					}
					catch
                    {
						MessageBox.Show("Поля заполнены некорректно");
						return;
					}

					iNCOMESize = "0";

					IncomeDataGrid = bd.GetALLINCOMESSELECT(iNCOMEDate1, iNCOMEDate2, App.id);
					double r = 0;
					for (int i = 0; i < IncomeDataGrid.Count; i++)
					{
						r += (double)IncomeDataGrid[i].income_size;
					}
					iNCOMESum = "Итог за выбранный период:  " + r.ToString();
				});
			}

		}
		public RelayCommand editSourcesOfIncome
		{
			get
			{
				return new RelayCommand(o =>
				{
					EditSourcesOfIncomePage window = new EditSourcesOfIncomePage();
					window.Show();
					w.Close();
				});
			}
		}

		public RelayCommand EditIncome
		{
			get
			{
				return new RelayCommand(o =>
				{
					if (selectedItemDataGrid == -1)
					{
						MessageBox.Show("Выберите запись для редактирования");
						return;
					}
					SourcesUpdate = bd.GetALLINCOME_GUIDES(App.id); 
					SelectedSourceIdUpdate = SourcesUpdate.IndexOf(SourcesUpdate.FirstOrDefault(x => x.income_guide_code_ID == (int)IncomeDataGrid[selectedItemDataGrid].income_guide_FK));
					DateUpdate = (DateTime)IncomeDataGrid[selectedItemDataGrid].income_date;
					SizeUpdate = Convert.ToString(IncomeDataGrid[selectedItemDataGrid].income_size);
					EditIncomePage window = new EditIncomePage(this);
					wEditInc = window; 
					wEditInc.Show();
				});
			}
		}
		public RelayCommand UpdateIncome
		{
			get
			{
				return new RelayCommand(o =>
				{
                   
						if (SelectedSourceUpdate == null || SizeUpdate == "" || Convert.ToString(DateUpdate) == "")
						{
							MessageBox.Show("Не все поля заполнены");
							return;
						}
					if (Convert.ToDecimal(SizeUpdate) < 0)
					{
						MessageBox.Show("Размер дохода имеет неверный формат");
					}
					try
					{
						IncomeModel income = new IncomeModel();
						income.income_user_FK = App.id;
						income.income_code_ID = (int)IncomeDataGrid[selectedItemDataGrid].id;
						income.income_date = DateUpdate;
						income.income_size = Convert.ToDecimal(SizeUpdate);
						income.income_guide_FK = SelectedSourceUpdate.income_guide_code_ID;

						bd.UpdateINCOME(income);
						MessageBox.Show("Доход успешно изменён");
						
					}
					catch
                    {
						MessageBox.Show("Поля заполнены некорректно");
						return;
					}

					wEditInc.Close();
					IncomeDataGrid = bd.GetALLINCOMESSELECT(iNCOMEDate1, iNCOMEDate2, App.id);
					double r = 0;
					if (IncomeDataGrid != null)
					{
						for (int i = 0; i < IncomeDataGrid.Count; i++)
						{
							r += (double)IncomeDataGrid[i].income_size;
						}
					}
					iNCOMESum = "Итог за выбранный период:  " + r.ToString();
				});
			}
		}
		
		public RelayCommand Delete
		{
			get
			{
				return new RelayCommand(o =>
				{
					if (selectedItemDataGrid == -1)
					{
						MessageBox.Show("Выберите запись для удаления");
						return;
					}
					MessageBoxResult result = MessageBox.Show(
	   "Вы точно хотите удалить запись дохода?",
	   "Удаление записи",
	   MessageBoxButton.YesNo
	  );
					if (result == MessageBoxResult.Yes)
					{
						int id = IncomeDataGrid[selectedItemDataGrid].id;
						bd.DeleteINCOME(id);
						MessageBox.Show("Доход удален");
						IncomeDataGrid = bd.GetALLINCOMESSELECT(iNCOMEDate1, iNCOMEDate2, App.id);
						double r = 0;
						if (IncomeDataGrid != null)
						{
							for (int i = 0; i < IncomeDataGrid.Count; i++)
							{
								r += (double)IncomeDataGrid[i].income_size;
							}
						}
						iNCOMESum = "Итог за выбранный период: " + r.ToString();
					}

				});
			}
		}
		public RelayCommand UpdateIncomeDataGrid
		{//обновление данных в датагриде при изменении дат
			get
			{
				return new RelayCommand(o =>
				{
					if (iNCOMEDate1 == null || DateUpdate == null)
					{
						MessageBox.Show("Выберите даты");
						return;
					}
					try
                    {
						IncomeDataGrid = bd.GetALLINCOMESSELECT(iNCOMEDate1, iNCOMEDate2, App.id);
						
					}
					catch
                    {
						MessageBox.Show("Даты имеют неверный формат");
						return;
					}
					double r = 0;
					for (int i = 0; i < IncomeDataGrid.Count; i++)
					{
						r += (double)IncomeDataGrid[i].income_size;
					}
					iNCOMESum = "Итог за выбранный период:  " + r.ToString();
				});
			}
		}

		public RelayCommand Expense
		{
			get
			{
				return new RelayCommand(o =>
				{
					ExpensePage window = new ExpensePage();
					window.Show();
					w.Close();
				});
			}
		}

		public RelayCommand Plan
        {
			get
			{
				return new RelayCommand(o =>
				{
					PlanDayPage window = new PlanDayPage();
					window.Show();
					w.Close();
				});
			}
		}

		public RelayCommand Print
		{
			get
			{
				return new RelayCommand(o =>
				{
					if (IncomeDataGrid.Count == 0)
					{
						MessageBox.Show("Доходы не выбраны");
						return;
					}

					Document doc = new Document();
					PdfWriter.GetInstance(doc, new FileStream("Доходы_" + iNCOMEDate1.Year + "." + iNCOMEDate1.Month + "." + iNCOMEDate1.Day + "_" + iNCOMEDate2.Year + "." + iNCOMEDate2.Month + "." + iNCOMEDate2.Day + ".pdf", FileMode.Create));
					doc.Open();

					BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\USER\Desktop\Конструирование ПО\курсовой\курсовой\Resourses\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
					Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

					PdfPTable table = new PdfPTable(3);

					PdfPCell cell = new PdfPCell(new Phrase("Доходы с " + iNCOMEDate1.ToLongDateString() + " по " + iNCOMEDate2.ToLongDateString(), font));
					cell.Colspan = 3;
					cell.HorizontalAlignment = 1;
					cell.Border = 0;
					table.AddCell(cell);
					table.AddCell(new Phrase("Источник дохода", font));
					table.AddCell(new Phrase("Дата", font));
					table.AddCell(new Phrase("Размер", font));
					font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
					for (int j = 0; j < IncomeDataGrid.Count; j++)
					{
						table.AddCell(new Phrase(IncomeDataGrid[j].income_type.ToString(), font));
						table.AddCell(new Phrase(((DateTime)IncomeDataGrid[j].income_date).ToLongDateString(), font));
						table.AddCell(new Phrase(IncomeDataGrid[j].income_size.ToString(), font));
					}

					PdfPCell cell2 = new PdfPCell(new Phrase(iNCOMESum.ToString(), font));
					cell2.Colspan = 3;
					cell2.HorizontalAlignment = 2;
					table.AddCell(cell2);
					doc.Add(table);

					doc.Close();

					MessageBox.Show("Pdf-документ сохранен");

				});
			}
		}

		public RelayCommand MyProfile
		{
			get
			{
				return new RelayCommand(o =>
				{
					EditMyProfilePage window = new EditMyProfilePage(1);
					window.Show();
					w.Close();
				});
			}
		}
		public RelayCommand Cancel
		{
			get
			{
				return new RelayCommand(o =>
				{
				wEditInc.Close();	
				});
			}
		}
		public RelayCommand Close
		{
			get
			{
				return new RelayCommand(o =>
				{
					w.Close();
				});
			}
		}
		public IncomeViewModel(DBDataOperation myBd, Window w2)
		{
			bd = myBd;
			IncomeGuide = bd.GetALLINCOME_GUIDES(App.id);
			iNCOMEDate = DateTime.Now;
			iNCOMESize = "0";
			iNCOMEDate2 = DateTime.Now;
			iNCOMEDate1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, App.id);
			IncomeDataGrid = bd.GetALLINCOMESSELECT(iNCOMEDate1, iNCOMEDate2, App.id);
			w = w2;
			double r = 0;
			if (IncomeDataGrid != null)
			{
				for (int i = 0; i < IncomeDataGrid.Count; i++)
				{
					r += (double)IncomeDataGrid[i].income_size;
				}
			}
			iNCOMESum = "Итог за выбранный период:  " + r.ToString();
		}
	}
}
