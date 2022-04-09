using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using volgaHack.ViewModels.Chart;

namespace volgaHack.ViewModels
{
    public class GraphicsDataResult
    {
        public int AppId { get; set; }

        public string AppName {get;set;}

        public List<ChartDataViewModel> ChartData { get; set; }
    }
}
