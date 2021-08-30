using Learning.Infrastructure.Tool.Attributes;
using System;
using System.Collections.Generic;
using Learning.Service.Base;
using Learning.Service.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.IOC
{
    
    [Provide, Inject]
   public class RightIOC
    {
        public readonly BaseRightService _baseRightService;
        public readonly BaseRightRelationService _baseRightRelationService;
        public readonly BaseRightConfigService _baseRightConfigService;
        public readonly BaseRightConfigDetailsService _baseRightConfigDetails;
        public readonly BaseAttributesService _baseAttributesService;

        public RightIOC(BaseAttributesService baseAttributesService,BaseRightService baseRightService,BaseRightRelationService baseRightRelationService,BaseRightConfigService baseRightConfigService,BaseRightConfigDetailsService baseRightConfigDetailsService) {
            _baseRightService = baseRightService;
            _baseRightRelationService = baseRightRelationService;
            _baseRightConfigService = baseRightConfigService;
            _baseRightConfigDetails = baseRightConfigDetailsService;
            _baseAttributesService = baseAttributesService;
        }
    }
}
