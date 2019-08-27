using System;
using System.Collections.Generic;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysStartDate { get; set; }
        public DateTime SysEndDate { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
