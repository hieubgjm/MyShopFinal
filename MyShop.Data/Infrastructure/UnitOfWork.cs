using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Infrastructure
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private MyShopDbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory) 
        {
        
            _dbFactory = dbFactory;

        }

        public MyShopDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }
        public void Commit()
        {
           DbContext.SaveChanges();
        }
    }
}
