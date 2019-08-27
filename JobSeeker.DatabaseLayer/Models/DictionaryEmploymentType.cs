using System;
using System.Collections.Generic;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class DictionaryEmploymentType
    {
        public DictionaryEmploymentType()
        {
            Job = new HashSet<Job>();
        }

        public int DictionaryEmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysStartDate { get; set; }
        public DateTime SysEndDate { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }
}
