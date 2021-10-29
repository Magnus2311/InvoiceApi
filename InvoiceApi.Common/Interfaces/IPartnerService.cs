using InvoiceApi.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IPartnerService
    {
        Task Add(PartnerDTO partner);
        Task Update(PartnerDTO partner);
        Task Delete(int id);

        Task<IEnumerable<PartnerDTO>> GetAllPartnersAsync();
    }
}
