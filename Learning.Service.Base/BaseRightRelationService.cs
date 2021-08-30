using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Repository.Interface;

namespace Learning.Service.Base
{
    [Provide, Inject]
    public class BaseRightRelationService: BaseService<RightsRelation>
    {
        public BaseRightRelationService(IRepository<RightsRelation> repository) : base(repository)
        {
        }
    }
   
}
