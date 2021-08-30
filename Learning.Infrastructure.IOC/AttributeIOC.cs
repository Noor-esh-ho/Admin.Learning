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
    public class AttributeIOC
    {
        public readonly BaseAttributesService _baseAttributesService;
        public readonly BaseAttributeTypeService _baseAttributeTypeService;

        public AttributeIOC(BaseAttributesService baseAttributesService, BaseAttributeTypeService baseAttributeTypeService) {
            _baseAttributesService = baseAttributesService;
            _baseAttributeTypeService = baseAttributeTypeService;
        }
    }
}
