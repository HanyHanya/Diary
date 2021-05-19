namespace Diary.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [Key]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [StringLength(15)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public byte[] img { get; set; }
    }
}
