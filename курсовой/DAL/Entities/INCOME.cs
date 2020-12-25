namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INCOME")]
    public partial class INCOME
    {
        public int id { get; set; }

        public int income_user_FK { get; set; }

        public int income_guide_FK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? income_date { get; set; }

        public decimal income_size { get; set; }

        public virtual INCOME_GUIDE INCOME_GUIDE { get; set; }

        public virtual USER USER { get; set; }
    }
}
