using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.Interface
{
    //在不确定需要用到的次数和需要的多少时用到泛型（在不确定的情况下使用）
    public interface IBaseService<T> where T:class,new()
    {
        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        T Find(params object[] @params);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        IQueryable<T> QueryAll(params Expression<Func<T, bool>>[] whereExps);

        /// <summary>
        /// 单个排序 查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        IQueryable<T> QueryAll<type>(Expression<Func<T, type>> orderEpx, bool isAsc, params Expression<Func<T, bool>>[] whereExps);

        /// <summary>
        /// 多个排序 查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx, IEnumerable<bool> isAsc, params Expression<Func<T, bool>>[] whereExps);


        /// <summary>
        /// 分页 查询 （单个排序）
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="total"></param>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        IQueryable<T> QueryAll<type>(Expression<Func<T, type>> orderEpx, bool isAsc, out int total, int skipCount = 1, int takeCount = 10, params Expression<Func<T, bool>>[] whereExps);

        /// <summary>
        /// 分页 查询 （多个排序）
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="total"></param>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <param name="orderEpx"></param>
        /// <param name="isAsc"></param>
        /// <param name="whereExps"></param>
        /// <returns></returns>
        IQueryable<T> QueryAll<type>(IEnumerable<Expression<Func<T, type>>> orderEpx, IEnumerable<bool> isAsc, out int total, int skipCount = 1, int takeCount = 10, params Expression<Func<T, bool>>[] whereExps);

        /// <summary>
        /// 单个新增
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="ie"></param>
        void AddRange(IEnumerable<T> ie);

        /// <summary>
        /// 单个修改
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="ie"></param>
        void UpdateRange(IEnumerable<T> ie);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="t"></param>
        void Remove(T t);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ie"></param>
        void RemoveRange(IEnumerable<T> ie);

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();



    }
}
