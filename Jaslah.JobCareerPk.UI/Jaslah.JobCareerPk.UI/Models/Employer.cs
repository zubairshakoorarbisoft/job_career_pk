using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        public IndustryType IndustryType { get; set; }
    }
}
