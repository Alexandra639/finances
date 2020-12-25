using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BLL.Models;


namespace BLL
{
    public class DBDataOperation
    {

        private FinanceDBContext db;
        public DBDataOperation()
        {
            db = new FinanceDBContext();

        }

        // USER

        public void CreateUSER(UserModel u)
        {
            db.USER.Add(new USER()
            {
                id = u.user_code_ID,
                name = u.name,
                surname = u.surname,
                login = u.login,
                password = u.password,
            });
            Save();

        }
        public void UpdateUSER(UserModel u)
        {
            USER ph = db.USER.Find(u.user_code_ID);

            ph.id = u.user_code_ID;
            ph.name = u.name;
            ph.surname = u.surname;
            ph.password = u.password;

            Save();
        }
        //функция определяет есть ли пользователь с таким логином и паролем в базе
        public int GetUSER(string login, string password)
        {
            var k = db.USER.ToList().Where(i => i.login == login && i.password == password).FirstOrDefault();

            if (k != null)
            {
                return k.id;
            }
            else
            {
                return 0;
            }

        }
        //определяет есть ли пользовательс таким логином
        public bool GetUSER(string login)
        {
            var k = db.USER.ToList().Where(i => i.login == login).ToList();
            if (k.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public UserModel GetUSER(int id)
        {
            var k = db.USER.ToList().Where(i => i.id == id).Select(i => new UserModel(i)).FirstOrDefault();
            return k;

        }
        public List<UserModel> GetALLUSERS()
        {
            return db.USER.ToList().Select(i => new UserModel(i)).ToList();

        }

        // INCOME

        public void CreateINCOME(IncomeModel i)

        {
            db.INCOME.Add(new INCOME()
            {
                id = i.income_code_ID,
                income_user_FK = (int)i.income_user_FK,
                income_guide_FK = (int)i.income_guide_FK,
                income_date = (DateTime)i.income_date,
                income_size = (int)i.income_size
            });
            Save();
        }
        public void UpdateINCOME(IncomeModel inc)
        {
            INCOME i = db.INCOME.Find(inc.income_code_ID);
            i.id = inc.income_code_ID;
            i.income_guide_FK = (int)inc.income_guide_FK;
            i.income_size = (decimal)inc.income_size;
            i.income_date = (DateTime)inc.income_date;
            Save();
        }
        public List<IncomeModel> GetALLINCOMES(int user_id)
        {
            return db.INCOME.ToList()
            .Where(i => i.income_user_FK == user_id)
            .Select(i => new IncomeModel(i)).ToList();

        }
        public List<IncomeSelect> GetALLINCOMESSELECT(DateTime date1, DateTime date2, int id_user)
        {
            var result = db.INCOME.ToList()
            .Where(i => i.income_user_FK == id_user).ToList()
            .Intersect(db.INCOME.Where(i => i.income_date >= date1)).ToList()
            .Intersect(db.INCOME.Where(i => i.income_date <= date2)).ToList()
            .Select(i => new IncomeSelect(i)).ToList()
            .OrderBy(i => i.income_date).ToList();

            return result;
        }
        public void DeleteINCOME(int id)
        {
            INCOME i = db.INCOME.Find(id);
            if (i != null)
            {
                db.INCOME.Remove(i);
                Save();
            }
        }

        //EXPENSE

        public void CreateEXPENSE(ExpenseModel i)

        {
            db.EXPENSE.Add(new EXPENSE()
            {
                id = (int)i.expense_code_ID,
                expense_user_FK = (int)i.expense_user_FK,
                expense_guide_FK = (int)i.expense_guide_FK,
                expense_date = i.expense_date,
                expense_size = (int)i.expense_size
            });
            Save();
        }
        public void UpdateEXPENSE(ExpenseModel exp)
        {
            EXPENSE e = db.EXPENSE.Find(exp.expense_code_ID);
            e.id = exp.expense_code_ID;
            e.expense_guide_FK = (int)exp.expense_guide_FK;
            e.expense_size = (decimal)exp.expense_size;
            e.expense_date = (DateTime)exp.expense_date;
            Save();
        }
        public List<ExpenseModel> GetALLEXPENSES(int user_id)
        {
            return db.EXPENSE.ToList()
            .Where(i => i.expense_user_FK == user_id)
            .Select(i => new ExpenseModel(i)).ToList();

        }
        public List<ExpenseSelect> GetALLEXPENSESSELECT(DateTime date1, DateTime date2, int id_user)
        {
            var result = db.EXPENSE.ToList()
           .Where(i => i.expense_user_FK == id_user).ToList()
           .Intersect(db.EXPENSE.Where(i => i.expense_date >= date1)).ToList()
           .Intersect(db.EXPENSE.Where(i => i.expense_date <= date2)).ToList()
           .Select(i => new ExpenseSelect(i)).ToList()
           .OrderBy(i => i.expense_date).ToList();

            return result;

        }
        public void DeleteEXPENSE(int id)
        {
            EXPENSE i = db.EXPENSE.Find(id);
            if (i != null)
            {
                db.EXPENSE.Remove(i);
                Save();
            }
        }

        //INCOME_GUIDE

        public void CreateINCOME_GUIDE(IncomeGuideModel i)
        {
            db.INCOME_GUIDE.Add(new INCOME_GUIDE()
            {
                id = i.income_guide_code_ID,
                income_type = i.income_type,
                userFk = i.userFk,
                show = i.show
            });
            Save();

        }
        public IncomeGuideModel GetINCOME_GUIDE(int id)
        {
            var result = db.INCOME_GUIDE.ToList()
            .Where(i => i.id == id)
           .Select(i => new IncomeGuideModel(i))
            .FirstOrDefault();
            return result;
        }
        public List<IncomeGuideModel> GetALLINCOME_GUIDES(int user_id)
        {
            return db.INCOME_GUIDE.ToList()
            .Where(i => i.userFk == user_id)
            .Where(i => i.show == true)
            .Select(i => new IncomeGuideModel(i)).ToList()
            .OrderBy(i => i.income_type).ToList();
        }
        public void DeleteINCOME_GUIDE(int id, int user_id)
        {
            INCOME_GUIDE inc = db.INCOME_GUIDE.Find(id);
            if (inc != null)
            {

                var r = GetALLINCOMES(user_id)
                    .Where(i => i.income_guide_FK == id)
                    .FirstOrDefault();
                if (r != null)
                {
                    inc.show = false;
                    Save();
                }
                else
                {
                    db.INCOME_GUIDE.Remove(inc);
                    Save();
                }
            }
        }

        //EXPENSE_GUIDE

        public void CreateEXPENSE_GUIDE(ExpenseGuideModel e)
        {
            db.EXPENSE_GUIDE.Add(new EXPENSE_GUIDE()
            {
                id = e.expense_guide_code_ID,
                expense_type = e.expense_type,
                userFk = e.userFk,
                show = e.show
            });
            Save();

        }
        public ExpenseGuideModel GetEXPENSE_GUIDE(int id)
        {
            var result = db.EXPENSE_GUIDE.ToList()
           .Where(i => i.id == id)
           .Select(i => new ExpenseGuideModel(i))
           .FirstOrDefault();
            return result;
        }
        public List<ExpenseGuideModel> GetALLEXPENSE_GUIDES(int user_id)
        {
            return db.EXPENSE_GUIDE.ToList()
            .Where(i => i.userFk == user_id)
            .Where(i => i.show == true)
            .Select(i => new ExpenseGuideModel(i)).ToList()
            .OrderBy(i => i.expense_type).ToList();

        }
        public void DeleteEXPENSE_GUIDE(int id, int user_id)
        {
            EXPENSE_GUIDE e = db.EXPENSE_GUIDE.Find(id);
            if (e != null)
            {
                var r = GetALLEXPENSES(user_id)
                    .Where(i => i.expense_guide_FK == id)
                    .FirstOrDefault();
                if (r != null)
                {
                    e.show = false;
                    Save();
                }
                else
                {
                    db.EXPENSE_GUIDE.Remove(e);
                    Save();
                }

            }
        }


        // PLAN


        public void CreateIncomePlan(IncomePlanModel ip)
        {
            db.INCOME_PLAN.Add(new INCOME_PLAN()
            {
                plan_income_user_FK = ip.plan_income_user_FK,
                plan_income_type_Fk = ip.plan_income_type_Fk,
                plan_income_date = ip.plan_income_date,
                plan_income_size = ip.plan_income_size
            });
            Save();
        }
        public void CreateExpensePlan(ExpensePlanModel ep)
        {
            db.EXPENSE_PLAN.Add(new EXPENSE_PLAN()
            {
                plan_expense_user_FK = ep.plan_expense_user_FK,
                plan_expense_type_Fk = ep.plan_expense_type_Fk,
                plan_expense_date = ep.plan_expense_date,
                plan_expense_size = ep.plan_expense_size
            });
            Save();
        }
        public void UpdateIncomePlan(IncomePlanModel ipm)
        {
            var u = db.USER.ToList().Where(i => i.id == ipm.plan_income_user_FK).FirstOrDefault();
            INCOME_PLAN i_p = u.INCOME_PLAN.ToList().Where(i => ((DateTime)i.plan_income_date.Date) == ipm.plan_income_date.Date).FirstOrDefault();
            if (i_p == null)
            {
                CreateIncomePlan(ipm);
            }
            else
            {
                i_p.plan_income_user_FK = ipm.plan_income_user_FK;
                i_p.plan_income_type_Fk = ipm.plan_income_type_Fk;
                i_p.plan_income_date = ipm.plan_income_date;
                i_p.plan_income_size = ipm.plan_income_size;

                Save();
            }

        }
        public void UpdateExpensePlan(ExpensePlanModel epm)
        {
            var u = db.USER.ToList().Where(i => i.id == epm.plan_expense_user_FK).FirstOrDefault();
            EXPENSE_PLAN e_p = u.EXPENSE_PLAN.ToList().Where(i => ((DateTime)i.plan_expense_date).Date == epm.plan_expense_date.Date).FirstOrDefault();
            if (e_p == null)
            {
                CreateExpensePlan(epm);
            }
            else
            {
                e_p.plan_expense_user_FK = epm.plan_expense_user_FK;
                e_p.plan_expense_type_Fk = epm.plan_expense_type_Fk;
                e_p.plan_expense_date = epm.plan_expense_date;
                e_p.plan_expense_size = epm.plan_expense_size;

                Save();
            }

        }
        // планируемый доход, расход на год
        public IncomePlanModel GetIncomePlanForYear(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 3).ToList()
                .Where(i => i.plan_income_date.Year == date.Year)
                .Select(i => new IncomePlanModel(i)).FirstOrDefault();
            return p;
        }
        public ExpensePlanModel GetExpensePlanForYear(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 3).ToList()
                .Where(i =>  i.plan_expense_date.Year == date.Year)
                .Select(i => new ExpensePlanModel(i)).FirstOrDefault();
            return p;
        }
        // полученный за год доход, расход 
        public decimal GetIncomeForYear(int id_user, DateTime date)
        {
            var inc = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME.ToList().Where(i => ((DateTime)i.income_date).Year == date.Year).ToList();
            decimal r = 0;
            for (int i = 0; i < inc.Count(); i++)
            {
                r += inc[i].income_size;
            }
            return r;
        }
        public decimal GetExpenseForYear(int id_user, DateTime date)
        {
            var exp = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Year == date.Year).ToList();
            decimal r = 0;
            for (int i = 0; i < exp.Count(); i++)
            {
                r += exp[i].expense_size;
            }
            return r;
        }
        // планируемый доход, расход на месяц
        public IncomePlanModel GetIncomePlanForMonth(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 2).ToList()
                .Where(i => i.plan_income_date.Month == date.Month && i.plan_income_date.Year == date.Year)
                .Select(i => new IncomePlanModel(i)).FirstOrDefault();
            return p;
        }
        public ExpensePlanModel GetExpensePlanForMonth(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 2).ToList()
                .Where(i => i.plan_expense_date.Month == date.Month && i.plan_expense_date.Year == date.Year)
                .Select(i => new ExpensePlanModel(i)).FirstOrDefault();
            return p;
        }
      // полученный за месяц доход, расход 
        public decimal GetIncomeForMonth(int id_user, DateTime date)
        {
            var inc = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME.ToList().Where(i => ((DateTime)i.income_date).Month == date.Month && ((DateTime)i.income_date).Year == date.Year).ToList();
            decimal r = 0;
               for (int i = 0; i< inc.Count();i++)
            {
                r += inc[i].income_size;
            }
            return r;
        }
        public decimal GetExpenseForMonth(int id_user, DateTime date)
        {
            var exp = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Month == date.Month && ((DateTime)i.expense_date).Year == date.Year).ToList();
            decimal r = 0;
            for (int i = 0; i < exp.Count(); i++)
            {
                r += exp[i].expense_size;
            }
            return r;
        }
        // планируемый доход, расход на день
        public IncomePlanModel GetIncomePlanForDay(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 1).ToList()
                .Where(i => i.plan_income_date.Date == date.Date)
                .Select(i => new IncomePlanModel(i)).FirstOrDefault();
            return p;
        }
        public ExpensePlanModel GetExpensePlanForDay(int id_user, DateTime date)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 1).ToList()
                .Where(i => i.plan_expense_date.Date == date.Date)
                .Select(i => new ExpensePlanModel(i)).FirstOrDefault();
            return p;
        }
        // полученный за день доход, расход 
        public decimal GetIncomeForDay(int id_user, DateTime date)
        {
            var inc = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
               .INCOME.ToList().Where(i => ((DateTime)i.income_date).Date == date.Date).ToList();
            decimal r = 0;
            for (int i = 0; i < inc.Count(); i++)
            {
                r += inc[i].income_size;
            }
            return r;
        }
        public decimal GetExpenseForDay(int id_user, DateTime date)
        {
            var exp = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                 .EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Date == date.Date).ToList();
            decimal r = 0;
            for (int i = 0; i < exp.Count(); i++)
            {
                r += exp[i].expense_size;
            }
            return r;
        }
        // сумарный планируемый доход, расход
        public decimal GetIncomePlanSum(int id_user, int type, DateTime date1, DateTime date2)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == type).ToList()
                .Where(i => i.plan_income_date.Date > date1.Date && i.plan_income_date.Date < date2.Date)
                .Select(i => new IncomePlanModel(i)).ToList();

            decimal r = 0;
            for (int i = 0; i < p.Count();i++)
            {
                r += p[i].plan_income_size;
            }

            return r;
        }
        public decimal GetExpensePlanSum(int id_user, int type, DateTime date1, DateTime date2)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == type).ToList()
                .Where(i => i.plan_expense_date.Date > date1.Date && i.plan_expense_date.Date < date2.Date)
                .Select(i => new ExpensePlanModel(i)).ToList();

            decimal r = 0;
            for (int i = 0; i < p.Count(); i++)
            {
                r += p[i].plan_expense_size;
            }

            return r;
        }
        // доход, расход полученные за десятилетие
        public decimal GetIncomeFor10Years(int id_user, int type, DateTime date1, DateTime date2)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .INCOME.ToList().Where(i => i.income_guide_FK == type).ToList()
                .Where(i => ((DateTime)i.income_date).Year >= date1.Year && ((DateTime)i.income_date).Year <= date2.Year)
                .Select(i => new IncomeModel(i)).ToList();

            decimal r = 0;
            for (int i = 0; i < p.Count(); i++)
            {
                r += (decimal)p[i].income_size;
            }

            return r;
        }
        public decimal GetExpenseFor10Years(int id_user, int type, DateTime date1, DateTime date2)
        {
            var p = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault()
                .EXPENSE.ToList().Where(i => i.expense_size == type).ToList()
                .Where(i => ((DateTime)i.expense_date).Year >= date1.Year && ((DateTime)i.expense_date).Year <= date2.Year)
                .Select(i => new ExpenseModel(i)).ToList();

            decimal r = 0;
            for (int i = 0; i < p.Count(); i++)
            {
                r +=(decimal)p[i].expense_size;
            }

            return r;
        }
     
        public List<PlanSelect> GetPlansDays(int id_user, DateTime date)
        {
            var u = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault();
            var ip = u.INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 1).ToList()
                .Where(i => i.plan_income_date.Month == date.Month && i.plan_income_date.Year == date.Year).ToList()
                .OrderBy(i => i.plan_income_date).ToList(); 
            if (ip == null)
                return null;
            var ii = u.INCOME.ToList().Where(i => ((DateTime)i.income_date).Month == date.Month && ((DateTime)i.income_date).Year == date.Year).ToList()
                .OrderBy(i => i.income_date).ToList();
            var ep = u.EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 1).ToList()
                .Where(i => i.plan_expense_date.Month == date.Month && i.plan_expense_date.Year == date.Year).ToList()
                .OrderBy(i => i.plan_expense_date).ToList();
            var ie = u.EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Month == date.Month && ((DateTime)i.expense_date).Year == date.Year).ToList()
                .OrderBy(i => i.expense_date).ToList();

            List<PlanSelect> pss = new List<PlanSelect>();
            for (int i = 0; i < ip.Count(); i++)
            {
                    PlanSelect ps = new PlanSelect();
                    ps.plan_date = ip[i].plan_income_date;
                    ps.plan_income_size = (decimal)ip[i].plan_income_size;
                    ps.plan_expense_size = (decimal)ep[i].plan_expense_size;

                    var ii1 = ii.Where(k => ((DateTime)k.income_date).Date == ip[i].plan_income_date.Date).ToList();
                    if (ii1.Count() > 0)
                    {
                        for (int j = 0; j < ii1.Count(); j++)
                        {
                            ps.itog_income_size += (decimal)ii1[j].income_size;
                        }
                    }
                    else
                    {
                        ps.itog_income_size = 0;
                    }

                    var ie1 = ie.Where(k => ((DateTime)k.expense_date).Date == ip[i].plan_income_date.Date).ToList();
                    if (ie1.Count() > 0)
                    {
                        for (int j = 0; j < ie1.Count(); j++)
                        {
                            ps.itog_expense_size += (decimal)ie1[j].expense_size;
                        }
                    }
                    else
                    {
                        ps.itog_expense_size = 0;
                    }
                if (ip[i].plan_income_size > 0 || ep[i].plan_expense_size > 0 || ps.itog_income_size > 0 || ps.itog_expense_size > 0)
                {
                    pss.Add(ps);
                }
            }
            return pss;
        }
        public List<PlanSelect> GetPlansMonths(int id_user, DateTime date)
        {
            var u = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault();
            var ip = u.INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 2).ToList()
                .Where(i => i.plan_income_date.Year == date.Year).ToList()
                .OrderBy(i => i.plan_income_date).ToList();
            if (ip == null)
                return null;
            var ii = u.INCOME.ToList().Where(i => ((DateTime)i.income_date).Year == date.Year).ToList()
                .OrderBy(i => i.income_date).ToList();
            var ep = u.EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 2).ToList()
                .Where(i =>  i.plan_expense_date.Year == date.Year).ToList()
                .OrderBy(i => i.plan_expense_date).ToList();
            var ie = u.EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Year == date.Year).ToList()
                .OrderBy(i => i.expense_date).ToList();

            List<PlanSelect> pss = new List<PlanSelect>();
            for (int i = 0; i < ip.Count(); i++)
            {
                PlanSelect ps = new PlanSelect();
                ps.plan_date = ip[i].plan_income_date;
                ps.plan_income_size = (decimal)ip[i].plan_income_size;
                ps.plan_expense_size = (decimal)ep[i].plan_expense_size;
                ps.plan_balance = ps.plan_income_size - ps.plan_expense_size;

                var ii1 = ii.Where(k => ((DateTime)k.income_date).Month == ip[i].plan_income_date.Month).ToList();
                if (ii1.Count() > 0)
                {
                    for (int j = 0; j < ii1.Count(); j++)
                    {
                        ps.itog_income_size += (decimal)ii1[j].income_size;
                    }
                }
                else
                {
                    ps.itog_income_size = 0;
                }

                var ie1 = ie.Where(k => ((DateTime)k.expense_date).Month == ip[i].plan_income_date.Month).ToList();
                if (ie1.Count() > 0)
                {
                    for (int j = 0; j < ie1.Count(); j++)
                    {
                        ps.itog_expense_size += (decimal)ie1[j].expense_size;
                    }
                }
                else
                {
                    ps.itog_expense_size = 0;
                }

                ps.itog_balance = ps.itog_income_size - ps.itog_expense_size;

                if (ip[i].plan_income_size > 0 || ep[i].plan_expense_size > 0 || ps.itog_income_size > 0 || ps.itog_expense_size > 0)
                {
                    pss.Add(ps);
                }
            }
            return pss;
        }
        public List<PlanSelect> GetPlansYears(int id_user, DateTime date1, DateTime date2)
        {
            var u = db.USER.ToList().Where(i => i.id == id_user).FirstOrDefault();
            var ip = u.INCOME_PLAN.ToList().Where(i => i.plan_income_type_Fk == 3).ToList()
                .Where(i => i.plan_income_date.Year >= date1.Year && i.plan_income_date.Year <= date2.Year).ToList()
                .OrderBy(i => i.plan_income_date).ToList();
            if (ip == null)
                return null;
            var ii = u.INCOME.ToList().Where(i => ((DateTime)i.income_date).Year >= date1.Year && ((DateTime)i.income_date).Year <= date2.Year).ToList()
                .OrderBy(i => i.income_date).ToList();
            var ep = u.EXPENSE_PLAN.ToList().Where(i => i.plan_expense_type_Fk == 3).ToList()
                .Where(i => i.plan_expense_date.Year >= date1.Year && i.plan_expense_date.Year <= date2.Year).ToList()
                .OrderBy(i => i.plan_expense_date).ToList();
            var ie = u.EXPENSE.ToList().Where(i => ((DateTime)i.expense_date).Year >= date1.Year && ((DateTime)i.expense_date).Year <= date2.Year).ToList()
                .OrderBy(i => i.expense_date).ToList();

            List<PlanSelect> pss = new List<PlanSelect>();
            for (int i = 0; i < ip.Count(); i++)
            {
                PlanSelect ps = new PlanSelect();
                ps.plan_date = ip[i].plan_income_date;
                ps.plan_income_size = (decimal)ip[i].plan_income_size;
                ps.plan_expense_size = (decimal)ep[i].plan_expense_size;
                ps.plan_balance = ps.plan_income_size - ps.plan_expense_size;

                var ii1 = ii.Where(k => ((DateTime)k.income_date).Year == ip[i].plan_income_date.Year).ToList();
                if (ii1.Count() > 0)
                {
                    for (int j = 0; j < ii1.Count(); j++)
                    {
                        ps.itog_income_size += (decimal)ii1[j].income_size;
                    }
                }
                else
                {
                    ps.itog_income_size = 0;
                }

                var ie1 = ie.Where(k => ((DateTime)k.expense_date).Year == ip[i].plan_income_date.Year).ToList();
                if (ie1.Count() > 0)
                {
                    for (int j = 0; j < ie1.Count(); j++)
                    {
                        ps.itog_expense_size += (decimal)ie1[j].expense_size;
                    }
                }
                else
                {
                    ps.itog_expense_size = 0;
                }

                ps.itog_balance = ps.itog_income_size - ps.itog_expense_size;

                if (ip[i].plan_income_size > 0 || ep[i].plan_expense_size > 0 || ps.itog_income_size > 0 || ps.itog_expense_size > 0)
                {
                    pss.Add(ps);
                }
            }
            return pss;
        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
