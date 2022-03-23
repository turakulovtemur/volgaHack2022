using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.ViewModels
{
    public class StatisticQueryRequest
    {
        public int ApplicationId {get;set;}
        
        public string EventName { get; set; }

        public DateTime CreatedAtFrom { get; set; }


        public DateTime CreateAtTo { get; set; }
    }
}
