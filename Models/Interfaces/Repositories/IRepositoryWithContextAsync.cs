using Microsoft.EntityFrameworkCore;

namespace Models.Interfaces.Repositories
{
    public interface IRepositoryWithContextAsync <T, TContext> : IRepositoryAsync<T>
		where T : class
		where TContext : DbContext
	{
		TContext GetDbContext();
	}
}