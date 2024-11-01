

using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Application.Interface
{
	public interface IUnitOfWork : IDisposable
	{
		Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable);
		Task RollbackAsync();
		Task SaveAndCommitAsync();
	}
}
