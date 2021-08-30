using Learning.Infrastructure.Tool.Attributes;
using Learning.Service;
using Learning.Service.Base;
using Learning.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Infrastructure.IOC
{
    [Provide,Inject]
    public class UserIOC
    {
        public readonly BaseUserService _baseuserService;
        public readonly BaseUserInfoService _baseUserInfoService;
        public readonly BaseOrganizationRelationService _baseOrganizationRelationService;
        public readonly BaseResourcesService _baseResourcesService;

        public UserIOC(BaseUserService baseuserService,BaseUserInfoService baseUserInfoService,BaseOrganizationRelationService baseOrganizationRelationService, BaseResourcesService baseResourcesService)
        {
            _baseuserService = baseuserService;
            _baseUserInfoService = baseUserInfoService;
            _baseOrganizationRelationService = baseOrganizationRelationService;
            _baseResourcesService = baseResourcesService;
        }
    }
}
