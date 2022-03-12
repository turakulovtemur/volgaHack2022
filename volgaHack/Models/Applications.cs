using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.Models
{
    public class Applications
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreatedApp { get; set; }

        public string UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
