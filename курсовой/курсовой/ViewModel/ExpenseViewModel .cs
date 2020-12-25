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
   public  class ExpenseViewModel : VM
    {

        DBDataOperation bd;
        public Window w;
        public Window wEditInc;

        public List<ExpenseGuideModel> ExpenseGuide { get; set; }
   
        private List<ExpenseSelect> _ExpenseDataGrid;
        public List<ExpenseSelect> ExpenseDataGrid
        {
            get
            {
                return _ExpenseDataGrid;
            }
            set
            {
                _ExpenseDataGrid = value;
                OnProperty("ExpenseDataGrid");
            }
        }
        //для получения данных из комбобокса
        private ExpenseGuideModel _EXPENSE;
        public ExpenseGuideModel EXPENSE
        {
            get
            {
                return _EXPENSE;
            }
            set
            {
                _EXPENSE = value;
                OnProperty("EXPENSE");
            }
        }

        //для получения данных из датапикчер1
        private DateTime _EXPENSEDate;
        public DateTime EXPENSEDate
        {
            get
            {
                return _EXPENSEDate;
            }
            set
            {
                _EXPENSEDate = value;
                OnProperty("EXPENSEDate");
            }
        }
        private DateTime _EXPENSEDate1;
        public DateTime EXPENSEDate1
        {
            get
            {
                return _EXPENSEDate1;
            }
            set
            {
                _EXPENSEDate1 = value;
                OnProperty("EXPENSEDate1");

            }
        }
        private DateTime _EXPENSEDate2;
        public DateTime EXPENSEDate2
        {
            get
            {
                return _EXPENSEDate2;
            }
            set
            {
                _EXPENSEDate2 = value;
                OnProperty("EXPENSEDate2");
            }
        }
        private string _EXPENSESize;
        public string EXPENSESize
        {
            get
            {
                return _EXPENSESize;
            }
            set
            {
                _EXPENSESize = value;
                OnProperty("EXPENSESize");
            }
        }

        private string _EXPENSESum;
        public string EXPENSESum
        {
            get
            {
                return _EXPENSESum;
            }
            set
            {
                _EXPENSESum = value;
                OnProperty("EXPENSESum");
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
        public List<ExpenseGuideModel> SourcesUpdate { get; set; }
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
        private ExpenseGuideModel _SelectedSourceUpdate;
        public ExpenseGuideModel SelectedSourceUpdate
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
        public RelayCommand AddExpense
        {//добавление расхода
            get
            {
                return new RelayCommand(o =>
                {
                    if (EXPENSE == null || EXPENSESize == "0" || EXPENSESize == "" || Convert.ToString(EXPENSEDate) == "")
                    {
                        MessageBox.Show("Не все поля заполнены");
                        return;
                    }
                    if (Convert.ToDecimal(EXPENSESize) < 0)
                    {
                        MessageBox.Show("Размер расхода имеет неверный формат");
                    }
                    try
                    {
                        ExpenseModel expense = new ExpenseModel();
                        expense.expense_user_FK = App.id;

                        expense.expense_date = EXPENSEDate;
                        expense.expense_size = Convert.ToInt32(EXPENSESize);
                        expense.expense_guide_FK = Convert.ToInt32(EXPENSE.expense_guide_code_ID);
                        bd.CreateEXPENSE(expense);
                        MessageBox.Show("Расход успешно добавлен");

                    }
                    catch
                    {
                        MessageBox.Show("Поля заполнены некорректно");
                        return;
                    }

                    LimitTracking();

                    EXPENSESize = "0";

                    ExpenseDataGrid = bd.GetALLEXPENSESSELECT(EXPENSEDate1, EXPENSEDate2, App.id);
                    double r = 0;
                    for (int i = 0; i < ExpenseDataGrid.Count; i++)
                    {
                        r += (double)ExpenseDataGrid[i].expense_size;
                    }

                    EXPENSESum = "Итог за выбранный период:  " + r.ToString();
                    LimitTracking();
                });
            }
        }
        public RelayCommand EditSourcesOfExpense
        {
            get
            {
                return new RelayCommand(o =>
                {
                    EditSourcesOfExpensePage window = new EditSourcesOfExpensePage();
                    window.Show();
                    w.Close();
                });
            }
        }
        public RelayCommand EditExpense
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
                    SourcesUpdate = bd.GetALLEXPENSE_GUIDES(App.id);
                    SelectedSourceIdUpdate = SourcesUpdate.IndexOf(SourcesUpdate.FirstOrDefault(x => x.expense_guide_code_ID == (int)ExpenseDataGrid[selectedItemDataGrid].expense_guide_Fk));
                    DateUpdate = (DateTime)ExpenseDataGrid[selectedItemDataGrid].expense_date;
                    SizeUpdate = Convert.ToString(ExpenseDataGrid[selectedItemDataGrid].expense_size);
                    EditExpensePage window = new EditExpensePage(this);
                    wEditInc = window;
                    wEditInc.Show();
                });
            }
        }
        public RelayCommand UpdateExpense
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
                        MessageBox.Show("Размер расхода имеет неверный формат");
                    }
                    try
                    {
                        ExpenseModel expense = new ExpenseModel();
                        expense.expense_user_FK = App.id;
                        expense.expense_code_ID = (int)ExpenseDataGrid[selectedItemDataGrid].id;
                        expense.expense_date = DateUpdate;
                        expense.expense_size = Convert.ToDecimal(SizeUpdate);
                        expense.expense_guide_FK = SelectedSourceUpdate.expense_guide_code_ID;

                        bd.UpdateEXPENSE(expense);
                        MessageBox.Show("Расход успешно изменён");
                       
                    }

                    catch
                    {
                        MessageBox.Show("Поля заполнены некорректно");
                        return;
                    }

                    wEditInc.Close();
                    ExpenseDataGrid = bd.GetALLEXPENSESSELECT(EXPENSEDate1, EXPENSEDate2, App.id);
                    double r = 0;

                    for (int i = 0; i < ExpenseDataGrid.Count; i++)
                    {
                        r += (double)ExpenseDataGrid[i].expense_size;
                    }

                    EXPENSESum = "Итог за выбранный период:  " + r.ToString();
                    LimitTracking();
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
       "Вы точно хотите удалить запись расхода?",
       "Удаление записи",
       MessageBoxButton.YesNo
      );
                    if (result == MessageBoxResult.Yes)
                    {
                        int id = ExpenseDataGrid[selectedItemDataGrid].id;
                        bd.DeleteEXPENSE(id);
                        MessageBox.Show("Расход удален");
                        ExpenseDataGrid = bd.GetALLEXPENSESSELECT(EXPENSEDate1, EXPENSEDate2, App.id);
                        double r = 0;

                        for (int i = 0; i < ExpenseDataGrid.Count; i++)
                        {
                            r += (double)ExpenseDataGrid[i].expense_size;
                        }

                        EXPENSESum = "Итог за выбранный период:  " + r.ToString();
                    }

                });
            }
        }


        public RelayCommand UpdateExpenseDataGrid
        {
            get
            {
                return new RelayCommand(o =>
                {
                    if (EXPENSEDate1 == null || EXPENSEDate2 == null)
                    {
                        MessageBox.Show("Выберите даты");
                        return;
                    }
                    try
                    {
                        ExpenseDataGrid = bd.GetALLEXPENSESSELECT(EXPENSEDate1, EXPENSEDate2, App.id);
                        
                    }
                    catch
                    {
                        MessageBox.Show("Даты имеют неверный формат");
                        return;
                    }
                    double r = 0;
                    for (int i = 0; i < ExpenseDataGrid.Count; i++)
                    {
                        r += (double)ExpenseDataGrid[i].expense_size;
                    }
                    EXPENSESum = "Итог за выбранный период:  " + r.ToString();
                });
            }
        }

        public RelayCommand Income
        {
            get
            {
                return new RelayCommand(o =>
                {
                    IncomePage window = new IncomePage();
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
                    if (ExpenseDataGrid.Count == 0)
                    {
                        MessageBox.Show("Расходы не выбраны");
                        return;
                    }
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream("Расходы_" + EXPENSEDate1.Year + "." + EXPENSEDate1.Month + "." + EXPENSEDate1.Day + "_" + EXPENSEDate2.Year + "." + EXPENSEDate2.Month + "." + EXPENSEDate2.Day + ".pdf", FileMode.Create));
                    doc.Open();

                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\USER\Desktop\Конструирование ПО\курсовой\курсовой\Resourses\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

                    PdfPTable table = new PdfPTable(3);

                    PdfPCell cell = new PdfPCell(new Phrase("Расходы с " + EXPENSEDate1.ToLongDateString() + " по " + EXPENSEDate2.ToLongDateString(), font));
                    cell.Colspan = 3;
                    cell.HorizontalAlignment = 1;
                    cell.Border = 0;
                    table.AddCell(cell);
                    table.AddCell(new Phrase("Источник расхода", font));
                    table.AddCell(new Phrase("Дата", font));
                    table.AddCell(new Phrase("Размер", font));
                    font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL); 
                    for (int j = 0; j < ExpenseDataGrid.Count; j++)
                    {
                        table.AddCell(new Phrase(ExpenseDataGrid[j].expense_type.ToString(), font));
                        table.AddCell(new Phrase(((DateTime)ExpenseDataGrid[j].expense_date).ToLongDateString(), font));
                        table.AddCell(new Phrase(ExpenseDataGrid[j].expense_size.ToString(), font));
                    }

                    PdfPCell cell2 = new PdfPCell(new Phrase(EXPENSESum.ToString(), font));
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
                    EditMyProfilePage window = new EditMyProfilePage(2);
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
        public ExpenseViewModel (DBDataOperation myBd, System.Windows.Window w2)
        {
            bd = myBd;
            ExpenseGuide = bd.GetALLEXPENSE_GUIDES(App.id);
            
            EXPENSEDate = DateTime.Now;
            EXPENSESize = "0";
            EXPENSEDate2 = DateTime.Now;
            EXPENSEDate1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, App.id);
            ExpenseDataGrid = bd.GetALLEXPENSESSELECT(EXPENSEDate1, EXPENSEDate2, App.id);
            w = w2;

            double r = 0;
            
                for (int i = 0; i < ExpenseDataGrid.Count; i++)
                {
                    r += (double)ExpenseDataGrid[i].expense_size;
                }
            
            EXPENSESum = "Итог за выбранный период:  " + r.ToString();
        }
        public void LimitTracking()
        {
            var ep = bd.GetExpensePlanForDay(App.id, EXPENSEDate);
            if (ep != null && ep.plan_expense_size != 0 )
            {
                var e = bd.GetExpenseForDay(App.id, EXPENSEDate);
                if (ep.plan_expense_size == e)
                {
                    MessageBox.Show("Лимит за день достигнут");
                }
                else if (ep.plan_expense_size < e)
                {
                    MessageBox.Show("Лимит за день превышен");
                }
            }
            ep = bd.GetExpensePlanForMonth(App.id, EXPENSEDate);
            if (ep != null && ep.plan_expense_size != 0)
            {
                var e = bd.GetExpenseForMonth(App.id, EXPENSEDate);
                if (ep.plan_expense_size == e)
                {
                    MessageBox.Show("Лимит за месяц достигнут");
                }
                else if (ep.plan_expense_size < e)
                {
                    MessageBox.Show("Лимит за месяц превышен");
                }
            }
            ep = bd.GetExpensePlanForYear(App.id, EXPENSEDate);
            if (ep != null && ep.plan_expense_size != 0)
            {
                var e = bd.GetExpenseForYear(App.id, EXPENSEDate);
                if (ep.plan_expense_size == e)
                {
                    MessageBox.Show("Лимит за год достигнут");
                }
                else if (ep.plan_expense_size < e)
                {
                    MessageBox.Show("Лимит за год превышен");
                }
            }

        }
    }
}

