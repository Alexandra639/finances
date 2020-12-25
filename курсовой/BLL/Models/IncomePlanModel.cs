using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class IncomePlanModel
    {
        public int income_plan_id { get; set; }

        public int plan_income_user_FK { get; set; }

        public int plan_income_type_Fk { get; set; }

        public DateTime plan_income_date { get; set; }

        public decimal plan_income_size { get; set; }

        public IncomePlanModel() { }
        public IncomePlanModel(INCOME_PLAN i)
        {
            income_plan_id = i.id;
            plan_income_user_FK = i.plan_income_user_FK;
            plan_income_type_Fk = i.plan_income_type_Fk;
            plan_income_date = i.plan_income_date;
            plan_income_size = (decimal)i.plan_income_size;
        }
    }
}
