using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.ViewModels
{
    public class EventListViewModel
    {
        public int ApplicationId { get; set; }

        public List<EventViewModel> EventList { get; set; }
    }
}
