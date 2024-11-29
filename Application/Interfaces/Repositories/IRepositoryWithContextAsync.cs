using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Repositories
{
    public interface IRepositoryWithContextAsync <T, TContext> : IRepositoryAsync<T>
		where T : class
		where TContext : DbContext
	{
		TContext GetDbContext();
	}
}