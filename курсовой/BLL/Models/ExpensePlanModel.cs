using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class ExpensePlanModel
    {
        public int expense_plan_id { get; set; }

        public int plan_expense_user_FK { get; set; }

        public int plan_expense_type_Fk { get; set; }

        public DateTime plan_expense_date { get; set; }

        public decimal plan_expense_size { get; set; }

        public ExpensePlanModel() { }
        public ExpensePlanModel(EXPENSE_PLAN e)
        {
            expense_plan_id = e.id;
            plan_expense_user_FK = e.plan_expense_user_FK;
            plan_expense_type_Fk = e.plan_expense_type_Fk;
            plan_expense_date = e.plan_expense_date;
            plan_expense_size = (decimal)e.plan_expense_size;
        }
    }
}
