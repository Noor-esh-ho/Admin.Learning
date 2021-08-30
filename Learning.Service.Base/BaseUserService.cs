using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Repository.Interface;

namespace Learning.Service.Base
{
    [Provide,Inject]
    public class BaseUserService : BaseService<User>
    {
        public BaseUserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
