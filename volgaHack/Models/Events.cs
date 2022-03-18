using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime DateCreatedEvent { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public int ApplicationId { get; set; }

        
        public Applications Applications { get; set; }
    }
}
