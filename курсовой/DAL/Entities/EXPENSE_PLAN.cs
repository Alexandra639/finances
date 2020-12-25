namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXPENSE PLAN")]
    public partial class EXPENSE_PLAN
    {
        public int id { get; set; }

        public int plan_expense_user_FK { get; set; }

        public int plan_expense_type_Fk { get; set; }

        public DateTime plan_expense_date { get; set; }

        public decimal? plan_expense_size { get; set; }

        public virtual PLAN_TYPE PLAN_TYPE { get; set; }

        public virtual USER USER { get; set; }
    }
}
