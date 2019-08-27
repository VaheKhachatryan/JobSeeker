using System;
using System.Collections.Generic;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class DictionaryJobCategory
    {
        public DictionaryJobCategory()
        {
            Job = new HashSet<Job>();
        }

        public int DictionaryJobCategoryId { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysStartDate { get; set; }
        public DateTime SysEndDate { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }
}
