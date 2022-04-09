using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.ViewModels
{
    public class GraphicsDataResult
    {
        public int AppId { get; set; }

        public List<string> Labels { get; set; }

        public List<int> Data { get; set; }
    }
}
