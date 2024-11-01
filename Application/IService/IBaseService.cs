using Application.IInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
	public interface IBaseService<T>
	{
		void Delete(T entity);
		List<T>? FindByCondition(Expression<Func<T, bool>> predicate);
		Task<List<T>?> FindByConditionAsync(Expression<Func<T, bool>> predicate);
	
		Task<List<T>?> GetAllAsync();
		Task<List<T>?> GetAllPagedAsync(int page, int rowPerPage);
		Task<T?> GetAsync(int id);
		Task<T> InsertAsync(T entity);
		Task SaveChangesAsync();
		Task<int> TotalRecords();
		void Update(T entity);
	}
}
