using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            claims = new List<string>();
            roles = new List<string>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> claims { get; set; }
        public List<string> roles { get; set; }
    }
}
