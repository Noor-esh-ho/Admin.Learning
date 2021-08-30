using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Repository.Interface;

namespace Learning.Service.Base
{
    [Provide, Inject]
    public class BaseRightService : BaseService<Right>
    {
        public BaseRightService(IRepository<Right> repository) : base(repository)
        {
        }
    }
}
