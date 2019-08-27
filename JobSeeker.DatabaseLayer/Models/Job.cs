using System;
using System.Collections.Generic;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class Job
    {
        public int JobId { get; set; }
        public int DictionaryJobCategoryId { get; set; }
        public int DictionaryEmploymentTypeId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysStartDate { get; set; }
        public DateTime SysEndDate { get; set; }

        public virtual City City { get; set; }
        public virtual DictionaryEmploymentType DictionaryEmploymentType { get; set; }
        public virtual DictionaryJobCategory DictionaryJobCategory { get; set; }
    }
}
