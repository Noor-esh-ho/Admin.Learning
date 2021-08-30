using Learning.Infrastructure.Dto;
using Learning.Infrastructure.Tool.Attributes;
using Learning.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.Base
{
    [Provide, Inject]
    public class BaseAttributesService:BaseService<Infrastructure.Dto.Attribute>
    {
        public BaseAttributesService(IRepository<Infrastructure.Dto.Attribute> repository) : base(repository)
        {
        }
    }
}
