using BLL.Models;
using BLL.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IStatisticService
    {
        IEnumerable<QueryStatisticDto> Query(QueryStatisticModel model);

        EventCountStatisticDto EventCount(QueryStatisticModel model);
    }
}
