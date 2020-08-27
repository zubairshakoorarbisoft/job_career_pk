using Jaslah.JobCareerPk.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.ViewModels
{
    public class SignUpViewModel
    {
        [Required, EmailAddress, Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Passwords must have at least one non alphanumeric character, lowercase ('a'-'z') and one uppercase ('A'-'Z').")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required, Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        [Required, Display(Name = "Industry Type")]
        public int IndustryTypeId { get; set; }
        [Required, Display(Name = "Sign Up as")]
        public int RoleId { get; set; }

        #region Employee Fields
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string KeySkills { get; set; }
        public string LastDegree { get; set; }
        #endregion

        #region Employer Fields
        public string EmployerName { get; set; }
        #endregion

        #region Collections
        public IEnumerable<IndustryType> IndustryTypes { get; set; }
        public IEnumerable<object> UserRoles = new List<object>()
        {
            new { Id = 1, Name = "Employee" },
            new { Id = 2, Name = "Employer" }
        };
        #endregion

    }
}
