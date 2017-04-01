using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.StatusType;

namespace WebApplication.Infrastructure.Interface.Repository
{
    public interface IStatusTypeRepository
    {
        Task Delete(StatusType statusType);
        Task<List<StatusType>> FindAll();
        Task<StatusType> Get(string _id);
        Task Save(StatusType statusType);
        Task Update(StatusType statusType);

    }
}
