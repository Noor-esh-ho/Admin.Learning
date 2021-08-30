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
    public class OrganizationICO
    {
        public readonly BaseOrganizationService _baseOrganizationService;
        public readonly BaseOrganizationRelationService _baseOrganizationRelationService;

        public OrganizationICO(BaseOrganizationService baseOrganizationService, BaseOrganizationRelationService baseOrganizationRelationService) {
            _baseOrganizationService = baseOrganizationService;
            _baseOrganizationRelationService = baseOrganizationRelationService;
        }
    }
}
