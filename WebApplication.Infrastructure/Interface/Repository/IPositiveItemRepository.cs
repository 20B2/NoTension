using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Positive;

namespace WebApplication.Infrastructure.Interface.Repository
{
    public interface IPositiveItemRepository
    {
        Task Delete(PositiveItem item);
        Task<List<PositiveItem>> FindAll();
        PositiveItem Get(string _id);
        Task Save(PositiveItem item);
        Task Update(PositiveItem item);
    }
}