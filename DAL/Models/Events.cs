using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
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

        #region FK
        public Applications Applications { get; set; }
        #endregion
    }
}
