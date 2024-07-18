using MyShop.Data.Infrastructure;
using MyShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Respositories
{

    public interface ISystemConfigRepository : IRepository<Tag>
    {

    }

    public class SystemConfigRepository : RepositoryBase<Tag>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
