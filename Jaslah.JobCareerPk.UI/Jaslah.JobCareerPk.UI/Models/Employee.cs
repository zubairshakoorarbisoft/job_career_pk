using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string KeySkills { get; set; }
        public string LastDegree { get; set; }
        public string UserId { get; set; }
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        public IndustryType IndustryType { get; set; }
    }
}
