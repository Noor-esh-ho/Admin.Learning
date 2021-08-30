
using Learning.Infrastructure.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    public class BaseService
    {
        #region GetResult
        public ApiResult GetResult(Actions action, int result = 0, ApiCode apiCode = ApiCode.invalid, string message = null, object data = null)
        {
            ApiCode code = ApiCode.ok;

            string msg = "";
            switch (action)
            {
                case Actions.add:
                    msg = "新增";
                    break;
                case Actions.delete:
                    msg = "删除";
                    break;
                case Actions.update:
                    msg = "修改";
                    break;
                case Actions.save:
                    msg = "保存";
                    break;
                case Actions.query:

                    break;
                case Actions.login:
                    msg = "登录";
                    break;
            }
            msg += result == 0 ? "成功" : "失败";
            if (action == Actions.paraError)
            {
                msg = "【参数/状态】错误";
                code = ApiCode.fail;
            }

            if (action == Actions.noAuthoriztion)
            {
                msg = "权限不足";
                code = ApiCode.noAuthoriztion;
            }

            if (action == Actions.notfound)
            {
                msg = "错误的请求地址";
                code = ApiCode.notFound;
            }

            if (result != 0)
            {
                code = ApiCode.fail;//代表失败啦
            }

            switch (apiCode)
            {
                case ApiCode.loginFail:
                    msg = "账号或者密码错误";
                    break;
                case ApiCode.ban:
                    msg = "账号被禁止登录";
                    break;
                case ApiCode.notAcive:
                    msg = "账号未激活";
                    break;
                case ApiCode.notLogin:
                    msg = "未登录";
                    break;
                case ApiCode.unAuthorized:
                    msg = "未授权";
                    break;
            }
            if (apiCode != ApiCode.invalid)
            {
                code = apiCode;//使用自定义返回值
            }
            if (message != null)
            {
                msg = message;//使用自定义提示
            }

            return new ApiResult
            {
                code = code,
                message = msg,
                data = data
            };
        }
        #endregion
    }
}
