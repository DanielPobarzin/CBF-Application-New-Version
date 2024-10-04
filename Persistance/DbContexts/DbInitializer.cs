using Microsoft.EntityFrameworkCore;

namespace Persistance.DbContexts
{
	public static class DbInitializer<TContext> where TContext : DbContext
	{
		public static void Initialize(TContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
