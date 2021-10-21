using AutoMapper;
using InvoiceApi.Common.Interfaces.Mappers;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;

namespace InvoiceApi.Infrastructure.Services
{
    public class MapMyCompanyService : IMapMyCompanyService
    {
        private readonly IMapper _mapper;

        public MapMyCompanyService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MyCompany MapMyCompanyDTO(MyCompanyDTO myCompanyDTO)
            => _mapper.Map<MyCompany>(myCompanyDTO);

        public MyCompanyDTO MapMyCompanyToDTO(MyCompany myCompany)
            => _mapper.Map<MyCompanyDTO>(myCompany);
    }
}
