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
using System.Windows.Controls;

namespace курсовой.ViewModel
{
    class PlanForMonthsViewModel:VM
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
        private string _IPlan1;
        public string IPlan1
        {
            get
            {
                return _IPlan1;
            }
            set
            {
                _IPlan1 = value;
                OnProperty("IPlan1");
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
        private string _EPlan1;
        public string EPlan1
        {
            get
            {
                return _EPlan1;
            }
            set
            {
                _EPlan1 = value;
                OnProperty("EPlan1");
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
        private DateTime _SelectedMonth;
        public DateTime SelectedMonth
        {
            get
            {
                return _SelectedMonth;
            }
            set
            {
                _SelectedMonth = value;
                OnProperty("SelectedMonth");
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
                        MessageBox.Show("План ни для одного месяца этого года не создан");
                        return;
                    }

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream("План_на_месяцы_" + SelectedMonth.Year + ".pdf", FileMode.Create));
                    doc.Open();

                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\USER\Desktop\Конструирование ПО\курсовой\курсовой\Resourses\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    Font font1 = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;

                    PdfPCell cell = new PdfPCell(new Phrase("План на " + SelectedMonth.Year + "г.", font1));
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
                        PdfPCell c = new PdfPCell(new Phrase(PlanDataGrid[j].plan_date.Month +"."+ PlanDataGrid[j].plan_date.Year, font2));
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

                    PdfPCell cell2 = new PdfPCell(new Phrase("Планируемый доход за год: " + IPlan1.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Суммарный планируемый доход за год: " + IPlan2.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    cell2.DisableBorderSide(PdfPCell.TOP_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Фактический доход за год: " + IPlan3.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.TOP_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Планируемый расход за год: " + EPlan1.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    table.AddCell(cell2);
                     cell2 = new PdfPCell(new Phrase("Суммарный планируемый доход за год: " + IPlan2.ToString(), font1));
                    cell2.Colspan = 5;
                    cell2.HorizontalAlignment = 2;
                    cell2.DisableBorderSide(PdfPCell.BOTTOM_BORDER);
                    cell2.DisableBorderSide(PdfPCell.TOP_BORDER);
                    table.AddCell(cell2);
                    cell2 = new PdfPCell(new Phrase("Фактический расход за год: " + EPlan3.ToString(), font1));
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
        public RelayCommand PlanYear
        {
            get
            {
                return new RelayCommand(o =>
                {
                    PlanYearPage window = new PlanYearPage();
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
                        ipm.plan_income_type_Fk = 2;
                        ipm.plan_income_date = SelectedMonth;
                        ipm.plan_income_size = Convert.ToDecimal(iNCOMEPlanSize);
                        bd.UpdateIncomePlan(ipm);

                        ExpensePlanModel epm = new ExpensePlanModel();
                        epm.plan_expense_user_FK = App.id;
                        epm.plan_expense_type_Fk = 2;
                        epm.plan_expense_date = SelectedMonth;
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
        public RelayCommand DuplicateForTheNextMonth
        {
            get
            {
                return new RelayCommand(o =>
                {
                    var ips = bd.GetIncomePlanForMonth(App.id, SelectedMonth);
                    var eps = bd.GetExpensePlanForMonth(App.id, SelectedMonth);
                    if (ips == null || eps == null)
                    {
                        MessageBox.Show("Нет плана на выбранный выбранный месяц");
                        return;
                    }

                    DateTime month = SelectedMonth.Date.AddMonths(1);

                    if (CheckIncome)
                    {
                        IncomePlanModel ipm = new IncomePlanModel();
                        ipm.plan_income_user_FK = App.id;
                        ipm.plan_income_type_Fk = 2;
                        ipm.plan_income_date = month;
                        ipm.plan_income_size = ips.plan_income_size;
                        bd.UpdateIncomePlan(ipm);

                        if (bd.GetExpensePlanForMonth(App.id, month) == null)
                        {
                            ExpensePlanModel e = new ExpensePlanModel();
                            e.plan_expense_user_FK = App.id;
                            e.plan_expense_type_Fk = 2;
                            e.plan_expense_date = month;
                            e.plan_expense_size = 0;
                            bd.UpdateExpensePlan(e);
                        }
                    }
                    else
                    {
                        ExpensePlanModel epm = new ExpensePlanModel();
                        epm.plan_expense_user_FK = App.id;
                        epm.plan_expense_type_Fk = 2;
                        epm.plan_expense_date = month;
                        epm.plan_expense_size = eps.plan_expense_size;
                        bd.UpdateExpensePlan(epm);

                        if (bd.GetIncomePlanForMonth(App.id, month) == null)
                        {
                            IncomePlanModel ipm = new IncomePlanModel();
                            ipm.plan_income_user_FK = App.id;
                            ipm.plan_income_type_Fk = 2;
                            ipm.plan_income_date = month;
                            ipm.plan_income_size = 0;
                            bd.UpdateIncomePlan(ipm);
                        }
                    }

                    MessageBox.Show("План продублирован");

                    UpdatePage();
                });
            }
        }
        public RelayCommand DuplicateForMonthsOfTheYear
        {
            get
            {
                return new RelayCommand(o =>
                {
                    var ips = bd.GetIncomePlanForMonth(App.id, SelectedMonth);
                    var eps = bd.GetExpensePlanForMonth(App.id, SelectedMonth);
                    if (ips == null || eps == null)
                    {
                        MessageBox.Show("Нет плана на выбранный день");
                        return;
                    }

                    DateTime d1 = SelectedMonth.Date.AddMonths(1);
                    DateTime d2 = new DateTime(SelectedMonth.Year, 1, 1).AddYears(1);
                    for (DateTime d = d1; d < d2; d = d.AddMonths(1))
                    {
                        if (CheckIncome)
                        {
                            IncomePlanModel ipm = new IncomePlanModel();
                            ipm.plan_income_user_FK = App.id;
                            ipm.plan_income_type_Fk = 2;
                            ipm.plan_income_date = d;
                            ipm.plan_income_size = ips.plan_income_size;
                            bd.UpdateIncomePlan(ipm);

                            if (bd.GetExpensePlanForMonth(App.id, d) == null)
                            {
                                ExpensePlanModel e = new ExpensePlanModel();
                                e.plan_expense_user_FK = App.id;
                                e.plan_expense_type_Fk = 2;
                                e.plan_expense_date = d;
                                e.plan_expense_size = 0;
                                bd.UpdateExpensePlan(e);
                            }
                        }
                        else
                        {
                            ExpensePlanModel epm = new ExpensePlanModel();
                            epm.plan_expense_user_FK = App.id;
                            epm.plan_expense_type_Fk = 2;
                            epm.plan_expense_date = d;
                            epm.plan_expense_size = eps.plan_expense_size;
                            bd.UpdateExpensePlan(epm);

                            if (bd.GetIncomePlanForMonth(App.id, d) == null)
                            {
                                IncomePlanModel ipm = new IncomePlanModel();
                                ipm.plan_income_user_FK = App.id;
                                ipm.plan_income_type_Fk = 2;
                                ipm.plan_income_date = d;
                                ipm.plan_income_size = 0;
                                bd.UpdateIncomePlan(ipm);
                            }
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
                    EditMyProfilePage window = new EditMyProfilePage(4);
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
  
        public PlanForMonthsViewModel(DBDataOperation myBd, Window w2)
        {
            bd = myBd;
            w = w2;

            SelectedMonth = DateTime.Now;
        }
        public void UpdatePage()
        {
            var ip = bd.GetIncomePlanForYear(App.id, SelectedMonth);
            if (ip == null || ip.plan_income_size == 0)
            {
                IPlan1 = "Нет";
            }
            else
            {
                IPlan1 = ip.plan_income_size.ToString();
            }
            var ep = bd.GetExpensePlanForYear(App.id, SelectedMonth);
            if (ep == null || ip.plan_income_size == 0)
            {
                EPlan1 = "Нет";
            }
            else
            {
                EPlan1 = ep.plan_expense_size.ToString();
            }

            DateTime date1 = new DateTime(SelectedMonth.Year, 1, 1).AddDays(-1);
            DateTime date2 = new DateTime(SelectedMonth.Year, 12, 1).AddMonths(1);
            IPlan2 = bd.GetIncomePlanSum(App.id, 2, date1, date2).ToString();
            EPlan2 = bd.GetExpensePlanSum(App.id, 2, date1, date2).ToString();
            IPlan3 = bd.GetIncomeForYear(App.id, SelectedMonth).ToString();
            EPlan3 = bd.GetExpenseForYear(App.id, SelectedMonth).ToString();

            iNCOMEItogSize = bd.GetIncomeForMonth(App.id, SelectedMonth).ToString();
            EXPENSEItogSize = bd.GetExpenseForMonth(App.id, SelectedMonth).ToString();
            ItogBalance = Convert.ToDecimal(iNCOMEItogSize) - Convert.ToDecimal(EXPENSEItogSize);

            var ips = bd.GetIncomePlanForMonth(App.id, SelectedMonth);
            if (ips == null)
            {
                iNCOMEPlanSize = "";
            }
            else
            {
                iNCOMEPlanSize = ips.plan_income_size.ToString();
            }
            var eps = bd.GetExpensePlanForMonth(App.id, SelectedMonth);
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
            PlanDataGrid = bd.GetPlansMonths(App.id, SelectedMonth);
        }

    }
}
