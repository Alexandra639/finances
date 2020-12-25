namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXPENSE")]
    public partial class EXPENSE
    {
        public int id { get; set; }

        public int expense_user_FK { get; set; }

        public int expense_guide_FK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expense_date { get; set; }

        public decimal expense_size { get; set; }

        public virtual EXPENSE_GUIDE EXPENSE_GUIDE { get; set; }

        public virtual USER USER { get; set; }
    }
}
