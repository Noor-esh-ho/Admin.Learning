using Learning.Repository.Interface;
using Learning.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.Base
{
    //(不需要被批量注入)so使用抽象方法声明  
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T t)
        {
            _repository.Add(t);
        }

        public void AddRange(IEnumerable<T> ie)
        {
            _repository.AddRange(ie);
        }

        public T Find(params object[] @params)
        {
            return _repository.Find(@params);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll(params Expression<Func<T, bool>>[] whereExps)
        {
            return _repository.QueryAll(whereExps);
        }

        /// <summary>
        /// 单个排序 查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(Expression<Func<T, type>> orderEpx, bool isAsc, params Expression<Func<T, bool>>[] whereExps)
        {
            return _repository.QueryAll(orderEpx,isAsc, whereExps);
        }

        /// <summary>
        /// 多个排序 查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx, IEnumerable<bool> isAsc, params Expression<Func<T, bool>>[] whereExps)
        {
            return _repository.QueryAll(orderEpx, isAsc, whereExps);
        }

        /// <summary>
        /// 分页 查询（单个排序）
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="total"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(Expression<Func<T, type>> orderEpx, bool isAsc, out int total, int page , int limit, params Expression<Func<T, bool>>[] whereExps)
        {
            return _repository.QueryAll(orderEpx, isAsc,out total,(page-1)*limit,limit, whereExps);
        }

        /// <summary>
        /// 分页 查询(多个排序)
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="total"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx, IEnumerable<bool> isAsc, out int total, int page = 1, int limit = 10, params Expression<Func<T, bool>>[] whereExps)
        {
            return _repository.QueryAll(orderEpx, isAsc, out total, (page - 1) * limit, limit, whereExps);

        }

        public void Remove(T t)
        {
            _repository.Remove(t);
        }

        public void RemoveRange(IEnumerable<T> ie)
        {
            _repository.RemoveRange(ie);
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public void Update(T t)
        {
            _repository.Update(t);
        }

        public void UpdateRange(IEnumerable<T> ie)
        {
            _repository.UpdateRange(ie);
        }
    }
}
