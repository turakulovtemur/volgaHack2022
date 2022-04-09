using BLL.Models;
using BLL.Models.Dtos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly ApplicationContext _dbContext;

        public StatisticService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EventCountStatisticDto EventCount(QueryStatisticModel model)
        {
            var events = Query(model);

            var dict = events.GroupBy(x => x.Name)
                .Select(x => new
                {
                    EventName = x.Key,
                    Count = x.Count()
                }).ToDictionary(x => x.EventName, x => x.Count);

            return new EventCountStatisticDto()
            {
                EventDataCount = dict
            };
        }

        public IEnumerable<QueryStatisticDto> Query(QueryStatisticModel model)
        {
            var events = _dbContext.Events.Where(x => x.ApplicationId == model.ApplicationId);

            if(!string.IsNullOrEmpty(model.EventName))
            {
                events = events.Where(x => x.Name == model.EventName);
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                events = events.Where(x => x.Description == model.Description);
            }

            if (model.CreatedAtFrom is not null)
            {
                events = events.Where(x => x.DateCreatedEvent >= model.CreatedAtFrom);
            }

            if (model.CreatedAtTo is not null)
            {
                events = events.Where(x => x.DateCreatedEvent <= model.CreatedAtTo);
            }

            return events.Select(x => new QueryStatisticDto
            {
                EventId = x.Id,
                Name = x.Name,
                Description = x.Description,
                DateCreatedEvent = x.DateCreatedEvent,
                ApplicationId = x.ApplicationId

            }).ToList();
        }
    }
}
