using AutoMapper;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Services
{
    public class MapPartnerService : IMapPartnerService
    {
        private readonly IMapper _mapper;

        public MapPartnerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Partner PartnerDTOToPartner(PartnerDTO partnerDTO)
        {
            return _mapper.Map<Partner>(partnerDTO);
        }

        public PartnerDTO PartnerToPartnerDTO(Partner partner)
        {
            return _mapper.Map<PartnerDTO>(partner);
        }

        public List<Partner> ListPartnerDTOToListPartner(List<PartnerDTO> partnerDTO)
        {
            return _mapper.Map<List<Partner>>(partnerDTO);
        }

        public List<PartnerDTO> ListPartnerToListPartnerDTO(List<Partner> partners)
        {
            return _mapper.Map<List<PartnerDTO>>(partners);
        }
    }
}
