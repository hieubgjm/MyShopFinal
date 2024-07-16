﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Infrastructure
{
    class DbFactory : Disposable, IDbFactory
    {
        MyShopDbContext dbContext;
        public MyShopDbContext Init()
        {
            return dbContext ?? (dbContext = new MyShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
