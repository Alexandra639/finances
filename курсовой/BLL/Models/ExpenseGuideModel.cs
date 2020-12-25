using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class ExpenseGuideModel
    {

        public int expense_guide_code_ID { get; set; }
        public string expense_type { get; set; }
        public int userFk { get; set; }
        public bool show { get; set; }

        public ExpenseGuideModel() { }
        public ExpenseGuideModel(EXPENSE_GUIDE e)
        {
            expense_guide_code_ID = e.id;
            expense_type = e.expense_type;
            userFk = e.userFk;
            show = e.show;
        }
    }
}
