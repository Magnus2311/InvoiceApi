using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IPartnerRepository
    {
        Task Add(Partner partner);
        Task UpdatePartner(Partner partner);
        Task Delete(int id);
        Task<List<Partner>> GetAllPartners();
    }
}