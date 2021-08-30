using Learning.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _dbcontext;

        public SqlRepository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Add(T t)
        {
            _dbcontext.Set<T>().Add(t);
        }

        public void AddRange(IEnumerable<T> ie)
        {
            _dbcontext.Set<T>().AddRange(ie);
        }

        public T Find(params object[] @params)
        {
            return this._dbcontext.Set<T>().Find(@params);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll(params Expression<Func<T, bool>>[] whereExps)
        {
            var iq = _dbcontext.Set<T>() as IQueryable<T>;
            foreach (var item in whereExps)
            {
                iq = iq.Where(item);
            }
            return iq;
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
            var iq = this.QueryAll(whereExps);
            return isAsc ? iq.OrderBy(orderEpx) : iq.OrderByDescending(orderEpx);
        }

        /// <summary>
        /// 多个排序 查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx,IEnumerable< bool> isAsc, params Expression<Func<T, bool>>[] whereExps)
        {
            var iq = this.QueryAll(whereExps);
            var order = orderEpx.ToList();
            var asc = isAsc.ToList();
            for (int i = 0; i < orderEpx.Count(); i++)
            {
                if (asc[i])
                {
                    iq =iq.OrderBy(order[i]);
                }
                else
                {
                    iq = iq.OrderByDescending(order[i]);
                }
            }
            return iq;
        }

        /// <summary>
        /// 分页  查询(单个排序)
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="total"></param>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(Expression<Func<T, type>> orderEpx, bool isAsc, out int total, int skipCount = 1, int takeCount = 10, params Expression<Func<T, bool>>[] whereExps)
        {
            var iq = this.QueryAll(orderEpx: orderEpx, isAsc: isAsc, whereExps: whereExps);
            total = iq.Count();
            return iq.Skip(skipCount).Take(takeCount);
        }

        /// <summary>
        /// 分页 查询(多个排序)
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="total"></param>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        public IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx, IEnumerable<bool> isAsc, out int total, int skipCount = 1, int takeCount = 10, params Expression<Func<T, bool>>[] whereExps)
        {
            var iq = this.QueryAll(orderEpx: orderEpx, isAsc: isAsc, whereExps: whereExps);
            var order = orderEpx.ToList();
            var asc = isAsc.ToList();
            total = iq.Count();
            for (int i = 0; i < orderEpx.Count(); i++)
            {
                if (asc[i])
                {
                    iq = iq.OrderBy(order[i]);
                }
                else
                {
                    iq = iq.OrderByDescending(order[i]);
                }
            }
            return iq.Skip(skipCount).Take(takeCount);
        }

        public void Remove(T t)
        {
            _dbcontext.Set<T>().Remove(t);
        }

        public void RemoveRange(IEnumerable<T> ie)
        {
            _dbcontext.Set<T>().RemoveRange(ie);
        }

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }

        public void Update(T t)
        {
            _dbcontext.Set<T>().Update(t);
        }

        public void UpdateRange(IEnumerable<T> ie)
        {
            _dbcontext.Set<T>().UpdateRange();
        }
    }
}
