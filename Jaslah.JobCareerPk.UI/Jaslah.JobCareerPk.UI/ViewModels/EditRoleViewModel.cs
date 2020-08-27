﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jaslah.JobCareerPk.UI.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<string> Users{ get; set; }
    }
}
