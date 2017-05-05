using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Tech;

namespace WebApplication.Infrastructure.Interface.Repository
{
    public interface ITechItemRepository
    {
        Task Delete(TechItem item);
        Task<List<TechItem>> FindAll();
        TechItem Get(string _id);
        Task Save(TechItem item);
        Task Update(TechItem item);
    }
}