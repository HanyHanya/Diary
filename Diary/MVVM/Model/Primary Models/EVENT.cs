namespace Diary.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EVENT")]
    public partial class EVENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EVRNT_ID { get; set; }

        [StringLength(50)]
        public string EVENT_NAME { get; set; }

        [StringLength(50)]
        public string EVENT_TYPE { get; set; }

        public DateTime? START { get; set; }

        public DateTime? END { get; set; }

        [Column(TypeName = "date")]
        public DateTime? REPEAT { get; set; }

        [StringLength(5)]
        public string CONTACT_ID { get; set; }

        [StringLength(30)]
        public string STATUS { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual EVENT_TYPE EVENT_TYPE1 { get; set; }

        public virtual REPEAT REPEAT1 { get; set; }

        public virtual STATUS STATUS1 { get; set; }
    }
}
