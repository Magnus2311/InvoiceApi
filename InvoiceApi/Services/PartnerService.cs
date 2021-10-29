using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Services
{
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository partnerRepository;
        private IMapPartnerService mapPartnerService;

        public PartnerService(IPartnerRepository _partnerRepository,
            IMapPartnerService _mapPartnerService)
        {
            partnerRepository = _partnerRepository;
            mapPartnerService = _mapPartnerService;
        }
        public async Task Add(PartnerDTO partner)
        {
            var partn = mapPartnerService.PartnerDTOToPartner(partner);
            await partnerRepository.Add(partn);
        }

        public async Task Update(PartnerDTO partner)
        {
            await partnerRepository.UpdatePartner(mapPartnerService.PartnerDTOToPartner(partner));
        }

        public async Task Delete(int id)
        {
            await partnerRepository.Delete(id);
        }

        public async Task<IEnumerable<PartnerDTO>> GetAllPartnersAsync()
        {
            var partners = await partnerRepository.GetAllPartners();
            return mapPartnerService.ListPartnerToListPartnerDTO(partners);
        }
    }
}
