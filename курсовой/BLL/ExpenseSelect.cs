using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Runtime;

namespace BLL
{
   public class ExpenseSelect
    {
        public int id { get; set; }
        public DateTime? expense_date { get; set; }
        public decimal? expense_size { get; set; }
        public int expense_guide_Fk { get; set; }
        public string expense_type { get; set; }
        public ExpenseSelect(EXPENSE expense)
        {
            id = expense.id;
            expense_date = expense.expense_date;
            expense_size = expense.expense_size;
            expense_type = expense.EXPENSE_GUIDE.expense_type;
            expense_guide_Fk = expense.expense_guide_FK;
        }
    }
}
