namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INCOME GUIDE")]
    public partial class INCOME_GUIDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INCOME_GUIDE()
        {
            INCOME = new HashSet<INCOME>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string income_type { get; set; }

        public int userFk { get; set; }

        public bool show { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INCOME> INCOME { get; set; }

        public virtual USER USER { get; set; }
    }
}
