using System;
using System.ComponentModel;

namespace sage.challenge.data.Entities
{
    /// <summary>
    /// Common properties
    /// </summary>
    public class ObjectModel
    {
        public DateTime? CreateDate { get; set; }

        [DefaultValue(null)]
        public int? CreateBy { get; set; }

        [DefaultValue(null)]
        public DateTime? EditDate { get; set; }

        [DefaultValue(null)]
        public int? EditBy { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
