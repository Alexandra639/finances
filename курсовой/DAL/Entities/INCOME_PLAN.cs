namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INCOME PLAN")]
    public partial class INCOME_PLAN
    {
        public int id { get; set; }

        public int plan_income_user_FK { get; set; }

        public int plan_income_type_Fk { get; set; }

        public DateTime plan_income_date { get; set; }

        public decimal? plan_income_size { get; set; }

        public virtual PLAN_TYPE PLAN_TYPE { get; set; }

        public virtual USER USER { get; set; }
    }
}
