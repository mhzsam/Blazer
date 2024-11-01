using Application.IInfrastructure;
using Application.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class BaseService<T> : IBaseService<T>
	{
		private readonly IRepository<T> _repository;

		public BaseService(IRepository<T> repository)
		{
			_repository = repository;
		}

		public virtual void Delete(T entity)
		{
			_repository.Delete(entity);
		}

		public virtual async Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
		{
			return await _repository.FindByConditionAsync(predicate);
		}
	
		public virtual List<T>? FindByCondition(Expression<Func<T, bool>> predicate)
		{
			return _repository.FindByCondition(predicate);
		}


		public virtual async Task<List<T>?> GetAllPagedAsync(int page, int rowPerPage)
		{
			return await _repository.GetAllPagedAsync(page, rowPerPage);
		}

		public virtual async Task<T?> GetAsync(int id)
		{
			return await _repository.GetAsync(id);
		}

		public virtual async Task<T> InsertAsync(T entity)
		{
			return await _repository.InsertAsync(entity);
		}

		public virtual async Task<int> TotalRecords()
		{
			return await _repository.TotalRecords();
		}

		public virtual void Update(T entity)
		{
			_repository.Update(entity);
		}
		public virtual async Task<List<T>?> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}
		public virtual async Task SaveChangesAsync()
		{
			await _repository.SaveChangesAsync();
		}
	}
}
