namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXPENSE GUIDE")]
    public partial class EXPENSE_GUIDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXPENSE_GUIDE()
        {
            EXPENSE = new HashSet<EXPENSE>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string expense_type { get; set; }

        public int userFk { get; set; }

        public bool show { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPENSE> EXPENSE { get; set; }

        public virtual USER USER { get; set; }
    }
}
