using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class QueryStatisticModel
    {
        public int ApplicationId { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? CreatedAtFrom { get; set; }


        public DateTimeOffset? CreatedAtTo { get; set;  }
    }
}
