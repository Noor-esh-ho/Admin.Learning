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
        public readonly BaseAttributesService _baseAttributesService;
        public readonly BaseOrganizationRelationService _baseOrganizationRelationService;

        public OrganizationICO(BaseOrganizationService baseOrganizationService, BaseOrganizationRelationService baseOrganizationRelationService,BaseAttributesService baseAttributesService) {
            _baseOrganizationService = baseOrganizationService;
            _baseAttributesService = baseAttributesService;
            _baseOrganizationRelationService = baseOrganizationRelationService;
        }
    }
}
