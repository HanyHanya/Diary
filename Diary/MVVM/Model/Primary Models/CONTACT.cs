namespace Diary.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTACT()
        {
            EVENT = new HashSet<EVENT>();
        }

        [Key]
        [StringLength(5)]
        public string CONTACT_ID { get; set; }

        [StringLength(50)]
        public string FIO { get; set; }

        [StringLength(10)]
        public string TEL_NUM { get; set; }

        public string NOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENT> EVENT { get; set; }
    }
}
