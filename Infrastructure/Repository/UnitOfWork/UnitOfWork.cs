

using Application.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Infrastructure.Repository.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly ApplicationDBContext _context;
		private IDbContextTransaction? _transaction = null;
		private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); // حداکثر 1 درخواست همزمان

		public UnitOfWork(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable)
		{
			// انتظار برای گرفتن قفل
			await _semaphore.WaitAsync();

			try
			{
				if (_transaction != null)
					throw new InvalidOperationException("A transaction is already in progress.");

				_transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
				return _transaction;
			}
			catch
			{
				// در صورت بروز خطا، قفل آزاد می‌شود
				_semaphore.Release();
				throw;
			}
		}

		public async Task SaveAndCommitAsync()
		{
			if (_transaction == null)
				throw new InvalidOperationException("No transaction started.");

			try
			{
				await _context.SaveChangesAsync();
				await _transaction.CommitAsync();
				_context.ChangeTracker.Clear();
			}
			catch
			{
				await RollbackAsync();
				throw;
			}
			finally
			{
				DisposeTransaction();
				_semaphore.Release(); // آزاد کردن قفل
			}
		}

		public async Task RollbackAsync()
		{
			if (_transaction != null)
			{
				await _transaction.RollbackAsync();
				DisposeTransaction();
				_semaphore.Release(); // آزاد کردن قفل
			}
		}

		private void DisposeTransaction()
		{
			_transaction?.Dispose();
			_transaction = null;
		}

		public void Dispose()
		{
			DisposeTransaction();
			_context.Dispose();
			GC.SuppressFinalize(this);
		}
	}


}
