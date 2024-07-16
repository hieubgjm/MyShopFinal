namespace MyShop.Data.Infrastructure
{
    internal class DbFactory : Disposable, IDbFactory
    {
        private MyShopDbContext dbContext;

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