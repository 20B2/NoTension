using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;

namespace WebApplication.Infrastructure.Interface.Repository
{
    public interface IRoleStatusTypeMappingRepository
    {

        Task<RoleStatusTypeMapping> Get(string _id);
        Task Save(RoleStatusTypeMapping statusType);
        Task Delete(string statusType);
        Task Update(RoleStatusTypeMapping statusType);
        Task<List<RoleStatusTypeMapping>> FindAll();
        Task Delete(RoleStatusTypeMapping item);
    }
}
