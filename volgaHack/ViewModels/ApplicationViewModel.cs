﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.ViewModels
{
    public class ApplicationViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreatedApp { get; set; }
    }
}
