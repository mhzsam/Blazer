using Application.IInfrastructure;
using Application.IService;
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

		public void Delete(T entity)
		{
			_repository.Delete(entity);
		}

		public Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> predicate)
		{
			return _repository.FindByConditionAsync(predicate);
		}

		public Task<List<T>?> GetAllPagedAsync(int page, int rowPerPage)
		{
			return _repository.GetAllPagedAsync(page, rowPerPage);
		}

		public async Task<T?> GetAsync(int id)
		{
			return await _repository.GetAsync(id);
		}

		public Task<T> InsertAsync(T entity)
		{
			return _repository.InsertAsync(entity);
		}

		public Task<int> TotalRecords()
		{
			return _repository.TotalRecords();
		}

		public void Update(T entity)
		{
			_repository.Update(entity);
		}
		public Task<List<T>?> GetAllAsync()
		{
			return _repository.GetAllAsync();
		}
		public async Task SaveChangesAsync()
		{
			await _repository.SaveChangesAsync();
		}
	}
}
