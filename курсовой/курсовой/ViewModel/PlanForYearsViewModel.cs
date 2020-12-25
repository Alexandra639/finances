using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using System.Windows;
using курсовой.View;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace курсовой.ViewModel
{
    class PlanForYearsViewModel: VM
    {
        DBDataOperation bd;
        public Window w;

        private List<PlanSelect> _PlanDataGrid;
        public List<PlanSelect> PlanDataGrid
        {
            get
            {
                return _PlanDataGrid;
            }
            set
            {
                _PlanDataGrid = value;
                OnProperty("PlanDataGrid");

            }
        }
        private string _IPlan2;
        public string IPlan2
        {
            get
            {
                return _IPlan2;
            }
            set
            {
                _IPlan2 = value;
                OnProperty("IPlan2");
            }
        }
        private string _IPlan3;
        public string IPlan3
        {
            get
            {
                return _IPlan3;
            }
            set
            {
                _IPlan3 = value;
                OnProperty("IPlan3");
            }
        }
        private string _EPlan2;
        public string EPlan2
        {
            get
            {
                return _EPlan2;
            }
            set
            {
                _EPlan2 = value;
                OnProperty("EPlan2");
            }
        }
        private string _EPlan3;
        public string EPlan3
        {
            get
            {
                return _EPlan3;
            }
            set
            {
                _EPlan3 = value;
                OnProperty("EPlan3");
            }
        }
        private DateTime _SelectedYear;
        public DateTime SelectedYear
        {
            get
            {
                return _SelectedYear;
            }
            set
            {
                _SelectedYear = value;
                OnProperty("SelectedYear");
                CheckIncome = true;
                UpdatePage();
            }
        }
        private string _iNCOMEPlanSize;
        public string iNCOMEPlanSize
        {
            get
            {
                return _iNCOMEPlanSize;
            }
            set
            {
                _iNCOMEPlanSize = value;
                OnProperty("iNCOMEPlanSize");
            }
        }
        private string _iNCOMEItogSize;
        public string iNCOMEItogSize
        {
            get
            {
                return _iNCOMEItogSize;
            }
            set
            {
                _iNCOMEItogSize = value;
                OnProperty("iNCOMEItogSize");
            }
        }
        private string _EXPENSEPlanSize;
        public string EXPENSEPlanSize
        {
            get
            {
                return _EXPENSEPlanSize;
            }
            set
            {
                _EXPENSEPlanSize = value;
                OnProperty("EXPENSEPlanSize");
            }
        }
        private string _EXPENSEItogSize;
        public string EXPENSEItogSize
        {
            get
            {
                return _EXPENSEItogSize;
            }
            set
            {
                _EXPENSEItogSize = value;
                OnProperty("EXPENSEItogSize");
            }
        }
        private bool _CheckIncome;
        public bool CheckIncome
        {
            get
            {
                return _CheckIncome;
            }
            set
            {
                _CheckIncome = value;
                OnProperty("CheckIncome");
            }
        }
        private decimal _PlanBalance;
        public decimal PlanBalance
        {
            get
            {
                return _PlanBalance;
            }
            set
            {
                _PlanBalance = value;
                OnProperty("PlanBalance");
            }
        }
        private decimal _ItogBalance;
        public decimal ItogBalance
        {
            get
            {
                return _ItogBalance;
            }
            set
            {
                _ItogBalance = value;
                OnProperty("ItogBalance");
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
        public RelayCommand Print
        {
            get
            {
                return new RelayCommand(o =>
                {
                    if (PlanDataGrid.Count == 0)
                    {
                        MessageBox.Show("План ни для одного года этого десятилетия не создан");
                        return;
                    }

                    int d = SelectedYear.Year % 10;
                    DateTime date1 = new DateTime(SelectedYear.Year, 1, 1).AddYears(-d);
                    DateTime date2 = new DateTime(SelectedYear.Year, 1, 1).AddYears(-d + 9);

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream("План_на_года_" + date1 + "_" + date2 + ".pdf", FileMode.Create));
                    doc.Open();

                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\USER\Desktop\Конструирование ПО\курсовой\курсовой\Resourses\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font font1 = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;

                    PdfPCell cell = new PdfPCell(new Phrase("План на " + date1 + " - " + date2 + "г.", font1));
                    cell.Colspan = 5;
                    cell.HorizontalAlignment = 1;
                    cell.Border = 0;
                    table.AddCell(cell);
                    table.AddCell(new Phrase("Дата", font1));
                    table.AddCell(new Phrase("Доход", font1));
                    table.AddCell(new Phrase("Расход", font1));
                    table.AddCell(new Phrase("Остаток", font1));
                    table.AddCell(new Phrase());
                    Font font2 = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                    for (int j = 0; j < PlanDataGrid.Count; j++)
                    {
                        PdfPCell c = new PdfPCell(new Phrase(PlanDataGrid[j].plan_date.Year.ToString(), font2));
                        c.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                        table.AddCell(c);
                        table.AddCell(new Phrase(PlanDataGrid[j].plan_income_size.ToString(), font2));
                        table.AddCell(new Phrase(PlanDataGrid[j].plan_expense_size.ToString(), font2));
                        table.AddCell(new Phrase(PlanDataGrid[j].plan_balance.ToString(), font2));
                        table.AddCell(new Phrase("План", font1));
                        c = new PdfPCell(new Phrase());
                        c.DisableBorderSide(PdfPCell.TOP_BORDER);
                        table.AddCell(c);
                        table.AddCell(new Phrase(PlanDataGrid[j].itog_income_size.ToString(), font2));
                        table.AddCell(new Phrase(PlanDataGrid[j].itog_expense_size.ToString(), font2));
                        table.AddCell(new Phrase(PlanDataGrid[j].itog_balance.ToString(), font2));
                        table.AddCell(new Phrase("Факт", font1));
                    }

                    PdfPCell cell2 = new PdfPCell(new Phrase("Суммарный планируемый доход за 10 лет: " + IPlan2.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Фактический доход за 10 лет: " + IPlan3.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.TOP_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Суммарный планируемый расход за 10 лет: " + EPlan2.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Фактический расход за 10 лет: " + EPlan3.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.TOP_BORDER);
                    table.AddCell(cell2);

                    doc.Add(table);

                    doc.Close();

                    MessageBox.Show("Pdf-документ сохранен");
                });
            }
        }
        public RelayCommand PlanDay
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
        public RelayCommand PlanMonth
        {
            get
            {
                return new RelayCommand(o =>
                {
                    PlanMonthPage window = new PlanMonthPage();
                    window.Show();
                    w.Close();
                });
            }
        }
        public RelayCommand UpdatePlan
        {
            get
            {
                return new RelayCommand(o =>
                {
                    if (iNCOMEPlanSize == "" || EXPENSEPlanSize == "")
                    {
                        MessageBox.Show("Не все поля заполнены");
                        return;
                    }
                    if (Convert.ToDecimal(iNCOMEPlanSize) < 0 || Convert.ToDecimal(EXPENSEPlanSize) < 0)
                    {
                        MessageBox.Show("Поля заполнены неккоректно");
                    }
                    try
                    {
                        IncomePlanModel ipm = new IncomePlanModel();
                        ipm.plan_income_user_FK = App.id;
                        ipm.plan_income_type_Fk = 3;
                        ipm.plan_income_date = SelectedYear;
                        ipm.plan_income_size = Convert.ToDecimal(iNCOMEPlanSize);
                        bd.UpdateIncomePlan(ipm);

                        ExpensePlanModel epm = new ExpensePlanModel();
                        epm.plan_expense_user_FK = App.id;
                        epm.plan_expense_type_Fk = 3;
                        epm.plan_expense_date = SelectedYear;
                        epm.plan_expense_size = Convert.ToDecimal(EXPENSEPlanSize);
                        bd.UpdateExpensePlan(epm);

                        MessageBox.Show("План обновлён");
                    }
                    catch
                    {
                        MessageBox.Show("Поля заполнены неккоректно");
                    }
                    UpdatePage();
                });
            }
        }
        public RelayCommand DuplicateForTheNextYear
        {
            get
            {
                return new RelayCommand(o =>
                {
                    var ips = bd.GetIncomePlanForYear(App.id, SelectedYear);
                    var eps = bd.GetExpensePlanForYear(App.id, SelectedYear);
                    if (ips == null || eps == null)
                    {
                        MessageBox.Show("Нет плана на выбранный выбранный год");
                        return;
                    }

                    DateTime year = SelectedYear.Date.AddYears(1);

                    if (CheckIncome)
                    {
                        IncomePlanModel ipm = new IncomePlanModel();
                        ipm.plan_income_user_FK = App.id;
                        ipm.plan_income_type_Fk = 3;
                        ipm.plan_income_date = year;
                        ipm.plan_income_size = ips.plan_income_size;
                        bd.UpdateIncomePlan(ipm);

                        if (bd.GetExpensePlanForYear(App.id, year) == null)
                        {
                            ExpensePlanModel e = new ExpensePlanModel();
                            e.plan_expense_user_FK = App.id;
                            e.plan_expense_type_Fk = 3;
                            e.plan_expense_date = year;
                            e.plan_expense_size = 0;
                            bd.UpdateExpensePlan(e);
                        }
                    }
                    else
                    {
                        ExpensePlanModel epm = new ExpensePlanModel();
                        epm.plan_expense_user_FK = App.id;
                        epm.plan_expense_type_Fk = 3;
                        epm.plan_expense_date = year;
                        epm.plan_expense_size = eps.plan_expense_size;
                        bd.UpdateExpensePlan(epm);

                        if (bd.GetIncomePlanForYear(App.id, year) == null)
                        {
                            IncomePlanModel ipm = new IncomePlanModel();
                            ipm.plan_income_user_FK = App.id;
                            ipm.plan_income_type_Fk = 3;
                            ipm.plan_income_date = year;
                            ipm.plan_income_size = 0;
                            bd.UpdateIncomePlan(ipm);
                        }
                    }

                    MessageBox.Show("План продублирован");

                    UpdatePage();
                });
            }
        }

        public RelayCommand MyProfile
        {
            get
            {
                return new RelayCommand(o =>
                {
                    EditMyProfilePage window = new EditMyProfilePage(5);
                    window.Show();
                    w.Close();
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
        public PlanForYearsViewModel(DBDataOperation myBd, Window w2)
        {
            bd = myBd;
            w = w2;

            SelectedYear = DateTime.Now;
        }
        public void UpdatePage()
        {
            int d = SelectedYear.Year % 10;
            DateTime date1 = new DateTime(SelectedYear.Year, 1, 1).AddYears(-d).AddDays(-1);
            DateTime date2 = new DateTime(SelectedYear.Year, 1, 1).AddYears(-d + 9).AddYears(1);
            IPlan2 = bd.GetIncomePlanSum(App.id, 3, date1, date2).ToString();
            EPlan2 = bd.GetExpensePlanSum(App.id, 3, date1, date2).ToString();
            IPlan3 = bd.GetIncomeFor10Years(App.id, 3, date1, date2).ToString();
            EPlan3 = bd.GetIncomeFor10Years(App.id, 3, date1, date2).ToString();

            iNCOMEItogSize = bd.GetExpenseForYear(App.id, SelectedYear).ToString();
            EXPENSEItogSize = bd.GetExpenseForYear(App.id, SelectedYear).ToString();
            ItogBalance = Convert.ToDecimal(iNCOMEItogSize) - Convert.ToDecimal(EXPENSEItogSize);

            var ips = bd.GetIncomePlanForYear(App.id, SelectedYear);
            if (ips == null)
            {
                iNCOMEPlanSize = "";
            }
            else
            {
                iNCOMEPlanSize = ips.plan_income_size.ToString();
            }
            var eps = bd.GetExpensePlanForYear(App.id, SelectedYear);
            if (eps == null)
            {
                EXPENSEPlanSize = "";
            }
            else
            {
                EXPENSEPlanSize = eps.plan_expense_size.ToString();
            }
            if (ips != null && eps != null)
            {
                PlanBalance = Convert.ToDecimal(iNCOMEPlanSize) - Convert.ToDecimal(EXPENSEPlanSize);
            }
            PlanDataGrid = bd.GetPlansYears(App.id, date1, date2);
        }
    }
}
