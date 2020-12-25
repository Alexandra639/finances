using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class IncomeGuideModel
    {
       
        public int income_guide_code_ID { get; set; }
        public string income_type { get; set; }
        public int userFk { get; set; }
        public bool show { get; set; }

        public IncomeGuideModel() { }
        public IncomeGuideModel(INCOME_GUIDE i)
        {
            income_guide_code_ID = i.id;
            income_type = i.income_type;
            userFk = i.userFk;
            show = i.show;

        }
    }
}
