using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Applications
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreatedApp { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
