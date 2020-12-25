using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL
{
    public class IncomeSelect
    {
        public int id { get; set; }
        public DateTime? income_date { get; set; }
        public decimal? income_size { get; set; }
        public int income_guide_FK { get; set; }
        public string income_type { get; set; }
        public IncomeSelect(INCOME income)
        {
            id = income.id;
            income_date = income.income_date;
            income_size = income.income_size;
            income_type = income.INCOME_GUIDE.income_type;
            income_guide_FK = income.income_guide_FK;
        }
    }
}
