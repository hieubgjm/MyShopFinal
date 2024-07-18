using Microsoft.EntityFrameworkCore;
using MyShop.Data.Infrastructure;
using MyShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Respositories
{
    public interface IApplicationGroupRepository : IRepository<ApplicationGroup>
    {
        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);
        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);
    }
    public class ApplicationGroupRepository : RepositoryBase<ApplicationGroup>, IApplicationGroupRepository
    {
        public ApplicationGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId)
        {
          
            return null;
        }

        public IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId)
        {
           
            return  null;
        }
    }
}
