using Shop.Database;

namespace Shop.Tests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly ShopDbContext Context;

        protected TestBase()
        {
            Context = ShopContextFactory.Create();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }
}
