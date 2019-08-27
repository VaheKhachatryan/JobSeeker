using System;
using System.Collections.Generic;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class City
    {
        public City()
        {
            Job = new HashSet<Job>();
        }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysStartDate { get; set; }
        public DateTime SysEndDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}
