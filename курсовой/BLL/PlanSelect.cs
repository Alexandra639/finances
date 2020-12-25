using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL
{
   public class PlanSelect
    {
        public DateTime plan_date { get; set; }
        public decimal plan_income_size { get; set; }
        public decimal itog_income_size { get; set; }
        public decimal plan_expense_size { get; set; }
        public decimal itog_expense_size { get; set; }
        public decimal plan_balance { get; set; }
        public decimal itog_balance { get; set; }
        public PlanSelect(){ }

    }
}
