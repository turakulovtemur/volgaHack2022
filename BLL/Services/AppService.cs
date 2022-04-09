using BLL.Models.Dtos;
using DAL;
using System.Linq;

namespace BLL.Services
{
    public class AppService : IAppService
    {
        private readonly ApplicationContext db;

        public AppService(ApplicationContext db)
        {
            this.db = db;
        }

        public ApplicationDto GetApplicationById(int id)
        {
            var result = db.Applications.First(x => x.Id == id);

            return new ApplicationDto
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                DateCreatedApp = result.DateCreatedApp
            };
        }
    }
}
