using Application.IInfrastructure;
using Domain.Entites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Base
{
	public class Repository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly ApplicationDBContext _context;
		private readonly DbSet<T> _entities;
		string _errorMessage = string.Empty;

		public Repository(ApplicationDBContext context)
		{
			_context = context;
			_entities = context.Set<T>();
		}
		public ApplicationDBContext GetContext()
		{
			return _context;
		}
		public DbSet<T> GetEntity() => _entities;

		public void Delete(T entity)
		{
			_entities.Remove(entity);
		}
		public async Task<T?> GetAsync(int id)
		{
			var result = await _entities.AsNoTracking<T>().FirstOrDefaultAsync(s => s.Id == id);
			return result;
		}
		public async Task<List<T>?> GetAllPagedAsync(int page, int rowPerPage)
		{
			if (page > 0)
				page = page - 1;

			return await _entities.Skip(page * rowPerPage).Take(rowPerPage).AsNoTracking<T>().ToListAsync();
		}
		public async Task<List<T>?> GetAllAsync()
		{
			return await _entities.AsNoTracking<T>().ToListAsync();
		}
		public async Task<T> InsertAsync(T entity)
		{
			EntityEntry<T> result = await _entities.AddAsync(entity);
			return result.Entity;
		}
		public void Update(T entity)
		{

			var entry = _context.Entry(entity);
			if (entry.State == EntityState.Detached)
				_context.Attach(entity);

			entry.State = EntityState.Modified;

		}
		public async Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = _entities.Where(predicate).AsNoTracking().AsQueryable<T>();
			return await query.ToListAsync();
		}


		public List<T>? FindByCondition(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = _entities.Where(predicate).AsQueryable<T>();
			return query.ToList();
		}
		public async Task<int> TotalRecords()
		{
			return await _entities.AsNoTracking<T>().CountAsync();
		}
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
			_context.ChangeTracker.Clear();
		}

	}
}
