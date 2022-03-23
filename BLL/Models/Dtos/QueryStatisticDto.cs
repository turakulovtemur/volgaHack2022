using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Dtos
{
    public class QueryStatisticDto
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateCreatedEvent { get; set; }

        public int ApplicationId { get; set; }
    }
}
