using Shop.Database;

namespace Shop.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ShopDbContext Context;

        protected TestCommandBase()
        {
            Context = ShopContextFactory.Create();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }
}
