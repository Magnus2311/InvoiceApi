using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IMapPartnerService
    {
        Partner PartnerDTOToPartner(PartnerDTO partnerDTO);
        PartnerDTO PartnerToPartnerDTO(Partner partner);
        List<Partner> ListPartnerDTOToListPartner(List<PartnerDTO> partnersDTO);
        List<PartnerDTO> ListPartnerToListPartnerDTO(List<Partner> partners);
    }
}
