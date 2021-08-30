using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Infrastructure.Dto.Base
{
    public enum ApiCode
    {
        invalid = int.MinValue,//无效参数 该参数代表无需进行处理
        ok = 2000,//操作成功
        fail = -1,//操作失败
        paraError = -999,//请求出现异常
        unAuthorized = -4001,//请求未进行授权,无权访问
        loginFail = 3001,//登录失败 账号或者密码错误
        notLogin = -3002,//未登录 无法进行请求
        notAcive = -3003,//账号未激活
        ban = -3004,//账号被禁止登录
        noAuthoriztion = 403,
        notFound=404
    }

    /// <summary>
    /// 行为代码
    /// </summary>
    public enum Actions
    {
        add = 1,//新增
        update = 2,//修改
        delete = 3,//删除
        query = 4,//查询
        save = 5,//保存
        action = 6,//行为
        login = 7,//登录
        paraError = -999, //参数/状态 错误
        loginOut = -1000,//登录过期
        noAuthoriztion = 403,//无权限
        notfound = 404//地址错误
    }
    public class ApiResult
    {
        /// <summary>
        /// 返回代码
        /// </summary>
        public ApiCode code { get; set; }
        /// <summary>
        /// 请求消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }


    }
}
