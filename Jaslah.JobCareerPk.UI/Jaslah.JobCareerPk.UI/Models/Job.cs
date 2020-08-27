using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string RequiredSkills { get; set; }
        public int Salary { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public int JobTypeId { get; set; }
        [ForeignKey("JobTypeId")]
        public IndustryType JobeType { get; set; }
        public int EmployerId { get; set; }
        [ForeignKey("EmployerId")]
        public Employer Employer { get; set; }
    }
}
