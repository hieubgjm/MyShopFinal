using MyShop.Data.Infrastructure;
using MyShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Respositories
{
    public interface IPostTagRepository : IRepository<PostTags>
    {

    }

    public class PostTagRepository : RepositoryBase<PostTags>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
