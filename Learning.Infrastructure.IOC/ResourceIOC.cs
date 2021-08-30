using Learning.Infrastructure.Tool.Attributes;
using Learning.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.IOC
{
    [Provide, Inject]
    public class ResourceIOC
    {
        public readonly BaseResourcesService _baseResourcesService;

        public ResourceIOC(BaseResourcesService baseResourcesService)
        {
            _baseResourcesService = baseResourcesService;
        }
    }
}
