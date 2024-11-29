using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts
{
	public static class DbInitializer<TContext> where TContext : DbContext
	{
		public static void Initialize(TContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
