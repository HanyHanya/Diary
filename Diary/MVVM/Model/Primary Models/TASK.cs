namespace Diary.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TASK")]
    public partial class TASK
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TASK_ID { get; set; }

        public DateTime? END { get; set; }

        [StringLength(30)]
        public string STATUS { get; set; }

        public string NOTES { get; set; }

        public virtual STATUS STATUS1 { get; set; }
    }
}
